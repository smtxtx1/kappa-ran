using System;
using System.Windows.Forms;

namespace Kappa
{
    public partial class Settings : Form
    {
        // Private fields to hold values
        private float _rangeFix;
        private float _skillTimer;
        private float _monDistance;

        // Constructor accepting values from Form1
        public Settings(float rangeFix, float skillTimer, float monDistance)
        {
            InitializeComponent();
            _rangeFix = rangeFix;
            _skillTimer = skillTimer;
            _monDistance = monDistance;
        }

        public float RangeFix
        {
            get => _rangeFix;
            set
            {
                _rangeFix = value;
                textBox2.Text = _rangeFix.ToString();
            }
        }

        public float SkillTimer
        {
            get => _skillTimer;
            set
            {
                _skillTimer = value;
                textBox1.Text = _skillTimer.ToString();
            }
        }

        public float MonDistance
        {
            get => _monDistance;
            set
            {
                _monDistance = value;
                textBox3.Text = _monDistance.ToString();
            }
        }

        public float RangeFixMinus => -_rangeFix;

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Update values before closing
            _rangeFix = float.TryParse(textBox2.Text, out var rangeFixValue) ? rangeFixValue : _rangeFix;
            _skillTimer = float.TryParse(textBox1.Text, out var skillTimerValue) ? skillTimerValue : _skillTimer;
            _monDistance = float.TryParse(textBox3.Text, out var monDistanceValue) ? monDistanceValue : _monDistance;

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void Settings_Load(object sender, EventArgs e)
        {
            // Initialize text boxes with current values
            textBox2.Text = _rangeFix.ToString();
            textBox1.Text = _skillTimer.ToString();
            textBox3.Text = _monDistance.ToString();
        }
    }
}
