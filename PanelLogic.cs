using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace WebApplication111.Models.panel
{




    public class VratiAgenciju : Controller
    {
        private agencijaEntities db = new agencijaEntities();

        public ActionResult Index()
        {
            return View(db.agencijas.ToList());
        }


    }
}
