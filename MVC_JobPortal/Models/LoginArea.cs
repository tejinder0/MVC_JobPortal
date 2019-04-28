using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
  


namespace MVC_JobPortal.Models
{
    public class LoginArea
    {
        //  this is global class having global variable that we can use in the all pages

        public String AdminUserName { get; set; }
        public String AdminPassword { get; set; }
    }
}