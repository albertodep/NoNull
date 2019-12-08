using System;
using System.Collections.Generic;
using System.Data.SqlClient;
namespace NoNullProject
{
    class Projects
    {
        public int ProjId { get; set; }
        public int GeneralAreaId { get; set; }
        public int CompId { get; set; }
        public string Description { get; set; }
    }
}
