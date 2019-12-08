using System;
using System.Collections.Generic;
using System.Data.SqlClient;
namespace NoNullProject
{
    class Skills
    {      
        public int SkillId { get; set; }
        public int GeneralAreaId { get; set; }
        public int ProfId { get; set; }
        public int Level { get; set; }
        public string Description { get; set; }
        public string Detail { get; set; }
    }
}



 
