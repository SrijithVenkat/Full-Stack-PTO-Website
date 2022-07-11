using FirstWebsite.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FirstWebsite.Data.Services
{
    public class InMemoryUserData : UserData
    {
        List<User> users;

        public InMemoryUserData()
        {
            users = new List<User>()
            {
                new User { userId = 1, firstName = "Srijith", lastName = "Venkateshwaran", Email = "srijith@tegrit.com", Address = "2700 Jolly Road", Phone = "517-444-5555", State = StatesAbbrev.MI},
                new User { userId = 2, firstName = "David", lastName = "Pace", Email = "srijith@tegrit.com", Address = "2700 Jolly Road", Phone = "517-444-5555", State = StatesAbbrev.MI }
            };
        }

        public void Add(User user)
        {
            users.Add(user);
            user.userId = users.Max(r => r.userId) + 1;
        }

        public void Update(User user)
        {
            var existing = Get(user.userId);
            if(existing != null)
            {
                existing.userId = user.userId;
                existing.firstName = user.firstName;
                existing.lastName = user.lastName;
                existing.Email = user.Email;
                existing.Address = user.Address;
                existing.Phone = user.Phone;
                existing.State = user.State;
            }
        }

        public User Get(int id)
        {
            return users.FirstOrDefault(r => r.userId == id);
        }

        public IEnumerable<User> GetAll()
        {
            return users;
        }

        public void Delete(int id)
        {
            var user = Get(id);
            if (user != null)
            {
                users.Remove(user);
            }
        }

        public IEnumerable<User> Search(string searchString)
        {
            var query_users = from user in users
                              where user.firstName.Contains(searchString)
                              || user.lastName.Contains(searchString)
                              select user;
            return query_users;
        }

        public List<User> CheckLogin(string user_name, string password)
        {
            var data = users.Where(s => s.userName.Equals(user_name) && s.passWord.Equals(password)).ToList();
            return data;
        }
    }
}
