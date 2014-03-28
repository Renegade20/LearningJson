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
using System.Runtime.Remoting.Activation;

namespace LOLChampions.Controllers
{
    public class ChampionsController : Controller
    {
        
        public ActionResult Index()
        {
            //Populate the champions list for the Index ViewModel
            JObject jObj = PopulateChampsList();
            //Instantiate a new List of Champions
            List<Champion> champlist = new List<Champion>();
            //Iterate through the list and add each according to the Champion Model
            foreach (var item in jObj["data"])
            {
                foreach (var champ in item)
                {
                    var details = champ as JObject;
                    champlist.Add(new Champion()
                    {
                        id = details["id"] + "",
                        name = details["name"]+"",
                        blurb = details["blurb"]+"",
                        title = details["title"] + "",
                        lore = details["lore"] + "",
                        image = details["image"]["full"] + ""
                    });
                }
            }

            // Pass the list of champions to the view model and set them equal
            var model = new ChampionViewModel { championsList = champlist };
            
            //Return the championViewModel to the View
            return View(model);
        }


        public ActionResult Details(string id)
        {
            //pull individual Champion Json File
            JObject jObj = GetIndividualChampionJson(id);
            // instantiate a new champion
            Champion singleChampData = new Champion();

            foreach (var item in jObj["data"])
            {
                foreach (var champ in item)
                {
                    var details = champ as JObject;
                    
                    
                       singleChampData.id = details["id"].ToString();
                       singleChampData.name = details["name"].ToString();
                       singleChampData.blurb = details["blurb"].ToString();
                       singleChampData.title = details["title"].ToString();
                       singleChampData.lore = details["lore"].ToString();
                       singleChampData.image = details["image"]["full"].ToString();
                    
                }
            }

            var model = new DetailsViewModel { championDetails = singleChampData };

            return View(model);
        }


        public JObject PopulateChampsList()
        {
            //Full File Path to Champion.Json
            string url = Server.MapPath("~/Jfiles/champion.json");

            StreamReader sr = new StreamReader(url);
			string jsonString = sr.ReadToEnd();
            sr.Close();

            JObject jObj = JObject.Parse(jsonString);

            return jObj;


        }

        public JObject GetIndividualChampionJson(string id)
        {
            //Full File path to selected champion json. (ie annie.json or brando.json)

            string url = Server.MapPath("~/Jfiles/champion/" + id + ".json");

            StreamReader sr = new StreamReader(url);
            string jsonString = sr.ReadToEnd();
            sr.Close();

            JObject jObj = JObject.Parse(jsonString);


            return jObj;

        }

    }

}


