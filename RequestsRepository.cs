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
    }
}