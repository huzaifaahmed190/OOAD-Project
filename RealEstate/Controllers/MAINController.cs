using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RealEstate.Models;
using RealEstate.Controllers;
using System.Data.SqlClient;

namespace RealEstate.Controllers
{
    public class MAINController : Controller
    {
        // GET: MAIN
       
        public ActionResult ShowPlot()
        {
            insertPlot s = new insertPlot();
            return View(s.showall());
        }

        public ActionResult deletee(int id)
        {
            insertPlot ip = new insertPlot();
            ip.deletee(id);
            return RedirectToAction("ShowPlot");
        }
        public ActionResult SecondHome()
        {
            Account s = new Account();
            return View(s.showall());

        }
        public ActionResult delete(int id)
        {
            Account s = new Account();
            s.delete(id);
            return RedirectToAction("SecondHome");
        }

        [HttpGet]
        public ActionResult insertStu()
        {
            return View();
        }
        [HttpPost]
        public ActionResult insertStu(insertPlot s)
        {
            s.AddPlot (s);
            return RedirectToAction("SecondHome");


        }

        [HttpGet]
        public ActionResult LoginPage()
        {
            return View();
        }

        [HttpPost]

       

        [HttpGet]
        public ActionResult HomePage()
        {
            return View();
        }

        [HttpPost]

        public ActionResult HomePage(Account acc)
        {
            acc.Register(acc);
            return View();
        }
        
        public ActionResult  Verify(Account acc)
        {
            string query = string.Format("select * from tblCustomer where CustomerID='" + acc.ID + "' and Password='" + acc.Password + "'");
            SqlCommand cmd = new SqlCommand(query, Connection.GetCon());
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                Connection.CloseCon();
                return View("HomePage");
            }
            else
            {
                Connection.CloseCon();
                return View("Error");
            }

        }
      
        
    }
}