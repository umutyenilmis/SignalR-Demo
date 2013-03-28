using System.Collections.Generic;
using System.Configuration;
using System.Web;
using Castle.MicroKernel.Facilities;
using Castle.MicroKernel.Registration;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Engine;
using NHibernate.Event;
using NHibernate.Tool.hbm2ddl;
using NHibernate.Type;
using SignalR.Core.Model.Domain;
using Configuration = NHibernate.Cfg.Configuration;

namespace SignalR.Core.Infrastructure.Facilities
{
    public class PersistenceFacility : AbstractFacility
    {
        protected override void Init()
        {
            var config = ConfigureNHibernate();


            //var schemaExport = new SchemaExport(config);
            //schemaExport.Drop(false, true);
            //schemaExport.Create(false, true);
            
            
            Kernel.Register(
                Component.For<ISessionFactory>().LifeStyle.Singleton
                    .UsingFactoryMethod(config.BuildSessionFactory));

            if (HttpContext.Current == null)
                Kernel.Register(Component.For<ISession>()
                                    .LifeStyle
                                    .PerThread
                                    .UsingFactoryMethod(k => k.Resolve<ISessionFactory>().OpenSession())
                                    .OnCreate((kernel, session) => { session.FlushMode = FlushMode.Commit; }));
            else
                Kernel.Register(Component.For<ISession>()
                                    .LifeStyle
                                    .PerWebRequest
                                    .UsingFactoryMethod(k => k.Resolve<ISessionFactory>().OpenSession())
                                    .OnCreate((kernel, session) => { session.FlushMode = FlushMode.Commit; }));
        }

        private Configuration ConfigureNHibernate()
        {
            var config = new Configuration();

            AddFilters(config);
            AddEventListeners(config);
            SetInterceptor(config);

            config = Fluently.Configure(config)
                .Database(
                    MsSqlConfiguration.MsSql2008.ConnectionString(
                        ConfigurationManager.ConnectionStrings["DbConnection"].ToString()))

                .Mappings(x => x.FluentMappings.AddFromAssemblyOf<EntityBase>())
                .BuildConfiguration();

            return config;
        }

        private void SetInterceptor(Configuration config)
        {
            config.SetInterceptor(new EnableFiltersInterceptor());
        }

        private void AddFilters(Configuration config)
        {
            var typeParameters = new Dictionary<string, IType> { { "IsDeleted", NHibernateUtil.Boolean } };
            config.AddFilterDefinition(new FilterDefinition("DeletedFilter", "", typeParameters, true));
        }

        private void AddEventListeners(Configuration config)
        {
            config.SetListener(ListenerType.PreInsert, new SetCreationDateListener());
            config.SetListener(ListenerType.Delete, new DeleteListener());
        }
    }
}