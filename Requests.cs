using System;
using System.Collections.Generic;
using System.Data.SqlClient;
namespace NoNullProject.Model
{
    class Requests
    {
        public int ReqId { get; set; }
        public int CompId { get; set; }
        public int ProjId { get; set; }
        public int SkillId { get; set; }
        public int DestinationId { get; set; }
        public DateTime BeginningDate { get; set; }
        public DateTime EndingDate { get; set; }
        public string Description { get; set; }
    }
}