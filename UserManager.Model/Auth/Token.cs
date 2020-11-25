using System;
using System.ComponentModel.DataAnnotations;

namespace UserManager.Model.Auth
{
    public class Token
    {
        public Token()
        {
            Token_Id = Guid.NewGuid().ToString();
        }

        [Key]
        public string Token_Id { get; set; }
        public string EndPointName { get; set; }
        public string AccessToken { get; set; }
        public DateTime Expires { get; set; }
    }
}
