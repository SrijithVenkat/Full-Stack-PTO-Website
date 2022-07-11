using FirstWebsite.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstWebsite.Data.Services
{
    public class SQLUserData : UserData
    {
        private readonly UserDbContext db;

        public SQLUserData(UserDbContext db)
        {
            this.db = db;
        }
        public void Add(User user)
        {
            db.Users.Add(user);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var user = db.Users.Find(id);
            db.Users.Remove(user);
            db.SaveChanges();
        }

        public User Get(int id)
        {
            var user = db.Users.FirstOrDefault(r => r.userId == id);
            return user;
        }

        public IEnumerable<User> GetAll()
        {
            return db.Users.OrderBy(r => r.userId);
        }

        public IEnumerable<User> Search(string searchString)
        {
            var query_users = from user in db.Users
                              where user.firstName.Contains(searchString)
                              || user.lastName.Contains(searchString)
                              select user;
            return query_users;
        }
        public List<User> CheckLogin(string user_name, string enc_password)
        {
            var data = db.Users.Where(s => s.userName.Equals(user_name) && s.passWord.Equals(enc_password)).ToList();
            return data;
        }

        public void Update(User user)
        {
            var entry = db.Entry(user);
            entry.State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}
