using System;
using System.Collections.Generic;
using System.Data.SqlClient;
namespace NoNullProject.Model
{
    class TrackRequests
    {
        public int TrackId { get; set; }
        public int ProfId { get; set; }
        public int ReqId { get; set; }
        public DateTime BeginningDate { get; set; }
        public DateTime EndingDate { get; set; }
        public string ProfComment { get; set; }
        public string CompComment { get; set; }
    }
}