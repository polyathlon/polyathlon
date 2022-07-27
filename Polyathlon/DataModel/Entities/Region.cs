using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Polyathlon.DataModel.Entities
{
    public class Region
    {
        [Display(Name = "Name")]
        public string? Name { get; set; }
        [Display(Name = "ShortName")]
        public string? ShortName { get; set; }
        public Region()
        {
         
        }
        public Region(Region region)
        {
            Name = region.Name;
            ShortName = region.ShortName;
        }
    }
}
