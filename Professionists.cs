using System;
using System.Collections.Generic;
using System.Data.SqlClient;
// namespace NoNullProject.Model
namespace NoNullProject
{
    public class Professionists
    {
        public int ProfId { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Profession { get; set; }
        public DateTime Birthdate { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string PostalCode { get; set; }
        public int DestinationId { get; set; }
        public string Phone { get; set; }
        public string Mail { get; set; }
        public string MinAvalaibility { get; set; }
        public string MaxAvalaibility { get; set; }

        public Professionists() { }
        public Professionists(string lastName, string firstName, string profession, string birthdate, string address, string city, string region, string postalCode, int destinationId, string phone, string mail, string minAvalaibility, string maxAvalaibility)
        {
            LastName = lastName;
            FirstName = firstName;
            Profession = profession;
            Birthdate = Convert.ToDateTime(birthdate);
            Address = address;
            City = city;
            Region = region;
            PostalCode = postalCode;
            DestinationId = destinationId;
            Phone = phone;
            Mail = mail;
            MinAvalaibility = minAvalaibility;
            MaxAvalaibility = maxAvalaibility;
        }
    }
}