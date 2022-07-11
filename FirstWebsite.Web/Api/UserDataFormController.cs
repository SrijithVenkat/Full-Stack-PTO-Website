using FirstWebsite.Data.Models;
using FirstWebsite.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;

namespace FirstWebsite.Web.API
{
    public class UserFormController : ApiController
    {
        private readonly UserData db;

        public UserFormController(UserData db)
        {
            this.db = db;
        }
        public IEnumerable<User> Get()
        {
            var model = db.GetAll();
            return model;
        }
    }
}
