using LOLChampions.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;

namespace LOLChampions.Controllers
{
    public class ChampionsController : Controller
    {
         Champion[] Champions = new Champion[] 
        { 
             
        };

        public IEnumerable<Champion> GetAllChampions()
        {
            return Champions;
        }

        //public IHttpActionResult GetChampion(int id)
        //{
        //    var Champion = Champions.FirstOrDefault((p) => p.ID == id);
        //    if (Champion == null)
        //    {
        //        return NotFound();
        //    }
        //    return Ok(Champion);
        //}

        public ActionResult Index()
        {
        
            return View();
        }



    }

}


