using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentInfoSystem.Models.Model
{
    public class Users
    {
        public int ID { get; set; }
        public string userName { get; set; }
        public string password { get; set; }
        public string checkCode { get; set; } 
        public int Sex { get; set; }
        public string Accout { get; set; }

    }
}
