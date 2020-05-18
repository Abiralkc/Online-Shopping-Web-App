using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalProject.Models
{
    public class MyMenu
    {
        public static List<tblCatagory> GetMenus()
        {
            using (var context = new MorningBroadway1Entities())
            {
                return context.tblCatagories.ToList();
            }
        }
      
    }
}