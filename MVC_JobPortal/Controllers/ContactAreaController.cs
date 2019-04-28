using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_JobPortal.Models;

namespace MVC_JobPortal.Controllers
{
    public class ContactAreaController : Controller
    {
        // GET: ContactArea
        [HttpGet]
        public ActionResult ContactArea()
        {
            return View();
        }



        [HttpPost]
        public ActionResult SendMsg(Mssg log)
        {
            //for adding new record to the databse taht user added in the text boxes

            Connection obj = new Connection();
            String query = "insert into contact(Sname,Scontact,Semail,Smsg) values('"+log.SName+"','"+log.SPhone+"','"+log.SEmail+"','"+log.SMsg+"')";
            obj.InsDelUpdt(query);
                return View("reveiws");
            
        }

    }
}