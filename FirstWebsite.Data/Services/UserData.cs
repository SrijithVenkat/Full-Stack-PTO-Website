using FirstWebsite.Data.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstWebsite.Data.Services
{
    public interface UserData
    {
        IEnumerable<User> GetAll();
        User Get(int id);

        void Add(User user);
        
        void Update(User user);

        void Delete(int id);
        IEnumerable<User> Search(string searchString);

        List<User> CheckLogin(string user_name, string password);
    }
}
