using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeautyZone.WEB.Models
{
    public class UserHelper
    {
        public int Id { get; set; }
        public string Token { get; set; }
        public string Login { get; set; }
        public static string IdUser { get; set; }
        public static string UserName { get; set; }
    }
}
