using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;


namespace RealEstate.Models
{
    public class insertPlot
    {
        public int ID { get; set; }
        public string PlotName { get; set; }
        public string PlotSize { get; set; }
        public string PlotLocation { get; set; }
        public int MarketPrice { get; set; }
        public string PlotImageName { get; set; }
        public string PlotImageLocation { get; set; }


        public void AddPlot(insertPlot pl)
        {
            string query = string.Format("Insert into tblPlot Values ( '{0}','{1}','{2}',{3},'{4}','{5}')", pl.PlotName,pl.PlotSize,pl.PlotLocation,pl.MarketPrice,pl.PlotImageName,pl.PlotImageLocation);
            SqlCommand cmd = new SqlCommand(query, Connection.GetCon());
            cmd.ExecuteNonQuery();
        }

        public List<insertPlot> showall()
        {
            string query = "select * from tblPlot";
            SqlCommand cmd = new SqlCommand(query, Connection.GetCon());
            SqlDataReader sdr = cmd.ExecuteReader();
            List<insertPlot> slist = new List<insertPlot>();

            while (sdr.Read())
            {
                insertPlot s = new insertPlot();
                s.ID = int.Parse(sdr[0].ToString());
                s.PlotName = sdr[1].ToString();
                s.PlotSize= sdr[2].ToString();
                s.PlotLocation = sdr[3].ToString();
                s.MarketPrice = int.Parse(sdr[4].ToString());
                s.PlotImageName = sdr[5].ToString();
                s.PlotImageLocation = sdr[6].ToString();
                slist.Add(s);
            }
            sdr.Close();
            return slist;
        }

        public void deletee(int id)
        {
            string query = string.Format("delete tblPlot where PlotID={0}",id);
            SqlCommand cmd = new SqlCommand(query, Connection.GetCon());
            cmd.ExecuteNonQuery();
        }

    }

}