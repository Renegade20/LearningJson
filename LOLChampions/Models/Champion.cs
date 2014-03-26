using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace LOLChampions.Models
{

    public class ChampionListDto
    {
        public List<Champion> champions { get; set;}
    }
   
        public class Champion
    {
        public List<string> allytips { get; set; }
        public string blurb { get; set; }
        public List<string> enemytips { get; set; }
        public string id { get; set; }
        public string key { get; set; }
        public string lore { get; set; }
        public string name { get; set; }
        public string partype { get; set; }
        public List<string> tags { get; set; }
        public string title { get; set; }

    }


    public class ChampionDBcontext : DbContext
    {
        public DbSet<Champion> Champions {get; set;}
    }
}



