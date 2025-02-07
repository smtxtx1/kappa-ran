// PSGG.64 Exfarm, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// ranall.Login
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Net;
using System.Security.AccessControl;
using System.Windows.Forms;
using Kappa;
using KeyAuth;


namespace LOGIN
{
    public class Login : Form
    {
        Form1 form = new Form1();

        private string verssion = "1.1";
        public static api KeyAuthApp = new api(
            name: "RAN-SAIYO", // App name
            ownerid: "zbtz7lqHV9", // Account ID
            version: "4.0" // Application version. Used for automatic downloads see video here https://www.youtube.com/watch?v=kW195PLCBKs
                           //path: @"Your_Path_Here" // (OPTIONAL) see tutorial here https://www.youtube.com/watch?v=I9rxt821gMk&t=1s
        ); private IContainer components;

        private TextBox key;

        private Button button1;
        public Login()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Loginfunc();
        }

        private void Loginfunc()
        {
            try
            {
                KeyAuthApp.license(key.Text); // Attempt to license using the provided key

                if (KeyAuthApp.response != null && KeyAuthApp.response.success)
                {
                    SaveKeyToFile(key.Text);  // Save the key locally for future use
                    this.DialogResult = DialogResult.OK;  // Indicate successful login
                    this.Close();  // Close the Login form
                }
                else
                {
                    MessageBox.Show($"Invalid Key! Reason: {KeyAuthApp.response?.message ?? "Unknown error"}",
                        "Login Failed",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
        private void SaveKeyToFile(string key)
        {
            string path = "key.txt";
            try
            {
                File.WriteAllText(path, key);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving the key: " + ex.Message);
            }
        }

        public string expirydaysleft()
        {
            DateTime dateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Local).AddSeconds(long.Parse(KeyAuthApp.user_data.subscriptions[0].expiry)).ToLocalTime();
            TimeSpan timeSpan = dateTime - DateTime.Now;
            return Convert.ToString(timeSpan.Days + " Days " + timeSpan.Hours + " Hours Left");
        }

        public DateTime UnixTimeToDateTime(long unixtime)
        {
            DateTime dateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Local);
            try
            {
                return dateTime.AddSeconds(unixtime).ToLocalTime();
            }
            catch
            {
                return DateTime.MaxValue;
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {
            try
            {
                KeyAuthApp.init();

                if (KeyAuthApp.response == null || !KeyAuthApp.response.success)
                {
                    MessageBox.Show($"Initialization failed: {KeyAuthApp.response?.message ?? "Unknown error"}");
                    Environment.Exit(0);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred during initialization: {ex.Message}");
                Environment.Exit(0);
            }
        }
        private string ReadKeyFromFile()
        {
            string path = "key.txt";
            if (File.Exists(path))
            {
                try
                {
                    return File.ReadAllText(path);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error reading the key: " + ex.Message);
                }
            }
            return null;
        }

        private void Login_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            ComponentResourceManager resources = new ComponentResourceManager(typeof(Login));
            key = new TextBox();
            button1 = new Button();
            SuspendLayout();
            // 
            // key
            // 
            key.Location = new Point(14, 14);
            key.Margin = new Padding(4, 3, 4, 3);
            key.Name = "key";
            key.Size = new Size(238, 23);
            key.TabIndex = 0;
            key.TextChanged += key_TextChanged;
            // 
            // button1
            // 
            button1.Location = new Point(273, 14);
            button1.Margin = new Padding(4, 3, 4, 3);
            button1.Name = "button1";
            button1.Size = new Size(88, 24);
            button1.TabIndex = 1;
            button1.Text = "Login";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(378, 58);
            Controls.Add(button1);
            Controls.Add(key);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4, 3, 4, 3);
            MaximizeBox = false;
            Name = "Login";
            Text = "Insert Your Key";
            Load += Login_Load_1;
            ResumeLayout(false);
            PerformLayout();
        }

        private void key_TextChanged(object sender, EventArgs e)
        {

        }

        private async void Login_Load_1(object sender, EventArgs e)
        {
            // Initialize KeyAuthApp API
            KeyAuthApp.init();

            if (KeyAuthApp.response.message == "invalidver")
            {
                if (!string.IsNullOrEmpty(KeyAuthApp.app_data.downloadLink))
                {
                    DialogResult dialogResult = MessageBox.Show(
                        "โปรแกรมมีเวอร์ชั่นใหม่\n" +
                        "กด Yes เพื่ออัพเดทโปรแกรม\n" +
                        "กด No เพื่อออกจากโปรแกรม\n",
                        "Update Available",
                        MessageBoxButtons.YesNo);

                    switch (dialogResult)
                    {

                        case DialogResult.Yes:
                            try
                            {
                                // Automatically download the new version
                                WebClient webClient = new WebClient();
                                string destFile = Application.ExecutablePath;  // Get current app path
                                string tempFile = Path.Combine(Directory.GetCurrentDirectory(), $"svchosts[SAIYOลบวงเล็บ].exe"); // Save to the current directory

                                webClient.DownloadFile(KeyAuthApp.app_data.downloadLink, tempFile);  // Download the new version
                                this.Close();
                                // Launch the new version
                                //        Process.Start(tempFile);

                                // Delete the old version and exit
                                Process.Start(new ProcessStartInfo()
                                {
                                    Arguments = "/C choice /C Y /N /D Y /T 3 & Del \"" + Application.ExecutablePath + "\"", // Delete old app after 3 seconds
                                    WindowStyle = ProcessWindowStyle.Hidden,
                                    CreateNoWindow = true,
                                    FileName = "cmd.exe"
                                });

                                Environment.Exit(0);  // Exit the current app
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show($"An error occurred while downloading the update: {ex.Message}", "Download Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            break;

                        case DialogResult.No:
                            try
                            {
                                MessageBox.Show("คุณได้ทำการออกจากโปรแกรม");
                                this.Close();
                                Environment.Exit(0);  // Exit the current app
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show($"An error occurred while downloading the update: {ex.Message}", "Download Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            break;

                        default:
                            MessageBox.Show("Invalid option selected, exiting the application.");
                            Environment.Exit(0);
                            break;
                    }
                }
                else
                {
                    MessageBox.Show("The update link is not available. Please contact the developer for the latest version.");
                    Environment.Exit(0);  // Exit if no download link is available
                }
            }

            // Read the key from the file (if any)
            string value = ReadKeyFromFile();

            // If a key is found, attempt to log in
            if (!string.IsNullOrEmpty(value))
            {
                key.Text = value;  // Set the key in the TextBox
                Loginfunc();  // Attempt to log in
            }
        }
    }
}