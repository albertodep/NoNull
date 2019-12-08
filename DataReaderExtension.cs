using System;
using System.Collections.Generic;
using System.Data.SqlClient;
namespace NoNullProject
{
    public static class DataReaderExtension
    {
        public static List<Professionists> SelectProfessionist(SqlCommand cmd, SqlConnection con)
        {
            List<Professionists> prof = new List<Professionists>();

            Console.WriteLine("got connection");
            using (SqlDataReader reader = cmd.ExecuteReader())
            {

                while (reader.Read())
                {
                    var p = new Professionists();

                    p.ProfId = reader.GetFieldValue<int>(reader.GetOrdinal("profid"));
                    p.LastName = reader.GetFieldValue<string>(reader.GetOrdinal("lastname"));
                    p.FirstName = reader.GetFieldValue<string>(reader.GetOrdinal("firstname"));
                    p.Profession = reader.GetFieldValue<string>(reader.GetOrdinal("profession"));
                    p.Birthdate = reader.GetFieldValue<DateTime>(reader.GetOrdinal("birthdate"));
                    p.Address = reader.GetFieldValue<string>(reader.GetOrdinal("address"));
                    p.City = reader.GetFieldValue<string>(reader.GetOrdinal("city"));
                    p.Region = ReaderIsNull(reader, "region") ? null : reader.GetFieldValue<string>(reader.GetOrdinal("region"));
                    p.PostalCode = ReaderIsNull(reader, "postalcode") ? null : reader.GetFieldValue<string>(reader.GetOrdinal("postalcode"));
                    p.DestinationId = reader.GetFieldValue<int>(reader.GetOrdinal("destinationid"));
                    p.Phone = reader.GetFieldValue<string>(reader.GetOrdinal("phone"));
                    reader.GetFieldValue<string>(reader.GetOrdinal("phone"));
                    p.Mail = reader.GetFieldValue<string>(reader.GetOrdinal("mail"));
                    p.MinAvalaibility = reader.GetFieldValue<string>(reader.GetOrdinal("minavailability"));
                    p.MaxAvalaibility = (reader.GetFieldValue<string>(reader.GetOrdinal("maxavailability")));
                    prof.Add(p);
                }

                return prof;
            }
        }
        public static bool ReaderIsNull(SqlDataReader reader, string columnName)
        {
            if (reader.IsDBNull(reader.GetOrdinal(columnName)))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static List<Requests> SelectRequests(SqlCommand cmd, SqlConnection con)
        {
            List<Requests> req = new List<Requests>();

            Console.WriteLine("got connection");
            using (SqlDataReader reader = cmd.ExecuteReader())
            {

                while (reader.Read())
                {
                    var r = new Requests();

                    r.ReqId = reader.GetFieldValue<int>(reader.GetOrdinal("reqid"));
                    r.CompId = reader.GetFieldValue<int>(reader.GetOrdinal("compid"));
                    r.ProjId = reader.GetFieldValue<int>(reader.GetOrdinal("projid"));
                    r.SkillId = reader.GetFieldValue<int>(reader.GetOrdinal("skillid"));
                    r.DestinationId = reader.GetFieldValue<int>(reader.GetOrdinal("destinationid"));
                    r.BeginningDate = reader.GetFieldValue<DateTime>(reader.GetOrdinal("beginningdate"));
                    r.EndingDate = reader.GetFieldValue<DateTime>(reader.GetOrdinal("endingdate"));

                    req.Add(r);
                }

                return req;
            }
        }



    }


}