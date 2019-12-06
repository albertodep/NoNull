using System;
using System.Collections.Generic;
using System.Data.SqlClient;
namespace NoNullProject.Model
{
    class Skills
    {      
      public int SkillId { get; set; }
        public int GeneralAreaId { get; set; }
        public int ProfId { get; set; }
        public int Level { get; set; }
        public string Description { get; set; }
    }
}



 
