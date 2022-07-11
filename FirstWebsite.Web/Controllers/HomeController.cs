using FirstWebsite.Data.Models;
using FirstWebsite.Data.Services;
using FirstWebsite.Web.Models;
using java.util;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace FirstWebsite.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly UserData users;
        private readonly RequestProcessing requests;

        public HomeController(UserData userDb, RequestProcessing requestDb)
        {
            users = userDb;
            requests = requestDb;
        }
        public ActionResult Index()
        {

            if (Session["idUser"] != null)
            {
                var model = users.GetAll();
                return View(model);
            }
            else
            {
                return RedirectToAction("Logout");
            }
        }
        [HttpGet]
       public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(HttpPostedFileBase image1, User _user)
        {

                var check = users.GetAll().FirstOrDefault(s => s.userName == _user.userName);
                if (check == null)
                {
                    if (image1 == null)
                    {
                        string fileName = HttpContext.Server.MapPath(@"~/Content/defaultUser.png");

                        byte[] imageData = null;
                        FileInfo fileInfo = new FileInfo(fileName);
                        long imageFileLength = fileInfo.Length;
                        FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
                        BinaryReader br = new BinaryReader(fs);
                        imageData = br.ReadBytes((int)imageFileLength);

                        _user.profilePicture = imageData;
                    }
                    else
                    {
                        _user.profilePicture = new byte[image1.ContentLength];
                        image1.InputStream.Read(_user.profilePicture, 0, image1.ContentLength);
                    }
                    _user.isActive = false;
                    _user.isAdmin = false;
                    _user.isApprover = false;
                    _user.passWord = GetMD5(_user.passWord);
                    users.Add(_user);
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.error = "Email already exists";
                    return View();
                }

        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(string username, string password)
        {
            if (ModelState.IsValid)
            {

                var model = users.GetAll();
                var f_password = GetMD5(password);
                var data = users.CheckLogin(username, f_password);
                if (data.Count() > 0)
                {
                    //add session
                    Session["FullName"] = data.FirstOrDefault().firstName + " " + data.FirstOrDefault().lastName;
                    Session["UserName"] = data.FirstOrDefault().userName;
                    Session["FirstName"] = data.FirstOrDefault().firstName;
                    Session["LastName"] = data.FirstOrDefault().lastName;
                    Session["Email"] = data.FirstOrDefault().Email;
                    Session["idUser"] = data.FirstOrDefault().userId;
                    Session["isAdmin"] = data.FirstOrDefault().isAdmin;
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.error = "Login failed";
                    return RedirectToAction("Login");
                }
            }
            return View();
        }


        //Logout
        public ActionResult Logout()
        {
            Session.Clear();//remove session
            Session["idUser"] = null;
            Session["FullName"] = null;
            Session["UserName"] = null;
            Session["FirstName"] = null;
            Session["LastName"] = null;
            Session["Email"] = null;
            Session["idUser"] = null;
            Session["isAdmin"] = null;
            return RedirectToAction("Login");
        }


        //create a string MD5
        public static string GetMD5(string str1)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] fromData = Encoding.UTF8.GetBytes(str1);
            byte[] targetData = md5.ComputeHash(fromData);
            string byte2String = null;

            for (int i = 0; i < targetData.Length; i++)
            {
                byte2String += targetData[i].ToString("x2");

            }
            return byte2String;
        }


        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        /// <summary>  
        /// GET: /Home/GetCalendarData  
        /// </summary>  
        /// <returns>Return data</returns>  
        public ActionResult GetCalendarData()
        {
            // Initialization.  
            JsonResult result = new JsonResult();

            try
            {
                // Loading.  
                List<CalendarEvent> data = this.LoadData();

                // Processing.  
                result = this.Json(data, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                // Info  
                Console.Write(ex);
            }

            // Return info.  
            return result;
        }

        /// <summary>  
        /// Load data method.  
        /// </summary>  
        /// <returns>Returns - Data</returns>  
        private List<CalendarEvent> LoadData()
        {
            // Initialization.  
            List<CalendarEvent> lst = new List<CalendarEvent>(); 
            try
            {
                // Read file.  
                foreach(var request in requests.GetAll())
                {
                    // Initialization.  
                    CalendarEvent infoObj = new CalendarEvent();
                    var curr_user = users.Get(request.userID);
                    // Setting.  
                    infoObj.User = request.userName;
                    if(request.requestType == 1)
                    {
                        infoObj.Title = "PTO - " + curr_user.firstName +" "+ curr_user.lastName;
                        infoObj.Type = 1;
                    }
                    else if (request.requestType == 2)
                    {
                        infoObj.Title = "Out of Office - " + curr_user.firstName + " " + curr_user.lastName;
                        infoObj.Type = 2;
                    }
                    else
                    {
                        infoObj.Title = "Event - " + request.requestDescription;
                        infoObj.Type = 3;
                    }
                    if(request.userName == Session["UserName"].ToString())
                    {
                        infoObj.personalDisplay = true;
                    }
                    else
                    {
                        infoObj.personalDisplay = false;
                    }
                    infoObj.Start_Date = request.requestStartDate;
                    infoObj.End_Date = request.requestEndDate;

                    // Adding.  
                    lst.Add(infoObj);
                }
            }
            catch (Exception ex)
            {
                // info.  
                Console.Write(ex);
            }

            // info.  
            return lst;
        }
    }
}