using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LogonBGChanger2 {
    partial class License: Form {
        public License() {
            InitializeComponent();
            textBoxDescription.Select(0, 0);
        }

        private void buttonOK_Click(object sender, EventArgs e) { this.Close(); }
    }
}
