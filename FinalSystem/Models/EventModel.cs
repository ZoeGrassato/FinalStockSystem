using FinalSystem.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalSystem.Models
{
    public class EventModel : BaseItem
    {
        public string Name { get; set; }
        public string Place { get; set; }
        public string ShopID { get; set; }
        public DateTime DateTime { get; set; }
    }
}
