using System;

namespace UserManager.Model.User
{
    public class UpdateUserModel
    {
        public Guid UserId { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Rol { get; set; }
    }
}
