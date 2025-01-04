using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using System.Text;
using Memory;
using System.Runtime.InteropServices;
using System;
using System.Reflection.Emit;
using System.Windows.Forms.Automation;
using Newtonsoft;
using Newtonsoft.Json;
using System.Web;
using System.IO;
using System.ComponentModel;
using System.Numerics;
using System.Text.Encodings;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Security.Policy;
using LOGIN;
using KeyAuth;
using Loader;
using Microsoft.VisualBasic.Devices;
using System.Windows.Forms;
using static KeyAuth.api;
using Newtonsoft.Json.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace Kappa
{

    public partial class Form1 : Form
    {

        public class ITEM_COLLECT
        {
            public string SubItem2 { get; set; } // Represents SubItems[2]
        }

        public class LocationData
        {
            public string Position { get; set; }

            public string X { get; set; }

            public string Y { get; set; }

            public string Z { get; set; }
        }
        public class ComboBoxItem
        {
            public string DisplayText { get; set; }

            public string Value { get; set; }

            public ComboBoxItem(string displayText, string value)
            {
                DisplayText = displayText;
                Value = value;
            }

            public override string ToString()
            {
                return DisplayText;
            }
        }

        private Mem m = new Mem();
        private Mem mem = new Mem();

        // public string Drone_adr = "MiniA.exe+2E49A60";
        public string ServerName = "Ran Cafe";

        public string FastZoom = "0324BA7C";

        public string AOE_adr = "";

        public string LongRange_adr = "";

        public string NameAdr = "00FF38A0,2B0";


        public string selectedFilePath;
        public long AOB_MONVIEW;
        public long AOB_LOCALPLAYER;
        public long AOB_AOE;
        public long AOB_PATH;
        public long AOB_BA;
        public long AOB_LR;
        public long AOB_Superpot;
        public long AOB_Superpot2;
        public long AOB_WH;
        public long AOB_HT;
        public long AOB_HT2;
        public long AOB_GETBUFF;
        public long AOB_GETSKILL_LIST;


        public long AOB_DRONE;
        public long AOB_ASPD;
        public long AOB_CUTAM;
        public long AOB_ANTIAFK;
        public long AOB_RUN;
        public long AOB_ITEMDROP;
        public long AOB_ANTISLIDE;
        public long AOB_NOLIMIT;
        public long AOB_FASTLE;
        public long AOB_UNLOCK;
        public long AOB_ANTICB;
        public long AOB_ANTICHAT;
        public long AOB_LONGBUFF;
        public long AOB_FastPET;


        public string FASTPET_ADR_RESULT;
        public string Guildselected;
        public string SKILLPET_ADR_RESULT;
        public string LONGBUFF_ADR_RESUT;
        public string GETBUFF_ADR_RESULT;
        public string GETSKILL_LIST_ADR_RESULT;
        public string ANTICHAT_ADR_RESULT;
        public string ANTICB_ADR_RESULT;
        public string UNLOCK_ADR_RESULT;
        public string FASTLE_ADR_RESULT;
        public string ANTISLIDE_ADR_RESULT;
        public string MONVIEW_ADR;
        public string LOCALPLAYER_ADR_RESULT;
        public string NOLIMIT_ADR_RESULT;
        public string NOLIMIT_ADR_RESULT2;
        public string RUN1_ADR_RESULT;
        public string RUN2_ADR_RESULT;
        public string RUN3_ADR_RESULT;
        public string RUN4_ADR_RESULT;
        public string RUN5_ADR_RESULT;
        public string RUN6_ADR_RESULT;
        public string ITEMDROP_ADR_RESULT;
        public string CUTAM_ADR_RESULT;
        public string ANTIAFK_ADR_RESULT;
        public string ASPD_ADR_RESULT;
        public string ASPD_ADR_RESULT2;
        public string DELAYPOT_ADR_RESULT;
        public string HT_ADR_RESULT;
        public string HT2_ADR_RESULT;
        public string HT3_ADR_RESULT;
        public string WH_ADR_RESULT;
        public string AOE_ADR_RESULT;
        public string LR_ADR_RESULT;
        public string BA_ADR_RESULT;
        public string PATH_ADR_RESULT;
        public string SUPERPOT_ADR_RESULT;
        public string SUPERPOT_ADR_RESULT2;
        public string DRONE_ADR_RESULT;

        private Dictionary<string, string> itemDescriptions = new Dictionary<string, string>
    {
        { "1", "Hp+Sp+MP" },
        { "2", "Power" },
        { "3", "Defender" },
        { "4", "Auto Pot" },
        { "5", "Protect Item" },
        { "6", "Collect All" },
        { "7", "Collect Rare" },
        { "8", "Collect Potion" },
        { "9", "Collect Gold" },
        { "10", "Collect Ore" },
        { "11", "Collect Box" }
    };



        //    //            AOE_ADR_RESULT = AOB_AOE.ToString("x");
        //    LR_ADR_RESULT = AOB_LR.ToString("x");
        //BA_ADR_RESULT = AOB_BA.ToString("x");
        //    PATH_ADR_RESULT = AOB_PATH.ToString("x");



        public string DroneBypass = "005B72F8";

        public string IDadr = "00FF38A0,4E0";

        public string Level_ADR = "00FF38A0,90";

        public float GetX1;

        public float GetY1;

        public float GetZ1;

        public float GetX2;

        public float GetY2;

        public float GetZ2;

        private bool autoAddItems;

        private bool CurrentPos;

        public string saveID;

        /// <summary>
        /// POSITION 
        /// </summary>

        public string CurrentX = "00FF38A0,2FE8";

        public string CurrentY = "00FF38A0,2FEC";

        public string CurrentZ = "00FF38A0,2FF0";

        public string ZoomAdr = "";

        public string AngleAdr = "";

        public string gotoX = "00FF38A0,302C";

        public string gotoY = "00FF38A0,3030";

        public string gotoZ = "00FF38A0,3034";
        /// <summary>
        /// POSITION END
        /// </summary>

        public float currentrange;

        public float currentrange2;

        /// <summary>
        /// ////// BUTTON START ////////////
        /// </summary>

        public string LeftClick = "031F39D8";

        public string RightClick = "031F39D8+1";

        public string AltButton = "031F3804";

        public string Spacebar = "031F3804+1";

        public string RightArrow = "031F3899";

        /// <summary>
        /// ////// BUTTON END ////////////
        /// </summary>

        /// <summary>
        /// Autoskill START ///////////////
        /// </summary>
        /// 

        public string Skilluse1_adr = "00FF38A0,3198";

        public string Skilluse2_adr = "00FF38A0,319A";

        public string prevskill1_adr = "00FF38A0,319C";

        public string prevskill2_adr = "00FF38A0,319E";

        public string forceattack_adr = "00FF38A0,3298";

        public string actioncheck = "00FF38A0,32AC";

        public string TARGET_SKILL = "00FF38A0,32B0"; //MiniA.exe+793E74

        public string TARGET_RING_CHECK = "00FF38A0,4060"; //


        public string TARGET_RING = "00FF38A0,4064"; //

        public string MATION_CHECK = "00FF38A0,30FC";

        public string SKILL_TIME = "00FF38A0,32C4";

        public string PATH2_ADR_RESULT;
        /// <summary>
        /// Autoskill END ///////////////
        /// </summary>

        public string Superpot = "007757B8";
        public string Superpot2 = "007757D6";
        public string Superpot3 = "007757F4";


        public string HpFreeze_1 = "00FF38A0,390";

        public string HpFreeze_2 = "00FF38A0,394";

        public string Antislide = "004324D8";

        public string Wallhack = "005E2FC1";

        public string ASPD_adr = "MiniA.exe+5694D8";

        public bool autoskillsstand = false;

        private int selectedProcessId = -1;

        private int selectedProcessId2 = -1;


        public Form1()
        {
            timer.Tick += Timer_Tick;
            timer.Interval = 10000; // 10 seconds
            InitializeComponent();
            backgroundWorker1.WorkerSupportsCancellation = true;
            backgroundWorker5.WorkerSupportsCancellation = true;
            backgroundWorker6.WorkerSupportsCancellation = true;

        }
        [DllImport("kernel32.dll")]
        public static extern IntPtr OpenProcess(uint dwDesiredAccess, bool bInheritHandle, int dwProcessId);

        [DllImport("kernel32.dll")]
        public static extern IntPtr VirtualAllocEx(IntPtr hProcess, IntPtr lpAddress, uint dwSize, uint flAllocationType, uint flProtect);

        [DllImport("kernel32.dll")]
        public static extern bool VirtualFreeEx(IntPtr hProcess, IntPtr lpAddress, uint dwSize, uint dwFreeType);

        [DllImport("kernel32.dll")]
        public static extern bool CloseHandle(IntPtr hObject);

        // Constants for process access rights
        public const uint PROCESS_ALL_ACCESS = 0x1F0FFF;

        // Constants for memory allocation
        public const uint MEM_COMMIT = 0x1000;
        public const uint PAGE_READWRITE = 0x04;

        private IntPtr allocate_adr;
        private IntPtr allocate_adr_cutam;
        private IntPtr allocate_adr_Display;
        private IntPtr allocate_adr_aoe;
        private IntPtr allocate_adr_Path;
        private IntPtr allocate_adr_Monview;
        private IntPtr allocate_adr_BA;
        private IntPtr allocate_adr_LOCALPLAYER;
        private IntPtr allocate_adr_Nolimit;
        private IntPtr allocate_adr_Nolimit2;
        private IntPtr allocate_adr_SKILL_LIST;
        private IntPtr allocate_adr_BUFF;

        public string Expirydaysleft()
        {
            Login.KeyAuthApp.check();
            System.DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Local);
            dtDateTime = dtDateTime.AddSeconds(long.Parse(Login.KeyAuthApp.user_data.subscriptions[0].expiry)).ToLocalTime();
            TimeSpan difference = dtDateTime - DateTime.Now;
            return Convert.ToString(difference.Days + " Days " + difference.Hours + " Hours Left");
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            string value = ReadWebhook();
            if (!string.IsNullOrEmpty(value))
            {
                textBox11.Text = value;
                UrlAlert = value;
            }

            label4.Text = Expirydaysleft().ToString();
            LoadListView12FromJSON(listView12, "ITEM_COLLECT.json");
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            var enc1252 = Encoding.GetEncoding(874);
            comboBox3.Items.Add("listView1");
            comboBox3.Items.Add("listView2");
            comboBox3.Items.Add("listView3");
            comboBox3.Items.Add("listView4");
            comboBox3.Items.Add("listView5");
            comboBox3.Items.Add("listView6");
            comboBox3.Items.Add("listView7");
            comboBox3.Items.Add("listView8");
            comboBox3.Items.Add("listView9");
            comboBox3.Items.Add("listView10");
            comboBox3.Items.Add("listView13");
            comboBox3.Items.Add("listView14");
            comboBox3.Items.Add("listView15");
            comboBox3.Items.Add("listView16");
            comboBox3.Items.Add("listView17");
            comboBox3.Items.Add("listView18");
            comboBox3.Items.Add("listView19");
            comboBox3.Items.Add("listView20");

            listViewDictionary.Add("listView1", listView1);
            listViewDictionary.Add("listView2", listView2);
            listViewDictionary.Add("listView3", listView3);
            listViewDictionary.Add("listView4", listView4);
            listViewDictionary.Add("listView5", listView5);
            listViewDictionary.Add("listView6", listView6);
            listViewDictionary.Add("listView7", listView7);
            listViewDictionary.Add("listView8", listView8);
            listViewDictionary.Add("listView9", listView9);
            listViewDictionary.Add("listView10", listView10);
            listViewDictionary.Add("listView13", listView13);
            listViewDictionary.Add("listView14", listView14);
            listViewDictionary.Add("listView15", listView15);
            listViewDictionary.Add("listView16", listView16);
            listViewDictionary.Add("listView17", listView17);
            listViewDictionary.Add("listView18", listView18);
            listViewDictionary.Add("listView19", listView19);
            listViewDictionary.Add("listView20", listView20);

            comboBox3.SelectedIndexChanged += comboBox3_SelectedIndexChanged;
            foreach (KeyValuePair<string, string> itemDescription in itemDescriptions)
            {

                comboBox4.Items.Add(new ComboBoxItem(itemDescription.Value, itemDescription.Key));

            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();

            Process[] processesByName = Process.GetProcessesByName("minia");
            foreach (Process process in processesByName)
            {
                comboBox1.Items.Add(process.Id);

            }

        }
        string rawString;
        int maxLength = 20;
        [DllImport("user32.dll", SetLastError = true)]
        private static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);

        [DllImport("user32.dll", SetLastError = true)]
        private static extern bool SetWindowText(IntPtr hWnd, string lpString);

        [DllImport("user32.dll", SetLastError = true)]
        private static extern int GetWindowLong(IntPtr hWnd, int nIndex);

        [DllImport("user32.dll", SetLastError = true)]
        private static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);

        private const uint SWP_NOZORDER = 0x0004;
        private const uint SWP_NOACTIVATE = 0x0010;
        private const uint SWP_SHOWWINDOW = 0x0040;
        private const uint SWP_NOMOVE = 0x0002;

        private const int GWL_STYLE = -16;
        private const int WS_THICKFRAME = 0x00040000; // Window style that allows resizing
        private const int WS_VISIBLE = 0x10000000;    // Window style that makes the window visible


        private async void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {


            MessageBox.Show("Scaning address..");
            m.OpenProcess(int.Parse(comboBox1.Text));
            // Check for null before converting to string


            selectedProcessId = int.Parse(comboBox1.SelectedItem.ToString());

            IEnumerable<long> AoB_Scan_AOE = await m.AoBScan("D8 5C 24 0C DF E0 F6 C4 05 7A 06 B8", false, true);
            IEnumerable<long> AoB_Scan_LR = await m.AoBScan("D9 5C 24 14 FF 52 10", false, true);
            IEnumerable<long> AoB_Scan_LB = await m.AoBScan("0f b7 ? ? ? ? ? 89 44 ? ? db 44 ? ? 89 4c ? ? da 44", false, true);

            IEnumerable<long> AoB_Scan_BA = await m.AoBScan("83 7f 44 ? 0f 85 ? ? ? ? 83 7f 5c", false, true);
            IEnumerable<long> AoB_Scan_PATH = await m.AoBScan("39 5C 24 28 74 ??", false, true);
            IEnumerable<long> AoB_Scan_Superpot = await m.AoBScan("6A 02 52 83 CE FF", false, true);
            IEnumerable<long> AoB_Scan_WallHack = await m.AoBScan("74 23 8B 4C 24 34", false, true);
            IEnumerable<long> AoB_Scan_HitTru = await m.AoBScan("0f 84 ? ? ? ? 83 f8 ? 0f 84 ? ? ? ? f6 84 24 4c 01 00 00", false, true);
            IEnumerable<long> Aob_Scan_ASPD = await m.AoBScan("?? 0D ?? ?? ?? 00 8D 46 10 52 8B 54", false, true);
            IEnumerable<long> AoB_Scan_Drone = await m.AoBScan("8B 96 CC 00 00 00 89 96 D0 00 00 00", false, true);
            IEnumerable<long> AoB_Scan_CutAnimate = await m.AoBScan("D8 4C 24 10 8B CE", false, true);
            IEnumerable<long> AoB_Scan_ANTI_AFK = await m.AoBScan("d8 1d ? ? ? ? df e0 f6 c4 ? 7a ? 68 ? ? ? ? c7 81", false, true);
            IEnumerable<long> AoB_Scan_RUN = await m.AoBScan("74 28 55 E8 ?? ?? ?? 00 8B C8", false, true);
            IEnumerable<long> AoB_Scan_Nolimit = await m.AoBScan("C7 81 C0 01 00 00 00 00 A0 40", false, true);

            var AoB_Scan_SABUD = await m.AoBScan("e8 ? ? ? ? 5f 5e 5d 5b 83 c4 ? c2 ? ? 8b 54 ? ? 55 57 52 50 8b ce e8 ? ? ? ? 5f 5e 5d 5b 83 c4 ? c2 ? ? 8b 4f", false, true);
            var AoB_Scan_Monview = await m.AoBScan("8B 81 A4 17 00 00", false, true);
            var AoB_Scan_ITEMDROP = await m.AoBScan("8B 96 B8 03 00 00", false, true);
            var AoB_Scan_LOCALPLAYER = await m.AoBScan("8b 86 ? ? ? ? 81 c6 ? ? ? ? 52", false, true);
            var AoB_Scan_AntiSlide = await m.AoBScan("38 ?? ?? ?? 00 00 74 ?? 8B 96 ??", false, true);
            var AoB_Scan_ATKBP = await m.AoBScan("74 ? 8d be ? ? ? ? 8b c7", false, true);
            var AoB_Scan_ANTICB = await m.AoBScan("74 58 55 55", false, true);
            var AoB_Scan_ANTICHAT = await m.AoBScan("C7 86 94 01 00 00 00 00 00 41", false, true);
            var AoB_Scan_ANTIDELAY = await m.AoBScan("0F 84 ?? ?? 00 00 F6 84 ? ? 2A 00 00 10", false, true);
            var AoB_Scan_DelayPot = await m.AoBScan("7A ? b8 ? ? ? ? 5e 83 c4 ? c2 ? ? 8b 8e", false, true);
            var AoB_Scan_SKILLPET = await m.AoBScan("66 8B 4F 1E 33 D2 66 8B 57 1C", false, true);
            var AoB_Scan_FastPet = await m.AoBScan("89 86 ? ? ? ? 8a c1", false, true);
            var AoB_Scan_GETBUFF = await m.AoBScan("8b 16 3b d5 74 ? 33 c0", false, true);
            var AoB_Scan_GET_SKILL_LIST = await m.AoBScan("8B BC B8 ?? ?? 00 00 89", false, true); // LINE 731
            long AOB_DELAYPOT = AoB_Scan_DelayPot.FirstOrDefault();
            AOB_GETBUFF = AoB_Scan_GETBUFF.FirstOrDefault();
            AOB_GETSKILL_LIST = AoB_Scan_GET_SKILL_LIST.FirstOrDefault();
            long AOB_SKILLPET = AoB_Scan_SKILLPET.FirstOrDefault();
            long AOB_SABUD = AoB_Scan_SABUD.FirstOrDefault();
            AOB_LONGBUFF = AoB_Scan_LB.FirstOrDefault();
            long AOB_ANTIDELAY = AoB_Scan_ANTIDELAY.FirstOrDefault();
            AOB_ANTICHAT = AoB_Scan_ANTICHAT.FirstOrDefault();
            AOB_FastPET = AoB_Scan_FastPet.FirstOrDefault();

            AOB_ANTICB = AoB_Scan_ANTICB.FirstOrDefault();
            long AOB_ATKBP = AoB_Scan_ATKBP.FirstOrDefault();
            AOB_NOLIMIT = AoB_Scan_Nolimit.FirstOrDefault();
            AOB_ANTISLIDE = AoB_Scan_AntiSlide.FirstOrDefault();
            AOB_ITEMDROP = AoB_Scan_ITEMDROP.FirstOrDefault();
            AOB_RUN = AoB_Scan_RUN.FirstOrDefault();
            AOB_MONVIEW = AoB_Scan_Monview.FirstOrDefault();
            AOB_LOCALPLAYER = AoB_Scan_LOCALPLAYER.FirstOrDefault();
            AOB_CUTAM = AoB_Scan_CutAnimate.FirstOrDefault();
            AOB_ASPD = Aob_Scan_ASPD.FirstOrDefault();
            AOB_DRONE = AoB_Scan_Drone.FirstOrDefault();
            AOB_HT = AoB_Scan_HitTru.FirstOrDefault();
            AOB_WH = AoB_Scan_WallHack.FirstOrDefault();
            AOB_Superpot = AoB_Scan_Superpot.FirstOrDefault();
            AOB_AOE = AoB_Scan_AOE.FirstOrDefault();
            AOB_PATH = AoB_Scan_PATH.FirstOrDefault();
            AOB_LR = AoB_Scan_LR.FirstOrDefault();
            AOB_BA = AoB_Scan_BA.FirstOrDefault();
            AOB_ANTIAFK = AoB_Scan_ANTI_AFK.FirstOrDefault();
            //
            SKILLPET_ADR_RESULT = AOB_SKILLPET.ToString("x");
            FASTPET_ADR_RESULT = AOB_FastPET.ToString("x");

            DELAYPOT_ADR_RESULT = AOB_DELAYPOT.ToString("x");
            GETSKILL_LIST_ADR_RESULT = AOB_GETSKILL_LIST.ToString("x");
            string ANTIDELAY_ADR_RESULT = AOB_ANTIDELAY.ToString("x");
            ANTICHAT_ADR_RESULT = AOB_ANTICHAT.ToString("x");
            ANTICB_ADR_RESULT = AOB_ANTICB.ToString("x");
            string ATKBP_ADR_RESULT = AOB_ATKBP.ToString("x");
            NOLIMIT_ADR_RESULT = AOB_NOLIMIT.ToString("x");
            NOLIMIT_ADR_RESULT2 = (AOB_NOLIMIT + 0x34).ToString("x");
            LOCALPLAYER_ADR_RESULT = AOB_LOCALPLAYER.ToString("x");
            ITEMDROP_ADR_RESULT = AOB_ITEMDROP.ToString("x");
            RUN1_ADR_RESULT = AOB_RUN.ToString("x");
            RUN2_ADR_RESULT = (AOB_RUN + 0x83).ToString("x");
            RUN3_ADR_RESULT = (AOB_RUN + 0xEFE).ToString("x");
            RUN4_ADR_RESULT = (AOB_RUN + 0xF07).ToString("x");
            RUN5_ADR_RESULT = (AOB_RUN + 0xF7B).ToString("x");
            RUN6_ADR_RESULT = (AOB_RUN + 0x83).ToString("x");
            GETBUFF_ADR_RESULT = AOB_GETBUFF.ToString("x");
            LONGBUFF_ADR_RESUT = (AOB_LONGBUFF + 0x03).ToString("x");
            ANTISLIDE_ADR_RESULT = (AOB_ANTISLIDE + 0x22).ToString("x");
            MONVIEW_ADR = AOB_MONVIEW.ToString("x");
            ANTIAFK_ADR_RESULT = (AOB_ANTIAFK + 0x02).ToString("x");
            CUTAM_ADR_RESULT = AOB_CUTAM.ToString("x");
            ASPD_ADR_RESULT = (AOB_ASPD + 0x02).ToString("x");
            DRONE_ADR_RESULT = (AOB_DRONE - 0xB).ToString("x");
            HT_ADR_RESULT = AOB_HT.ToString("x");
            WH_ADR_RESULT = AOB_WH.ToString("x");
            SUPERPOT_ADR_RESULT = AOB_Superpot.ToString("x");
            AOE_ADR_RESULT = AOB_AOE.ToString("x");
            LR_ADR_RESULT = AOB_LR.ToString("x");
            BA_ADR_RESULT = AOB_BA.ToString("x");
            PATH_ADR_RESULT = AOB_PATH.ToString("x");
            PATH2_ADR_RESULT = (AOB_PATH + 0x27).ToString("x");
            MessageBox.Show("All Done");
            m.WriteMemory(ASPD_ADR_RESULT, "bytes", "00 A0 FA 00");
            m.WriteMemory(ANTIAFK_ADR_RESULT, "bytes", "12 00 FD 00");
            m.WriteMemory(LONGBUFF_ADR_RESUT, "bytes", "00 66 FF 00");
            m.WriteMemory("00FD0012", "float", "-1");
            m.WriteMemory("00FAA000", "float", "4800");
            m.WriteMemory(ATKBP_ADR_RESULT, "bytes", "90 90");
            m.WriteMemory(ANTIDELAY_ADR_RESULT, "bytes", "E9 94 49 00 00 90");
            LOCALPLAYER_ALLOC();
            Thread.Sleep(1000);
            int num = 20;

            byte[] array = m.ReadBytes(NameAdr, num);
            if (array != null)
            {
                saveID = m.ReadString(IDadr);

                string @string = Encoding.GetEncoding(874).GetString(array);
                label1.Text = @string + " " + comboBox1.Text;
                this.Text = selectedProcessId.ToString() + " " + @string + $"{saveID}";

            }
            Process process = Process.GetProcessById(selectedProcessId);
            IntPtr windowHandle = process.MainWindowHandle;

            // Check if the handle is valid
            if (windowHandle != IntPtr.Zero)
            {

                // Set the window position and size
                int newX = 100; // X coordinate
                int newY = 100; // Y coordinate
                int newWidth = 400; // Window width
                int newHeight = 600; // Window height
                                     // Change the window title
                int style = GetWindowLong(windowHandle, GWL_STYLE);
                SetWindowLong(windowHandle, GWL_STYLE, style | WS_THICKFRAME | WS_VISIBLE);
                bool result = SetWindowPos(windowHandle, IntPtr.Zero, 0, 0, newWidth, newHeight, SWP_NOZORDER | SWP_NOACTIVATE | SWP_NOMOVE | SWP_SHOWWINDOW);

                SetWindowText(windowHandle, this.Text);
            }


            YourCallingMethod();

        }
        public void RunActive()
        {
            m.WriteMemory(RUN1_ADR_RESULT, "bytes", "EB");
            m.WriteMemory(RUN2_ADR_RESULT, "bytes", "90 90 90 90 90 90");
            m.WriteMemory(RUN3_ADR_RESULT, "bytes", "90 90 90 90 90 90");
            m.WriteMemory(RUN4_ADR_RESULT, "bytes", "eb");
            m.WriteMemory(RUN5_ADR_RESULT, "bytes", "90 90");
            m.WriteMemory(PATH2_ADR_RESULT, "bytes", "eb");

        }

        public void RunDeActive()
        {
            m.WriteMemory(RUN1_ADR_RESULT, "bytes", "74");
            m.WriteMemory(RUN2_ADR_RESULT, "bytes", "0F 84 A6 02 00 00");
            m.WriteMemory(RUN3_ADR_RESULT, "bytes", "0F 85 F1 00 00 00");
            m.WriteMemory(RUN4_ADR_RESULT, "bytes", "74");
            m.WriteMemory(RUN5_ADR_RESULT, "bytes", "74 7d");

            //m.WriteMemory(RUN5_ADR_RESULT, "bytes", "0F 85 E5 00 00 00");

        }
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            mem.OpenProcess(int.Parse(comboBox2.Text));
            label2.Text = mem.ReadString(NameAdr);
            selectedProcessId2 = int.Parse(comboBox2.SelectedItem.ToString());

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                //m.WriteMemory(Drone_adr, "float", "8000");
                m.WriteMemory(FastZoom, "float", "150");
                m.WriteMemory(DRONE_ADR_RESULT, "byte", "EB");
            }
            else
            {
                //  m.WriteMemory(Drone_adr, "float", "205");
                m.WriteMemory(FastZoom, "float", "80");
                m.WriteMemory(DRONE_ADR_RESULT, "byte", "75");

            }


        }

        public bool _INJECT_GET_SKILL = false;
        public bool _INJECT_GET_BUFF = false;
        public bool _INJECT_PET = false;
        public int SKILLPET_ADR_GET_SKILL = 0;
        public int SKILLPET_ADR_GET_BUFF = 0;
        //SKILLPET_ADR_GET_BUFF
        public int SKILLPET_ADR_RESULT2 = 0;
        public bool _INJECT_FPET = false;
        public int FASTPET_ADR_RESULT2 = 0;

        public void _Inject_Fpet()
        {
            if (!_INJECT_FPET)
            {
                byte[] freezebytesX = { 0xA1, 0x00, 0x10, 0xFE, 0x00, 0x89, 0x86, 0x60, 0x01, 0x00, 0x00 };
                FASTPET_ADR_RESULT2 = CodeCave.CreateCodeCave(freezebytesX, FASTPET_ADR_RESULT, FASTPET_ADR_RESULT2, 6, 100, m);//Input address to create codecave
            }

        }

        public void INJECT_PET()
        {
            if (!_INJECT_PET)
            {
                byte[] freezebytesX = { 0x66, 0x8B, 0x0D, 0x00, 0xFA, 0xFA, 0x00, 0x66, 0x89, 0x4F, 0x1E, 0x33, 0xD2 };
                SKILLPET_ADR_RESULT2 = CodeCave.CreateCodeCave(freezebytesX, SKILLPET_ADR_RESULT, SKILLPET_ADR_RESULT2, 6, 100, m);//Input address to create codecave
                _INJECT_PET = true;

            }
            else
            {
                _INJECT_PET = false;

            }
        }

        public void INJECT_GET_SKILL()
        {
            if (!_INJECT_GET_SKILL)
            {//A3 00 20 FE 00 8B BC B8 A4 09 00 00
                byte[] freezebytesX = { 0xA3, 0x00, 0x20, 0xFE, 0x00, 0x8B, 0xBC, 0xB8, 0xA4, 0x09, 0x00, 0x00 };
                SKILLPET_ADR_GET_SKILL = CodeCave.CreateCodeCave(freezebytesX, GETSKILL_LIST_ADR_RESULT, SKILLPET_ADR_GET_SKILL, 7, 100, m);//Input address to create codecave
                _INJECT_GET_SKILL = true;

            }
            else
            {
                _INJECT_GET_SKILL = false;

            }
        }
        public void INJECT_GET_BUFF()
        {
            if (!_INJECT_GET_BUFF)
            {
                byte[] freezebytesX = { 0x89, 0x35, 0x00, 0x30, 0xFE, 0x00, 0x8B, 0x16, 0x3B, 0xD5 };
                SKILLPET_ADR_GET_BUFF = CodeCave.CreateCodeCave(freezebytesX, GETBUFF_ADR_RESULT, SKILLPET_ADR_GET_BUFF, 6, 100, m);//Input address to create codecave
                _INJECT_GET_BUFF = true;

            }
            else
            {
                _INJECT_GET_BUFF = false;

            }
        }


        string originalcode_cutam = "D8 4C 24 10 8B CE";
        string originalcode_LR = "D9 5C 24 38 FF 52 10";
        string originalcode_ALE = "D8 5C 24 0C DF E0 F6 C4 05 7A 06 B8";
        string originalcode_Monview = "8B 81 A4 17 00 00";
        string originalcode_Path = "39 5C 24 28 74 23";
        string originalcode_BA = "83 7F 44 01 0F 85 5E 01 00 00 83 7F 5C 09";
        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (textBox2.Text != null && checkBox2.Checked)
            {
                m.WriteMemory("00FF6000", "float", textBox2.Text);
                m.WriteMemory("00FF6600", "int", textBox2.Text);
            }

            IntPtr processHandle = OpenProcess(PROCESS_ALL_ACCESS, false, selectedProcessId);
            Process ProcessbyID = Process.GetProcessById(selectedProcessId);
            if (allocate_adr_aoe == IntPtr.Zero)
            {

                allocate_adr_aoe = VirtualAllocEx(processHandle, IntPtr.Zero, 1000, MEM_COMMIT, PAGE_READWRITE);
            }
            if (checkBox2.Checked)
            {
                textBox2.Enabled = false;
                IntPtr baseModuleadr = ProcessbyID.MainModule.BaseAddress;

                // Assembly code for injecting
                byte[] assemblyCode = new byte[]
                {
                    0xD8,0x25,0x00,0x60,0xFF,0x00,0xD8,0x5C,0x24,0x0C,0xDF,0xE0,// fnstsw ax
                    0xE9, 0x00, 0x00, 0x00, 0x00 // jmp return (to be replaced later)
                };

                // Calculate the jump offset
                int jumpOffset = (int)AOB_AOE + 6 - ((int)allocate_adr_aoe + assemblyCode.Length + 0);
                BitConverter.GetBytes(jumpOffset).CopyTo(assemblyCode, assemblyCode.Length - 4);

                // Write the assembly code to the allocated address
                m.WriteMemory(allocate_adr_aoe.ToString("X"), "bytes", BitConverter.ToString(assemblyCode).Replace('-', ' '));

                // Code for jmp to allocated address with nop
                byte[] jmpCode = new byte[]
                {
                    0xE9, 0x00, 0x00, 0x00, 0x00,
                    0x90
                };

                // Calculate the jump offset
                int jmpOffset2 = (int)allocate_adr_aoe - ((int)AOB_AOE + jmpCode.Length - 1);
                BitConverter.GetBytes(jmpOffset2).CopyTo(jmpCode, 1);

                // Write the second jmp instruction to the specified address
                m.WriteMemory(AOE_ADR_RESULT, "bytes", BitConverter.ToString(jmpCode).Replace('-', ' '));
            }
            else
            {
                textBox2.Enabled = true;
                if (allocate_adr_aoe != IntPtr.Zero)
                {
                    processHandle = OpenProcess(PROCESS_ALL_ACCESS, false, selectedProcessId);
                    VirtualFreeEx(processHandle, allocate_adr_aoe, 0, 0x8000);
                    allocate_adr_aoe = IntPtr.Zero;
                }

                // Write the original code back
                m.WriteMemory(AOE_ADR_RESULT, "bytes", originalcode_ALE);
            }
        }
        private void button15_Click(object sender, EventArgs e)
        {
            int num = 20;

            byte[] array = m.ReadBytes(NameAdr, num);
            if (array != null)
            {
                string @string = Encoding.GetEncoding(874).GetString(array);
                label1.Text = @string + " " + comboBox1.Text;
            }
            YourCallingMethod();
        }


        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            IntPtr processHandle = OpenProcess(PROCESS_ALL_ACCESS, false, selectedProcessId);
            Process ProcessbyID = Process.GetProcessById(selectedProcessId);
            allocate_adr = VirtualAllocEx(processHandle, IntPtr.Zero, 2048, MEM_COMMIT, PAGE_READWRITE);
            if (textBox3.Text != null && checkBox3.Checked)
            {
                m.WriteMemory("00FF1000", "float", textBox3.Text);
            }


            if (checkBox3.Checked)
            {
                textBox3.Enabled = false;
                IntPtr baseModuleadr = ProcessbyID.MainModule.BaseAddress;

                // Assembly code for fstp dword ptr [esp+38]
                byte[] assemblyCode = new byte[]
                {
                    0xD8, 0x25, 0x00, 0x10, 0xFF, 0x00, 0xD9, 0x5C, 0x24, 0x14, 0xFF, 0x52, 0x10,
                    0xE9, 0x00, 0x00, 0x00, 0x00  // jmp 0x00000000 (to be replaced later)
                };
                //004DF357
                // Calculate the jump offset for the first jmp instruction
                int jumpOffset = (int)AOB_LR + 7 - ((int)allocate_adr + assemblyCode.Length + 0);
                BitConverter.GetBytes(jumpOffset).CopyTo(assemblyCode, assemblyCode.Length - 4);

                // Write the initial assembly code to the allocated address
                m.WriteMemory(allocate_adr.ToString("X"), "bytes", BitConverter.ToString(assemblyCode).Replace('-', ' '));

                // Assembly code for jmp to allocate_adr with nop 2
                byte[] jmpCode = new byte[]
                {
                    0xE9, 0x00, 0x00, 0x00, 0x00,
                    0x66, 0x90
                };

                // Calculate the jump offset for the second jmp instruction
                int jmpOffset2 = (int)allocate_adr - ((int)AOB_LR + jmpCode.Length - 2);
                BitConverter.GetBytes(jmpOffset2).CopyTo(jmpCode, 1);  // Offset is from the next instruction (E9), not the beginning

                // Write the second jmp instruction to the specified address (004EBB27)
                m.WriteMemory(LR_ADR_RESULT, "bytes", BitConverter.ToString(jmpCode).Replace('-', ' '));
            }
            else
            {
                m.WriteMemory(LR_ADR_RESULT, "bytes", originalcode_LR);
                textBox3.Enabled = true;
                if (allocate_adr != IntPtr.Zero)
                {
                    processHandle = OpenProcess(PROCESS_ALL_ACCESS, false, selectedProcessId);
                    VirtualFreeEx(processHandle, allocate_adr, 0, 0x8000);
                    allocate_adr = IntPtr.Zero;
                }
            }

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
        }

        private async void backgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            MonsterAlloc();
            List<ListView> listViews = new()
    {
        listView1, listView2, listView3, listView4, listView5,
        listView6, listView7, listView8, listView9, listView10,
        listView13, listView14, listView15,
        listView16, listView17, listView18, listView19, listView20
    };

            while (!backgroundWorker1.CancellationPending)
            {
                try
                {
                    RunActive();
                    foreach (var listView in listViews)
                    {
                        if (listView.Items.Count > 0)
                        {
                            await UpdateListViewItemsAsync(listView);
                            RunActive(); // Ensure it's called for each listView update
                        }
                    }

                    if (backgroundWorker1.CancellationPending)
                    {
                        RunDeActive();
                        break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Exception in UpdateListViewItemsAsync: {ex.Message}");
                }

                await Task.Delay(10);
            }

            // Unfreeze values and reset AltButton
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox4.Checked)
            {
                m.WriteMemory(SUPERPOT_ADR_RESULT, "bytes", "6A 01 52 83 CE FF");
                m.WriteMemory(DELAYPOT_ADR_RESULT, "bytes", "EB");
            }
            else
            {
                m.WriteMemory(SUPERPOT_ADR_RESULT, "bytes", "6A 02 52 83 CE FF");
                m.WriteMemory(DELAYPOT_ADR_RESULT, "bytes", "74");

            }
        }

        public async void Getback()
        {
            if (checkBox35.Checked )
            {
                // เก็บเวลาปัจจุบัน
                DateTime startTime = DateTime.Now;

                m.WriteMemory("02FD3DA2", "byte", "63");
                Thread.Sleep(100);
                m.WriteMemory("02FD3DA2", "byte", "01");
                Thread.Sleep(2000);


                Console.WriteLine($"เริ่มต้นเวลา: {startTime}");

                // แปลงค่าจาก textBox5.Text เป็นจำนวนเต็ม (นาที)
                if (int.TryParse(textBox10.Text, out int minutesToWait))
                {
                    // รอเป็นเวลาจำนวนที่กำหนด (ในหน่วยมิลลิวินาที)
                    await Task.Delay(minutesToWait * 60 * 1000);

                    // แสดงเวลาอีกครั้งหลังจากรอครบ
                    DateTime endTime = DateTime.Now;
                    m.WriteMemory("02FD3DA3", "byte", "63");
                    Thread.Sleep(100);
                    m.WriteMemory("02FD3DA3", "byte", "01");

                    Console.WriteLine($"เวลาปัจจุบันหลังจากผ่านไป {minutesToWait} นาที: {endTime}");
                }
                else
                {
                    // หาก textBox5.Text ไม่ใช่ค่าตัวเลข
                    Console.WriteLine("กรุณาใส่ค่าจำนวนเต็มที่ถูกต้องใน textBox10");
                }
            }
        }

        public int frenzzy_tar;

        private async Task WaitForActionCompletionAsync()
        {
            while (m.ReadInt(MATION_CHECK) != 3)
            {
                int checkStatus = m.ReadInt(MATION_CHECK);
                float skillTime = m.ReadFloat(SKILL_TIME);
                await Task.Delay(100);
                m.WriteMemory(forceattack_adr, "int", "5");
                label6.Text = $"{checkStatus}";
                label6.ForeColor = Color.Green;

                if (checkStatus == 3 && skillTime > 0.1f)
                {
                    await Task.Delay(100);
                    checkStatus = m.ReadInt(MATION_CHECK);
                    skillTime = m.ReadFloat(SKILL_TIME);

                    Console.WriteLine($"USINGSKILL:{checkStatus}");
                    while (checkStatus != 0 && checkStatus != 1)
                    {
                        checkStatus = m.ReadInt(MATION_CHECK);
                        skillTime = m.ReadFloat(SKILL_TIME);

                        await Task.Delay(100);

                        if (checkStatus == 0)
                        {
                                                Console.WriteLine($"Breaking:{checkStatus}");

                            break;
                        }
                        
                    }
                    break;
                }
                await Task.Delay(100);

            }
        }

        private async Task BuffTargetAsync(int targetSkill)
        {
            m.WriteMemory(actioncheck, "int", "0");
            m.WriteMemory(TARGET_SKILL, "int", targetSkill.ToString());
            m.WriteMemory(forceattack_adr, "int", "5");

            // Wait until the action completes
            while (m.ReadInt(MATION_CHECK) == 3)
            {
                Console.WriteLine("Buffering");
                await Task.Delay(1000);
            }

            m.WriteMemory(forceattack_adr, "int", "9");
        }

        private async Task Autobuff()
        {
            label6.Text = "Buffing";
            label6.ForeColor = Color.Green;
            await Task.Delay(1);

            List<int> buffList = new List<int>();
            List<int> remainingBuffList = new List<int>();

            // Clear buffList if it reaches size 5
            if (buffList.Count == 5)
            {
                buffList.Clear();
            }

            // Scan through buffer items
            for (int j = -0xB00; j <= 0x0; j += 0xB0)
            {
                if (m.Read2Byte($"00FE3000,{j.ToString("x")}") == 65535)
                {
                    continue;
                }

                string offsetBuff = j.ToString("x");
                int num4 = j + 0x02;
                int skillRemain = j + 0x8;
                int item = m.Read2Byte($"00FE3000,{offsetBuff}");
                int item2 = m.Read2Byte($"00FE3000,{num4.ToString("x")}");
                float item3 = m.ReadFloat($"00FE3000,{skillRemain.ToString("x")}");

                if (item3 <= 50f && !remainingBuffList.Contains(item2))
                {
                    remainingBuffList.Add(item2);
                }

                if (!buffList.Contains(item2))
                {
                    buffList.Add(item2);
                }
            }

            // Process skills in the specified range
            for (int k = 0xA1C; k <= 0xA40; k += 0x04)
            {
                int checkStatus = m.Read2Byte(MATION_CHECK);
                float skillTime = m.ReadFloat(SKILL_TIME);
                Console.WriteLine($"USINGSKILL: {checkStatus}, F{skillTime}");

                if (m.Read2Byte($"00FE2000,{k.ToString("x")}") == 65535)
                {
                    continue;
                }

                int num5 = k + 0x02;
                int num6 = m.Read2Byte($"00FE2000,{k.ToString("x")}");
                int num7 = m.Read2Byte($"00FE2000,{num5.ToString("x")}");

                while (checkStatus != 3 && checkStatus == 0)
                {
                    label6.Text = $"{checkStatus}";
                    label6.ForeColor = Color.Green;

                    m.WriteMemory(forceattack_adr, "int", "5");
                    await Task.Delay(1500);
                    checkStatus = m.Read2Byte(MATION_CHECK);
                    skillTime = m.ReadFloat(SKILL_TIME);
                    Console.WriteLine($"WHILE1: {checkStatus}, F{skillTime}");
                    m.WriteMemory(forceattack_adr, "int", "5");

                    if (checkStatus == 3 && skillTime > 2f)
                    {
                        checkStatus = m.Read2Byte(MATION_CHECK);
                        skillTime = m.ReadFloat(SKILL_TIME);
                        await Task.Delay(1500);

                        Console.WriteLine($"USINGSKILLxxxxx:{checkStatus}");
                        while (checkStatus != 0 && checkStatus != 1)
                        {
                            checkStatus = m.Read2Byte(MATION_CHECK);
                            skillTime = m.ReadFloat(SKILL_TIME);

                            await Task.Delay(100);

                            if (checkStatus == 0)
                            {
                                Console.WriteLine($"Breaking:{checkStatus}");

                                break;
                            }
                        }
                        
                    }
                    break;

                    await Task.Delay(100);

                }


                // Handle skill if it's not already in the list
                //if (!buffList.Contains(num7))
                //{
                //    m.WriteMemory(prevskill1_adr, "byte", num6.ToString("x"));
                //    m.WriteMemory(prevskill2_adr, "byte", num7.ToString("x"));
                //    m.Read2Byte(k.ToString("x"));
                //    m.Read2Byte(num5.ToString("x"));

                //    await WaitForActionCompletionAsync();

                //    Process frenzy targets if available
                //    if (frenzzy_tarList.Count > 0)
                //        {
                //            foreach (int frenzzyTar in frenzzy_tarList)
                //            {
                //                Console.WriteLine($"Buffering To {frenzzyTar}");

                //                if (frenzzyTar != -1)
                //                {
                //                    await BuffTargetAsync(frenzzyTar);
                //                }
                //            }
                //        }
                //}

                // Remove the skill from the list if it's already there
                if (buffList.Contains(num7))
                {
                    buffList.Remove(num7);
                }
            }
        }
        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox5.Checked)
            {
                m.FreezeValue(HpFreeze_1, "2bytes", "999");
                m.FreezeValue(HpFreeze_2, "2bytes", "65535");
            }
            else
            {
                m.UnfreezeValue(HpFreeze_1);
                m.UnfreezeValue(HpFreeze_2);
            }
        }
        public string getadr = "";
        public byte[] jmpCodemy = new byte[]
{
                    0xE9, 0x00, 0x00, 0x00, 0x00,
                    0x90
};

        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {
            // C7 44 24 1C 00 00 30 C1 C7 44 24 20 00 00 30 C1 C7 44 24 24 00 00 30 C1 39 5C 24 28

            if (checkBox6.Checked)
            {
                IntPtr processHandle = OpenProcess(PROCESS_ALL_ACCESS, false, selectedProcessId);
                Process ProcessbyID = Process.GetProcessById(selectedProcessId);
                allocate_adr_Path = VirtualAllocEx(processHandle, IntPtr.Zero, 2048, MEM_COMMIT, PAGE_READWRITE);
                getadr = allocate_adr_Path.ToString("x");

                IntPtr baseModuleadr = ProcessbyID.MainModule.BaseAddress;

                // Assembly code for fstp dword ptr [esp+38]
                byte[] assemblyCode = new byte[]
                {
                    0xC7 ,0x44 ,0x24 ,0x10 ,0x00 ,0x00 ,0x30 ,0xC1 ,
                    0xC7 ,0x44 ,0x24 ,0x14 ,0x00 ,0x00 ,0x30 ,0xC1 ,
                    0xC7 ,0x44 ,0x24 ,0x18 ,0x00 ,0x00 ,0x30 ,0xC1 ,
                    0x39 ,0x5C ,0x24 ,0x28 ,0x90 ,0x90,
                    0xE9, 0x1A, 0x00, 0x00, 0x00 // 
                };

                // Calculate the jump offsets for the je and jmp instructions
                int jumpOffset2 = (int)AOB_PATH + 0x38 - ((int)allocate_adr_Path + assemblyCode.Length + 0); // - 6

                // Replace the jump offsets in the assembly code
                BitConverter.GetBytes(jumpOffset2).CopyTo(assemblyCode, assemblyCode.Length - 4);
                // Write the initial assembly code to the allocated address
                m.WriteMemory(allocate_adr_Path.ToString("X"), "bytes", BitConverter.ToString(assemblyCode).Replace('-', ' '));

                // Assembly code for jmp to allocate_adr with nop 2
                jmpCodemy = new byte[]
                {
                    0xE9, 0x00, 0x00, 0x00, 0x00,
                    0x90
                };

                // Calculate the jump offset for the second jmp instruction
                int jmpOffset2 = (int)allocate_adr_Path - ((int)AOB_PATH + jmpCodemy.Length - 1);
                BitConverter.GetBytes(jmpOffset2).CopyTo(jmpCodemy, 1);  // Offset is from the next instruction (E9), not the beginning

                m.WriteMemory(PATH_ADR_RESULT, "bytes", BitConverter.ToString(jmpCodemy).Replace('-', ' '));
            }
            else
            {
                if (allocate_adr_Path != IntPtr.Zero)
                {
                    IntPtr processHandle = OpenProcess(PROCESS_ALL_ACCESS, false, selectedProcessId);
                    VirtualFreeEx(processHandle, allocate_adr_Path, 0, 0x8000);
                    allocate_adr_Path = IntPtr.Zero;
                }

                // Restore the original code
                m.WriteMemory(PATH_ADR_RESULT, "bytes", originalcode_Path);

            }

        }

        private void checkBox7_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox7.Checked)
            {

                followLeaderCancellationTokenSource = new CancellationTokenSource();
                Task.Run((Func<Task>)FollowLeaderTask);
            }
            else
            {
                followLeaderCancellationTokenSource?.Cancel();
            }

        }
        private CancellationTokenSource followLeaderCancellationTokenSource;
        private CancellationTokenSource AutosearchCancellationTokenSource;
        private async Task FollowLeaderTask()
        {
            Random rand = new Random();
            float previousX = float.MinValue;
            float previousZ = float.MinValue;

            while (!followLeaderCancellationTokenSource.Token.IsCancellationRequested)
            {
                // Read current coordinates and other necessary values once at the start of the loop
                float currentX = mem.ReadFloat(CurrentX);
                float currentY = mem.ReadFloat(CurrentY);
                float currentZ = mem.ReadFloat(CurrentZ);
                int mainSK1 = mem.Read2Byte(prevskill1_adr);
                int mainSK2 = mem.Read2Byte(prevskill2_adr);
                int target = mem.ReadInt(TARGET_RING);
                int mationCheck = mem.ReadInt(MATION_CHECK);
                int actiontarget = mem.ReadInt(actioncheck);

                // Calculate new follow positions
                float followXnew = currentX + ((float)rand.NextDouble() - 0.5f) * 2.0f * 0.1f;
                float followZnew = currentZ + ((float)rand.NextDouble() - 0.5f) * 2.0f * 0.1f;

                // Check conditions to follow
                if (mationCheck == 1 && mationCheck != 3)
                {
                    // Only write memory if position has changed
                    if (followXnew != previousX || followZnew != previousZ)
                    {
                        m.WriteMemory(getadr + "+4", "float", followXnew.ToString());
                        m.WriteMemory(getadr + "+C", "float", currentY.ToString());
                        m.WriteMemory(getadr + "+14", "float", followZnew.ToString());

                        RunActive();
                        previousX = followXnew;
                        previousZ = followZnew;

                        await Task.Delay(10); // Small delay for smoother movement
                        RunDeActive();

                        // Handle spacebar action
                        if (mem.ReadByte(Spacebar) != 1)
                        {
                            m.WriteMemory(Spacebar, "byte", "63");
                            await Task.Delay(10);
                            m.WriteMemory(Spacebar, "byte", "01");
                        }
                    }

                    await Task.Delay(10); // Wait before the next iteration
                }
                else if (checkBox8.Checked && mationCheck != 1)
                {
                    mainSK1 = mem.ReadByte(prevskill1_adr);
                    mainSK2 = mem.ReadByte(prevskill2_adr);
                    target = mem.ReadInt(TARGET_RING);

                    if (mationCheck == 3)
                    {
                        if (mainSK2 == 9)
                        {
                            await Task.Delay(1500); // Simulate delay for special condition
                        }

                        m.WriteMemory(TARGET_SKILL, "int", target.ToString());
                        m.WriteMemory(actioncheck, "int", actiontarget.ToString());
                        m.WriteMemory(prevskill1_adr, "byte", mainSK1.ToString("x"));
                        m.WriteMemory(prevskill2_adr, "byte", mainSK2.ToString("x"));
                        m.WriteMemory(forceattack_adr, "int", "5");

                        await Task.Delay(10); // Wait before the next iteration
                    }

                    // Store current position for the next iteration
                    previousX = currentX;
                    previousZ = currentZ;
                }

                // Perform any cleanup or final actions outside the loop
                await Task.Delay(10);
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            currentrange = m.ReadFloat(AngleAdr);
            currentrange2 = m.ReadFloat(ZoomAdr);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            comboBox2.Items.Clear();

            Process[] processesByName = Process.GetProcessesByName("minia");
            foreach (Process process in processesByName)
            {
                comboBox2.Items.Add(process.Id);

            }

        }

        private void checkBox10_CheckedChanged(object sender, EventArgs e)
        {
            IntPtr processHandle = OpenProcess(PROCESS_ALL_ACCESS, false, selectedProcessId);
            Process ProcessbyID = Process.GetProcessById(selectedProcessId);
            allocate_adr_Monview = VirtualAllocEx(processHandle, IntPtr.Zero, 2048, MEM_COMMIT, PAGE_READWRITE);
            if (checkBox10.Checked)
            {
                IntPtr baseModuleadr = ProcessbyID.MainModule.BaseAddress;

                // Assembly code for fstp dword ptr [esp+38]
                byte[] assemblyCode = new byte[]
                {
                    0x89,0x0D,0x00,0x50,0xFF,0x00,0x8B,0x81,0x18,0x0C,0x00,0x00,0xE9,
                    0x00, 0x00, 0x00, 0x00  // jmp 0x00000000 (to be replaced later)
                };

                // Calculate the jump offset for the first jmp instruction
                int jumpOffset = (int)baseModuleadr + 0xA2B76 - ((int)allocate_adr_Monview + assemblyCode.Length + 0);
                BitConverter.GetBytes(jumpOffset).CopyTo(assemblyCode, assemblyCode.Length - 4);

                // Write the initial assembly code to the allocated address
                m.WriteMemory(allocate_adr_Monview.ToString("X"), "bytes", BitConverter.ToString(assemblyCode).Replace('-', ' '));

                // Assembly code for jmp to allocate_   adr with nop 2
                byte[] jmpCode = new byte[]
                {
                    0xE9, 0x00, 0x00, 0x00, 0x00,
                    0x90
                };

                // Calculate the jump offset for the second jmp instruction
                int jmpOffset2 = (int)allocate_adr_Monview - ((int)baseModuleadr + 0xA2B70 + jmpCode.Length - 1);
                BitConverter.GetBytes(jmpOffset2).CopyTo(jmpCode, 1);  // Offset is from the next instruction (E9), not the beginning

                // Write the second jmp instruction to the specified address (004EBB27)
                m.WriteMemory(MONVIEW_ADR, "bytes", BitConverter.ToString(jmpCode).Replace('-', ' '));

            }
            else
            {
                m.WriteMemory(MONVIEW_ADR, "bytes", originalcode_Monview);
                if (allocate_adr_Monview != IntPtr.Zero)
                {
                    processHandle = OpenProcess(PROCESS_ALL_ACCESS, false, selectedProcessId);
                    VirtualFreeEx(processHandle, allocate_adr_Monview, 0, 0x8000);
                    allocate_adr_Monview = IntPtr.Zero;
                }
            }

        }
        private System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();



        private int previousCount = 0;
        private DateTime lastUpdate = DateTime.MinValue;
        private bool Position = false;
        private void UpdateListView(List<int> check_id_mon, int id_mon, int hp_mon, float x_mon, float y_mon, float z_mon)
        {
            if (check_id_mon.Count == 8)
            {
                check_id_mon.Clear();
                listView11.Items.Clear();
            }
            if (DateTime.Now.Subtract(lastUpdate).TotalSeconds >= 6 && previousCount == check_id_mon.Count - 1)
            {
                if (!Position)
                {
                    UpdatePosition(GetX1, GetY1, GetZ1);
                    Position = !Position;
                }
                else
                {
                    UpdatePosition(GetX2, GetY2, GetZ2);
                    Position = !Position;

                }
            }

            previousCount = check_id_mon.Count;
            lastUpdate = DateTime.Now;

            int hptoadds;
            if (!check_id_mon.Contains(id_mon) && int.TryParse(textBox5.Text, out hptoadds) && hptoadds == hp_mon)
            {
                check_id_mon.Add(id_mon);

                ListViewItem item = new ListViewItem(id_mon.ToString());
                item.SubItems.Add(hp_mon.ToString());
                item.SubItems.Add(x_mon.ToString());
                item.SubItems.Add(y_mon.ToString());
                item.SubItems.Add(z_mon.ToString());
                listView11.Items.Add(item);

                // Check if the list has been updated within the last 10 seconds
            }
            else
            {
                // Show error message if item could not be added
                //  MessageBox.Show("Error: Unable to add item to check_id_mon.");
            }
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            // Show message box if the list is not updated within 10 seconds
        }

        private async void SearchAndPrintTargets(int id_mon, int hp_mon, float x_mon, float y_mon, float z_mon, int[] valuesToWrite)
        {
            int current_target = m.ReadInt("MiniA.exe+7E02DC");
            int Hpcheckmon;

            if (int.TryParse(textBox5.Text, out Hpcheckmon) && hp_mon == Hpcheckmon)
            {
                float currentX_ = m.ReadFloat(CurrentX);
                float currentZ_ = m.ReadFloat(CurrentZ);

                // Calculate the distance
                float distance = CalculateDistance(currentX_, currentZ_, x_mon, z_mon);

                if (Hpcheckmon == hp_mon && distance > 1f)
                {
                    UpdateCurrentTarget(id_mon);
                    PerformActionsForTarget();
                    Autobuff();
                    await Task.Delay(10);
                }



            }
        }

        private void UpdateCurrentTarget(int newTargetId)
        {
            m.WriteMemory("MiniA.exe+869250", "int", newTargetId.ToString());
            m.WriteMemory("MiniA.exe+7E02DC", "int", newTargetId.ToString());
            m.WriteMemory("MiniA.exe+7DF538", "int", newTargetId.ToString());
        }

        private void PerformActionsForTarget()
        {
            int current_target = m.ReadInt("MiniA.exe+7DF2DC");

            if (current_target > -1)
            {

                for (int i = 0x00BDD7F4; i <= 0x00BDD810; i += 4)
                {
                    int idskilltype1 = m.ReadByte(i.ToString("X"));
                    int num = i + 2;
                    int idskilltype2 = m.ReadByte(num.ToString("X"));
                    int prevskill2 = m.ReadByte(prevskill2_adr);
                    Thread.Sleep(200);
                    if (m.Read2Byte(MATION_CHECK) != 3)
                    {
                        m.WriteMemory(prevskill1_adr, "byte", idskilltype1.ToString("x"));
                        m.WriteMemory(prevskill2_adr, "byte", idskilltype2.ToString("x"));
                        m.WriteMemory(forceattack_adr, "int", "5");
                        Thread.Sleep(100);
                    }
                }
                Thread.Sleep(100);

            }
        }
        List<int> SkillID = new List<int>();

        private void GetSkillID()
        {
            for (int i = 0x00BDF804; i <= 0x00BDF828; i += 4)
            {
                int idskilltype1 = m.ReadByte(i.ToString("X"));
                int num = i + 2;
                int idskilltype2 = m.ReadByte(num.ToString("X"));
                int prevskill2 = m.ReadByte(prevskill2_adr);
                if (idskilltype1 == 65535)
                {
                    continue;
                }
                if (idskilltype2 == 65535)
                {
                    continue;
                }
                SkillID.Add(i);
                SkillID.Add(num);
            }
        }
        private void UpdatePositionAndPerformActions(float distance, float currentX_, float currentZ_)
        {
            if (CurrentPos && IsPositionInRange(currentX_, GetX1, currentZ_, GetZ1))
            {
                UpdatePosition(GetX1, GetY1, GetZ1);

            }
            else if (!CurrentPos && IsPositionInRange(currentX_, GetX2, currentZ_, GetZ2))
            {
                UpdatePosition(GetX2, GetY2, GetZ2);
            }
        }

        private bool IsPositionInRange(float currentX, float targetX, float currentZ, float targetZ)
        {
            return Math.Abs(currentX - targetX) <= 20f && Math.Abs(currentZ - targetZ) <= 20f;
        }

        private void UpdatePosition(float x, float y, float z)
        {
            m.WriteMemory(PATH_ADR_RESULT, "bytes", BitConverter.ToString(jmpCodemy).Replace('-', ' '));
            m.WriteMemory(getadr + "+4", "float", x.ToString());
            m.WriteMemory(getadr + "+C", "float", y.ToString());
            m.WriteMemory(getadr + "+14", "float", z.ToString());
            m.WriteMemory(LeftClick, "int", "63");
            Thread.Sleep(10);
            m.WriteMemory(LeftClick, "int", "01");
            Thread.Sleep(100);
            m.WriteMemory(PATH_ADR_RESULT, "bytes", originalcode_Path);

        }

        private float CalculateDistance(float x1, float z1, float x2, float z2)
        {
            // Simple distance calculation for demonstration purposes
            return (float)Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(z2 - z1, 2));
        }



        private void checkBox9_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void button4_Click(object sender, EventArgs e)
        {
            GetX1 = m.ReadFloat(CurrentX);
            GetY1 = m.ReadFloat(CurrentY);
            GetZ1 = m.ReadFloat(CurrentZ);
            MessageBox.Show($"{GetX1},{GetY1},{GetZ1}");
        }
        private void button5_Click(object sender, EventArgs e)
        {
            GetX2 = m.ReadFloat(CurrentX);
            GetY2 = m.ReadFloat(CurrentY);
            GetZ2 = m.ReadFloat(CurrentZ);
            MessageBox.Show($"{GetX2},{GetY2},{GetZ2}");
        }

        private void checkBox11_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox11.Checked)
            {
                m.WriteMemory(HT_ADR_RESULT, "bytes", "E9 E3 02 00 00 90");
                //   m.WriteMemory(HT2_ADR_RESULT, "bytes", "E9 FA 02 00 00 90");
                //   m.WriteMemory(HT3_ADR_RESULT, "bytes", "E9 EE 02 00 00 90");
                //0F 84 ED 02 00 00
            }
            else
            {
                m.WriteMemory(HT_ADR_RESULT, "bytes", "0F 84 E2 02 00 00");
                //  m.WriteMemory(HT2_ADR_RESULT, "bytes", "0F 84 F9 02 00 00");
                //       m.WriteMemory(HT3_ADR_RESULT, "bytes", "0F 84 ED 02 00 00");

            }
        }

        private void checkBox12_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox12.Checked)
            {
                m.WriteMemory(WH_ADR_RESULT, "bytes", "EB");
            }
            else
            {
                m.WriteMemory(WH_ADR_RESULT, "bytes", "74 23 8B 4C 24 30 51");
            }
        }

        private async void button8_Click(object sender, EventArgs e)
        {
            autoAddItems = !autoAddItems;
            if (autoAddItems)
            {
                await AddItemsAutomaticallyAsync();
            }
        }
        private Dictionary<string, ListView> listViewDictionary = new Dictionary<string, ListView>();
        private int positionCounter = 1;
        private async Task AddItemsAutomaticallyAsync()
        {
            float previousX = float.MinValue;
            float previousY = float.MinValue;
            float previousZ = float.MinValue;
            while (autoAddItems)
            {
                if (comboBox3.SelectedItem == null)
                {
                    continue;
                }
                string key = comboBox3.SelectedItem.ToString();
                if (!listViewDictionary.TryGetValue(key, out var selectedListView))
                {
                    continue;
                }
                float num = m.ReadFloat(gotoX);
                float num2 = m.ReadFloat(gotoY);
                float num3 = m.ReadFloat(gotoZ);
                if (num != previousX || num2 != previousY || num3 != previousZ)
                {
                    ListViewItem location = new ListViewItem($"Position {positionCounter++}");
                    location.SubItems.Add(num.ToString());
                    location.SubItems.Add(num2.ToString());
                    location.SubItems.Add(num3.ToString());
                    selectedListView.Invoke((MethodInvoker)delegate
                    {
                        selectedListView.Items.Add(location);
                    });
                    previousX = num;
                    previousY = num2;
                    previousZ = num3;
                }
                await Task.Delay(1);
            }
        }
        private void SaveListViewToJSON(ListView listView, string fileName)
        {
            List<LocationData> list = new List<LocationData>();
            foreach (ListViewItem item2 in listView.Items)
            {
                LocationData item = new LocationData
                {
                    Position = item2.SubItems[0].Text,
                    X = item2.SubItems[1].Text,
                    Y = item2.SubItems[2].Text,
                    Z = item2.SubItems[3].Text
                };
                list.Add(item);
            }
            string contents = JsonConvert.SerializeObject(list);
            File.WriteAllText(fileName, contents);
        }


        private void SaveListView12ToJSON(ListView listView12, string fileName)
        {
            List<ITEM_COLLECT> list = new List<ITEM_COLLECT>();
            foreach (ListViewItem item in listView12.Items)
            {
                ITEM_COLLECT dataItem = new ITEM_COLLECT
                {
                    SubItem2 = item.SubItems[2].Text // Save only SubItems[2]
                };
                list.Add(dataItem);
            }
            string contents = JsonConvert.SerializeObject(list, Formatting.Indented);
            File.WriteAllText(fileName, contents);
        }
        private void StopMonitoringPlayer()
        {
            BTN_START.Enabled = true;
            BTN_STOP.Enabled = false;
            monitoringCtsPlayer?.Cancel();
        }

        private void BrowseButton_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog())
            {
                folderBrowserDialog.Description = "Select a folder containing JSON files";
                folderBrowserDialog.RootFolder = Environment.SpecialFolder.MyComputer;
                if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                {
                    selectedFilePath = folderBrowserDialog.SelectedPath;
                    selectedPathTextBox.Text = selectedFilePath;
                }
            }
        }

        private CancellationTokenSource monitoringCts;
        private CancellationTokenSource monitoringCtsPlayer;

        private async Task StartMonitoringMonstersAsync()
        {
            monitoringCts = new CancellationTokenSource();
            try
            {
                while (!monitoringCts.Token.IsCancellationRequested)
                {
                    //   label2.Text = MonDistance.ToString();
                    await GetMonstersAsync();
                    await Task.Delay(100); // Adjust the delay as needed
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in StartMonitoringMonsters: {ex.Message}");
                // StopMonitoringMonsters(); // Ensure stopping on exception
            }
        }
        private async Task StartMonitoringPlayerAsync()
        {
            monitoringCtsPlayer = new CancellationTokenSource();
            try
            {
                while (!monitoringCtsPlayer.Token.IsCancellationRequested)
                {
                    //   label2.Text = MonDistance.ToString();
                    await GetPlayerAsync();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in StartMonitoringMonsters: {ex.Message}");
                StopMonitoringMonsters(); // Ensure stopping on exception
            }
        }


        private void StopMonitoringMonsters()
        {
            monitoringCts?.Cancel();
        }
        public uint MonsterID_FromGetMonster = 0;
        public uint MonsterHP_FromGetMonster = 0;
        public float distance_FromGetMonster = 0;
        public float X_fromGetMonster = 0;
        public float Y_fromGetMonster = 0;
        public float Z_fromGetMonster = 0;
        public UIntPtr mob_HP;
        public UIntPtr closestMonsterHP_ADR;
        [DllImport("user32.dll")]
        private static extern short GetAsyncKeyState(Keys vKey);

        private static bool IsKeyPressed(Keys key)
        {
            return (GetAsyncKeyState(key) & 0x8000) != 0;
        }

        public string GMFOUND = "";

        private async Task GetPlayerAsync()
        {
            bool FoundGm = false;
            bool ResNOW = false;
            bool Attacknow = false;
            int GETPlAYERID = 0; // Closest Player ID
            int SendID = 0; // ID to send for targeting
            int SendRES = 0; // ID to send for targeting
            int Res_Player = 0;
            int globalCrow = int.MaxValue;
            try
            {
                string Guild = "";
                string NAMEGET = "";
                globalCrow = m.ReadInt("MiniA.exe+7963E0,D6E4");
                UIntPtr curr = m.GetCode("MiniA.exe+7963E0,D6E8");

                float closestDistance = float.MaxValue;
                float closestDistancePlayer = float.MaxValue;
                for (int i = 0; i < globalCrow; i++)
                {
                    UIntPtr data = m.GetCode($"{curr:X},0");
                    var mobDetails = await ReadPlayerDetailsAsync(data);
                    UIntPtr PlayerID = m.GetCode($"{data:X},28C");

                    // Read Guild and Player Name
                    UIntPtr PlayerGUILD = m.GetCode($"{data:X},22C");
                    UIntPtr PlayerNAMEGET = m.GetCode($"{data:X},1E0");

                    int num = 30;
                    byte[] guildArray = m.ReadBytes(PlayerGUILD.ToString("x"), num);
                    if (guildArray != null)
                    {
                        Guild = Encoding.GetEncoding(874).GetString(guildArray).TrimEnd('\0');
                    }

                    byte[] nameArray = m.ReadBytes(PlayerNAMEGET.ToString("x"), num);
                    if (nameArray != null)
                    {
                        NAMEGET = Encoding.GetEncoding(874).GetString(nameArray).TrimEnd('\0');
                        if (!IsItemAlreadyInList2(NAMEGET))
                        {
                            string[] row = { NAMEGET, NAMEGET, NAMEGET };
                            listView11.Items.Add(new ListViewItem(row));
                        }
                    }

                    float distance_mon = CalculateDistance(mobDetails.X, mobDetails.Y, mobDetails.Z);
                    if (distance_mon <= MonDistance &&
                        distance_mon < closestDistance &&
                        !Guild.Contains(Guildselected) &&
                        !IsNameInListView12(NAMEGET) && mobDetails.HP > 50)

                    {
                        closestDistance = distance_mon;
                        GETPlAYERID = mobDetails.ID;
                    }

                    if (distance_mon <= MonDistance && distance_mon < closestDistancePlayer && Guild.Contains(Guildselected) && mobDetails.HP < 50)
                    {
                        closestDistancePlayer = distance_mon;
                        Res_Player = mobDetails.ID;

                    }
                    if (IsNameInListView12_GM(NAMEGET) && FoundGm == false && checkBox35.Checked)
                    {
                        try
                        {
                            Getback();
                        }
                        catch(Exception ex)
                        {

                        }
                    }
                    if (IsNameInListView12_GM(NAMEGET) && FoundGm == false && checkBox37.Checked)
                    {
                        try
                        {

                            Console.WriteLine($"ชื่อ {NAMEGET} \n Playeraddress: {PlayerID} \n");
                            GMFOUND = NAMEGET;
                            GMAlert();
                            if (checkBox36.Checked)
                            {
                                Process processToTerminate = Process.GetProcessById(selectedProcessId);
                                processToTerminate.Kill();
                                processToTerminate.WaitForExit(); // Optional: Waits for the process to exit
                                MessageBox.Show($"Process with PID {selectedProcessId} terminated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            }
                            FoundGm = true;
                            StopMonitoringPlayer();


                        }
                        catch (Exception ex)
                        {
                        }
                    }

                    if (IsNameInListView12_GM(NAMEGET) && checkBox36.Checked)
                    {
                        try
                        {
                            Process processToTerminate = Process.GetProcessById(selectedProcessId);
                            processToTerminate.Kill();
                            processToTerminate.WaitForExit(); // Optional: Waits for the process to exit
                            MessageBox.Show($"Process with PID {selectedProcessId} terminated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            StopMonitoringPlayer();
                            break;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Failed to terminate process with PID {selectedProcessId}. Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                        }
                    }


                    curr = m.GetCode($"{curr:X},8");
                }

                // Assign the closest player ID if found
                if (closestDistance <= MonDistance)
                {
                    SendID = GETPlAYERID;
                }
                if (closestDistancePlayer <= MonDistance && Guild.Contains(Guildselected))
                {
                    SendRES = Res_Player;
                }
                if (IsKeyPressed(Keys.Z) && checkBox38.Checked)
                {
                    ResNOW = true;
                }
                else
                {
                    ResNOW = false;
                }

                if (ResNOW && SendRES != 0)
                {
                    m.WriteMemory($"{TARGET_RING_CHECK}", "int", "0");
                    m.WriteMemory($"{TARGET_RING}", "int", SendRES.ToString());
                    m.WriteMemory($"{TARGET_SKILL}", "int", SendRES.ToString());
                    m.WriteMemory(actioncheck, "int", "0");
                    m.WriteMemory(prevskill1_adr, "byte", "E");
                    m.WriteMemory(prevskill2_adr, "byte", "F");
                    m.WriteMemory(forceattack_adr, "int", "5");
                    Task.Delay(1);

                }



                if (IsKeyPressed(Keys.X) && checkBox38.Checked)
                {

                    Attacknow = true;

                }
                else
                {
                    Attacknow = false;
                }
                if (Attacknow && SendID != 0)
                {

                    for (int i3 = 0x9A4; i3 <= 0x9C8; i3 += 4)
                    {
                        if (!Attacknow && SendID == 0)
                        {
                            break;
                        }
                        label2.Text = Guild;
                        int RUN = m.Read2Byte(MATION_CHECK);

                        int idskilltype_test1 = m.ReadByte($"00FE2000,{i3:x}");
                        int idskilltype_test2 = m.ReadByte($"00FE2000,{(i3 + 0x02):x}");

                        if (idskilltype_test1 != 255 && idskilltype_test2 != 255)
                        {
                            m.WriteMemory($"{TARGET_RING_CHECK}", "int", "0");
                            m.WriteMemory($"{TARGET_RING}", "int", SendID.ToString());
                            m.WriteMemory($"{TARGET_SKILL}", "int", SendID.ToString());
                            PerformSkillPlayer(idskilltype_test1, idskilltype_test2);
                            if (RUN == 1 && checkBox40.Checked)
                            {
                                m.WriteMemory(MATION_CHECK, "int", "3");
                            }

                            Console.WriteLine($"{RUN}");
                        }

                        await Task.Delay(1);
                    }

                }
                await Task.Delay(10);
            }


            catch (Exception ex)
            {
                Console.WriteLine($"Error in GetPlayerAsync: {ex.Message}");
            }
        }
        private bool IsNameInListView12_GM(string name)
        {
            // Iterate through each item in listView12
            foreach (ListViewItem item in listView12.Items)
            {
                if (name.Contains(item.SubItems[2].Text))
                {
                    Console.WriteLine(name);

                    return true;
                }
            }
            return false;
        }

        private bool IsNameInListView12(string name)
        {
            foreach (ListViewItem item in listView12.Items)
            {
                // Check the item's main text
                if (item.Text.Contains(name))
                {
                    return true;
                }

                // Check all subitems
                foreach (ListViewItem.ListViewSubItem subItem in item.SubItems)
                {
                    if (subItem.Text.Contains(name))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private async Task<(float X, float Y, float Z, int ID, int HP)> ReadPlayerDetailsAsync(UIntPtr data)
        {
            try
            {

                UIntPtr mob_X = m.GetCode($"{data:X},10");
                UIntPtr mob_Y = m.GetCode($"{data:X},14");
                UIntPtr mob_Z = m.GetCode($"{data:X},18");
                UIntPtr PlayerID = m.GetCode($"{data:X},28C");
                UIntPtr PlayerHP = m.GetCode($"{data:X},284");
                float Player_X = await Task.Run(() => m.ReadFloat(mob_X.ToString("x")));
                float Player_Y = await Task.Run(() => m.ReadFloat(mob_Y.ToString("x")));
                float Player_Z = await Task.Run(() => m.ReadFloat(mob_Z.ToString("x")));
                int Player_ID = await Task.Run(() => m.ReadInt(PlayerID.ToString("x")));
                int Player_HP = await Task.Run(() => m.ReadInt(PlayerHP.ToString("x")));

                return (Player_X, Player_Y, Player_Z, Player_ID, Player_HP);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading monster details: {ex.Message}");

                return (0, 0, 0, 0, 0);
            }
        }
        private async Task HandleKeyLogicAsync(float myX, float myY, float myZ, int playerID)
        {
            for (int i3 = 0x9A4; i3 <= 0x9C8; i3 += 4)
            {
                if (!IsKeyPressed(Keys.X)) break;

                int runState = m.Read2Byte(MATION_CHECK);
                if (runState == 1)
                {
                    m.WriteMemory(MATION_CHECK, "int", "3");
                }

                int idskilltype_test1 = m.ReadByte($"00FE2000,{i3:x}");
                int idskilltype_test2 = m.ReadByte($"00FE2000,{(i3 + 0x02):x}");

                if (idskilltype_test1 != 255 && idskilltype_test2 != 255)
                {
                    // Write player's position
                    m.WriteMemory($"{TARGET_RING}", "int", playerID.ToString());
                    m.WriteMemory($"{TARGET_SKILL}", "int", playerID.ToString());
                    m.WriteMemory($"{CurrentX}", "float", myX.ToString());
                    m.WriteMemory($"{CurrentY}", "float", myY.ToString());
                    m.WriteMemory($"{CurrentZ}", "float", myZ.ToString());

                    PerformSkillPlayer(idskilltype_test1, idskilltype_test2);

                    // Check and break if MATION_CHECK is not 3
                    if (m.ReadInt(MATION_CHECK) != 3)
                    {
                        break;
                    }
                }

                // Task.Delay(10); // Small delay to avoid excessive CPU usage
            }
        }
        private void buttonOpenRadar_Click(object sender, EventArgs e)
        {
        }

        private async Task GetMonstersAsync()
        {
            try
            {
                int globalCrow = m.ReadInt("MiniA.exe+7963E0,A7EC");
                UIntPtr curr = m.GetCode("MiniA.exe+7963E0,A7F0");

                float closestDistance = float.MaxValue;
                uint closestMonsterID = 0;
                uint closestMonsterHP = 0;
                float closest_X = 0;
                float closest_Y = 0;
                float closest_Z = 0;
                for (int i = 0; i < globalCrow; i++)
                {
                    UIntPtr data = m.GetCode($"{curr:X},0");
                    // Reading data pointers
                    var mobDetails = await ReadMonsterDetailsAsync(data);

                    float distance_mon = CalculateDistance(mobDetails.X, mobDetails.Y, mobDetails.Z);
                    if (mobDetails.HP > 70 && distance_mon <= MonDistance && distance_mon <= closestDistance)
                    {
                        closest_X = mobDetails.X;
                        closest_Y = mobDetails.Y;
                        closest_Z = mobDetails.Z;
                        closestDistance = distance_mon;
                        closestMonsterID = mobDetails.ID;
                        closestMonsterHP = mobDetails.HP;
                        closestMonsterHP_ADR = mob_HP;
                        //  label2.Text = MonDistance.ToString();
                    }

                    curr = m.GetCode($"{curr:X},8");
                }

                // Update global variables
                if (closestMonsterHP > 50 && closestDistance <= MonDistance)
                {
                    MonsterID_FromGetMonster = closestMonsterID;
                    MonsterHP_FromGetMonster = closestMonsterHP;
                    X_fromGetMonster = closest_X;
                    Y_fromGetMonster = closest_Y;
                    Z_fromGetMonster = closest_Z;

                    distance_FromGetMonster = closestDistance;
                }
                else if (closestDistance > MonDistance)
                {
                    // Clear the variables if no monster meets the conditions
                    MonsterID_FromGetMonster = 0;
                    MonsterHP_FromGetMonster = 0;
                    distance_FromGetMonster = float.MaxValue;
                }
                await Task.Delay(10);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in GetMonsters: {ex.Message}");
            }
        }

        private async Task<(uint ID, float X, float Y, float Z, uint HP)> ReadMonsterDetailsAsync(UIntPtr data)
        {
            try
            {
                UIntPtr mobID = m.GetCode($"{data:X},17A4");
                UIntPtr mob_X = m.GetCode($"{data:X},1678");
                UIntPtr mob_Y = m.GetCode($"{data:X},167C");
                UIntPtr mob_Z = m.GetCode($"{data:X},1680");
                mob_HP = m.GetCode($"{data:X},1618");

                uint mobValue = await Task.Run(() => m.ReadUInt(mobID.ToString("X")));
                float mobVaLue_X = await Task.Run(() => m.ReadFloat(mob_X.ToString("x")));
                float mobVaLue_Y = await Task.Run(() => m.ReadFloat(mob_Y.ToString("x")));
                float mobVaLue_Z = await Task.Run(() => m.ReadFloat(mob_Z.ToString("x")));
                uint mobVaLue_HP = await Task.Run(() => m.ReadUInt(mob_HP.ToString("X")));

                return (mobValue, mobVaLue_X, mobVaLue_Y, mobVaLue_Z, mobVaLue_HP);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading monster details: {ex.Message}");

                return (0, 0, 0, 0, 0);
            }
        }
        private float CalculateDistance(float mobX, float mobY, float mobZ)
        {
            float myX = m.ReadFloat(CurrentX);
            float myY = m.ReadFloat(CurrentY);
            float myZ = m.ReadFloat(CurrentZ);
            return (float)Math.Round(MathF.Sqrt(MathF.Pow(mobX - myX, 2) + MathF.Pow(mobZ - myZ, 2)) / 10, 2);
        }
        private void btnLoad_Click(object sender, EventArgs e)
        {
            // Use the folder path from selectedPathTextBox
            selectedFilePath = selectedPathTextBox.Text;

            if (string.IsNullOrEmpty(selectedFilePath) || !Directory.Exists(selectedFilePath))
            {
                MessageBox.Show("Please select a valid folder first.", "Error");
                return; // Exit if the path is invalid
            }

            // Get all JSON files in the selected folder
            string[] jsonFiles = Directory.GetFiles(selectedFilePath, "*.json");

            // Iterate over each file and try to find the corresponding ListView dynamically
            foreach (string file in jsonFiles)
            {
                // Extract the base filename (without extension) and split the part before 'adslmas1'
                string key = Path.GetFileNameWithoutExtension(file);

                // Assume the ListView name is everything before the first non-digit/letter character
                string listViewName = GetListViewName(key);

                //   MessageBox.Show($"Trying to load file: {file}, with ListView name: {listViewName}", "Debug Info");

                // Try to get the ListView control by its name dynamically
                ListView listView = FindControlRecursive(this, listViewName) as ListView;

                if (listView != null)
                {
                    // Load the JSON data into the ListView
                    LoadListViewFromJSON(listView, file);
                }
                else
                {
                    //  MessageBox.Show($"No ListView found for key: {listViewName}", "Warning");
                }
            }

            //   MessageBox.Show("All files loaded successfully.", "Load Complete");
        }

        // Method to extract the base list view name (e.g., listView1, listView2, etc.)
        private string GetListViewName(string key)
        {
            // Match until the first non-letter or non-digit character after the 'listView' prefix
            for (int i = 0; i < key.Length; i++)
            {
                if (!char.IsLetterOrDigit(key[i]))
                {
                    return key.Substring(0, i); // Return the base name like 'listView1'
                }
            }
            return key; // In case there's no extra part, return the full key
        }

        // Helper method to recursively find a control by name in the form or its child containers

        private void LoadListViewFromJSON(ListView listView, string fileName)
        {
            if (!File.Exists(fileName))
            {
                return;
            }

            var items = JsonConvert.DeserializeObject<List<LocationData>>(File.ReadAllText(fileName));

            // Clear existing items in the ListView before loading new data
            listView.Items.Clear();

            foreach (LocationData item in items)
            {
                ListViewItem listViewItem = new ListViewItem(item.Position);
                listViewItem.SubItems.Add(item.X);
                listViewItem.SubItems.Add(item.Y);
                listViewItem.SubItems.Add(item.Z);
                listView.Items.Add(listViewItem);
            }
        }




        private void button10_Click(object sender, EventArgs e)
        {
            if (comboBox3.SelectedItem != null)
            {
                try
                {
                    string key = comboBox3.SelectedItem.ToString();
                    if (listViewDictionary.TryGetValue(key, out var value))
                    {
                        value.Items.Clear();
                        positionCounter = 1;
                    }
                    else
                    {
                        MessageBox.Show("Selected ListView not found");
                    }
                    return;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error clearing items: " + ex.Message);
                    return;
                }
            }
            MessageBox.Show("Please select a ListView");
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (comboBox3.SelectedItem != null && !string.IsNullOrEmpty(selectedFilePath))
            {
                //saveID = m.ReadString(IDadr);
                string key = comboBox3.SelectedItem.ToString();
                if (listViewDictionary.TryGetValue(key, out var listView))
                {
                    string filePath = Path.Combine(selectedFilePath, $"{key}.json");
                    SaveListViewToJSON(listView, filePath);
                    MessageBox.Show($"{comboBox2.SelectedItem} saved successfully.", "Save Complete");
                }
                else
                {
                    MessageBox.Show("No matching ListView found.", "Error");
                }
            }
            else
            {
                MessageBox.Show("Please select a folder and an item from the combo box.", "Warning");
            }
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            autoAddItems = false;
        }

        private async Task UpdateListViewItemsAsync(ListView listView)
        {

            try
            {
                int itemCount = listView.Items.Count;
                int currentIndex = 0;
                int direction = 1;
                int iterations = (checkBox9.Checked ? 1 : 2);
                float currentX = m.ReadFloat(CurrentX);
                float currentY = m.ReadFloat(CurrentY);
                float currentZ = m.ReadFloat(CurrentZ);
                for (int i = 0; i < iterations * itemCount; i++)
                {
                    if (backgroundWorker1.CancellationPending)
                    {
                        backgroundWorker1.CancelAsync();
                        break;
                    }
                    ListViewItem listViewItem = listView.Items[currentIndex];
                    await Task.Delay(10);
                    float newX = float.Parse(listViewItem.SubItems[1].Text);
                    float newY = float.Parse(listViewItem.SubItems[2].Text);
                    float newZ = float.Parse(listViewItem.SubItems[3].Text);
                    RunActive();
                    label6.Text = "Runing";
                    label6.ForeColor = Color.Red;
                    m.WriteMemory(getadr + "+4", "float", newX.ToString());
                    m.WriteMemory(getadr + "+C", "float", newY.ToString());
                    m.WriteMemory(getadr + "+14", "float", newZ.ToString());
                    while (!(currentX >= newX - 20f) || !(currentX <= newX + 20f) || !(currentY >= newY - 20f) || !(currentY <= newY + 20f) || !(currentZ >= newZ - 20f) || !(currentZ <= newZ + 20f))
                    {
                        currentX = m.ReadFloat(CurrentX);
                        currentY = m.ReadFloat(CurrentY);
                        currentZ = m.ReadFloat(CurrentZ);
                        await Task.Delay(10);
                    }
                    if (currentX >= newX - 20f && currentX <= newX + 20f && currentY >= newY - 20f && currentY <= newY + 20f && currentZ >= newZ - 20f && currentZ <= newZ + 20f)
                    {
                        m.WriteMemory(getadr + "+4", "float", newX.ToString());
                        m.WriteMemory(getadr + "+C", "float", newY.ToString());
                        m.WriteMemory(getadr + "+14", "float", newZ.ToString());
                    }
                    currentIndex += direction;
                    if ((currentIndex != itemCount - 1 && currentIndex != 0) || !(currentX >= newX - 20f) || !(currentX <= newX + 20f) || !(currentY >= newY - 20f) || !(currentY <= newY + 20f) || !(currentZ >= newZ - 20f) || !(currentZ <= newZ + 20f))
                    {
                        continue;
                    }
                    RunDeActive();
                    if (checkBox25.Checked)
                    {
                        m.WriteMemory("02FD3DA2", "byte", "63");
                        Thread.Sleep(100);
                        m.WriteMemory("02FD3DA2", "byte", "01");
                        Thread.Sleep(2000);

                        m.WriteMemory("02FD3DA3", "byte", "63");
                        Thread.Sleep(100);
                        m.WriteMemory("02FD3DA3", "byte", "01");


                    }
                    if (checkBox14.Checked)
                    {
                        m.WriteMemory(PATH_ADR_RESULT, "bytes", originalcode_Path);

                        int j;
                        if (int.TryParse(textBox1.Text, out var numberOfIterations))
                        {

                            for (j = 0; j < numberOfIterations; j++)
                            {
                                await AutoSkills2();
                                await Task.Delay(100);
                                Console.WriteLine($"Attacking {j} < {numberOfIterations}");

                            }

                        }
                        m.WriteMemory(PATH_ADR_RESULT, "bytes", BitConverter.ToString(jmpCodemy).Replace('-', ' '));

                        if (checkBox31.Checked && int.TryParse(textBox4.Text, out j))
                        {
                            m.WriteMemory(PATH_ADR_RESULT, "bytes", originalcode_Path);
                            for (int u2 = 0; u2 < j; u2++)
                            {
                                m.WriteMemory(RUN1_ADR_RESULT, "bytes", "EB");
                                m.WriteMemory(RUN2_ADR_RESULT, "bytes", "90 90 90 90 90 90");
                                m.WriteMemory(RUN3_ADR_RESULT, "bytes", "90 90 90 90 90 90");

                                m.WriteMemory("02FD3DBD", "byte", "63");
                                await Task.Delay(5);
                                m.WriteMemory("02FD3DBD", "byte", "01");
                                await Task.Delay(5);
                                m.WriteMemory("02FD3DBD", "byte", "63");
                                await Task.Delay(5);
                                m.WriteMemory("02FD3DBD", "byte", "01");
                                await Task.Delay(5);
                                m.WriteMemory("02FD3DBD", "byte", "63");
                                await Task.Delay(5);
                                m.WriteMemory("02FD3DBD", "byte", "01");
                                await Task.Delay(5);
                                m.WriteMemory(RUN1_ADR_RESULT, "bytes", "74");
                                m.WriteMemory(RUN2_ADR_RESULT, "bytes", "0F 84 A6 02 00 00");
                                m.WriteMemory(RUN3_ADR_RESULT, "bytes", "0F 85 F1 00 00 00");
                            }
                            m.WriteMemory(PATH_ADR_RESULT, "bytes", BitConverter.ToString(jmpCodemy).Replace('-', ' '));

                            int j2;
                            if (int.TryParse(textBox1.Text, out var numberOfIterations2))
                            {
                                m.WriteMemory(PATH_ADR_RESULT, "bytes", originalcode_Path);

                                for (j2 = 0; j2 < numberOfIterations2; j2++)
                                {
                                    await AutoSkills2();
                                    await Task.Delay(10);
                                    Console.WriteLine($"Attacking {j2} < {numberOfIterations2}");

                                }

                                for (int u2 = 0; u2 < j; u2++)
                                {
                                    m.WriteMemory(RUN1_ADR_RESULT, "bytes", "EB");
                                    m.WriteMemory(RUN2_ADR_RESULT, "bytes", "90 90 90 90 90 90");
                                    m.WriteMemory(RUN3_ADR_RESULT, "bytes", "90 90 90 90 90 90");

                                    m.WriteMemory("02FD3DBD", "byte", "63");
                                    await Task.Delay(5);
                                    m.WriteMemory("02FD3DBD", "byte", "01");
                                    await Task.Delay(5);
                                    m.WriteMemory("02FD3DBD", "byte", "63");
                                    await Task.Delay(5);
                                    m.WriteMemory("02FD3DBD", "byte", "01");
                                    await Task.Delay(5);
                                    m.WriteMemory("02FD3DBD", "byte", "63");
                                    await Task.Delay(5);
                                    m.WriteMemory("02FD3DBD", "byte", "01");
                                    await Task.Delay(5);
                                    m.WriteMemory(RUN1_ADR_RESULT, "bytes", "74");
                                    m.WriteMemory(RUN2_ADR_RESULT, "bytes", "0F 84 A6 02 00 00");
                                    m.WriteMemory(RUN3_ADR_RESULT, "bytes", "0F 85 F1 00 00 00");
                                    Console.WriteLine($"Looting{u2} < {j}");

                                }
                                m.WriteMemory(PATH_ADR_RESULT, "bytes", BitConverter.ToString(jmpCodemy).Replace('-', ' '));
                                if (int.TryParse(textBox1.Text, out var numberOfIterations3))
                                {
                                    int j3;
                                    for (j3 = 0; j3 < numberOfIterations3; j3++)
                                    {
                                        await Autobuff();
                                        await Task.Delay(100);


                                    }
                                }

                            }

                            m.WriteMemory(PATH_ADR_RESULT, "bytes", BitConverter.ToString(jmpCodemy).Replace('-', ' '));
                        }



                        if (checkBox15.Checked && int.TryParse(textBox4.Text, out j))
                        {
                            m.WriteMemory(PATH_ADR_RESULT, "bytes", originalcode_Path);
                            for (int u2 = 0; u2 < j; u2++)
                            {
                                try
                                {
                                    await ItemGet();
                                    await Task.Delay(10);
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine(ex);
                                }

                            }
                            m.WriteMemory(PATH_ADR_RESULT, "bytes", BitConverter.ToString(jmpCodemy).Replace('-', ' '));

                            int j2;
                            if (int.TryParse(textBox1.Text, out var numberOfIterations2))
                            {
                                m.WriteMemory(PATH_ADR_RESULT, "bytes", originalcode_Path);

                                for (j2 = 0; j2 < numberOfIterations2; j2++)
                                {
                                    await AutoSkills2();
                                    await Task.Delay(100);
                                }

                                for (int u2 = 0; u2 < j; u2++)
                                {
                                    try
                                    {
                                        await ItemGet();
                                        await Task.Delay(10);
                                    }
                                    catch (Exception ex)
                                    {
                                        Console.WriteLine(ex);
                                    }
                                }
                                m.WriteMemory(PATH_ADR_RESULT, "bytes", BitConverter.ToString(jmpCodemy).Replace('-', ' '));
                                if (int.TryParse(textBox1.Text, out var numberOfIterations3))
                                {
                                    int j3;
                                    for (j3 = 0; j3 < numberOfIterations3; j3++)
                                    {
                                        await Autobuff();
                                        await Task.Delay(100);
                                    }
                                }

                            }

                            m.WriteMemory(PATH_ADR_RESULT, "bytes", BitConverter.ToString(jmpCodemy).Replace('-', ' '));
                        }
                    }

                    if (checkBox26.Checked)
                    {
                        if (int.TryParse(textBox1.Text, out var numberOfIterations))
                        {
                            m.WriteMemory(AngleAdr, "float", currentrange.ToString());
                            m.WriteMemory(ZoomAdr, "float", currentrange2.ToString());
                            m.WriteMemory(LeftClick, "byte", "01");
                            await Task.Delay(10);
                            m.WriteMemory(AngleAdr, "float", currentrange.ToString());
                            m.WriteMemory(ZoomAdr, "float", currentrange2.ToString());
                            await Task.Delay(10);
                            m.WriteMemory(AngleAdr, "float", currentrange.ToString());
                            m.WriteMemory(ZoomAdr, "float", currentrange2.ToString());
                            await Task.Delay(10);
                            int j = 0;
                            for (j = 0; j < numberOfIterations; j++)
                            {
                                await Task.Delay(150);

                                await Autobuff();
                                await Task.Delay(150);

                            }
                        }

                    }
                    m.WriteMemory(LeftClick, "byte", "00");
                    await Task.Delay(50);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception in UpdateListViewItemsAsync: " + ex.Message);
            }
        }

        static List<int> check_id_mon = new List<int>();
        string base_mon = "00000000";


        public float rangefix;
        public float rangefixminus;
        public float skilltimer = 2;
        private void OpenSettingsForm()
        {
            using (Settings settingsForm = new Settings(rangefix, skilltimer, MonDistance))
            {
                if (settingsForm.ShowDialog() == DialogResult.OK)
                {
                    rangefix = settingsForm.RangeFix;
                    rangefixminus = settingsForm.RangeFixMinus; // If you need this updated
                    skilltimer = settingsForm.SkillTimer;
                    MonDistance = settingsForm.MonDistance;
                }
            }
        }

        public async void ItemGetSpaceBar()
        {
            m.WriteMemory(RUN1_ADR_RESULT, "bytes", "EB");
            m.WriteMemory(RUN2_ADR_RESULT, "bytes", "90 90 90 90 90 90");
            m.WriteMemory(RUN3_ADR_RESULT, "bytes", "90 90 90 90 90 90");

            m.WriteMemory("02FD3DBD", "byte", "63");
            await Task.Delay(5);
            m.WriteMemory("02FD3DBD", "byte", "01");
            await Task.Delay(5);
            m.WriteMemory("02FD3DBD", "byte", "63");
            await Task.Delay(5);
            m.WriteMemory("02FD3DBD", "byte", "01");
            await Task.Delay(5);
            m.WriteMemory("02FD3DBD", "byte", "63");
            await Task.Delay(5);
            m.WriteMemory("02FD3DBD", "byte", "01");
            await Task.Delay(5);
            m.WriteMemory(RUN1_ADR_RESULT, "bytes", "74");
            m.WriteMemory(RUN2_ADR_RESULT, "bytes", "0F 84 A6 02 00 00");
            m.WriteMemory(RUN3_ADR_RESULT, "bytes", "0F 85 F1 00 00 00");

        }
        private async Task MoveWhileAttacking()
        {
            // Lock movement
            m.WriteMemory(PATH_ADR_RESULT, "bytes", BitConverter.ToString(jmpCodemy).Replace('-', ' '));

            // Read current coordinates
            float myX = m.ReadFloat(CurrentX);
            float myY = m.ReadFloat(CurrentY);
            float myZ = m.ReadFloat(CurrentZ);

            rangefix = 5f;
            rangefixminus = -5f;

            // Create a random generator
            Random random = new Random();

            // Randomly decide to add or subtract 20 for myX
            // Randomly decide to add or subtract 20 for myXget
            float xOffset = (random.Next(2) == 0) ? rangefix : rangefixminus;
            float newX = myX + xOffset;

            // Randomly decide to add or subtract 20 for myZ
            float zOffset = (random.Next(2) == 0) ? rangefix : rangefixminus;
            float newZ = myZ + zOffset;

            // Write new coordinates
            m.WriteMemory(getadr + "+4", "float", X_fromGetMonster.ToString());
            m.WriteMemory(getadr + "+C", "float", Y_fromGetMonster.ToString()); // Y-coordinate stays the same
            m.WriteMemory(getadr + "+14", "float",Z_fromGetMonster.ToString());
            label6.Text = "MoveWhileAttacking";
            // Perform the movement
            RunActive();
            await Task.Delay(100); // Delay to simulate the move duration
            RunDeActive();

            // Unlock movement
            m.WriteMemory(PATH_ADR_RESULT, "bytes", originalcode_Path);

        }
        float MonDistance = 8f;
        int TARGET_RINGs = -1;
        float limitdistance = 8f;
        private async Task AutoSkills2()
        {

            m.WriteMemory(TARGET_SKILL, "int", MonsterID_FromGetMonster.ToString());
            m.WriteMemory(TARGET_RING, "int", MonsterID_FromGetMonster.ToString());
            while (true)
            {
                label6.Text = "Attacking";
                label6.ForeColor = Color.Red;
                m.WriteMemory(TARGET_SKILL, "int", MonsterID_FromGetMonster.ToString());
                m.WriteMemory(TARGET_RING, "int", MonsterID_FromGetMonster.ToString());
                int TARGET_RINGS = m.ReadInt(TARGET_RING);
                int TARGET_SKILLS = m.ReadInt(TARGET_SKILL);
                uint monsterHP = m.ReadUInt(closestMonsterHP_ADR.ToString("X"));
                if (ShouldStopAttacking(monsterHP, MonDistance, TARGET_RINGs))
                {
                    break;

                }

                for (int i3 = 0x9A4; i3 <= 0x9C8; i3 += 4)
                {
                    int MATION = m.ReadInt(MATION_CHECK);
                    m.WriteMemory(TARGET_SKILL, "int", MonsterID_FromGetMonster.ToString());
                    m.WriteMemory(TARGET_RING, "int", MonsterID_FromGetMonster.ToString());
                    TARGET_RINGS = m.ReadInt(TARGET_RING);
                    monsterHP = m.ReadUInt(closestMonsterHP_ADR.ToString("X"));

                    if (ShouldStopAttacking(monsterHP, MonDistance, TARGET_RINGs))
                    {
                        break;
                    }

                    int idskilltype_test1 = m.ReadByte($"00FE2000,{i3:x}");
                    int idskilltype_test2 = m.ReadByte($"00FE2000,{(i3 + 0x02):x}");

                    if (idskilltype_test1 != 255 && idskilltype_test2 != 255 && MonsterHP_FromGetMonster > 70 && distance_FromGetMonster <= MonDistance)
                    {
                        if (TARGET_RINGS == MonsterID_FromGetMonster && TARGET_SKILLS == MonsterID_FromGetMonster)
                        {
                            
                            TARGET_RINGS = m.ReadInt(TARGET_RING);
                            monsterHP = m.ReadUInt(closestMonsterHP_ADR.ToString("X"));

                            if (ShouldStopAttacking(monsterHP, MonDistance, TARGET_RINGs))
                            {
                                break;
                            }
                            Console.WriteLine($"TARGET_RING: {TARGET_RINGS}, TARGET_SKILL: {TARGET_SKILLS}");
                            Console.WriteLine($"Monster HP: {monsterHP}, Distance: {distance_FromGetMonster}");
                            Console.WriteLine($"Can Attack: {MATION != 0}");

                            PerformSkill(idskilltype_test1, idskilltype_test2);
                        }

                        if (MATION == 0) // if can't hit will move
                        {

                            label6.Text = "Unable to attack. Retrying...";
                            await Task.Delay(100);
                            MATION = m.ReadInt(MATION_CHECK); // Re-read MATION
                            if (MATION == 0 && checkBox39.Checked)
                            {
                                await Task.Delay(300);
                                MoveWhileAttacking();
                                await Task.Delay(100);
                                break;
                            }
                        }

                    }

                    await Task.Delay(100);
                }
                TARGET_RINGS = m.ReadInt(TARGET_RING);
                monsterHP = m.ReadUInt(closestMonsterHP_ADR.ToString("X"));

                if (ShouldStopAttacking(monsterHP, MonDistance, TARGET_RINGs))
                {
                    break;
                }
                await Task.Delay(200);

            }
            label6.Text = "NONE";
            label6.ForeColor = Color.Green;

        }
        private void PerformSkillPlayer(int skill1, int skill2)
        {

            m.WriteMemory(actioncheck, "int", "0");
            m.WriteMemory(prevskill1_adr, "byte", skill1.ToString("x"));
            m.WriteMemory(prevskill2_adr, "byte", skill2.ToString("x"));
            m.WriteMemory(forceattack_adr, "int", "5");
            Task.Delay(0);
        }

        private void PerformSkill(int skill1, int skill2)
        {

            m.WriteMemory(actioncheck, "int", "2");
            m.WriteMemory(prevskill1_adr, "byte", skill1.ToString("x"));
            m.WriteMemory(prevskill2_adr, "byte", skill2.ToString("x"));
            m.WriteMemory(forceattack_adr, "int", "5");
            Task.Delay(200);
        }

        private bool ShouldStopAttacking(uint monsterHP, float MonDistance, int TARGET_RINGs)
        {
            return monsterHP < 5 || distance_FromGetMonster > MonDistance || m.ReadInt(TARGET_RING) == -1;
        }


        public void LOCALPLAYER_ALLOC()
        {
            try
            {
                IntPtr processHandle = OpenProcess(PROCESS_ALL_ACCESS, false, selectedProcessId);
                Process ProcessbyID = Process.GetProcessById(selectedProcessId);
                if (allocate_adr_LOCALPLAYER == IntPtr.Zero)
                {
                    allocate_adr_LOCALPLAYER = VirtualAllocEx(processHandle, IntPtr.Zero, 2048, MEM_COMMIT, PAGE_READWRITE);

                }

                IntPtr baseModuleadr = ProcessbyID.MainModule.BaseAddress;

                // Assembly code for fstp dword ptr [esp+38]
                byte[] assemblyCode = new byte[]
                {
                    0x8B, 0x86, 0x90, 0x03, 0x00, 0x00, 0x89, 0x35, 0xA0, 0x38, 0xFF, 0x00,
                    0xE9,
                    0x00, 0x00, 0x00, 0x00  // jmp 0x00000000 (to be replaced later)
                };

                // Calculate the jump offset for the first jmp instruction
                int jumpOffset = (int)AOB_LOCALPLAYER + 6 - ((int)allocate_adr_LOCALPLAYER + assemblyCode.Length + 0);
                BitConverter.GetBytes(jumpOffset).CopyTo(assemblyCode, assemblyCode.Length - 4);

                // Write the initial assembly code to the allocated address
                m.WriteMemory(allocate_adr_LOCALPLAYER.ToString("X"), "bytes", BitConverter.ToString(assemblyCode).Replace('-', ' '));

                // Assembly code for jmp to allocate_   adr with nop 2
                byte[] jmpCode = new byte[]
                {
                    0xE9, 0x00, 0x00, 0x00, 0x00,
                    0x90
                };

                // Calculate the jump offset for the second jmp instruction
                int jmpOffset2 = (int)allocate_adr_LOCALPLAYER - ((int)AOB_LOCALPLAYER + jmpCode.Length - 1);
                BitConverter.GetBytes(jmpOffset2).CopyTo(jmpCode, 1);  // Offset is from the next instruction (E9), not the beginning

                // Write the second jmp instruction to the allocated address
                m.WriteMemory(LOCALPLAYER_ADR_RESULT, "bytes", BitConverter.ToString(jmpCode).Replace('-', ' '));
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error while finding monster: {ex.Message}");
            }
        }

        public void MonsterAlloc()
        {
            try
            {
                IntPtr processHandle = OpenProcess(PROCESS_ALL_ACCESS, false, selectedProcessId);
                Process ProcessbyID = Process.GetProcessById(selectedProcessId);
                if (allocate_adr_Monview == IntPtr.Zero)
                {
                    allocate_adr_Monview = VirtualAllocEx(processHandle, IntPtr.Zero, 2048, MEM_COMMIT, PAGE_READWRITE);

                }

                IntPtr baseModuleadr = ProcessbyID.MainModule.BaseAddress;

                // Assembly code for fstp dword ptr [esp+38]
                byte[] assemblyCode = new byte[]
                {
                    0x89,0x0D,0x00,0x55,0xFF,0x00,0x8B,0x81,0xA4,0x17,0x00,0x00,
                    0xE9,
                    0x00, 0x00, 0x00, 0x00  // jmp 0x00000000 (to be replaced later)
                };

                // Calculate the jump offset for the first jmp instruction
                int jumpOffset = (int)AOB_MONVIEW + 6 - ((int)allocate_adr_Monview + assemblyCode.Length + 0);
                BitConverter.GetBytes(jumpOffset).CopyTo(assemblyCode, assemblyCode.Length - 4);

                // Write the initial assembly code to the allocated address
                m.WriteMemory(allocate_adr_Monview.ToString("X"), "bytes", BitConverter.ToString(assemblyCode).Replace('-', ' '));

                // Assembly code for jmp to allocate_   adr with nop 2
                byte[] jmpCode = new byte[]
                {
                    0xE9, 0x00, 0x00, 0x00, 0x00,
                    0x90
                };

                // Calculate the jump offset for the second jmp instruction
                int jmpOffset2 = (int)allocate_adr_Monview - ((int)AOB_MONVIEW + jmpCode.Length - 1);
                BitConverter.GetBytes(jmpOffset2).CopyTo(jmpCode, 1);  // Offset is from the next instruction (E9), not the beginning

                // Write the second jmp instruction to the allocated address
                m.WriteMemory(MONVIEW_ADR, "bytes", BitConverter.ToString(jmpCode).Replace('-', ' '));
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error while finding monster: {ex.Message}");
            }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private async void checkBox13_CheckedChanged(object sender, EventArgs e)
        {
            DisplayAlloc();
            if (!checkBox13.Checked)
            {
                StopMonitoringMonsters();

            }

            if (checkBox13.Checked)
            {
                StartMonitoringMonstersAsync();

                backgroundWorker6.RunWorkerAsync();
            }
            else
            {
                backgroundWorker6.CancelAsync();
            }

            if (checkBox13.Checked && !backgroundWorker1.IsBusy)
            {
                backgroundWorker1.RunWorkerAsync();
                return;
            }
            else
            {
                backgroundWorker1.CancelAsync();
                RunDeActive();

            }
        }
        public void DisplayAlloc()
        {
            try
            {
                IntPtr processHandle = OpenProcess(PROCESS_ALL_ACCESS, false, selectedProcessId);
                Process ProcessbyID = Process.GetProcessById(selectedProcessId);
                if (allocate_adr_Display == IntPtr.Zero)
                {
                    allocate_adr_Display = VirtualAllocEx(processHandle, IntPtr.Zero, 2048, MEM_COMMIT, PAGE_READWRITE);

                }

                IntPtr baseModuleadr = ProcessbyID.MainModule.BaseAddress;

                // Assembly code for fstp dword ptr [esp+38]
                byte[] assemblyCode = new byte[]
                {
                    0x89,0x35,0x50,0x45,0xFF,0x00,0x8B,0x96,0xB8,0x03,0x00,0x00,
                    0xE9,
                    0x00, 0x00, 0x00, 0x00  // jmp 0x00000000 (to be replaced later)
                };

                // Calculate the jump offset for the first jmp instruction
                int jumpOffset = (int)AOB_ITEMDROP + 6 - ((int)allocate_adr_Display + assemblyCode.Length + 0);
                BitConverter.GetBytes(jumpOffset).CopyTo(assemblyCode, assemblyCode.Length - 4);

                // Write the initial assembly code to the allocated address
                m.WriteMemory(allocate_adr_Display.ToString("X"), "bytes", BitConverter.ToString(assemblyCode).Replace('-', ' '));

                // Assembly code for jmp to allocate_   adr with nop 2
                byte[] jmpCode = new byte[]
                {
                    0xE9, 0x00, 0x00, 0x00, 0x00,
                    0x90
                };

                // Calculate the jump offset for the second jmp instruction
                int jmpOffset2 = (int)allocate_adr_Display - ((int)AOB_ITEMDROP + jmpCode.Length - 1);
                BitConverter.GetBytes(jmpOffset2).CopyTo(jmpCode, 1);  // Offset is from the next instruction (E9), not the beginning

                // Write the second jmp instruction to the allocated address
                m.WriteMemory(ITEMDROP_ADR_RESULT, "bytes", BitConverter.ToString(jmpCode).Replace('-', ' '));
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error while finding monster: {ex.Message}");
            }
        }

        public void f_GET_Buff()
        {
            try
            {

                IntPtr processHandle = OpenProcess(PROCESS_ALL_ACCESS, false, selectedProcessId);
                Process ProcessbyID = Process.GetProcessById(selectedProcessId);
                if (allocate_adr_BUFF == IntPtr.Zero)
                {
                    allocate_adr_BUFF = VirtualAllocEx(processHandle, IntPtr.Zero, 2048, MEM_COMMIT, PAGE_READWRITE);

                }

                IntPtr baseModuleadr = ProcessbyID.MainModule.BaseAddress;

                // Assembly code for fstp dword ptr [esp+38]
                byte[] assemblyCode = new byte[]
                {
                0x89, 0x35, 0x00, 0x30, 0xFE, 0x00, 0x8B, 0x16, 0x39, 0xEA,
                0x0F, 0x84, 0xF3, 0x35, 0x84, 0xF5,
                0xE9, 0xA4, 0x35, 0x84, 0xF5

                };


                int jumpOffset1 = (int)AOB_GETBUFF + 0x50 - ((int)allocate_adr_BUFF + assemblyCode.Length - 5);
                int jumpOffset2 = (int)AOB_GETBUFF + 0x06 - ((int)allocate_adr_BUFF + assemblyCode.Length + 0);

                // Replace the jump offsets in the assembly code
                BitConverter.GetBytes(jumpOffset1).CopyTo(assemblyCode, assemblyCode.Length - 9);
                BitConverter.GetBytes(jumpOffset2).CopyTo(assemblyCode, assemblyCode.Length - 4);

                m.WriteMemory(allocate_adr_BUFF.ToString("X"), "bytes", BitConverter.ToString(assemblyCode).Replace('-', ' '));

                // Assembly code for jmp to allocate_   adr with nop 2
                byte[] jmpCode = new byte[]
                {
                    0xE9, 0x00, 0x00, 0x00, 0x00,
                    0x90
                };

                // Calculate the jump offset for the second jmp instruction
                int jmpOffset2 = (int)allocate_adr_BUFF - ((int)AOB_GETBUFF + jmpCode.Length - 1);
                BitConverter.GetBytes(jmpOffset2).CopyTo(jmpCode, 1);  // Offset is from the next instruction (E9), not the beginning

                // Write the second jmp instruction to the allocated address
                m.WriteMemory(GETBUFF_ADR_RESULT, "bytes", BitConverter.ToString(jmpCode).Replace('-', ' '));
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error while finding monster: {ex.Message}");
            }
        }


        public void f_GET_SKILL_LIST()
        {
            try
            {
                IntPtr processHandle = OpenProcess(PROCESS_ALL_ACCESS, false, selectedProcessId);
                Process ProcessbyID = Process.GetProcessById(selectedProcessId);
                if (allocate_adr_SKILL_LIST == IntPtr.Zero)
                {
                    allocate_adr_SKILL_LIST = VirtualAllocEx(processHandle, IntPtr.Zero, 2048, MEM_COMMIT, PAGE_READWRITE);

                }

                IntPtr baseModuleadr = ProcessbyID.MainModule.BaseAddress;

                // Assembly code for fstp dword ptr [esp+38]
                byte[] assemblyCode = new byte[]
                {
                    0xA3, 0x00, 0x20, 0xFE, 0x00, 0x8B, 0xBC, 0xB8, 0x64, 0x09, 0x00, 0x00,
                    0xE9,
                    0x00, 0x00, 0x00, 0x00  // jmp 0x00000000 (to be replaced later)
                };

                // Calculate the jump offset for the first jmp instruction
                int jumpOffset = (int)AOB_GETSKILL_LIST + 7 - ((int)allocate_adr_SKILL_LIST + assemblyCode.Length + 0);
                BitConverter.GetBytes(jumpOffset).CopyTo(assemblyCode, assemblyCode.Length - 4);

                // Write the initial assembly code to the allocated address
                m.WriteMemory(allocate_adr_SKILL_LIST.ToString("X"), "bytes", BitConverter.ToString(assemblyCode).Replace('-', ' '));

                // Assembly code for jmp to allocate_   adr with nop 2
                byte[] jmpCode = new byte[]
                {
                    0xE9, 0x00, 0x00, 0x00, 0x00,
                    0x66, 0x90
                };

                // Calculate the jump offset for the second jmp instruction
                int jmpOffset2 = (int)allocate_adr_SKILL_LIST - ((int)AOB_GETSKILL_LIST + jmpCode.Length - 2);
                BitConverter.GetBytes(jmpOffset2).CopyTo(jmpCode, 1);  // Offset is from the next instruction (E9), not the beginning

                // Write the second jmp instruction to the allocated address
                m.WriteMemory(GETSKILL_LIST_ADR_RESULT, "bytes", BitConverter.ToString(jmpCode).Replace('-', ' '));
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error while finding monster: {ex.Message}");
            }
        }


        List<int> ItemID = new List<int>();
        private bool ShouldAddItem(int itemType)
        {
            return itemType != 0 && itemType != 5 && itemType != 2;
        }
        private bool IsItemAlreadyInList2(string itemId)
        {
            return listView11.Items.Cast<ListViewItem>().Any(item => item.SubItems[1].Text == itemId.ToString());
        }

        private bool IsItemAlreadyInList(int itemId)
        {
            return listView11.Items.Cast<ListViewItem>().Any(item => item.SubItems[1].Text == itemId.ToString());
        }

        private async Task WriteMemoryMultipleTimes(string address, string type, string value, int times, int delay)
        {
            for (int i = 0; i < times; i++)
            {
                m.WriteMemory(address, type, value);
                await Task.Delay(delay);
            }
        }

        private void LogError(Exception ex, string names)
        {
            string logFileName = $"error_logs_{names}.txt";
            File.AppendAllText(logFileName, $"{DateTime.Now}: {ex.Message}{Environment.NewLine}{ex.StackTrace}{Environment.NewLine}");
        }

        // Refactored AddItemToListView Method
        private async Task AddItemToListView()
        {
            try
            {
                int num = 30;
                int itemType = m.ReadInt("00FF4550,3b8");
                int itemId = m.ReadInt("00FF4550,3bc");
                byte[] array = m.ReadBytes("00FF4550,3d1", num);

                if (array != null && ShouldAddItem(itemType))
                {
                    string stringFromBytes = Encoding.GetEncoding(874).GetString(array);
                    if (!IsItemAlreadyInList(itemId))
                    {
                        string[] row = { itemType.ToString(), itemId.ToString(), stringFromBytes };
                        listView11.Items.Add(new ListViewItem(row));
                    }
                }

                if (listView11.Items.Count > 8)
                {
                    listView11.Items.Clear();
                }

                await Task.Delay(10);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        // Refactored ItemGet Method
        private async Task ItemGet()
        {
            string names = m.ReadString(IDadr);
            try
            {
                if (listView11 != null)
                {
                    foreach (ListViewItem item in listView11.Items)
                    {
                        bool found = false;

                        foreach (ListViewItem item12 in listView12.Items)
                        {
                            if (item.SubItems[2].Text.Contains(item12.SubItems[2].Text))
                            {
                                found = true;
                                break;
                            }
                        }

                        if (found)
                        {
                            if (m.ReadInt(MATION_CHECK) != 1)
                            {
                                m.WriteMemory(actioncheck, "int", "3");
                                m.WriteMemory(TARGET_SKILL, "int", item.SubItems[1].Text);
                                await WriteMemoryMultipleTimes(forceattack_adr, "int", "4", 1, 100);
                                item.Remove();

                                while (m.ReadInt(MATION_CHECK) == 1)
                                {
                                    await WriteMemoryMultipleTimes(forceattack_adr, "int", "4", 1, 1000);

                                    if (m.ReadInt(MATION_CHECK) == 0)
                                    {
                                        await WriteMemoryMultipleTimes(actioncheck, "int", "3", 3, 50);
                                        await WriteMemoryMultipleTimes(TARGET_SKILL, "int", item.SubItems[1].Text, 3, 50);
                                        await WriteMemoryMultipleTimes(forceattack_adr, "int", "4", 3, 50);

                                        item.Remove();
                                        break;
                                    }
                                }
                            }
                        }

                        if (item.SubItems[0].Text == "4")
                        {
                            m.WriteMemory(TARGET_SKILL, "int", item.SubItems[1].Text);
                            if (m.ReadInt(MATION_CHECK) != 1)
                            {
                                m.WriteMemory(actioncheck, "int", "4");
                                await WriteMemoryMultipleTimes(TARGET_SKILL, "int", item.SubItems[1].Text, 1, 50);
                                await WriteMemoryMultipleTimes(forceattack_adr, "int", "4", 1, 50);
                                item.Remove();

                                while (m.ReadInt(MATION_CHECK) == 1)
                                {
                                    await WriteMemoryMultipleTimes(forceattack_adr, "int", "4", 1, 10);

                                    if (m.ReadInt(MATION_CHECK) == 0)
                                    {
                                        await WriteMemoryMultipleTimes(forceattack_adr, "int", "4", 2, 50);
                                        item.Remove();
                                        break;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                LogError(ex, names);
            }

            await Task.Delay(20);
        }

        private async Task ItemGetAll()
        {
            string names = m.ReadString(IDadr);
            try
            {
                if (listView11 != null)
                {
                    foreach (ListViewItem item in listView11.Items)
                    {
                        if (item.SubItems[0].Text == "3")
                        {
                            if (m.ReadInt(MATION_CHECK) != 1)
                            {
                                m.WriteMemory(actioncheck, "int", "3");
                                m.WriteMemory(TARGET_SKILL, "int", item.SubItems[1].Text); // Assuming "ItemID" is the column header
                                m.WriteMemory(forceattack_adr, "int", "4");
                                await Task.Delay(100);
                                item.Remove();

                                while (m.ReadInt(MATION_CHECK) == 1)
                                {
                                    await Task.Delay(1000);

                                    if (m.ReadInt(MATION_CHECK) == 0)
                                    {
                                        m.WriteMemory(actioncheck, "int", "3");

                                        m.WriteMemory(TARGET_SKILL, "int", item.SubItems[1].Text); // Assuming "ItemID" is the column header

                                        m.WriteMemory(forceattack_adr, "int", "4");
                                        await Task.Delay(20);
                                        m.WriteMemory(forceattack_adr, "int", "4");
                                        await Task.Delay(20);
                                        m.WriteMemory(forceattack_adr, "int", "4");
                                        await Task.Delay(20);

                                        item.Remove();
                                        break;
                                    }
                                }
                            }
                        }
                        if (item.SubItems[0].Text == "4")
                        {
                            m.WriteMemory(TARGET_SKILL, "int", item.SubItems[1].Text); // Assuming "ItemID" is the column header
                            if (m.ReadInt(MATION_CHECK) != 1)
                            {
                                m.WriteMemory(actioncheck, "int", "4");
                                m.WriteMemory(TARGET_SKILL, "int", item.SubItems[1].Text); // Assuming "ItemID" is the column header
                                m.WriteMemory(forceattack_adr, "int", "4");
                                await Task.Delay(10);
                                item.Remove();

                                while (m.ReadInt(MATION_CHECK) == 1)
                                {
                                    m.WriteMemory(forceattack_adr, "int", "4");

                                    await Task.Delay(10);

                                    if (m.ReadInt(MATION_CHECK) == 0)
                                    {
                                        m.WriteMemory(forceattack_adr, "int", "4");
                                        m.WriteMemory(forceattack_adr, "int", "4");
                                        await Task.Delay(10);

                                        item.Remove();
                                        break;
                                    }
                                }
                            }

                        }
                    }

                }
            }
            catch (Exception ex)
            {
                File.AppendAllText($"errorlogsStacktrace{names}", ex.StackTrace);
                File.AppendAllText($"errorlogsMessage{names}", ex.Message);
                return;
            }



            await Task.Delay(20);

        }




        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            StopMonitoringMonsters();
            Application.Exit();
        }

        private void checkBox17_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox17.Checked)
            {
                m.WriteMemory(ANTISLIDE_ADR_RESULT, "byte", "0");
            }
            else
            {
                m.WriteMemory(ANTISLIDE_ADR_RESULT, "byte", "5");

            }
        }

        private void checkBox18_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox18.Checked)
            {
                m.WriteMemory(ANTICB_ADR_RESULT, "byte", "eb");
            }
            else
            {
                m.WriteMemory(ANTICB_ADR_RESULT, "byte", "74");
            }
        }

        private void checkBox16_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox16.Checked)
            {
                m.WriteMemory("00FAA000", "float", textBox6.Text);
            }
            else
            {
                m.WriteMemory("00FAA000", "float", "4800");

            }
        }

        public string sword1_adr = "MiniA.exe+11E2244,44";
        public string sword2_adr = "MiniA.exe+11E2254,44";

        public string sword3_adr = "MiniA.exe+11E223C,44";

        public string sword4_adr = "MiniA.exe+11E2240,44";


        private void checkBox19_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox19.Checked)
            {
                IntPtr processHandle = OpenProcess(PROCESS_ALL_ACCESS, false, selectedProcessId);
                Process ProcessbyID = Process.GetProcessById(selectedProcessId);
                allocate_adr_BA = VirtualAllocEx(processHandle, IntPtr.Zero, 2048, MEM_COMMIT, PAGE_READWRITE);
                getadr = allocate_adr_BA.ToString("x");

                IntPtr baseModuleadr = ProcessbyID.MainModule.BaseAddress;

                // Assembly code for fstp dword ptr [esp+38]
                byte[] assemblyCode = new byte[]
                {
                    0x83, 0x7F, 0x44, 0x01,      // cmp dword ptr [edi+44],01
                    0x74, 0x00,                 // je (short jump), to be replaced with jumpOffset1
                    0x0F, 0x1F, 0x40, 0x00,     // nop
                    0xE9, 0x00, 0x00, 0x00, 0x00, // jmp, to be replaced with jumpOffset2
                    0xC7, 0x47, 0x44, 0x00, 0x00, 0x00, 0x00, // mov [edi+48], 3
                    0xC7, 0x47, 0x48, 0x01, 0x00, 0x00, 0x00, // mov [edi+48], 3
                    0xE9, 0x00, 0x00, 0x00, 0x00, // jmp, to be replaced with jumpOffset3
                    0xEB, 0x00,                 // jmp short backward (loop), to be replaced with jumpOffset4
                    0x0F, 0x1F, 0x44, 0x00, 0x00 // nop
                };

                // Calculate offsets dynamically
                int jumpOffset1 = (int)allocate_adr_BA + 0x0F - ((int)allocate_adr_BA + 6); // Offset for `je`, replace at offset 5
                int jumpOffset2 = (int)AOB_BA + 0xA - ((int)allocate_adr_BA + 15);          // Offset for the first `jmp`, replace at offset 11
                int jumpOffset3 = (int)AOB_BA + 0xA - ((int)allocate_adr_BA + 34);          // Offset for the second `jmp`, replace at offset 23
                int jumpOffset4 = (int)allocate_adr_BA - ((int)allocate_adr_BA + 36);       // Short backward jump to `allocate_adr_BA`, replace at offset 28

                // Update the jump offsets in the assembly code
                assemblyCode[5] = (byte)(jumpOffset1 & 0xFF); // Short jump offset for `je` instruction, which only takes 1 byte
                BitConverter.GetBytes(jumpOffset2).CopyTo(assemblyCode, 11); // Place the offset for the first `jmp`
                BitConverter.GetBytes(jumpOffset3).CopyTo(assemblyCode, 30); // Place the offset for the second `jmp`
                assemblyCode[35] = (byte)(jumpOffset4 & 0xFF); // Short jump offset for `EB`, which only takes 1 byte

                // Now you can write 'assemblyCode' to the allocated memory and proceed with the injection

                // Write the initial assembly code to the allocated address
                m.WriteMemory(allocate_adr_BA.ToString("X"), "bytes", BitConverter.ToString(assemblyCode).Replace('-', ' '));



                // Assembly code for jmp to allocate_adr with nop 2
                jmpCodemy = new byte[]
                {
                    0xE9, 0x00, 0x00, 0x00, 0x00,
                    0x0F, 0x1F, 0x44

                };

                // Calculate the jump offset for the second jmp instruction
                int jmpOffset3 = (int)allocate_adr_BA - ((int)AOB_BA + jmpCodemy.Length - 3);
                BitConverter.GetBytes(jmpOffset3).CopyTo(jmpCodemy, 1);  // Offset is from the next instruction (E9), not the beginning

                m.WriteMemory(BA_ADR_RESULT, "bytes", BitConverter.ToString(jmpCodemy).Replace('-', ' '));
            }
            else
            {
                if (allocate_adr_BA != IntPtr.Zero)
                {
                    IntPtr processHandle = OpenProcess(PROCESS_ALL_ACCESS, false, selectedProcessId);
                    VirtualFreeEx(processHandle, allocate_adr_BA, 0, 0x8000);
                    allocate_adr_BA = IntPtr.Zero;
                }

                // Restore the original code
                m.WriteMemory(BA_ADR_RESULT, "bytes", originalcode_BA);

            }
        }



        public string ReadKeyFromFile()
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
        public string ReadWebhook()
        {
            string path = "urlwebhook.txt";
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


        public string webhookUrl = "https://discord.com/api/webhooks/1299969140152602635/2uSYRdtTXQm56hDex2R7MVXvx7JPQZY30lJu0bGCaOWt_vMIkermqlUg_eiu-j2GDDvq";
        public string UrlAlert = "";

        private async void YourCallingMethod()
        {
            saveID = m.ReadString(IDadr);
            string value = ReadKeyFromFile();

            var payload = new
            {
                avatar_url = "https://playserver.in.th/user_image/server_icon/2037910_306087278.gif",
                username = ServerName,
                content = $"ตัวละครที่ล็อคอิน: {label1.Text}\nID: {saveID}\nKEY: {value} "

            };

            // Call the SendWebhookAsync function
            bool success = await WebhookSender.SendWebhookAsync(webhookUrl, payload);

            if (success)
            {
                // MessageBox.Show("Webhook sent successfully!");
            }
            else
            {
                // MessageBox.Show("Failed to send webhook.");
            }
        }
        private async void GMAlert()
        {
            //  saveID = m.ReadString(IDadr);
            string value = ReadKeyFromFile();

            var payload = new
            {
                avatar_url = "https://playserver.in.th/user_image/server_icon/2043139_1132176446.gif",
                username = ServerName,
                content = $"ชื่อตัวละคร:{label1.Text}\nพบเจอGM: {GMFOUND}\nที่จอ{selectedProcessId}\nKEY: {value}\n "

            };

            // Call the SendWebhookAsync function
            bool success = await WebhookSender.SendWebhookAsync(UrlAlert, payload);

            if (success)
            {
                //   MessageBox.Show("Webhook sent successfully!");
            }
            else
            {
                //    MessageBox.Show("Failed to send webhook.");
            }
        }


        private void checkBox20_CheckedChanged(object sender, EventArgs e)
        {


        }

        private void button6_Click(object sender, EventArgs e)
        {
            button6.Enabled = false;
            button7.Enabled = true;

            StartMonitoringMonstersAsync();
            autoskillsstand = true;
            if (!backgroundWorker2.IsBusy)
            {
               // DisplayAlloc();
               // MonsterAlloc();
                backgroundWorker2.RunWorkerAsync();
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            button7.Enabled = false;
            button6.Enabled = true;
            autoskillsstand = false;
            m.WriteMemory(MONVIEW_ADR, "bytes", originalcode_Monview);
            m.WriteMemory(ITEMDROP_ADR_RESULT, "bytes", "8B 96 B8 03 00 00 83 C1 FE");
            if (backgroundWorker2.IsBusy)
            {
                backgroundWorker2.CancelAsync();
            }
        }

        private async void backgroundWorker2_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            while (autoskillsstand)
            {
                //await AddItemToListView();
                //await Task.Delay(100);

                //await ItemGet();
                //await Task.Delay(100);

                await Autobuff();
                await Task.Delay(100);

                await AutoSkills2();

                await Task.Delay(100);

            }
        }

        private void checkBox21_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox21.Checked)
            {
                m.WriteMemory(UNLOCK_ADR_RESULT, "bytes", "90 90");
            }
            else
            {
                m.WriteMemory(UNLOCK_ADR_RESULT, "bytes", "76 28");
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            _Inject_Fpet();
            _INJECT_FPET = true;

        }

        private void checkBox22_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox23_CheckedChanged(object sender, EventArgs e)
        {
            FixedSkill();
            _Inject_FixedSkill = !_Inject_FixedSkill;
        }

        private void backgroundWorker5_DoWork(object sender, DoWorkEventArgs e)
        {


            while (!backgroundWorker5.CancellationPending)
            {
                int Petcheck = m.Read2Byte("00D34B84");

                while (Petcheck == 0)
                {
                    Petcheck = m.Read2Byte("00D34B84");
                    m.WriteMemory("031F37EC", "byte", "63");
                    Thread.Sleep(20);
                    m.WriteMemory("031F37EC", "byte", "01");
                    Thread.Sleep(500);
                    Petcheck = m.Read2Byte("00D34B84");
                }
            }
        }

        List<int> frenzzy_tarList = new List<int>();

        private void button14_Click(object sender, EventArgs e)
        {
            int frenzzy_tar = m.ReadInt(TARGET_RING);
            if (frenzzy_tarList.Count > 8)
            {
                frenzzy_tarList.Clear();
            }
            if (frenzzy_tar != null)
            {
                // Add the value to the list
                frenzzy_tarList.Add(frenzzy_tar);
                MessageBox.Show($"frenzzy_tar{frenzzy_tarList.Count} saved: {frenzzy_tar}");
            }
            else
            {
                MessageBox.Show("frenzzy_tar must be greater than 1.");
            }
        }
        private void checkBox24_CheckedChanged(object sender, EventArgs e)
        {
            IntPtr processHandle = OpenProcess(PROCESS_ALL_ACCESS, false, selectedProcessId);
            Process ProcessbyID = Process.GetProcessById(selectedProcessId);
            allocate_adr_cutam = VirtualAllocEx(processHandle, IntPtr.Zero, 2048, MEM_COMMIT, PAGE_READWRITE);
            if (textBox8.Text != null && checkBox24.Checked)
            {
                m.WriteMemory("00FF8800", "float", textBox8.Text);
            }


            if (checkBox24.Checked)
            {
                textBox8.Enabled = false;
                IntPtr baseModuleadr = ProcessbyID.MainModule.BaseAddress;

                // Assembly code for fstp dword ptr [esp+38]
                byte[] assemblyCode = new byte[]
                {
                    0xD8,0x25,0x00,0x88,0xFF,0x00,0xD8,0x4C,0x24,0x10,0x8B,0xCE,
                    0xE9, 0x00, 0x00, 0x00, 0x00  // jmp 0x00000000 (to be replaced later)
                };
                //004DF357
                // Calculate the jump offset for the first jmp instruction
                int jumpOffset = (int)AOB_CUTAM + 6 - ((int)allocate_adr_cutam + assemblyCode.Length + 0);
                BitConverter.GetBytes(jumpOffset).CopyTo(assemblyCode, assemblyCode.Length - 4);

                // Write the initial assembly code to the allocated address
                m.WriteMemory(allocate_adr_cutam.ToString("X"), "bytes", BitConverter.ToString(assemblyCode).Replace('-', ' '));

                // Assembly code for jmp to allocate_adr with nop 2
                byte[] jmpCode = new byte[]
                {
                    0xE9, 0x00, 0x00, 0x00, 0x00,
                    0x90
                };

                // Calculate the jump offset for the second jmp instruction
                int jmpOffset2 = (int)allocate_adr_cutam - ((int)AOB_CUTAM + jmpCode.Length - 1);
                BitConverter.GetBytes(jmpOffset2).CopyTo(jmpCode, 1);  // Offset is from the next instruction (E9), not the beginning

                // Write the second jmp instruction to the specified address (004EBB27)
                m.WriteMemory(CUTAM_ADR_RESULT, "bytes", BitConverter.ToString(jmpCode).Replace('-', ' '));
            }
            else
            {
                m.WriteMemory(CUTAM_ADR_RESULT, "bytes", originalcode_cutam);
                textBox8.Enabled = true;
                if (allocate_adr_cutam != IntPtr.Zero)
                {
                    processHandle = OpenProcess(PROCESS_ALL_ACCESS, false, selectedProcessId);
                    VirtualFreeEx(processHandle, allocate_adr_cutam, 0, 0x8000);
                    allocate_adr_cutam = IntPtr.Zero;
                }
            }

        }

        private async void backgroundWorker6_DoWork(object sender, DoWorkEventArgs e)
        {
            while (!backgroundWorker6.CancellationPending)
            {
                try
                {
                    await AddItemToListView();
                    //AddMonsterList();
                    Thread.Sleep(10);

                }
                catch (Exception ex)
                {
                    return;
                }
            }
        }

        public void AllocNolimit()
        {
            IntPtr processHandle = OpenProcess(PROCESS_ALL_ACCESS, false, selectedProcessId);
            Process ProcessbyID = Process.GetProcessById(selectedProcessId);
            allocate_adr_Nolimit2 = VirtualAllocEx(processHandle, IntPtr.Zero, 2048, MEM_COMMIT, PAGE_READWRITE);
            if (checkBox28.Checked)
            {
                m.FreezeValue("00fd4567,140", "int", "0");
                IntPtr baseModuleadr = ProcessbyID.MainModule.BaseAddress;

                // Assembly code for fstp dword ptr [esp+38]
                byte[] assemblyCode = new byte[]
                {
                    0x8B ,0x86 ,0x14 ,0x01 ,0x00 ,0x00 ,0x89 ,0x35 ,0x67 ,0x45 ,0xFD ,0x00,
                    0xE9, 0x00, 0x00, 0x00, 0x00  // jmp 0x00000000 (to be replaced later)
                };
                //004DF357
                // Calculate the jump offset for the first jmp instruction
                int jumpOffset = (int)AOB_NOLIMIT + 0x33 + 0x06 - ((int)allocate_adr_Nolimit2 + assemblyCode.Length + 0);
                BitConverter.GetBytes(jumpOffset).CopyTo(assemblyCode, assemblyCode.Length - 4);

                // Write the initial assembly code to the allocated address
                m.WriteMemory(allocate_adr_Nolimit2.ToString("X"), "bytes", BitConverter.ToString(assemblyCode).Replace('-', ' '));

                // Assembly code for jmp to allocate_adr with nop 2
                byte[] jmpCode = new byte[]
                {
                    0xE9, 0x00, 0x00, 0x00, 0x00,
                    0x90,

                };

                // Calculate the jump offset for the second jmp instruction
                int jmpOffset2 = (int)allocate_adr_Nolimit2 - ((int)AOB_NOLIMIT + 0x34 + jmpCode.Length - 1);
                BitConverter.GetBytes(jmpOffset2).CopyTo(jmpCode, 1);  // Offset is from the next instruction (E9), not the beginning

                // Write the second jmp instruction to the specified address (004EBB27)
                m.WriteMemory(NOLIMIT_ADR_RESULT2, "bytes", BitConverter.ToString(jmpCode).Replace('-', ' '));
            }
            else
            {
                m.WriteMemory(NOLIMIT_ADR_RESULT2, "bytes", originalcode_cutam);
                textBox8.Enabled = true;
                if (allocate_adr_Nolimit2 != IntPtr.Zero)
                {
                    processHandle = OpenProcess(PROCESS_ALL_ACCESS, false, selectedProcessId);
                    VirtualFreeEx(processHandle, allocate_adr_Nolimit2, 0, 0x8000);
                    allocate_adr_Nolimit2 = IntPtr.Zero;
                }
            }

        }
        private void checkBox28_CheckedChanged(object sender, EventArgs e)
        {
            AllocNolimit();
            IntPtr processHandle = OpenProcess(PROCESS_ALL_ACCESS, false, selectedProcessId);
            Process ProcessbyID = Process.GetProcessById(selectedProcessId);
            allocate_adr_Nolimit = VirtualAllocEx(processHandle, IntPtr.Zero, 2048, MEM_COMMIT, PAGE_READWRITE);
            if (checkBox28.Checked)
            {
                //   
                IntPtr baseModuleadr = ProcessbyID.MainModule.BaseAddress;

                // Assembly code for fstp dword ptr [esp+38]
                byte[] assemblyCode = new byte[]
                {
                    0xC7,0x81,0xC0,0x01,0x00,0x00,0x20,0xBC,0xBE,0x4C,
                    0xE9, 0x00, 0x00, 0x00, 0x00  // jmp 0x00000000 (to be replaced later)
                };
                //004DF357
                // Calculate the jump offset for the first jmp instruction
                int jumpOffset = (int)AOB_NOLIMIT + 0xA - ((int)allocate_adr_Nolimit + assemblyCode.Length + 0);
                BitConverter.GetBytes(jumpOffset).CopyTo(assemblyCode, assemblyCode.Length - 4);

                // Write the initial assembly code to the allocated address
                m.WriteMemory(allocate_adr_Nolimit.ToString("X"), "bytes", BitConverter.ToString(assemblyCode).Replace('-', ' '));

                // Assembly code for jmp to allocate_adr with nop 2
                byte[] jmpCode = new byte[]
                {
                    0xE9, 0x00, 0x00, 0x00, 0x00,
                    0x0F ,0x1F ,0x44 ,0x00 ,0x00
                };

                // Calculate the jump offset for the second jmp instruction
                int jmpOffset2 = (int)allocate_adr_Nolimit - ((int)AOB_NOLIMIT + jmpCode.Length - 5);
                BitConverter.GetBytes(jmpOffset2).CopyTo(jmpCode, 1);  // Offset is from the next instruction (E9), not the beginning

                // Write the second jmp instruction to the specified address (004EBB27)
                m.WriteMemory(NOLIMIT_ADR_RESULT, "bytes", BitConverter.ToString(jmpCode).Replace('-', ' '));
            }
            else
            {
                m.WriteMemory(NOLIMIT_ADR_RESULT, "bytes", "C7 81 80 01 00 00 00 00 A0 40");
                if (allocate_adr_Nolimit != IntPtr.Zero)
                {
                    processHandle = OpenProcess(PROCESS_ALL_ACCESS, false, selectedProcessId);
                    VirtualFreeEx(processHandle, allocate_adr_Nolimit, 0, 0x8000);
                    allocate_adr_Nolimit = IntPtr.Zero;
                }
            }

        }

        private void checkBox29_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox29.Checked)
            {
                IntPtr processHandle = OpenProcess(PROCESS_ALL_ACCESS, false, selectedProcessId);
                Process ProcessbyID = Process.GetProcessById(selectedProcessId);
                allocate_adr_BA = VirtualAllocEx(processHandle, IntPtr.Zero, 2048, MEM_COMMIT, PAGE_READWRITE);
                getadr = allocate_adr_BA.ToString("x");

                IntPtr baseModuleadr = ProcessbyID.MainModule.BaseAddress;

                // Assembly code for fstp dword ptr [esp+38]
                byte[] assemblyCode = new byte[]
                {
                    0x83, 0x7F, 0x44, 0x02,      // cmp dword ptr [edi+44],01
                    0x74, 0x00,                 // je (short jump), to be replaced with jumpOffset1
                    0x0F, 0x1F, 0x40, 0x00,     // nop
                    0xE9, 0x00, 0x00, 0x00, 0x00, // jmp, to be replaced with jumpOffset2
                    0xC7, 0x47, 0x44, 0x00, 0x00, 0x00, 0x00, // mov [edi+48], 3
                    0xC7, 0x47, 0x48, 0x01, 0x00, 0x00, 0x00, // mov [edi+48], 3
                    0xE9, 0x00, 0x00, 0x00, 0x00, // jmp, to be replaced with jumpOffset3
                    0xEB, 0x00,                 // jmp short backward (loop), to be replaced with jumpOffset4
                    0x0F, 0x1F, 0x44, 0x00, 0x00 // nop
                };

                // Calculate offsets dynamically
                int jumpOffset1 = (int)allocate_adr_BA + 0x0F - ((int)allocate_adr_BA + 6); // Offset for `je`, replace at offset 5
                int jumpOffset2 = (int)AOB_BA + 0xA - ((int)allocate_adr_BA + 15);          // Offset for the first `jmp`, replace at offset 11
                int jumpOffset3 = (int)AOB_BA + 0xA - ((int)allocate_adr_BA + 34);          // Offset for the second `jmp`, replace at offset 23
                int jumpOffset4 = (int)allocate_adr_BA - ((int)allocate_adr_BA + 36);       // Short backward jump to `allocate_adr_BA`, replace at offset 28

                // Update the jump offsets in the assembly code
                assemblyCode[5] = (byte)(jumpOffset1 & 0xFF); // Short jump offset for `je` instruction, which only takes 1 byte
                BitConverter.GetBytes(jumpOffset2).CopyTo(assemblyCode, 11); // Place the offset for the first `jmp`
                BitConverter.GetBytes(jumpOffset3).CopyTo(assemblyCode, 30); // Place the offset for the second `jmp`
                assemblyCode[35] = (byte)(jumpOffset4 & 0xFF); // Short jump offset for `EB`, which only takes 1 byte

                // Now you can write 'assemblyCode' to the allocated memory and proceed with the injection

                // Write the initial assembly code to the allocated address
                m.WriteMemory(allocate_adr_BA.ToString("X"), "bytes", BitConverter.ToString(assemblyCode).Replace('-', ' '));



                // Assembly code for jmp to allocate_adr with nop 2
                jmpCodemy = new byte[]
                {
                    0xE9, 0x00, 0x00, 0x00, 0x00,
                    0x0F, 0x1F, 0x44

                };

                // Calculate the jump offset for the second jmp instruction
                int jmpOffset3 = (int)allocate_adr_BA - ((int)AOB_BA + jmpCodemy.Length - 3);
                BitConverter.GetBytes(jmpOffset3).CopyTo(jmpCodemy, 1);  // Offset is from the next instruction (E9), not the beginning

                m.WriteMemory(BA_ADR_RESULT, "bytes", BitConverter.ToString(jmpCodemy).Replace('-', ' '));
            }
            else
            {

                if (allocate_adr_BA != IntPtr.Zero)
                {
                    IntPtr processHandle = OpenProcess(PROCESS_ALL_ACCESS, false, selectedProcessId);
                    VirtualFreeEx(processHandle, allocate_adr_BA, 0, 0x8000);
                    allocate_adr_BA = IntPtr.Zero;
                }

                // Restore the original code
                m.WriteMemory(BA_ADR_RESULT, "bytes", originalcode_BA);



            }


        }

        private void checkBox22_CheckedChanged_1(object sender, EventArgs e)
        {
            m.WriteMemory(FASTLE_ADR_RESULT, "float", "-1");
        }

        private void checkBox30_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox30.Checked)
            {
                IntPtr processHandle = OpenProcess(PROCESS_ALL_ACCESS, false, selectedProcessId);
                Process ProcessbyID = Process.GetProcessById(selectedProcessId);
                allocate_adr_BA = VirtualAllocEx(processHandle, IntPtr.Zero, 2048, MEM_COMMIT, PAGE_READWRITE);
                getadr = allocate_adr_BA.ToString("x");

                IntPtr baseModuleadr = ProcessbyID.MainModule.BaseAddress;

                // Assembly code for fstp dword ptr [esp+38]
                byte[] assemblyCode = new byte[]
                {
                    0x83, 0x7F, 0x44, 0x01,      // cmp dword ptr [edi+44],01
                    0x74, 0x00,                 // je (short jump), to be replaced with jumpOffset1
                    0x0F, 0x1F, 0x40, 0x00,     // nop
                    0xE9, 0x00, 0x00, 0x00, 0x00, // jmp, to be replaced with jumpOffset2
                    0xC7, 0x47, 0x44, 0x03, 0x00, 0x00, 0x00, // mov [edi+48], 3
                    0xC7, 0x47, 0x48, 0x03, 0x00, 0x00, 0x00, // mov [edi+48], 3
                    0xE9, 0x00, 0x00, 0x00, 0x00, // jmp, to be replaced with jumpOffset3
                    0xEB, 0x00,                 // jmp short backward (loop), to be replaced with jumpOffset4
                    0x0F, 0x1F, 0x44, 0x00, 0x00 // nop
                };

                // Calculate offsets dynamically
                int jumpOffset1 = (int)allocate_adr_BA + 0x0F - ((int)allocate_adr_BA + 6); // Offset for `je`, replace at offset 5
                int jumpOffset2 = (int)AOB_BA + 0xA - ((int)allocate_adr_BA + 15);          // Offset for the first `jmp`, replace at offset 11
                int jumpOffset3 = (int)AOB_BA + 0xA - ((int)allocate_adr_BA + 34);          // Offset for the second `jmp`, replace at offset 23
                int jumpOffset4 = (int)allocate_adr_BA - ((int)allocate_adr_BA + 36);       // Short backward jump to `allocate_adr_BA`, replace at offset 28

                // Update the jump offsets in the assembly code
                assemblyCode[5] = (byte)(jumpOffset1 & 0xFF); // Short jump offset for `je` instruction, which only takes 1 byte
                BitConverter.GetBytes(jumpOffset2).CopyTo(assemblyCode, 11); // Place the offset for the first `jmp`
                BitConverter.GetBytes(jumpOffset3).CopyTo(assemblyCode, 30); // Place the offset for the second `jmp`
                assemblyCode[35] = (byte)(jumpOffset4 & 0xFF); // Short jump offset for `EB`, which only takes 1 byte

                // Now you can write 'assemblyCode' to the allocated memory and proceed with the injection

                // Write the initial assembly code to the allocated address
                m.WriteMemory(allocate_adr_BA.ToString("X"), "bytes", BitConverter.ToString(assemblyCode).Replace('-', ' '));



                // Assembly code for jmp to allocate_adr with nop 2
                jmpCodemy = new byte[]
                {
                    0xE9, 0x00, 0x00, 0x00, 0x00,
                    0x0F, 0x1F, 0x44

                };

                // Calculate the jump offset for the second jmp instruction
                int jmpOffset3 = (int)allocate_adr_BA - ((int)AOB_BA + jmpCodemy.Length - 3);
                BitConverter.GetBytes(jmpOffset3).CopyTo(jmpCodemy, 1);  // Offset is from the next instruction (E9), not the beginning

                m.WriteMemory(BA_ADR_RESULT, "bytes", BitConverter.ToString(jmpCodemy).Replace('-', ' '));
            }
            else
            {
                if (allocate_adr_BA != IntPtr.Zero)
                {
                    IntPtr processHandle = OpenProcess(PROCESS_ALL_ACCESS, false, selectedProcessId);
                    VirtualFreeEx(processHandle, allocate_adr_BA, 0, 0x8000);
                    allocate_adr_BA = IntPtr.Zero;
                }

                // Restore the original code
                m.WriteMemory(BA_ADR_RESULT, "bytes", originalcode_BA);

            }
        }

        private void LoadListView12FromJSON(ListView listView12, string fileName)
        {
            if (!File.Exists(fileName))
            {
                return;
            }

            List<ITEM_COLLECT> list = JsonConvert.DeserializeObject<List<ITEM_COLLECT>>(File.ReadAllText(fileName));

            listView12.Items.Clear(); // Optional: Clear existing items if needed

            foreach (ITEM_COLLECT dataItem in list)
            {
                ListViewItem listViewItem = new ListViewItem(); // Create a new ListViewItem
                listViewItem.SubItems.Add(""); // Add empty subitems for columns that are not used
                listViewItem.SubItems.Add(dataItem.SubItem2); // Set SubItems[2]
                listViewItem.SubItems.Add(""); // Add an empty subitem for SubItems[3] if applicable
                listView12.Items.Add(listViewItem);
            }
        }


        private void button16_Click(object sender, EventArgs e)
        {
            // Ensure there is a selected item
            if (listView11.SelectedItems.Count > 0)
            {
                foreach (ListViewItem item in listView11.SelectedItems)
                {
                    // Create a new ListViewItem with the same text and subitems
                    ListViewItem newItem = (ListViewItem)item.Clone();

                    // Add the new item to listView12
                    listView12.Items.Add(newItem);
                    SaveListView12ToJSON(listView12, "ITEM_COLLECT.json");

                }
            }
            else
            {
                MessageBox.Show("Please select an item in listView11 to copy.", "No item selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private bool ANTICHAT = false;

        private void checkBox32_CheckedChanged(object sender, EventArgs e)
        {
            ANTICHAT = !ANTICHAT;

            if (ANTICHAT == true)
            {
                m.WriteMemory(ANTICHAT_ADR_RESULT, "bytes", "C7 86 94 01 00 00 00 00 80 BF");
            }
            else if (ANTICHAT == false)
            {
                m.WriteMemory(ANTICHAT_ADR_RESULT, "bytes", "C7 86 94 01 00 00 00 00 00 41");

            }
        }
        private void button17_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox7.Text))  // Check if the textbox is not empty
            {
                ListViewItem item = new ListViewItem(); // Create a new ListViewItem

                // Ensure that SubItems[2] exists by adding SubItems as necessary
                item.SubItems.Add(""); // SubItem[1]
                item.SubItems.Add(textBox7.Text); // SubItem[2] is where you add the text from textBox7

                listView12.Items.Add(item); // Add the item to listView12
                SaveListView12ToJSON(listView12, "ITEM_COLLECT.json");
            }
        }

        private void button18_Click(object sender, EventArgs e)
        {
            // Check if any items are selected
            if (listView12.SelectedItems.Count > 0)
            {
                // Loop through the selected items and remove them
                foreach (ListViewItem item in listView12.SelectedItems)
                {
                    listView12.Items.Remove(item);
                    SaveListView12ToJSON(listView12, "ITEM_COLLECT.json");
                }
            }
            else
            {
                MessageBox.Show("Please select an item to remove."); // Optional: Notify the user if no item is selected
            }
        }

        private void listView12_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listView12_ControlAdded(object sender, ControlEventArgs e)
        {
            SaveListView12ToJSON(listView12, "ITEM_COLLECT.json");
        }


        private void listView12_AfterLabelEdit_1(object sender, LabelEditEventArgs e)
        {
            // Check if the item is being edited (e.Item is not null)
            if (e.Item >= 0 && e.Label != null)
            {
                // Get the edited ListViewItem
                ListViewItem item = listView12.Items[e.Item];

                // Update the subitem text based on the edited label
                item.SubItems[2].Text = e.Label;

                // Save the updated listView12 to a JSON file
                SaveListView12ToJSON(listView12, "ITEM_COLLECT.json");
            }
        }

        private bool Get = false;
        private void button19_Click(object sender, EventArgs e)
        {
            if (Get == false && selectedProcessId != null)
            {
                button6.Enabled = true;
                checkBox13.Enabled = true;
                INJECT_GET_SKILL();
                INJECT_GET_BUFF();
                Get = true;
            }
            else
            {
                button19.Enabled = false;
            }
        }

        private void ClearAllListViews()
        {
            try
            {
                for (int i = 1; i <= 10; i++)
                {
                    // Construct the ListView name dynamically (e.g., listView1, listView2, etc.)
                    string listViewName = $"listView{i}";

                    // Find the ListView control by its name
                    ListView listView = FindControlRecursive(this, listViewName) as ListView;

                    if (listView != null)
                    {
                        // Clear the items in the ListView
                        listView.Items.Clear();
                        positionCounter = 1;
                        // MessageBox.Show($"Cleared items from {listViewName}");
                    }
                    else
                    {
                        //MessageBox.Show($"ListView {listViewName} not found");
                    }
                }
            }
            catch (Exception ex)
            {
                // MessageBox.Show("Error clearing items: " + ex.Message);
            }
        }

        // Helper method to recursively find a control by name
        private Control FindControlRecursive(Control parent, string name)
        {
            if (parent.Name == name)
            {
                return parent;
            }

            foreach (Control child in parent.Controls)
            {
                Control result = FindControlRecursive(child, name);
                if (result != null)
                {
                    return result;
                }
            }

            return null;
        }

        private void btnClearAll_Click(object sender, EventArgs e)
        {
            ClearAllListViews();
        }
        private void button20_Click(object sender, EventArgs e)
        {

            OpenSettingsForm();
        }

        public bool _Inject_FixedSkill = true;

        public UIntPtr Mob_HP { get => Mob_HP2; set => Mob_HP2 = value; }
        public UIntPtr Mob_HP1 { get => Mob_HP2; set => Mob_HP2 = value; }
        public UIntPtr Mob_HP2 { get => mob_HP; set => mob_HP = value; }

        public void FixedSkill()
        {
            if (_Inject_FixedSkill == true)
            {
                IntPtr processHandle = OpenProcess(PROCESS_ALL_ACCESS, false, selectedProcessId);
                Process ProcessbyID = Process.GetProcessById(selectedProcessId);
                allocate_adr_BA = VirtualAllocEx(processHandle, IntPtr.Zero, 2048, MEM_COMMIT, PAGE_READWRITE);
                getadr = allocate_adr_BA.ToString("x");

                IntPtr baseModuleadr = ProcessbyID.MainModule.BaseAddress;

                // Assembly code for fstp dword ptr [esp+38]
                byte[] assemblyCode = new byte[]
                {
                    0x83, 0x7F, 0x44, 0x01,      // cmp dword ptr [edi+44],01
                    0x74, 0x00,                 // je (short jump), to be replaced with jumpOffset1
                    0x0F, 0x1F, 0x40, 0x00,     // nop
                    0xE9, 0x00, 0x00, 0x00, 0x00, // jmp, to be replaced with jumpOffset2
                    0xC7, 0x47, 0x48, 0x03, 0x00, 0x00, 0x00, // mov [edi+48], 3
                    0xE9, 0x00, 0x00, 0x00, 0x00, // jmp, to be replaced with jumpOffset3
                    0xEB, 0x00,                 // jmp short backward (loop), to be replaced with jumpOffset4
                    0x0F, 0x1F, 0x44, 0x00, 0x00 // nop
                };

                // Calculate offsets dynamically
                int jumpOffset1 = (int)allocate_adr_BA + 0x0F - ((int)allocate_adr_BA + 6); // Offset for `je`, replace at offset 5
                int jumpOffset2 = (int)AOB_BA + 0xA - ((int)allocate_adr_BA + 15);          // Offset for the first `jmp`, replace at offset 11
                int jumpOffset3 = (int)AOB_BA + 0xA - ((int)allocate_adr_BA + 27);          // Offset for the second `jmp`, replace at offset 23
                int jumpOffset4 = (int)allocate_adr_BA - ((int)allocate_adr_BA + 29);       // Short backward jump to `allocate_adr_BA`, replace at offset 28

                // Update the jump offsets in the assembly code
                assemblyCode[5] = (byte)(jumpOffset1 & 0xFF); // Short jump offset for `je` instruction, which only takes 1 byte
                BitConverter.GetBytes(jumpOffset2).CopyTo(assemblyCode, 11); // Place the offset for the first `jmp`
                BitConverter.GetBytes(jumpOffset3).CopyTo(assemblyCode, 23); // Place the offset for the second `jmp`
                assemblyCode[28] = (byte)(jumpOffset4 & 0xFF); // Short jump offset for `EB`, which only takes 1 byte

                // Now you can write 'assemblyCode' to the allocated memory and proceed with the injection

                // Write the initial assembly code to the allocated address
                m.WriteMemory(allocate_adr_BA.ToString("X"), "bytes", BitConverter.ToString(assemblyCode).Replace('-', ' '));



                // Assembly code for jmp to allocate_adr with nop 2
                jmpCodemy = new byte[]
                {
                    0xE9, 0x00, 0x00, 0x00, 0x00,
                    0x0F, 0x1F, 0x44

                };

                // Calculate the jump offset for the second jmp instruction
                int jmpOffset3 = (int)allocate_adr_BA - ((int)AOB_BA + jmpCodemy.Length - 3);
                BitConverter.GetBytes(jmpOffset3).CopyTo(jmpCodemy, 1);  // Offset is from the next instruction (E9), not the beginning

                m.WriteMemory(BA_ADR_RESULT, "bytes", BitConverter.ToString(jmpCodemy).Replace('-', ' '));

            }
            else
            {

                if (allocate_adr_BA != IntPtr.Zero)
                {
                    IntPtr processHandle = OpenProcess(PROCESS_ALL_ACCESS, false, selectedProcessId);
                    VirtualFreeEx(processHandle, allocate_adr_BA, 0, 0x8000);
                    allocate_adr_BA = IntPtr.Zero;
                }

                // Restore the original code
                m.WriteMemory(BA_ADR_RESULT, "bytes", originalcode_BA);



            }

        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!_INJECT_PET)
            {
                INJECT_PET();
            }
            comboBox4.Invoke((Action)delegate
            {
                int num2 = int.Parse(((ComboBoxItem)comboBox4.SelectedItem).Value);
                m.FreezeValue("00FAFA00", "2bytes", num2.ToString());
            });

        }

        private void button21_Click(object sender, EventArgs e)
        {
        }

        private void button22_Click(object sender, EventArgs e)
        {
            listView11.Items.Clear();
        }

        private void SaveUrlWebhook(string key)
        {
            string path = "urlwebhook.txt";
            try
            {
                File.WriteAllText(path, key);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving the key: " + ex.Message);
            }
        }

        private void button21_Click_1(object sender, EventArgs e)
        {

        }

        private void BTN_START_Click(object sender, EventArgs e)
        {


            Guildselected = textBox9.Text;
            textBox9.Enabled = false;
            SaveUrlWebhook(textBox11.Text);
            BTN_START.Enabled = false;
            BTN_STOP.Enabled = true;
            StartMonitoringPlayerAsync();

        }

        private void BTN_STOP_Click(object sender, EventArgs e)
        {
            textBox9.Enabled = true;
            BTN_START.Enabled = true;
            BTN_STOP.Enabled = false;
            StopMonitoringPlayer();
        }

        private void hScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            m.WriteMemory("00FE1000", "float", hScrollBar1.Value.ToString());

        }
    }

}
