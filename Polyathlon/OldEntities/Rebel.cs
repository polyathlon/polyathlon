using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CouchDB.Driver.Types;

namespace Polyathlon.Entities
{
    internal class Rebel : CouchDocument
    {
        public string? Name { get; set; }
        public string? Age { get; set; }    
    }
}
