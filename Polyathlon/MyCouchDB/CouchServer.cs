using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Polyathlon.MyCouchDB
{
    using Options;

    public partial class CouchServer : Component
    {
        
        public CouchServer()
        {
            InitializeComponent();
        }

        public CouchServer(IContainer container)
        {
            container.Add(this);
            InitializeComponent();
        }

        public bool CheckConnection()
        {
            return true;
        }
    }
}
