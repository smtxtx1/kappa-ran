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


public class Login : Form
{

    public static api KeyAuthApp = new api(
        name: "Autotracing", // Application Name
        ownerid: "zbtz7lqHV9", // Owner ID
        secret: "87e66ca811406726d54a7708245d5476f5a08178e3bb906d04080392928d71e3", // Application Secret
        version: "1.0" // Application Version /*, 
);
    private IContainer components;

    private TextBox key;

    private Button button1;
    public Login()
    {
        InitializeComponent();
    }
    private void button1_Click(object sender, EventArgs e)
    {
        KeyAuthApp.license(key.Text);
        if (KeyAuthApp.response.success)
        {
            SaveKeyToFile(key.Text);
            Form1 form = new Form1();
            Hide();
            form.Show();
            foreach (Control control in base.Controls)
            {
                control.Enabled = true;
            }
            MessageBox.Show("Date Expire: " + UnixTimeToDateTime(long.Parse(KeyAuthApp.user_data.subscriptions[0].expiry)).ToString());
        }
        else
        {
            MessageBox.Show("Invalid Key!!");
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
        KeyAuthApp.init();

        if (KeyAuthApp.response.message == "invalidver")
        {
            if (!string.IsNullOrEmpty(KeyAuthApp.app_data.downloadLink))
            {
                DialogResult dialogResult = MessageBox.Show("Yes to open file in browser\nNo to download file automatically", "Auto update", MessageBoxButtons.YesNo);
                switch (dialogResult)
                {
                    case DialogResult.Yes:
                        Process.Start(KeyAuthApp.app_data.downloadLink);
                        Environment.Exit(0);
                        break;
                    case DialogResult.No:
                        WebClient webClient = new WebClient();
                        string destFile = Application.ExecutablePath;
                        webClient.DownloadFile(KeyAuthApp.app_data.downloadLink, destFile);

                        Process.Start(destFile);
                        Process.Start(new ProcessStartInfo()
                        {
                            Arguments = "/C choice /C Y /N /D Y /T 3 & Del \"" + Application.ExecutablePath + "\"",
                            WindowStyle = ProcessWindowStyle.Hidden,
                            CreateNoWindow = true,
                            FileName = "cmd.exe"
                        });
                        Environment.Exit(0);

                        break;
                    default:
                        MessageBox.Show("Invalid option");
                        Environment.Exit(0);
                        break;
                }
            }
            MessageBox.Show("Version of this program does not match the one online. Furthermore, the download link online isn't set. You will need to manually obtain the download link from the developer");
            Environment.Exit(0);
        }

        if (!KeyAuthApp.response.success)
        {
            MessageBox.Show(KeyAuthApp.response.message);
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

    private void Login_Load_1(object sender, EventArgs e)
    {
        KeyAuthApp.init();

        string value = ReadKeyFromFile();
        if (!string.IsNullOrEmpty(value))
        {
            key.Text = value;
        }


    }
}
