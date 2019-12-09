using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace NoNullProject
{
    public class RequestsRepository
    {

        public List<Requests> All()
        {
            //     List<Professionists> prof = new List<Professionists>();
            using (SqlCommand cmd = new SqlCommand(Connector.SELECT_ALL_REQUEST))
            {
                return Read(cmd);
            }
        }
        public List<Requests> AllByDestinationId(int id)
        {
            using (SqlCommand cmd = new SqlCommand(Connector.SELECT_ALL_REQUEST_DESTINATION_ID))
            {
                cmd.Parameters.AddWithValue("@id", "id");
                return Read(cmd);
            }

        }

        private List<Requests> Read(SqlCommand cmd)
        {
            List<Requests> requests = new List<Requests>();
            using (SqlConnection con = new SqlConnection(Connector.CONN_SQLServer))
            {
                con.Open();
                cmd.Connection = con;
                requests = DataReaderExtension.SelectRequests(cmd, con);
            }
            return requests;
        }

        //Insert\\
        public void InsertNewRequests(Requests req)
        {
            using (SqlConnection con = new SqlConnection(Connector.CONN_SQLServer))
            {
                try
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand(Connector.INSERT_PROFESSIONIST, con))
                    {
                        cmd.Parameters.AddWithValue("@reqId", req.ReqId);
                        cmd.Parameters.AddWithValue("@compId", req.CompId);
                        cmd.Parameters.AddWithValue("@projId", req.ProjId);
                        cmd.Parameters.AddWithValue("@skillId", req.SkillId);
                        cmd.Parameters.AddWithValue("@destinationId", req.DestinationId);
                        cmd.Parameters.AddWithValue("@beginningDate", req.BeginningDate);
                        cmd.Parameters.AddWithValue("@endingDate", req.EndingDate);
                        cmd.Parameters.AddWithValue("@description", req.Description);

                        cmd.ExecuteNonQuery();
                    }
                }
                catch (SqlException ex)
                {
                    System.Console.WriteLine(ex.Message);
                }
            }
        }

        // //Delete\\
        public void DeleteRequestByID(int id)
        {
            using (SqlConnection con = new SqlConnection(Connector.CONN_SQLServer))
            {
                con.Open();
                SqlTransaction tran = con.BeginTransaction();
                try
                {
                    System.Console.WriteLine("Open Delete");
                    SqlCommand cmd = new SqlCommand(Connector.DELETE_REQUEST_BY_ID, con, tran);

                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                    tran.Commit();
                }
                catch (SqlException e)
                {
                    tran.Rollback();
                    System.Console.WriteLine(e.Message);
                }
            }
        }

        private static string SEARCH_STRING     //generic search
         = "SELECT * FROM NoNull.Requests AS Req";

        public List<Request> Search(int? destinationid, DateTime? start, DateTime? end, List<int> skills)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                bool andNeeded = false;
                StringBuilder sql = new StringBuilder(SEARCH_STRING);//crea stringhe intermedie che sono più modificabili
                if (destinationid != null)
                {
                    sql.Append(" WHERE destionationid = @countryId");
                    cmd.Parameters.AddWithValue("@countryId", destinationid);
                    andNeeded = true;
                }
                if (start != null && end != null)
                {
                    sql.Append(andNeeded ? " AND" : "WHERE");
                    sql.Append(" beginningdate BETWEEN ( @start,@end) AND endingdate BETWEEN ( @start,@end)");
                }
                if (skills != null && skills.Count != 0)
                {
                    sql.Append(andNeeded ? " AND" : " WHERE");
                    sql.Append(" EXISTS ( SELECT * FROM NoNull.Requests WHERE reqid = req.reqid AND skillid IN ( ");
                    for (int i = 0; i < skills.Count; i++)
                    {
                        sql.Append("@skillid" + i + ",");
                        cmd.Parameters.AddWithValue("@skillid" + i, skills[i]);

                    }
                    sql.Replace(',', ')', sql.Length - 1, 1);
                }
                Console.WriteLine(sql);
                return Read(cmd);
            }
        }

        public static string UPDATE_REQUEST_BY_ID =     //update requests by id
        @"UPDATE NoNull.Requests 
        SET compid=@compid, projid=@projid, skillid=@skillid, destinationid=@destinationid, beginningdate=@beginningdate, endingdate=@endingdate, description=@description 
        Where reqid=@reqid";
        public void UpdateReq(Requests req)
        {
            using (SqlConnection con = new SqlConnection(Connector.CONN_SQLServer))
            {
                con.Open();
                System.Console.WriteLine("Open Update");
                using (SqlCommand cmd = new SqlCommand(UPDATE_REQUEST_BY_ID, con))
                {
                    cmd.Parameters.AddWithValue("@compId", req.CompId);
                    cmd.Parameters.AddWithValue("@projId", req.ProjId);
                    cmd.Parameters.AddWithValue("@skillId", req.SkillId);
                    cmd.Parameters.AddWithValue("@destinationId", req.DestinationId);
                    cmd.Parameters.AddWithValue("@beginningDate", req.BeginningDate);
                    cmd.Parameters.AddWithValue("@endingDate", req.EndingDate);
                    cmd.Parameters.AddWithValue("@description", req.Description);

                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}