using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace ADOExamples
{
    public class ProfessionistRepository
    {

        public List<Professionists> All()
        {
       //     List<Professionists> prof = new List<Professionists>();
            using (SqlCommand cmd = new SqlCommand(Connector.SELECT_ALL_PROFESSIONIST))
            {
                return Read(cmd);
            }
        }
        public List<Professionists> AllByLastname(string chars)
        {
          //  List<Professionists> professionist = new List<Professionists>();
                using (SqlCommand cmd = new SqlCommand(Connector.SELECT_ALL_PROFESSIONIST_LASTNAME_LIKE))
                {
                    cmd.Parameters.AddWithValue("@chars", "%" + chars + "%");
                    return Read(cmd);
                }
  
        }

        private List<Professionists> Read(SqlCommand cmd)
        {
            List<Professionists> professionist = new List<Professionists>();
            using (SqlConnection con = new SqlConnection(Connector.CONN_SQLServer))
            {
                con.Open();
                cmd.Connection = con;
               professionist = DataReaderExtension.SelectProfessionist(cmd, con);
            }
            return professionist;
        }

        //Insert\\
        public void InsertNewProfessionist(Professionists pro)
        {
            using (SqlConnection con = new SqlConnection(Connector.CONN_SQLServer))
            {
                try
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand(Connector.INSERT_PROFESSIONIST, con))
                    {
                        cmd.Parameters.AddWithValue("@lastname", pro.LastName);
                        cmd.Parameters.AddWithValue("@firstname", pro.FirstName);
                        cmd.Parameters.AddWithValue("@profession", pro.Profession);
                        cmd.Parameters.AddWithValue("@birthdate", pro.Birthdate);
                        cmd.Parameters.AddWithValue("@address", pro.Address);
                        cmd.Parameters.AddWithValue("@city", pro.City);
                        cmd.Parameters.AddWithValue("@region", pro.Region);
                        cmd.Parameters.AddWithValue("@postalcode", pro.PostalCode);
                        cmd.Parameters.AddWithValue("@destination", pro.DestinationId);
                        cmd.Parameters.AddWithValue("@phone", pro.Phone);
                        cmd.Parameters.AddWithValue("@mail", pro.Mail);
                        cmd.Parameters.AddWithValue("@minavailability", pro.MinAvalaibility);
                        cmd.Parameters.AddWithValue("@maxavailability", pro.MaxAvalaibility);

                        cmd.ExecuteNonQuery();
                    }
                }
                catch (SqlException ex)
                {
                    System.Console.WriteLine(ex.Message);
                }
            }
        }

        //Delete\\
        public void DeleteProfessionistByID(int id)
        {
            using (SqlConnection con = new SqlConnection(Connector.CONN_SQLServer))
            {
                con.Open();
                SqlTransaction tran = con.BeginTransaction();
                try
                {
                    System.Console.WriteLine("Open Delete");
                    SqlCommand cmd = new SqlCommand(Connector.DELETE_PROFESSIONIST_BY_ID, con, tran);

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

        // public List<Employee> SearchByTitle(string title)
        // {
        //     List<Employee> employees = new List<Employee>();
        //     using (SqlConnection con = new SqlConnection(Connector.CONN_SQLServer))
        //     {
        //         con.Open();
        //         using (SqlCommand cmd = new SqlCommand(Connector.SELECT_BY_TITLE, con))
        //         {
        //             cmd.Parameters.AddWithValue("@title", title);
        //             // employees = SelectEmployees(cmd, con);
        //             employees = DataReaderExtension.SelectEmployees(cmd,con);

        //         }
        //     }
        //     return employees;
        // }


       
        // public void DeleteByID(int id)
        // {


        //     using (SqlConnection con = new SqlConnection(Connector.CONN_SQLServer))
        //     {
        //         // Console.WriteLine(CONN_STRING);
        //         con.Open();
        //         SqlTransaction tran = con.BeginTransaction();
        //         try
        //         {
        //             System.Console.WriteLine("Open Delete");
        //             SqlCommand cmd0 = new SqlCommand(Connector.DELETE_ORDERS_BY_EMPID, con, tran);
        //             SqlCommand cmd = new SqlCommand(Connector.DELETE_EMPLOYEE_BY_ID, con, tran);

        //             //System.Console.WriteLine(cmd.CommandText);
        //             cmd0.Parameters.AddWithValue("@id", id);
        //             cmd.Parameters.AddWithValue("@id", id);
        //             cmd0.ExecuteNonQuery();
        //             cmd.ExecuteNonQuery();
        //             tran.Commit();

        //         }
        //         catch (SqlException e)
        //         {
        //             tran.Rollback();
        //             System.Console.WriteLine(e.Message);
        //         }

        //     }

        // }


        // public void InsertNewEmp(Employee emp1)
        // {
        //     using (SqlConnection con = new SqlConnection(Connector.CONN_SQLServer))
        //     {
        //         //Console.WriteLine(CONN_STRING);//Metti il try and catch se vuoi!
        //         con.Open();
        //         using (SqlCommand cmd = new SqlCommand(Connector.INSERT_EMP, con))
        //         {

        //             cmd.Parameters.AddWithValue("@lastname", emp1.LastName);
        //             cmd.Parameters.AddWithValue("@firstname", emp1.FirstName);
        //             cmd.Parameters.AddWithValue("@title", emp1.Title);
        //             cmd.Parameters.AddWithValue("@titleofcourtesy", emp1.TitleOfCourtesy);
        //             cmd.Parameters.AddWithValue("@birthdate", emp1.BirthDate);
        //             cmd.Parameters.AddWithValue("@hiredate", emp1.HireDate);
        //             cmd.Parameters.AddWithValue("@address", emp1.Address);
        //             cmd.Parameters.AddWithValue("@city", emp1.City);
        //             cmd.Parameters.AddWithValue("@region", emp1.Region);
        //             cmd.Parameters.AddWithValue("@postalcode", emp1.PostalCode);
        //             cmd.Parameters.AddWithValue("@country", emp1.Country);
        //             cmd.Parameters.AddWithValue("@phone", emp1.Phone);
        //             cmd.Parameters.AddWithValue("@mgrid", emp1.ManagerId);

        //             cmd.ExecuteNonQuery();
        //         }

        //     }
        // }



    }
}