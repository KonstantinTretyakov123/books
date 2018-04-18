using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseLevel.Entities
{
    public class User
    {
        [Key]
        public Guid Id { get; set; }

        public string AspNetId { get; set; }

        public string LastName { get; set; }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string Address { get; set; }

        public string Number { get; set; }
    }
}
