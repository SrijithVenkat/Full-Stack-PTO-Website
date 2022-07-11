using FirstWebsite.Data.Models;
using FirstWebsite.Data.Services;
using FirstWebsite.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FirstWebsite.Web.Controllers
{
    public class RequestEntryController : Controller
    {
        private readonly RequestProcessing requests;
        private readonly UserData users;

        public RequestEntryController(UserData userDb, RequestProcessing db)
        {
            requests = db;
            users = userDb;
        }
        [HttpGet]
        public ActionResult Index()
        {
            if (Session["idUser"] != null)
            {
                var ptoModel = requests.GetAllPTO();
                var outOfOfficeModel = requests.GetAllOutOfOffice();
                var eventModel = requests.GetAllEvent();

                IndexVM model = new IndexVM();
                model.PTOs = ptoModel;
                model.OutOfOffices = outOfOfficeModel;
                model.Events = eventModel;
                List<User> usersList = new List<User>();
                foreach (var user in users.GetAll())
                {
                    usersList.Add(user);
                }
                model.Users = usersList;
                return View(model);
            }
            else
            {
                return RedirectToAction("Logout", "Home");
            }
        }
        [HttpGet]
        public ActionResult CreatePTO()
        {
            if (Session["idUser"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Logout", "Home");
            }
        }
        [HttpGet]
        public ActionResult CreateOutOfOffice()
        {
            if (Session["idUser"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Logout", "Home");
            }
        }

        [HttpGet]
        public ActionResult CreateEvent()
        {
            if (Session["idUser"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Logout", "Home");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreatePTO(PTO pto)
        {
            pto.requestType = 1;
            pto.userName = Session["UserName"].ToString();
            pto.userID = (int)Session["idUser"];
            requests.Add(pto);
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateOutOfOffice(OutOfOffice oOO)
        {
            oOO.requestType = 2;
            oOO.userName = Session["FullName"].ToString();
            oOO.userID = (int)Session["idUser"];
            requests.Add(oOO);
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateEvent(Event event_add)
        {
            event_add.requestType = 3;
            event_add.userName = Session["UserName"].ToString();
            event_add.userID = (int)Session["idUser"];
            requests.Add(event_add);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult EditPTO(int id)
        {
            if (Session["idUser"] != null)
            {
                var model = requests.Get(id);
                if (model == null)
                {
                    HttpNotFound();
                }
                return View(model);
            }
            else
            {
                return RedirectToAction("Logout", "Home");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditPTO(PTO request)
        {
            TimeSpan daysOff = request.requestEndDate - request.requestStartDate;
            if (daysOff.Days != 0)
            {
                request.daysOff = daysOff.Days;
            }
            else
            {
                request.daysOff = 1;
            }
            requests.Update(request);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult EditOutOfOffice(int id)
        {
            if (Session["idUser"] != null)
            {
                var model = requests.Get(id);
                if (model == null)
                {
                    HttpNotFound();
                }
                return View(model);
            }
            else
            {
                return RedirectToAction("Logout", "Home");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditOutOfOffice(OutOfOffice request)
        {
            TimeSpan daysOff = request.requestEndDate - request.requestStartDate;
            if (daysOff.Days != 0)
            {
                request.daysOff = daysOff.Days;
            }
            else
            {
                request.daysOff = 1;
            }
            requests.Update(request);
            return RedirectToAction("Index");
        }


        [HttpGet]
        public ActionResult EditEvent(int id)
        {
            if (Session["idUser"] != null)
            {
                var model = requests.Get(id);
                if (model == null)
                {
                    HttpNotFound();
                }
                return View(model);
            }
            else
            {
                return RedirectToAction("Logout", "Home");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditEvent(Event request)
        {
            TimeSpan daysOff = request.requestEndDate - request.requestStartDate;
            if (daysOff.Days != 0)
            {
                request.daysOff = daysOff.Days;
            }
            else
            {
                request.daysOff = 1;
            }
            requests.Update(request);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult PTODetails(int id)
        {
            if (Session["idUser"] != null)
            {
                var model = requests.Get(id);
                if (model == null)
                {
                    return View("Not Found");
                }
                return View(model);
            }
            else
            {
                return RedirectToAction("Logout", "Home");
            }
        }

        [HttpGet]
        public ActionResult OutOfOfficeDetails(int id)
        {
            if (Session["idUser"] != null)
            {
                var model = requests.Get(id);
                if (model == null)
                {
                    return View("Not Found");
                }
                return View(model);
            }
            else
            {
                return RedirectToAction("Logout", "Home");
            }
        }

        [HttpGet]
        public ActionResult EventDetails(int id)
        {
            if (Session["idUser"] != null)
            {
                var model = requests.Get(id);
                if (model == null)
                {
                    return View("Not Found");
                }
                return View(model);
            }
            else
            {
                return RedirectToAction("Logout", "Home");
            }
        }

        [HttpGet]
        public ActionResult DeletePTO(int id)
        {
            if (Session["idUser"] != null)
            {
                var model = requests.Get(id);
                return View(model);
            }
            else
            {
                return RedirectToAction("Logout", "Home");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePTO(int id, FormCollection form)
        {
            requests.Delete(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult DeleteOutOfOffice(int id)
        {
            if (Session["idUser"] != null)
            {
                var model = requests.Get(id);
                return View(model);
            }
            else
            {
                return RedirectToAction("Logout", "Home");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteOutOfOffice(int id, FormCollection form)
        {
            requests.Delete(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult DeleteEvent(int id)
        {
            if (Session["idUser"] != null)
            {
                var model = requests.Get(id);
                return View(model);
            }
            else
            {
                return RedirectToAction("Logout", "Home");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteEvent(int id, FormCollection form)
        {
            requests.Delete(id);
            return RedirectToAction("Index");
        }
    }
}