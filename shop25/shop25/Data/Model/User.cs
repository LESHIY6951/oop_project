 using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace shop25
    {
        public class User
        {
            public int id { private set; get; }
            public int? cert_id { set; get; }
           public string login { set; get; }
            public string password { set; get; }
             public string name { set; get; }
            public string? email { set; get; }
            public string? number { set; get; }
            public string? address { set; get; }

        }
    }

