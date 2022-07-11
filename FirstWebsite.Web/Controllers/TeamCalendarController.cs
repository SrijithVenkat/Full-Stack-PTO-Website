using FirstWebsite.Data.Services;
using FirstWebsite.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FirstWebsite.Web.Controllers
{
    public class TeamCalendarController : Controller
    {

        private readonly UserData users;
        private readonly RequestProcessing requests;

        public TeamCalendarController(UserData userDb, RequestProcessing requestDb)
        {
            users = userDb;
            requests = requestDb;
        }
        // GET: TeamCalendar
        public ActionResult Index()
        {
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
                foreach (var request in requests.GetAll())
                {
                    // Initialization.  
                    CalendarEvent infoObj = new CalendarEvent();
                    var curr_user = users.Get(request.userID);
                    // Setting.  
                    infoObj.User = request.userName;
                    if (request.requestType == 1)
                    {
                        infoObj.Title = "PTO - " + curr_user.firstName + " " + curr_user.lastName;
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
                    if (request.userName == Session["UserName"].ToString())
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