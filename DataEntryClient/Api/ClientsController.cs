using ConsultingCompany.Lib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DataEntryClient.Api
{
    public class ClientsController : ApiController
    {
        private readonly IConsultingCompanyRepository db;
        public ClientsController(IConsultingCompanyRepository db){
            this.db = db;
            }
        public IEnumerable<Client>  Get()
        {
            var model = db.GetOrderedClients();
            return model;
        }
    }
}
