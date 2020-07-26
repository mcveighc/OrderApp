using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BGLOrderApp.Models.Auth
{
    public class InsecureAuthToken
    {
        public string User { get; set; }
        public bool isAdmin { get; set; }
    }
}
