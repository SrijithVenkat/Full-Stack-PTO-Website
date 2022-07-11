using FirstWebsite.Data.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstWebsite.Data.Services
{
    public interface RequestProcessing
    {
        IEnumerable<Request> GetAll();

        List<PTO> GetAllPTO();
        List<OutOfOffice> GetAllOutOfOffice();
        List<Event> GetAllEvent();

        Request Get(int id);

        void Add(Request user);

        void Update(Request user);

        void Delete(int id);
    }
}
