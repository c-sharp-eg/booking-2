using booking.client.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace booking.client.Abstract
{
    public interface IClientRepository: IRepository<Client>
    {
        new void Add(Client item);
        new void Delete(String id);
        new Client Get(string id);
        new IEnumerable<Client> GetAll();
        new Client Update(Client item);

    }
}
