using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineClinic.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Mobile { get; set; }
        public string Mail { get; set; }
        public Nullable<int> RoleId { get; set; }
    }
}