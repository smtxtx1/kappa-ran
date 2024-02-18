// PSGG.64 Exfarm, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// ranall.Login
using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Security.AccessControl;
using System.Windows.Forms;
using Kappa;
using KeyAuth;


public class Login : Form
{
    public static api KeyAuthApp = new api("smbotenglish", "zbtz7lqHV9", "bc923a5105f16fd9b12ae6a1ceee8660f1116f8af26061a1b75e9dae2c590e22", "1.4.6"); private IContainer components;

    private TextBox key;

    private Button button1;

    public Login()
    {
        KeyAuthApp.init();
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
        string value = ReadKeyFromFile();
        if (!string.IsNullOrEmpty(value))
        {
            key.Text = value;
        }


    }
}
