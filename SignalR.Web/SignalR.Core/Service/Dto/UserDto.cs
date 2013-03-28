using System;

namespace SignalR.Core.Service.Dto
{
    public class UserDto
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public Guid Token { get; set; }
    }
}
