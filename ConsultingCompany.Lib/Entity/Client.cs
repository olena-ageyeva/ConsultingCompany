
using ConsultingCompany.Lib.Entity;
using System.ComponentModel.DataAnnotations;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ConsultingCompany.Lib
{
    public class Client
    {
        private List<int> resources;

        public int Id { get; set; }

        [Required]
        public string CompanyName { get; set; }

        [Required]
        public string ContactFirstName { get; set; }

        [Required]
        public string ContactLastName { get; set; }

        public string City { get; set; }

        public States State { get; set; }

        public string Zip { get; set; }

        public List<Resource> Resources { get; set; }

        

    }
}