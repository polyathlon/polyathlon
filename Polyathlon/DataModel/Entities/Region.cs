using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Polyathlon.DataModel.Entities
{
    public record class Region
    {        
        public string? Name { get; set; }        
        public string? ShortName { get; set; }        
    }
}
