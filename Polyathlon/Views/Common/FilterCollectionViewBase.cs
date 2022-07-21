using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.Mvvm;
using Polyathlon.ViewModels;
using Polyathlon.ViewModels.Common;

namespace Polyathlon.Views {
    public partial class FilterCollectionViewBase : BaseViewWithWinUIButtons {
        public FilterCollectionViewBase() {
            InitializeComponent();
            Messenger.Default.Register<DocumentShownMessage>(this, DocumentShownMessageReceived);
            ApplyPadding();
        }

        void ApplyPadding() {
            labelControl.Padding = new System.Windows.Forms.Padding(41, 8, 13, 8);
            splitContainerControl.Panel1.Padding = new System.Windows.Forms.Padding(40, 2, 0, 2);
        }

        protected virtual void DocumentShownMessageReceived(DocumentShownMessage msg) {
        }
    }
}
