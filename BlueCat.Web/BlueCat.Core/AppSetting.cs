using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueCat.Core
{
    public class AppSetting
    {
        public static string FormTicket = ConfigurationManager.AppSettings["FormTicket"];  
    }
}
