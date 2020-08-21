using System; 
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Stajyer_Takip_Sistemi
{
    public partial class CV : Form
    {
        public CV()
        {
            InitializeComponent();
        }

        private void CV_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
        }
    }
}
