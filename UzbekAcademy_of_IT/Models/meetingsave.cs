using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace UzbekAcademy_of_IT.Models
{
    public class meetingsave
    {
        public string fan_nomi { get; set; }
        public string link_nomi { get; set; }
        public List<SelectListItem> Fanlar { get; set; }
    }
}