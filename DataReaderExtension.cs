using System;
using System.Collections.Generic;
using System.Data.SqlClient;
namespace ADOExamples
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
                    p.FirsttName = reader.GetFieldValue<string>(reader.GetOrdinal("firstname"));
                    p.Profession = reader.GetFieldValue<string>(reader.GetOrdinal("profession"));
                    p.Birthdate = reader.GetFieldValue<DateTime>(reader.GetOrdinal("birthdate"));
                    p.Address = reader.GetFieldValue<string>(reader.GetOrdinal("address"));
                    p.City = reader.GetFieldValue<string>(reader.GetOrdinal("city"));
                    p.Region = ReaderIsNull(reader, "region") ? null : reader.GetFieldValue<string>(reader.GetOrdinal("region"));
                    p.PostalCode = ReaderIsNull(reader, "postalcode") ? null : reader.GetFieldValue<string>(reader.GetOrdinal("postalcode"));
                    p.destinationId = reader.GetFieldValue<int>(reader.GetOrdinal("destinationid"));
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


    }


}