using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VidaControls
{
    public partial class VidaRegister : UserControl
    {
        List<Register> register = new List<Register>();

        public VidaRegister()
        {
            InitializeComponent();
        }

        private void buildRegister()
        {
            register.Add(new Register() {Date=, });
        }
    }
}
