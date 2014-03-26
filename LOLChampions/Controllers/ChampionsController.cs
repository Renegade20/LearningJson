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
using LOLChampions.ViewModels;

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
           // StreamReader sr = new StreamReader("C:\\Users\\craigky\\Documents\\GitHub\\LearningJson\\LOLChampions\\JFiles\\champion.json");
			StreamReader sr = new StreamReader("D:\\GitHub\\LearningJson\\LOLChampions\\JFiles\\champion.json");
            string jsonString = sr.ReadToEnd();
            sr.Close();


            JObject jObj = JObject.Parse(jsonString);

            //var champion = new Champion { name = (string)jObj["data"]["name"]};
			string[] Champions = new string[500];
			int index = 0;
			foreach(var item in jObj["data"])
			{
				foreach (var champ in item)
				{
					var details = champ as JObject;
					Champions[++index] = details["name"] + "";
				}
			}
			//This part really isn't necessary right now I'll explain later
			//var Champion = new Champion { name = Champions[id] };

			// You need a view model to pass information to the view I'll set it here
			var model = new ChampionViewModel { Name = Champions[id] };
           
            

            return View(model);
        }

    }

}


