using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_JobPortal.Models;
using System.Data;
namespace MVC_JobPortal.Controllers
{
    public class LoginAreaController : Controller
    {
        // GET: LoginArea  this area is returing loging information on page 
        [HttpGet]
        public ActionResult LoginArea()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Validate(LoginArea log)
        {
            // we use select querry for selecting data from databse to see that weather infor mation that is provided by the user is correct 
            //or not this is secure way 

            Connection obj = new Connection();
            String query = "select * from LoginData where Sname='" + log.AdminUserName + "' and Spassword='" + log.AdminPassword + "'";
            DataTable tbl = new DataTable();
            tbl = obj.Srch(query);
             
            // this is viewing area of loging if the user has added the right information it will open the working are and if the useer has not
            //enterd right information it will ask to enter the new information .
            if (tbl.Rows.Count > 0)
            {

                return View("WorkingArea");
            }
            else
            {

                return View("Invalid");
            }
        }


    }
}