using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Threading.Tasks;

namespace ConsultingCompany.Lib
{
    public enum ResourceType
    {
        ProjectManager,
        Architect,
        Developer,
        QA
    }

    public class Resource
    {
        private List<int> clients;

        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public ResourceType Position { get; set; }
        public string YearsOfExperience { get; set; }

        public ResourceType Type { get; set; }

        public List<int> Clients { get; set; }
    }
}
