using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace NoNullProject
{
     interface IRequestsRepository
    {
        List<Requests> All();
        List<Requests> AllByDestinationId(string chars);
        void InsertNewRequests(Requests req);
        void DeleteRequestByID(int id);
    }
}