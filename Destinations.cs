using System;
using System.Collections.Generic;
using System.Data.SqlClient;
namespace NoNullProject.Model
{
    class Destinations
    {
        public int DestinationId { get; set; }
        public string Name { get; set; }
        public int MacroArea { get; set; }

    }
}