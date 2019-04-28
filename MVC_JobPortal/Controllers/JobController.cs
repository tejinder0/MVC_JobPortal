using MVC_JobPortal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_JobPortal.Controllers
{
    public class JobController : Controller
    {
        // GET: Job used for getting job details
        jobDBEntities1 obj = new jobDBEntities1();

        public ActionResult placedJob()
        {
            return View(obj.JobDatas.ToList());
        }

        // GET: Job/Details/5 
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Job/Create  this function is used to create job
        public ActionResult Create()
        {
            return View();
        }

        // POST: Job/Create   data is being feetched by using loop 
        [HttpPost]
        public ActionResult Create([Bind(Exclude ="Id")] JobData data)       {
            if (!ModelState.IsValid)
                return View();
            obj.JobDatas.Add(data);
            obj.SaveChanges();
            return RedirectToAction("placedJob");
        }

        // GET: Job/Edit/5    for  editing job details or to update the data we have addded we can use this edit or add data 
        //to our databse file and so we can use this to edit update the data  
        public ActionResult Edit(int id)
        {

            var jobId = (from m in obj.JobDatas where m.id == id select m).First();
            return View(jobId);
        }

        // POST: Job/Edit/5
        [HttpPost]
        public ActionResult Edit(JobData jobid)
        {
            var g = (from m in obj.JobDatas where m.id == jobid.id select m).First();
            if (!ModelState.IsValid)
                return View(g);
            obj.Entry(g).CurrentValues.SetValues(jobid);

            obj.SaveChanges();
            return RedirectToAction("placedJob");


        }
         
        // GET: Job/Delete/5       to delete the record from the database we use this delete keyword for deleting the record from databse
        public ActionResult Delete(JobData Jobid)
        {
            var data = obj.JobDatas.Where(x=>x.id== Jobid.id).FirstOrDefault();
            obj.JobDatas.Remove(data);
            obj.SaveChanges();
            return RedirectToAction("placedJob");

        }

        // POST: Job/Delete/5    this also do the same work of deleteing data from database that return a value
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
             return View();
            
        }
    }
}
