using System;
using System.Collections.Generic;
using System.Data.SqlClient;
namespace NoNullProject
{
    class Companies
    {
        public int CompId { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string PostalCode { get; set; }
        public int DestinationId { get; set; }
        public int GeneralAreaId { get; set; }
        public string Mission { get; set; }
    }
}




