using ConsultingCompany.Lib;
using System.Linq;
using System;
using System.Collections.Generic;



namespace ConsultingCompany.DataStore
{
    using System.Collections.Generic;
    using System;
    using ConsultingCompany.Lib;
    using System.Linq;
    using ConsultingCompany.Lib.Entity;




public class ConsultingCompanyRepository : IConsultingCompanyRepository
    {
        public ConsultingCompanyRepository()
        {
            Initialize();
        }

        public List<Resource> _resources = null;

        public List<Client> _clients = null;

        public List<User> _users = null;

        public bool _loggedin = false;

        public List<Resource> Resources
        {
            get
            {
                return this._resources;
            }
        }


        public List<Client> Clients
        {
            get
            {
                return this._clients;
            }
        }

        public List<User> Users
        {
            get
            {
                return this._users;
            }
        }



        private void Initialize()
        {
            this._resources = new List<Resource>()
                                  {
                                      new Resource() { Id=1,FirstName = "Chris", LastName = "Smith", Type = ResourceType.Developer, Clients= new List<int> { 1,2 } },
                                      new Resource() { Id=2, FirstName = "Brian", LastName = "Jones", Type = ResourceType.Developer, Clients= new List<int> { 2,3 } },
                                      new Resource() { Id=3, FirstName = "Mary", LastName = "Bill", Type = ResourceType.Developer, Clients= new List<int> { 2 } },
                                      new Resource() { Id=4, FirstName = "Lin", LastName = "Mayer", Type = ResourceType.Developer, Clients= new List<int> { 3 } },
                                      new Resource() { Id=5, FirstName = "Jason", LastName = "Gold", Type = ResourceType.ProjectManager, Clients= new List<int> { 1,3 } },
                                      new Resource() { Id=6, FirstName = "Jennifer", LastName = "Mike", Type = ResourceType.ProjectManager,Clients= new List<int> { 2,3 } },
                                      new Resource() { Id=7, FirstName = "Bob", LastName = "Lawrence", Type = ResourceType.Architect,Clients= new List<int> { 2,3 } },
                                      new Resource() { Id=8, FirstName = "Susan", LastName = "Kennedy", Type = ResourceType.QA, Clients= new List<int> { 2,3 } },
                                      new Resource() { Id=9, FirstName = "Jerry", LastName = "Williams", Type = ResourceType.Architect, Clients= new List<int> { 2,3 } },
                                      new Resource() { Id=10, FirstName = "Eric", LastName = "Hammill", Type = ResourceType.QA, Clients= new List<int> { 2,3 } }
                                  };

            this._clients = new List<Client>()
                                {
                                    new Client()
                                        {
                                            Id=1,    
                                            CompanyName = "Microsoft",
                                            ContactFirstName = "Bill",
                                            ContactLastName = "Gates",
                                            City="Bedford",
                                            State=States.MA,
                                            Zip="01730",
                                            Resources=new List<Resource>{this.GetResource(1), this.GetResource(2), this.GetResource(3) }
                                        },
                                    new Client()
                                        {
                                            Id=2, 
                                            CompanyName = "Facebook",
                                            ContactFirstName = "Mark",
                                            ContactLastName = "Zuckerberg",
                                            City="Bedford",
                                            State=States.AK,
                                            Zip="01730",
                                            Resources=new List<Resource>{this.GetResource(2), this.GetResource(5), this.GetResource(10) }
                                        },
                                    new Client()
                                        {
                                            Id=3,
                                            CompanyName = "Amazon", 
                                            ContactFirstName = "Jeff", 
                                            ContactLastName = "Bezos",
                                            City="Bedford",
                                            State=States.CA,
                                            Zip="01730",
                                            Resources=new List<Resource>{this.GetResource(3), this.GetResource(5), this.GetResource(9) }
                                        },
                                };
            this._users = new List<User>()
                                  {
                                      new User() { Id=1,UserName = "admin", Password = "password", Role="admin",Status=""},
                                      new User() { Id=1,UserName = "user", Password = "password", Role="guest", Status=""},
                                      new User() { Id=1,UserName = "guest", Password = "password", Role="user", Status=""},
                                  };
        }

        public IEnumerable<Client> GetOrderedClients()
        {
            return this._clients.OrderBy(client => client.ContactLastName);
        }

        public Client Get(int id)
        {
            return _clients.FirstOrDefault(client => client.Id == id);
        }

        public void Add(Client client)
        {
            _clients.Add(client);
            client.Id = _clients.Max(item => item.Id)+1;
        }

        public void Update(Client client)
        {
            var existing = Get(client.Id);
            if (existing!= null)
            {
                existing.CompanyName = client.CompanyName;
                existing.ContactFirstName = client.ContactFirstName;
                existing.ContactLastName = client.ContactLastName;
                existing.City = client.City;
                existing.State = client.State;
                existing.Zip = client.Zip;
            }
        }

        public void Delete(Client client)
        {
            var existing = Get(client.Id);
            if (existing!=null)
            {
                _clients.Remove(Get(client.Id));
            }
        }

        public IEnumerable<string> GetClientResources(Client client)
        {
            return client.Resources.Select(resource => resource.FirstName);
            //client.Resources.Select(resource=> GetResource(resource).FirstName);
        }

        public IEnumerable<Resource> GetAllResources()
        {
            return this._resources;
        }
        public IEnumerable<Resource> GetOrderedResources()
        {
            return this._resources.OrderBy(resource => resource.LastName);
        }

        public Resource GetResource(int id)
        {
            return _resources.FirstOrDefault(resource => resource.Id == id);
        }

        public void DeleteResource(Resource resource)
        {
            var existing = GetResource(resource.Id);
            if (existing != null)
            {
                _resources.Remove(GetResource(resource.Id));
            }
        }

        public void AddResource(Resource resource)
        {
            _resources.Add(resource);
            resource.Id = _resources.Max(item => item.Id) + 1;
        }

        public void UpdateResource(Resource resource)
        {
            var existing = GetResource(resource.Id);
            if (existing != null)
            {
                existing.FirstName = resource.FirstName;
                existing.LastName = resource.LastName;
                existing.Type = resource.Type;
                existing.YearsOfExperience = resource.YearsOfExperience;               
            }
        }

        public User PasswordMatch(string username, string password)
        {
            var existing = _users.FirstOrDefault(user => user.Password == password && user.UserName == username);
            return existing; 
            
        }

        public bool LoggedIn()
        {
            return this._loggedin;
        }

        public void LogIn(bool credentialsMatch)
        {
            if (credentialsMatch == true)
            {
                this._loggedin = true;
            }
        }
    }
}

