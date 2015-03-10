using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Welded.FunctionalLayer
{
    public partial class clsListViewMIL : System.Windows.Forms.ListView
    {
        private int _WM_KILLFOCUS = 8;
        public clsListViewMIL()
        {
            InitializeComponent();
            this.View = System.Windows.Forms.View.Details;
        }

        public clsListViewMIL(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
        protected override void WndProc(ref System.Windows.Forms.Message m)
        {
            if (m.Msg != _WM_KILLFOCUS)
            {
               base.WndProc(ref m);
            }

        }
    }
}
