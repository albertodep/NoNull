using System;
using System.Collections.Generic;
using System.Data.SqlClient;
namespace NoNullProject.Model
{
    class Bid
    {
        
        public int BidId { get; set; }
        public int ProfId { get; set; }
        public int ReqId { get; set; }
        public bool Acceptation { get; set; }
        public DateTime SendData { get; set; }
        public string Message { get; set; }

    }
}