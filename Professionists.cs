using System;
using System.Collections.Generic;
using System.Data.SqlClient;
// namespace NoNullProject.Model
namespace ADOExamples{
    public class Professionists
    {
        public int ProfId { get; set; }
        public string LastName { get; set; }
        public string FirsttName { get; set; }
        public string Profession { get; set; }
        public DateTime Birthdate { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string PostalCode { get; set; }
        public int destinationId  { get; set; }
        public string Phone { get; set; }
        public string Mail { get; set; }
        public string MinAvalaibility  { get; set; }
        public string MaxAvalaibility  { get; set; }

    }
}