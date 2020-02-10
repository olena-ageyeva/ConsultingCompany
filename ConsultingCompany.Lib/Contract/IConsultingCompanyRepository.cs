using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using ConsultingCompany.Lib.Entity;

namespace ConsultingCompany.Lib
{
    public interface IConsultingCompanyRepository
    {
        List<Resource> Resources { get; }

        IEnumerable<Resource> GetAllResources();
        IEnumerable<Resource> GetOrderedResources();

        Resource GetResource(int id);

        void AddResource(Resource resource);

        void UpdateResource(Resource resource);

        void DeleteResource(Resource client);

        List<Client> Clients { get;  }

        IEnumerable<Client> GetOrderedClients(); 
        Client Get(int id);

        void Add(Client client);

        void Update(Client client);

        void Delete(Client client);

        IEnumerable<string> GetClientResources(Client client);

        List<User> Users { get; }

        User PasswordMatch(string username, string password);

       void LogIn(bool credentialsMatch);

        bool LoggedIn();


    }
}
