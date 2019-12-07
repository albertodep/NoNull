using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace ADOExamples
{
     interface IProfessionistsRepository
    {
        List<Professionists> All();
        List<Professionists> AllByLastname(string chars);
        void InsertNewProfessionist(Professionists pro);
        void DeleteProfessionistByID(int id);
    }
}