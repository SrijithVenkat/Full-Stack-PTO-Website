using FirstWebsite.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstWebsite.Data.Services
{
    public class SQLRequestProcessing : RequestProcessing
    {
        private readonly RequestDbContext db;

        public SQLRequestProcessing(RequestDbContext db)
        {
            this.db = db;
        }
        public void Add(Request request)
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
            request.dateSubmitted = DateTime.Now;
            request.Title = "Request";
            db.Requests.Add(request);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var user = db.Requests.Find(id);
            db.Requests.Remove(user);
            db.SaveChanges();
        }

        public Request Get(int id)
        {
            var request = db.Requests.FirstOrDefault(r => r.requestId == id);
            return request;
        }

        public IEnumerable<Request> GetAll()
        {
            return db.Requests.OrderBy(r => r.requestStartDate);
        }

        public List<PTO> GetAllPTO()
        {
            var PTOs = db.Requests.Where(r => r.requestType == 1);
            List<PTO> PTOFinal = new List<PTO>();
            foreach (var pTO in PTOs)
            {
                PTOFinal.Add((PTO)pTO);
            }
            return PTOFinal;
        }
        public List<OutOfOffice> GetAllOutOfOffice()
        {
            var OutOfOffices = db.Requests.Where(r => r.requestType == 2);
            List<OutOfOffice> outOfOfficesFinal = new List<OutOfOffice>();
            foreach (var oOOs in OutOfOffices)
            {
                outOfOfficesFinal.Add((OutOfOffice)oOOs);
            }
            return outOfOfficesFinal;
        }
        public List<Event> GetAllEvent()
        {
            var Events = db.Requests.Where(r => r.requestType == 3);
            List<Event> EventFinal = new List<Event>();
            foreach (var event_par in Events)
            {
                EventFinal.Add((Event)event_par);
            }
            return EventFinal;
        }

        /*
       public IEnumerable<Request> Search(string searchString)
       {
           var query_users = from user in db.Requests
                             where user.firstName.Contains(searchString)
                             || user.lastName.Contains(searchString)
                             select user;
           return query_users;
       }*/

        public void Update(Request request)
        {
            var entry = db.Entry(request);
            entry.State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}
