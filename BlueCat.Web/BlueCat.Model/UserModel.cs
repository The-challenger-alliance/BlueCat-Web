using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueCat.Model
{
    public class UserModel
    {
        public String UserName { get; set; }

        public DateTime ExpirationTime { get; set; }

        public bool Status { get; set; }
    }
}
