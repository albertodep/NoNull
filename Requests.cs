using System;
using System.Collections.Generic;
using System.Data.SqlClient;
namespace NoNullProject
{
    public class Requests
    {
        public int ReqId { get; set; }
        public int CompId { get; set; }
        public int ProjId { get; set; }
        public int SkillId { get; set; }
        public int DestinationId { get; set; }
        public DateTime BeginningDate { get; set; }
        public DateTime EndingDate { get; set; }
        public string Description { get; set; }
        public Requests() { }

        public Requests(int reqId, int compId, int projId, int skillId, int destinationId, DateTime beginningDate, DateTime endingDate, string description)
        {
            ReqId = reqId;
            CompId = compId;
            ProjId = projId;
            SkillId = skillId;
            DestinationId = destinationId;
            BeginningDate = beginningDate;
            EndingDate = endingDate;
            Description = description;
        }
    }
}