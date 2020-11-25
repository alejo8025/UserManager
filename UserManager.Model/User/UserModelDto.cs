﻿using System;

namespace UserManager.Model.User
{
    public class UserModelDto
    {
        public Guid Userid { get; set; }
        public string Username { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string DocumentType { get; set; }
        public string Document { get; set; }
        public string Rol { get; set; }
    }
}
