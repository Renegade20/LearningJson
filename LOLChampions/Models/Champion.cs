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
        public string id { get; set; }
        public string name { get; set; }
        public string blurb { get; set; }
        public string title { get; set; }
        public string lore { get; set; }
        public string image { get; set; }


    }


    public class ChampionDBcontext : DbContext
    {
        public DbSet<Champion> Champions {get; set;}
    }
}



