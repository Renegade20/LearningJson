using LOLChampions.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using Newtonsoft;
using Newtonsoft.Json.Linq;
using System.IO;

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


        public ActionResult Details(int id)
        {
            StreamReader sr = new StreamReader("C:\\Users\\craigky\\Documents\\GitHub\\LearningJson\\LOLChampions\\JFiles\\champion.json");
            string jsonString = sr.ReadToEnd();
            sr.Close();


            JObject jObj = JObject.Parse(jsonString);

            var champion = new Champion { name = (string)jObj["data"]["name"] };
           
            

            return View(champion);
        }

    }

}


