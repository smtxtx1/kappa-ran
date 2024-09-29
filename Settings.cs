using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kappa
{
    public partial class Settings : Form
    {
        public Settings()
        {
            InitializeComponent();
        }
        public float RangeFix
        {
            get
            {
                float.TryParse(textBox2.Text, out float value);
                return value;
            }
        }
        public float skilltimer
        {
            get
            {
                float.TryParse(textBox1.Text, out float value);
                return value;
            }
        }
        public float MonDistance
        {
            get
            {
                float.TryParse(textBox3.Text, out float value);
                return value;
            }
        }

        public float RangeFixMinus
        {
            get
            {
                float.TryParse("-" + textBox2.Text, out float value);
                return value;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
        public string TextBoxValue2
        {
            get { return textBox2.Text; }
        }

        private void Settings_Load(object sender, EventArgs e)
        {

        }
    }
}
