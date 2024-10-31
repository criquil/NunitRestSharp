using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NunitRestSharp.Helper
{
    internal class TokenReqConf
    {
        public  string TenantId { get; set; }
        public  string ClientId { get; set; }
        public  string ClientSecret { get; set; }
        public  string BaseUrl { get; set; }
        public  string Scope { get; set; }
        public  string Resource { get; set; }
        public  string Username { get; set; }
        public  string Password { get; set; }

    }
}
