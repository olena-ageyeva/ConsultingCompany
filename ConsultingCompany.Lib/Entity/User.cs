using System;
using System.Collections.Generic;
using System.Text;
using ConsultingCompany.Lib.Entity;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ConsultingCompany.Lib
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }

        public string Role { get; set; }

        
        public string Status { get; set; }

        
    }
}
