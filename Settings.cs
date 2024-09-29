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
        private float _rangeFix;
        private float _skillTimer;
        private float _monDistance;

        public float RangeFix
        {
            get
            {
                // Update the text box and return the current value
                textBox2.Text = _rangeFix.ToString();
                return _rangeFix;
            }
            set
            {
                // Set the value and update the text box
                _rangeFix = value;
                textBox2.Text = _rangeFix.ToString();
            }
        }

        public float SkillTimer
        {
            get
            {
                // Update the text box and return the current value
                textBox1.Text = _skillTimer.ToString();
                return _skillTimer;
            }
            set
            {
                // Set the value and update the text box
                _skillTimer = value;
                textBox1.Text = _skillTimer.ToString();
            }
        }

        public float MonDistance
        {
            get
            {
                // Update the text box and return the current value
                textBox3.Text = _monDistance.ToString();
                return _monDistance;
            }
            set
            {
                // Set the value and update the text box
                _monDistance = value;
                textBox3.Text = _monDistance.ToString();
            }
        }

        public float RangeFixMinus
        {
            get
            {
                // Return the negative value of RangeFix
                float negativeValue = -_rangeFix;
                textBox2.Text = negativeValue.ToString();
                return negativeValue;
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
            textBox2.Text = _rangeFix.ToString();
            textBox1.Text = _skillTimer.ToString();
            textBox3.Text = _monDistance.ToString();

        }
    }
}
