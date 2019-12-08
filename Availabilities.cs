using System;
using System.Collections.Generic;
using System.Data.SqlClient;
namespace NoNullProject
{
    class Availabilities
    {
        public int AvaId { get; set; }
        public int ProfId { get; set; }
        public DateTime BeginningDate { get; set; }
        public DateTime EndingDate { get; set; }
    }
}