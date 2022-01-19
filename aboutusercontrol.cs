using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Library_Management_System
{
    public partial class about_usercontrol : UserControl
    {
        private static about_usercontrol _instance;
        public static about_usercontrol Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new about_usercontrol();
                return _instance;

            }
        }
        public about_usercontrol()
        {
            InitializeComponent();
        }

        private void about_usercontrol_Load(object sender, EventArgs e)
        {

        }
    }
}
