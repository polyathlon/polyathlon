using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CouchDB.Driver.Exceptions;
using CouchDB.Driver.Options;
using CouchDB.Driver;

namespace Polyathlon
{
    internal class MyCouchDBContext : CouchContext
    {
        public CouchDatabase<Entities.Region> Regions { get; set; }

        protected override void OnConfiguring(CouchOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseEndpoint(Settings.Data.settingsDB.Host)
                .EnsureDatabaseExists()
                .UseBasicAuthentication(Settings.Data.settingsDB.UserName,
                                        Settings.Data.settingsDB.Password);
        }
    }
}
