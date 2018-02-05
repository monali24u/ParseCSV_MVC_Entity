using DataLibrary;
using ParsingLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplicationS.Controllers
{
    //This is default controller and entry point of the application
    public class HomeController : Controller
    {
        private Parser parse = new Parser();
        private DataManager dataManager = new DataManager();
        private UserAppDataEntities db = new UserAppDataEntities();

        // GET: Home
        public ActionResult Index()
        {
            //Clear the database first
            dataManager.ClearDatabase();
            return View(dataManager.GetDataList());
        }

        [HttpPost]
        public ActionResult Index(HttpPostedFileBase uploadedFile)
        {
            //Parse the file
            List<string> UserList = parse.ParseFile(uploadedFile);
            dataManager.UpdateDatabase(UserList);
            return View(dataManager.GetDataList());
        }
    }
}