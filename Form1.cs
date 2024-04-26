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

namespace Kappa
{

    public partial class Form1 : Form
    {
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
        public string ServerName = "Ran-Next";

        public string FastZoom = "031F3E5C";

        public string AOE_adr = "";

        public string LongRange_adr = "";

        public string NameAdr = "00B7E118";

        public long AOB_AOE;
        public long AOB_PATH;
        public long AOB_BA;
        public long AOB_LR;
        public long AOB_Superpot;
        public long AOB_WH;
        public long AOB_HT;
        public long AOB_DRONE;
        public long AOB_ASPD;
        public long AOB_CUTAM;
        public long AOB_ANTIAFK;
        public long AOB_PETBP;
        public long AOB_RUN1;
        public long AOB_RUN2;
        public long AOB_RUN3;
        public long AOB_RUN4;
        public long AOB_RUN5;
        public long AOB_RUN6;
        public long AOB_RUN7;
        public long AOB_MONVIEW;

        public string MONVIEW_ADR_RESULT;
        public string RUN1_ADR_RESULT;
        public string RUN2_ADR_RESULT;
        public string RUN3_ADR_RESULT;
        public string RUN4_ADR_RESULT;
        public string RUN5_ADR_RESULT;
        public string RUN6_ADR_RESULT;
        public string RUN7_ADR_RESULT;
        public string RUN8_ADR_RESULT;
        public string RUN9_ADR_RESULT;
        public string PETBP_ADR_RESULT;
        public string CUTAM_ADR_RESULT;
        public string ANTIAFK_ADR_RESULT;
        public string ASPD_ADR_RESULT;
        public string HT_ADR_RESULT;
        public string WH_ADR_RESULT;
        public string AOE_ADR_RESULT;
        public string LR_ADR_RESULT;
        public string BA_ADR_RESULT;
        public string PATH_ADR_RESULT;
        public string SUPERPOT_ADR_RESULT;
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

        public string IDadr = "00B7E338";

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

        public string CurrentX = "00B80AA0";

        public string CurrentY = "00B80AA0+4";

        public string CurrentZ = "00B80AA0+8";

        public string ZoomAdr = "031F3EF4";

        public string AngleAdr = "031F3ED4";

        public string gotoX = "00B80AE4";

        public string gotoY = "00B80AE4+4";

        public string gotoZ = "00B80AE4+8";
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
        public string prevskill1_adr = "00B80C54";

        public string prevskill2_adr = "00B80C56";

        public string Skilluse1_adr = "00B80C50";

        public string Skilluse2_adr = "00B80C52";

        public string forceattack_adr = "MiniA.exe+780CFC";

        public string actioncheck = "MiniA.exe+780D10";

        public string MoveCheck = "MiniA.exe+780BB4";

        /// <summary>
        /// Autoskill END ///////////////
        /// </summary>

        public string Superpot = "007757B8";
        public string Superpot2 = "007757D6";
        public string Superpot3 = "007757F4";


        public string HpFreeze_1 = "00D319F8";

        public string HpFreeze_2 = "00D319F8+2";

        public string Antislide = "004324D8";

        public string Wallhack = "005E2FC1";

        public string ASPD_adr = "MiniA.exe+53C524";

        public bool autoskillsstand = true;

        private int selectedProcessId = -1;

        private int selectedProcessId2 = -1;


        public Form1()
        {
            timer.Tick += Timer_Tick;
            timer.Interval = 10000; // 10 seconds
            InitializeComponent();
            backgroundWorker1.WorkerSupportsCancellation = true;
            backgroundWorker5.WorkerSupportsCancellation = true;
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

        private IntPtr allocate_adr_aoe;
        private IntPtr allocate_adr_Path;
        private IntPtr allocate_adr_Monview;
        private IntPtr allocate_adr_BA;
        private void Form1_Load(object sender, EventArgs e)
        {
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


        private async void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {


            MessageBox.Show("Scaning address..");
            m.OpenProcess(int.Parse(comboBox1.Text));
            int num = 20;
            byte[] array = m.ReadBytes(NameAdr, num);
            if (array != null)
            {
                string @string = Encoding.GetEncoding(874).GetString(array);
                label1.Text = @string + " " + comboBox1.Text;
            }
            // Check for null before converting to string


            selectedProcessId = int.Parse(comboBox1.SelectedItem.ToString());

            IEnumerable<long> AoB_Scan_AOE = await m.AoBScan("D8 5C 24 0C DF E0 F6 C4 05 7A 06 B8", false, true);
            IEnumerable<long> AoB_Scan_LR = await m.AoBScan("D9 5C 24 38 FF 52 10", false, true);
            IEnumerable<long> AoB_Scan_BA = await m.AoBScan("83 7F 44 01 0F 85 6? 01 00 00", false, true);
            IEnumerable<long> AoB_Scan_PATH = await m.AoBScan("39 5C 24 28 74 ??", false, true);
            IEnumerable<long> AoB_Scan_Superpot = await m.AoBScan("6A 02 52 83 CE FF", false, true);
            IEnumerable<long> AoB_Scan_WallHack = await m.AoBScan("74 23 8B 4C 24 34", false, true);
            IEnumerable<long> AoB_Scan_HitTru = await m.AoBScan("D9 44 24 44 8B 40 08", false, true);
            IEnumerable<long> Aob_Scan_ASPD = await m.AoBScan("00 00 96 45 49", false, true);
            IEnumerable<long> AoB_Scan_Drone = await m.AoBScan("8B 96 C4 00 00 00 89 96 C8 00 00 00", false, true);
            IEnumerable<long> AoB_Scan_CutAnimate = await m.AoBScan("D8 4C 24 10 8B CE", false, true);
            IEnumerable<long> AoB_Scan_ANTI_AFK = await m.AoBScan("D8 1D ?? ?? ?? 00 DF E0 F6 C4 05 7A ?? 68 ?? ?? ?? ?? C7 81 A? ??", false, true);
            IEnumerable<long> AoB_Scan_PETBP = await m.AoBScan("0F ?? ?? ?? 00 00 E8 64 8C F5 FF 33 C9 66 8B 4F 1E", false, true);
            var AoB_Scan_Monview = await m.AoBScan("8B 81 08 14 00 00", false, true);

            IEnumerable<long> AoB_Scan_Run1 = await m.AoBScan("0F ?? ?? ?? ?? ?? 8B 5C 24 34 8B 6C 24 3C 8B C3", false, true);
            IEnumerable<long> AoB_Scan_Run2 = await m.AoBScan("74 ?? ?? C9 8D 9E 14 3A 00 00", false, true);
            IEnumerable<long> AoB_Scan_Run3 = await m.AoBScan("74 ?? ?? 74 24 10 8B 7C 24 14", false, true);
            IEnumerable<long> AoB_Scan_Run4 = await m.AoBScan("F6 C3 0E 74 ??", false, true);
            IEnumerable<long> AoB_Scan_Run5 = await m.AoBScan("74 ?? E8 ?? ?? ?? 00 8B C8 E8 ?? ?? ?? 00 8D 8E 3C 2C 00 00 E8 ?? ?? ?? ?? 8B 86 F8 2A 00 00 8B 94 24 A0 00 00 00", false, true);
            IEnumerable<long> AoB_Scan_Run7 = await m.AoBScan("39 A8 C8 03 00 00 74 ?? 55", false, true);


            //0F ?? ?? ?? 00 00 E8 64 8C F5 FF 33 C9 66 8B 4F 1E
            AOB_MONVIEW = AoB_Scan_Monview.FirstOrDefault();
            AOB_PETBP = AoB_Scan_PETBP.FirstOrDefault();
            AOB_RUN1 = AoB_Scan_Run1.FirstOrDefault();
            AOB_RUN2 = AoB_Scan_Run2.FirstOrDefault();
            AOB_RUN3 = AoB_Scan_Run3.FirstOrDefault();
            AOB_RUN4 = AoB_Scan_Run4.FirstOrDefault();
            AOB_RUN5 = AoB_Scan_Run5.FirstOrDefault();
            AOB_RUN7 = AoB_Scan_Run7.FirstOrDefault();
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
            MONVIEW_ADR_RESULT = AOB_MONVIEW.ToString("x");
            PETBP_ADR_RESULT = AOB_PETBP.ToString("x");
            RUN1_ADR_RESULT = AOB_RUN1.ToString("x");
            RUN2_ADR_RESULT = AOB_RUN2.ToString("x");
            RUN3_ADR_RESULT = AOB_RUN3.ToString("x");
            RUN4_ADR_RESULT = (AOB_RUN4 + 0x03).ToString("x");
            RUN5_ADR_RESULT = AOB_RUN5.ToString("x");
            RUN6_ADR_RESULT = (AOB_RUN5 - 0x09).ToString("x");
            RUN7_ADR_RESULT = (AOB_RUN7 + 0x06).ToString("x");
            ANTIAFK_ADR_RESULT = (AOB_ANTIAFK + 0x02).ToString("x");
            CUTAM_ADR_RESULT = AOB_CUTAM.ToString("x");
            ASPD_ADR_RESULT = AOB_ASPD.ToString("x");
            DRONE_ADR_RESULT = (AOB_DRONE - 0xB).ToString("x");
            HT_ADR_RESULT = AOB_HT.ToString("x");
            WH_ADR_RESULT = AOB_WH.ToString("x");
            SUPERPOT_ADR_RESULT = AOB_Superpot.ToString("x");
            AOE_ADR_RESULT = AOB_AOE.ToString("x");
            LR_ADR_RESULT = AOB_LR.ToString("x");
            BA_ADR_RESULT = AOB_BA.ToString("x");
            PATH_ADR_RESULT = AOB_PATH.ToString("x");
            MessageBox.Show("All Done");
            m.WriteMemory(ANTIAFK_ADR_RESULT, "bytes", "12 00 FD 00");
            m.WriteMemory("00FD0012", "float", "-1");
            m.WriteMemory(PETBP_ADR_RESULT, "bytes", "90 90 90 90 90 90"); //pet bypass

        }

        public void RunActive()
        {
            m.WriteMemory(RUN1_ADR_RESULT, "bytes", "90 90 90 90 90 90");
            m.WriteMemory(RUN2_ADR_RESULT, "bytes", "eb 3c");
            m.WriteMemory(RUN3_ADR_RESULT, "bytes", "90 90");
            m.WriteMemory(RUN4_ADR_RESULT, "bytes", "90 90");
            m.WriteMemory(RUN5_ADR_RESULT, "bytes", "eb 6f");
            m.WriteMemory(RUN6_ADR_RESULT, "bytes", "90 90 90 90 90 90");
            m.WriteMemory(RUN7_ADR_RESULT, "byte", "eb");

        }
        public void RunDeactive()
        {
            m.WriteMemory(RUN1_ADR_RESULT, "bytes", "0F 84 A6 02 00 00");
            m.WriteMemory(RUN2_ADR_RESULT, "bytes", "74 3c");
            m.WriteMemory(RUN3_ADR_RESULT, "bytes", "74 5c");
            m.WriteMemory(RUN4_ADR_RESULT, "bytes", "74 7d");
            m.WriteMemory(RUN5_ADR_RESULT, "bytes", "74 6f");
            m.WriteMemory(RUN6_ADR_RESULT, "bytes", "0F 85 F1 00 00 00");
            m.WriteMemory(RUN7_ADR_RESULT, "byte", "74");

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
                m.WriteMemory(FastZoom, "float", "200");
                m.WriteMemory(DRONE_ADR_RESULT, "byte", "EB");
            }
            else
            {
                //  m.WriteMemory(Drone_adr, "float", "205");
                m.WriteMemory(FastZoom, "float", "80");
                m.WriteMemory(DRONE_ADR_RESULT, "byte", "75");

            }


        }
        string originalcode_cutam = "D8 4C 24 10 8B CE";
        string originalcode_LR = "D9 5C 24 38 FF 52 10";
        string originalcode_ALE = "D8 5C 24 0C DF E0 F6 C4 05 7A 06 B8";
        string originalcode_Monview = "8B 81 18 0C 00 00";
        string originalcode_Path = "39 5C 24 28 74 23";
        string originalcode_BA = "83 7F 44 01 0F 85 64 01";
        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (textBox2.Text != null && checkBox2.Checked)
            {
                m.WriteMemory("00FF5000", "float", textBox2.Text);
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
                    0xD8,0x25,0x00,0x50,0xFF,0x00,0xD8,0x5C,0x24,0x0C,0xDF,0xE0,// fnstsw ax
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
                    0xD8, 0x25, 0x00, 0x10, 0xFF, 0x00, 0xD9, 0x5C, 0x24, 0x38, 0xFF, 0x52, 0x10,
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

            while (!backgroundWorker1.CancellationPending)
            {
                try
                {
                    await UpdateListViewItemsAsync(listView1);
                    if (listView2.Items.Count > 0)
                    {
                        RunActive();
                        await UpdateListViewItemsAsync(listView2);
                        RunDeactive();
                    }
                    if (listView3.Items.Count > 0)
                    {
                        RunActive();

                        await UpdateListViewItemsAsync(listView3);
                        RunDeactive();

                    }
                    if (listView4.Items.Count > 0)
                    {
                        RunActive();

                        await UpdateListViewItemsAsync(listView4);
                        RunDeactive();

                    }
                    if (listView5.Items.Count > 0)
                    {
                        RunActive();

                        await UpdateListViewItemsAsync(listView5);
                        RunDeactive();

                    }
                    if (listView6.Items.Count > 0)
                    {
                        RunActive();

                        await UpdateListViewItemsAsync(listView6);
                        RunDeactive();

                    }
                    if (listView7.Items.Count > 0)
                    {
                        RunActive();

                        await UpdateListViewItemsAsync(listView7);
                        RunDeactive();

                    }
                    if (listView8.Items.Count > 0)
                    {
                        RunActive();

                        await UpdateListViewItemsAsync(listView8);
                        RunDeactive();

                    }
                    if (listView9.Items.Count > 0)
                    {
                        RunActive();

                        await UpdateListViewItemsAsync(listView9);
                        RunDeactive();

                    }
                    if (listView10.Items.Count > 0)
                    {
                        RunActive();

                        await UpdateListViewItemsAsync(listView10);
                        RunDeactive();

                    }


                    if (backgroundWorker1.CancellationPending)
                    {
                        RunDeactive();

                        break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Exception in UpdateListViewItemsAsync: " + ex.Message);
                }
                await Task.Delay(10);
            }
            m.UnfreezeValue(CurrentX);
            m.UnfreezeValue(CurrentY);
            m.UnfreezeValue(CurrentZ);
            m.UnfreezeValue(LeftClick);
            m.UnfreezeValue(AltButton);
            m.WriteMemory(AltButton, "byte", "01");
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox4.Checked)
            {
                m.WriteMemory(SUPERPOT_ADR_RESULT, "bytes", "6A 01 52 83 CE FF");
            }
            else
            {
                m.WriteMemory(SUPERPOT_ADR_RESULT, "bytes", "6A 02 52 83 CE FF");
            }
        }

        public int frenzzy_tar;

        private async Task Autobuff()
        {

            await Task.Delay(1);
            List<int> list = new List<int>();
            if (list.Count == 5)
            {
                list.Clear();
            }

            for (int j = 0x00B7F3A4; j <= 0x00B7FC94; j += 0xB0)
            {
                if (m.Read2Byte(j.ToString("x")) == 65535)
                {
                    continue;
                }

                int num4 = j + 2;
                int item = m.Read2Byte(j.ToString("x"));
                int item2 = m.Read2Byte(num4.ToString("x"));
                if (!list.Contains(item2))
                {
                    list.Add(item2);
                }
            }

            for (int k = 0x00B7E874; k <= 0x00B7E898; k += 0x4)
            {
                if (m.Read2Byte(k.ToString("x")) == 65535)
                {
                    continue;
                }

                int num5 = k + 2;
                int num6 = m.Read2Byte(k.ToString("x"));
                int num7 = m.Read2Byte(num5.ToString("x"));

                if (!list.Contains(num7))
                {

                    m.WriteMemory(prevskill1_adr, "byte", num6.ToString("x"));
                    m.WriteMemory(prevskill2_adr, "byte", num7.ToString("x"));
                    m.Read2Byte(k.ToString("x"));
                    m.Read2Byte(num5.ToString("x"));
                    if (m.ReadInt(MoveCheck) != 3)
                    {
                        m.WriteMemory(actioncheck, "int", "2");
                        m.WriteMemory(forceattack_adr, "int", "5");
                        Thread.Sleep(300);

                    }
                    //if (frenzzy_tar != null)
                    //{

                    //    m.WriteMemory("MiniA.exe+931CCC", "int", "0");
                    //    m.WriteMemory("MiniA.exe+931CD0", "int", frenzzy_tar.ToString());
                    //    m.WriteMemory("MiniA.exe+931CB8", "int", "5");
                    Thread.Sleep(300);
                    //}

                }
                if (list.Contains(num7))
                {
                    list.Remove(num7);

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
                0xC7,0x44,0x24,0x10,0x4F,0xD2,0x70,0xC3,0xC7,0x44,0x24,0x14,0x05,0x56,0x20,0x41,0xC7,0x44,0x24,0x18,0x3F,0xE4,0x03,0xC5,0x39,0x5C,0x24,0x28,0x90,0x90,0x90,0x90,0x90,0x90,
                0xE9, 0x1A, 0x00, 0x00, 0x00 // jmp 0x0000001A (to be replaced later)
                };

                // Calculate the jump offsets for the je and jmp instructions
                int jumpOffset2 = (int)AOB_PATH + 0x06 - ((int)allocate_adr_Path + assemblyCode.Length + 0); // - 6

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
                m.WriteMemory("0042396D", "bytes", "90 90");
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

            m.WriteMemory("0042396D", "bytes", "90 90");
            while (!followLeaderCancellationTokenSource.Token.IsCancellationRequested)
            {
                m.FreezeValue(RightArrow, "byte", "3F");
                m.WriteMemory(AngleAdr, "float", currentrange.ToString());
                m.WriteMemory(ZoomAdr, "float", currentrange2.ToString());
                m.WriteMemory(AngleAdr, "float", currentrange.ToString());
                m.WriteMemory(ZoomAdr, "float", currentrange2.ToString());
                m.WriteMemory(AngleAdr, "float", currentrange.ToString());
                m.WriteMemory(ZoomAdr, "float", currentrange2.ToString());
                m.ReadFloat(CurrentX);
                m.ReadFloat(CurrentY);
                m.ReadFloat(CurrentZ);
                int mainSK1 = mem.Read2Byte(prevskill1_adr);
                int mainSK2 = mem.Read2Byte(prevskill2_adr);
                int target = mem.ReadInt("MiniA.exe+934ABC");
                float previousX = float.MinValue;
                float previousZ = float.MinValue;
                float num = mem.ReadFloat(CurrentX);
                float followY = mem.ReadFloat(CurrentY);
                float num2 = mem.ReadFloat(CurrentZ);
                m.ReadInt(MoveCheck);
                mem.ReadInt(MoveCheck);
                int num3 = mem.ReadInt(MoveCheck);
                float followXnew = num + ((float)rand.NextDouble() - 10.5f) * 2.0f * 0.1f;
                float followZnew = num2 + ((float)rand.NextDouble() - 10.5f) * 2.0f * 0.1f;
                if (mem.Read2Byte(MoveCheck) == 1 && mem.Read2Byte(MoveCheck) != 3)
                {
                    if (followXnew != previousX || followZnew != previousZ)
                    {

                        mem.ReadInt(MoveCheck);
                        m.WriteMemory(getadr + "+4", "float", followXnew.ToString());
                        m.WriteMemory(getadr + "+C", "float", followY.ToString());
                        m.WriteMemory(getadr + "+14", "float", followZnew.ToString());
                        m.WriteMemory(LeftClick, "byte", "63");
                        previousX = followXnew;
                        previousZ = followZnew;
                        await Task.Delay(10);
                        m.WriteMemory(LeftClick, "byte", "01");
                        if (mem.ReadByte(Spacebar) != 01)
                        {
                            m.WriteMemory(Spacebar, "byte", "63");
                            Thread.Sleep(10);
                            m.WriteMemory(Spacebar, "byte", "01");
                            Thread.Sleep(10);

                        }
                    }
                }
                else if (checkBox8.Checked && mem.Read2Byte(MoveCheck) != 1)
                {
                    mainSK1 = mem.ReadByte(prevskill1_adr);
                    mainSK2 = mem.ReadByte(prevskill2_adr);
                    target = mem.ReadInt("MiniA.exe+934ABC");
                    if (mem.Read2Byte(MoveCheck) == 3)
                    {
                        if (mainSK2 == 9)
                        {
                            Thread.Sleep(1500);

                        }
                        m.WriteMemory("MiniA.exe+933D10", "int", target.ToString());
                        m.WriteMemory("minia.exe+933D0C", "int", "2");
                        m.WriteMemory(prevskill1_adr, "byte", mainSK1.ToString("x"));
                        m.WriteMemory(prevskill2_adr, "byte", mainSK2.ToString("x"));
                        m.WriteMemory(forceattack_adr, "int", "5");

                    }

                }
                mainSK1 = mem.Read2Byte(prevskill1_adr);
                mainSK2 = mem.Read2Byte(prevskill2_adr);

                previousX = num;
                previousZ = num2;
            }
            Thread.Sleep(1);

            Thread.Sleep(1);
            m.FreezeValue(RightArrow, "byte", "01");
            m.WriteMemory(LeftClick, "byte", "01");
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
                m.WriteMemory("004A2B70", "bytes", BitConverter.ToString(jmpCode).Replace('-', ' '));

            }
            else
            {
                m.WriteMemory("004A2B70", "bytes", originalcode_Monview);
                if (allocate_adr_Monview != IntPtr.Zero)
                {
                    processHandle = OpenProcess(PROCESS_ALL_ACCESS, false, selectedProcessId);
                    VirtualFreeEx(processHandle, allocate_adr_Monview, 0, 0x8000);
                    allocate_adr_Monview = IntPtr.Zero;
                }
            }

        }
        private async Task Autosearchmonster()
        {
            m.WriteMemory("00435D3D", "bytes", "90 90"); // bypass attacking

            int[] valuesToWrite = { 7, 10, 8, 6 };

            while (checkBox9.Checked)
            {
                try
                {
                    m.WriteMemory(PATH_ADR_RESULT, "bytes", originalcode_Path);

                    List<int> check_id_mon = new List<int>();
                    listView11.Items.Clear();

                    while (checkBox9.Checked)
                    {
                        string base_mon = "00FF5000";
                        int id_mon = m.ReadInt($"{base_mon},1408");
                        int hp_mon = m.ReadInt($"{base_mon},127C");
                        float x_mon = m.ReadFloat($"{base_mon},12DC");
                        float y_mon = m.ReadFloat($"{base_mon},12E0");
                        float z_mon = m.ReadFloat($"{base_mon},12E4");

                        if (hp_mon >= 2)
                        {
                            UpdateListView(check_id_mon, id_mon, hp_mon, x_mon, y_mon, z_mon);
                            SearchAndPrintTargets(id_mon, hp_mon, x_mon, y_mon, z_mon, valuesToWrite);
                        }

                        await Task.Delay(10);
                    }
                }
                catch (Exception ex)
                {
                    // Handle exceptions appropriately
                    MessageBox.Show($"An error occurred: {ex.Message}");
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
                    if (m.Read2Byte(MoveCheck) != 3)
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
            if (checkBox9.Checked)
            {
                AutosearchCancellationTokenSource = new CancellationTokenSource();
                Task.Run((Func<Task>)Autosearchmonster);

            }
            else
            {
                AutosearchCancellationTokenSource?.Cancel();
            }
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
                m.WriteMemory(HT_ADR_RESULT, "bytes", "90 90 90 90");
            }
            else
            {
                m.WriteMemory(HT_ADR_RESULT, "bytes", "D9 44 24 44");
            }
        }

        private void checkBox12_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox12.Checked)
            {
                m.WriteMemory(WH_ADR_RESULT, "bytes", "EB 23 8B 4C 24 34");
            }
            else
            {
                m.WriteMemory(WH_ADR_RESULT, "bytes", "74 23 8B 4C 24 34");
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

        private void LoadListViewFromJSON(ListView listView, string fileName)
        {
            if (!File.Exists(fileName))
            {
                return;
            }
            foreach (LocationData item in JsonConvert.DeserializeObject<List<LocationData>>(File.ReadAllText(fileName)))
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
            if (comboBox3.SelectedItem != null)
            {
                saveID = m.ReadString(IDadr);
                string key = comboBox3.SelectedItem.ToString();
                if (listViewDictionary.TryGetValue(key, out var value))
                {
                    SaveListViewToJSON(value, $"{comboBox3.SelectedItem}{saveID}.json");
                    MessageBox.Show($"૿{comboBox2.SelectedItem}{saveID}��\u0e35º�\u0e49��", "Save Complete");
                }
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            if (comboBox3.SelectedItem != null)
            {
                saveID = m.ReadString(IDadr);
                string key = comboBox3.SelectedItem.ToString();
                if (listViewDictionary.TryGetValue(key, out var value))
                {
                    LoadListViewFromJSON(value, $"{comboBox3.SelectedItem}{saveID}.json");
                    MessageBox.Show($"��Ŵ{comboBox2.SelectedItem}{saveID}��\u0e35º�\u0e49��", "Load Complete");
                }
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
                        if (checkBox25.Checked)
                    {
                        m.WriteMemory("031F37EA", "byte", "63");
                        Thread.Sleep(100);
                        m.WriteMemory("031F37EA", "byte", "01");
                        Thread.Sleep(2000);

                        m.WriteMemory("031F37EB", "byte", "63");
                        Thread.Sleep(100);
                        m.WriteMemory("031F37EB", "byte", "01");


                    }
                    if (checkBox14.Checked)
                    {
                        int j;
                        if (int.TryParse(textBox1.Text, out var numberOfIterations))
                        {
                                                RunDeactive();

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
                            for (j = 0; j < numberOfIterations; j++)
                            {
                                await AutoSkills();
                                await Task.Delay(50);
                                await Autobuff();

                            }
                        }
                        if (checkBox15.Checked && int.TryParse(textBox4.Text, out j))
                        {
                            m.WriteMemory(PATH_ADR_RESULT, "bytes", originalcode_Path);
                            for (int u2 = 0; u2 < j; u2++)
                            {
                                m.WriteMemory(Spacebar, "byte", "63");
                                await Task.Delay(50);
                                m.WriteMemory(Spacebar, "byte", "01");
                                await Task.Delay(50);
                            }
                            m.WriteMemory(PATH_ADR_RESULT, "bytes", BitConverter.ToString(jmpCodemy).Replace('-', ' '));

                            int j2;
                            if (int.TryParse(textBox1.Text, out var numberOfIterations2))
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
                                for (j2 = 0; j2 < numberOfIterations2; j2++)
                                {
                                    await AutoSkills();
                                    await Task.Delay(50);
                                }
                                m.WriteMemory(PATH_ADR_RESULT, "bytes", originalcode_Path);

                                for (int u2 = 0; u2 < j; u2++)
                                {
                                    m.WriteMemory(Spacebar, "byte", "63");
                                    await Task.Delay(50);
                                    m.WriteMemory(Spacebar, "byte", "01");
                                    await Task.Delay(50);
                                }
                                m.WriteMemory(PATH_ADR_RESULT, "bytes", BitConverter.ToString(jmpCodemy).Replace('-', ' '));
                                if (int.TryParse(textBox1.Text, out var numberOfIterations3))
                                {
                                    int j3;
                                    for (j3 = 0; j3 < numberOfIterations3; j3++)
                                    {
                                        Autobuff();
                                        await Task.Delay(100);
                                    }
                                }

                            }

                            m.WriteMemory(PATH_ADR_RESULT, "bytes", BitConverter.ToString(jmpCodemy).Replace('-', ' '));
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
        private async Task AutoSkills()
        {
            m.FreezeValue(RightArrow, "byte", "3F");
            m.FreezeValue(RightClick, "byte", "63");
            m.WriteMemory(AngleAdr, "float", currentrange.ToString());
            m.WriteMemory(ZoomAdr, "float", currentrange2.ToString());
            await Task.Delay(100);
            m.WriteMemory(AngleAdr, "float", currentrange.ToString());
            m.WriteMemory(ZoomAdr, "float", currentrange2.ToString());
            await Task.Delay(100);
            for (int i = 0x00D31FCC; i <= 0x00D31FF0; i += 4)
            {
                int idskilltype1 = m.ReadByte(i.ToString("X"));
                int num = i + 2;
                int idskilltype2 = m.ReadByte(num.ToString("X"));
                m.ReadByte(prevskill1_adr);
                int prevskill2 = m.ReadByte(prevskill2_adr);
                await Task.Delay(200);
                if (m.Read2Byte(MoveCheck) == 0 && idskilltype1 != 255 && idskilltype2 != 255 && m.Read2Byte(MoveCheck) != 3)
                {
                    m.WriteMemory(Skilluse1_adr, "byte", idskilltype1.ToString("x"));
                    m.WriteMemory(Skilluse2_adr, "byte", idskilltype2.ToString("x"));
                    await Task.Delay(200);
                }
            }
            await Task.Delay(100);
            m.WriteMemory(AngleAdr, "float", currentrange.ToString());
            m.WriteMemory(ZoomAdr, "float", currentrange2.ToString());
            await Task.Delay(10);
            m.WriteMemory(AngleAdr, "float", currentrange.ToString());
            m.WriteMemory(ZoomAdr, "float", currentrange2.ToString());
            await Task.Delay(10);
            m.UnfreezeValue(RightClick);
            m.UnfreezeValue(RightArrow);
            m.WriteMemory(RightArrow, "byte", "01");
            m.WriteMemory(RightClick, "byte", "01");
        }

        static List<int> check_id_mon = new List<int>();


        private async Task AutoSkills2()
        {
            if (check_id_mon.Count > 3)
            {
                check_id_mon.Clear();
                Console.WriteLine("Clear Monster List");
            }

            string base_mon = "00FF5000";
            int id_mon = m.ReadInt($"{base_mon},1408");
            int hp_mon = m.ReadInt($"{base_mon},127C");
            float x_mon = m.ReadFloat($"{base_mon},12DC");
            float y_mon = m.ReadFloat($"{base_mon},12E0");
            float z_mon = m.ReadFloat($"{base_mon},12E4");
            float myX = m.ReadFloat(CurrentX);
            float myY = m.ReadFloat(CurrentY);
            float myZ = m.ReadFloat(CurrentZ);
            int check_hp_mon = m.ReadInt($"{base_mon},A90");

            float distance_mon = (float)Math.Round(Math.Sqrt(Math.Pow(x_mon - myX, 2) + Math.Pow(z_mon - myZ, 2)), 2);
            if (hp_mon > 5 && distance_mon <= 40f)
            {
                if (!check_id_mon.Contains(id_mon))
                {
                    check_id_mon.Add(id_mon);
                }
            }

            foreach (int monsterId in check_id_mon)
            {
                m.WriteMemory("MiniA.exe+780D14", "int", monsterId.ToString());

                if (m.Read2Byte(MoveCheck) != 3)
                {
                    for (int i = 0x00B7E7FC; i <= 0x00B7E820; i += 4)
                    {
                        int idskilltype1 = m.ReadByte(i.ToString("X"));
                        int num = i + 2;
                        int idskilltype2 = m.ReadByte(num.ToString("X"));
                        m.WriteMemory(actioncheck, "int", "2");
                        m.WriteMemory(prevskill1_adr, "byte", idskilltype1.ToString("x"));
                        m.WriteMemory(prevskill2_adr, "byte", idskilltype2.ToString("x"));
                        m.WriteMemory(forceattack_adr, "int", "5");
                        await Task.Delay(10);
                        distance_mon = (float)Math.Round(Math.Sqrt(Math.Pow(x_mon - myX, 2) + Math.Pow(z_mon - myZ, 2)), 2);
                        check_hp_mon = m.ReadInt($"{base_mon},A90");
                        if (check_hp_mon <= 5 || distance_mon >= 40f)
                        {
                            break;
                        }
                        await Task.Delay(10);
                    }
                    distance_mon = (float)Math.Round(Math.Sqrt(Math.Pow(x_mon - myX, 2) + Math.Pow(z_mon - myZ, 2)), 2);
                    check_hp_mon = m.ReadInt($"{base_mon},A90");
                    if (check_hp_mon <= 5 || distance_mon >= 40f)
                    {
                        break;
                    }

                }
                distance_mon = (float)Math.Round(Math.Sqrt(Math.Pow(x_mon - myX, 2) + Math.Pow(z_mon - myZ, 2)), 2);
                check_hp_mon = m.ReadInt($"{base_mon},A90");
                if (check_hp_mon <= 5 || distance_mon >= 40f)
                {
                    break;
                }

            }

            await Task.Delay(10);

            await Task.Delay(1);

        }


        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void checkBox13_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox13.Checked && !backgroundWorker1.IsBusy)
            {
                backgroundWorker1.RunWorkerAsync();
                return;
            }
            backgroundWorker1.CancelAsync();
            m.UnfreezeValue(CurrentX);
            m.UnfreezeValue(CurrentY);
            m.UnfreezeValue(CurrentZ);
            m.UnfreezeValue(LeftClick);
            m.UnfreezeValue(AltButton);
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
                    0x89,0x0D,0x00,0x50,0xFF,0x00,0x8B,0x81,0x08,0x14,0x00,0x00,
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
                m.WriteMemory(MONVIEW_ADR_RESULT, "bytes", BitConverter.ToString(jmpCode).Replace('-', ' '));
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error while finding monster: {ex.Message}");
            }
        }


        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void checkBox17_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox17.Checked)
            {
                m.WriteMemory("0041FF88", "byte", "0");
            }
            else
            {
                m.WriteMemory("0041FF88", "byte", "5");

            }
        }

        private void checkBox18_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox18.Checked)
            {
                m.WriteMemory("007FA900", "byte", "0");
            }
            else
            {
                m.WriteMemory("007FA900", "byte", "1");
            }
        }

        private void checkBox16_CheckedChanged(object sender, EventArgs e)
        {

            if (checkBox16.Checked)
            {
                m.WriteMemory(ASPD_adr, "float", textBox6.Text);
            }
            else
            {
                m.WriteMemory(ASPD_adr, "float", "4800");
            }
        }

        public string sword1_adr = "MiniA.exe+11E2244,44";
        public string sword2_adr = "MiniA.exe+11E2254,44";

        public string sword3_adr = "MiniA.exe+11E223C,44";

        public string sword4_adr = "MiniA.exe+11E2240,44";


        private void checkBox19_CheckedChanged(object sender, EventArgs e)
        {
            BestAim();

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
                0x89,0x3D,0x00,0x80,0xFF,0x00,0x83,0x7F,0x44,0x01,
                0x0F, 0x85, 0x1C, 0x00, 0x00, 0x00, // je 0x0000001D (to be replaced later)
                0xE9, 0x1A, 0x00, 0x00, 0x00 // jmp 0x0000001A (to be replaced later)
                };

                // Calculate the jump offsets for the je and jmp instructions
                int jumpOffset1 = (int)AOB_BA + 0x16E - ((int)allocate_adr_BA + assemblyCode.Length - 5);
                int jumpOffset2 = (int)AOB_BA + 0xA - ((int)allocate_adr_BA + assemblyCode.Length + 0);

                // Replace the jump offsets in the assembly code
                BitConverter.GetBytes(jumpOffset1).CopyTo(assemblyCode, assemblyCode.Length - 9);
                BitConverter.GetBytes(jumpOffset2).CopyTo(assemblyCode, assemblyCode.Length - 4);
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

        private async Task BestAim()
        {
            while (checkBox19.Checked)
            {
                if (checkBox19.Checked)
                {
                    int currentSkill = m.ReadInt("00FF8000,44");
                    if (currentSkill > 0)
                    {
                        m.WriteMemory("00FF8000,44", "int", "3");
                    }
                    await Task.Delay(100);

                }
                Thread.Sleep(100);

            }
        }

        private void checkBox20_CheckedChanged(object sender, EventArgs e)
        {


        }

        private void button6_Click(object sender, EventArgs e)
        {
            MonsterAlloc();
            autoskillsstand = true;
            if (!backgroundWorker2.IsBusy)
            {
                backgroundWorker2.RunWorkerAsync();
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            autoskillsstand = false;
            if (backgroundWorker2.IsBusy)
            {
                backgroundWorker2.CancelAsync();
            }
        }

        private async void backgroundWorker2_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            m.WriteMemory(MONVIEW_ADR_RESULT, "bytes", "8B 81 08 14 00 00");
            while (autoskillsstand)
            {
                await AutoSkills2();
                await Autobuff();

            }
        }

        private void checkBox21_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox21.Checked)
            {
                m.WriteMemory("005E7EB1", "bytes", "31 d0");
            }
            else
            {
                m.WriteMemory("005E7EB1", "bytes", "33 c0");
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            m.FreezeValue("MiniA.exe+781B4C", "float", "500");
            comboBox4.Invoke((Action)delegate
            {
                int num2 = int.Parse(((ComboBoxItem)comboBox4.SelectedItem).Value);
                m.FreezeValue("00D34B7E", "2bytes", num2.ToString());
            });

        }

        private void checkBox22_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox22.Checked)
            {
                m.FreezeValue("MiniA.exe+92F910", "int", textBox7.Text);
            }
            else
            {
                m.WriteMemory("MiniA.exe+92F910", "int", "0");

                m.UnfreezeValue("MiniA.exe+92F910");
            }

        }

        private void checkBox23_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox23.Checked)
            {
                // Start the background worker if the checkbox is checked
                if (!backgroundWorker5.IsBusy)
                {
                    backgroundWorker5.RunWorkerAsync();
                }
            }
            else
            {
                // Stop the background worker if the checkbox is unchecked
                if (backgroundWorker5.IsBusy)
                {
                    backgroundWorker5.CancelAsync();
                }
            }
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

        private void button14_Click(object sender, EventArgs e)
        {
            frenzzy_tar = m.ReadInt("MiniA.exe+932A7C");
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

        private void button15_Click(object sender, EventArgs e)
        {
            RunActive();
        }
    }

}
