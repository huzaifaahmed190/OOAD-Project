using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace RealEstate.Models
{
    public class Account
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Contactno { get; set; }
        public string CNIC { get; set; }
        public string EmailID { get; set; }
        public string CustomerAddress { get; set; }
        public string City { get; set; }
        public string CustomerState { get; set; }
        public string Gender { get; set; }
        public DateTime CreateDate { get; set; }
        public string CustomerFBRStatus { get; set; }
        public string Password { get; set; }


        public void Register(Account acc)
        {
            string query = string.Format("Insert into tblCustomer Values ( '{0}','{1}',{2},{3},'{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}' )", acc.FirstName, acc.LastName, acc.Contactno, acc.CNIC, acc.EmailID, acc.CustomerAddress, acc.City, acc.CustomerState, acc.Gender, acc.CreateDate, acc.CustomerFBRStatus, acc.Password);
            SqlCommand cmd = new SqlCommand(query, Connection.GetCon());
            cmd.ExecuteNonQuery();
        }
        public List<Account> showall()
        {
            string query = "select * from tblCustomer";
            SqlCommand cmd = new SqlCommand(query, Connection.GetCon());
            SqlDataReader sdr = cmd.ExecuteReader();
            List<Account> slist = new List<Account>();

            while (sdr.Read())
            {
                Account s = new Account();
                s.ID = int.Parse(sdr[0].ToString());
                s.FirstName = sdr[1].ToString();
                s.LastName = sdr[2].ToString();
                s.Contactno = sdr[3].ToString();
                s.CNIC = sdr[4].ToString();
                s.EmailID = sdr[5].ToString();
                s.CustomerAddress = sdr[6].ToString();
                s.City = sdr[7].ToString();
                s.Gender = sdr[9].ToString();
                s.CustomerFBRStatus = sdr[11].ToString();
                s.Password = sdr[12].ToString();
                slist.Add(s);
            }
            sdr.Close();
            return slist;
        }

        public void delete(int id)
        {
            string query = string.Format("delete tblCustomer where CustomerID={0}", id);
            SqlCommand cmd = new SqlCommand(query, Connection.GetCon());
            cmd.ExecuteNonQuery();
        }
    }

}