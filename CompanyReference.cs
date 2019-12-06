using System;
using System.Collections.Generic;
using System.Data.SqlClient;
namespace NoNullProject.Model
{
    class CompanyReference
    {
        public int RefId { get; set; }
        public int CompId { get; set; }
        public string LastName { get; set; }
        public string FirsttName { get; set; }
        public DateTime Birthdate { get; set; }
        public int Phone { get; set; }
        public string Mail { get; set; }
    }
}