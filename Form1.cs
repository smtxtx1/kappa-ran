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
        private Mem m = new Mem();
        private Mem mem = new Mem();

        public string Drone_adr = "MiniA.exe+2E48A60";

        public string FastZoom = "03248A6C";

        public string AOE_adr = "";

        public string LongRange_adr = "";

        public string NameAdr = "00BDC140";

        public string IDadr = "00BDC330";

        public float GetX1;

        public float GetY1;

        public float GetZ1;

        public float GetX2;

        public float GetY2;

        public float GetZ2;

        private bool autoAddItems;

        public string saveID;

        public string CurrentX = "00BDE300";

        public string CurrentY = "00BDE304";

        public string CurrentZ = "00BDE308";

        public string ZoomAdr = "03248B04";

        public string AngleAdr = "03248AE4";

        public string RightArrow = "03248499";

        public string gotoX = "00BDE400";

        public string gotoY = "00BDE404";

        public string gotoZ = "00BDE408";

        public float currentrange;

        public float currentrange2;

        public string LeftClick = "032485D8";

        public string RightClick = "032485D9";

        public string AltButton = "03248404";

        public string prevskill1_adr = "00BDE490";

        public string prevskill2_adr = "00BDE492";

        public string Skilluse1_adr = "00BDE48C";

        public string Skilluse2_adr = "00BDE48E";

        public string forceattack_adr = "MiniA.exe+7DE520";

        public string Spacebar = "03248405";

        public string Superpot = "0077394B";

        public string HpFreeze_1 = "00BDC220";

        public string HpFreeze_2 = "00BDC222";

        public bool autoskillsstand = true;

        private int selectedProcessId = -1;

        private int selectedProcessId2 = -1;


        public Form1()
        {
            InitializeComponent();
            backgroundWorker1.WorkerSupportsCancellation = true;
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
        private IntPtr allocate_adr_aoe;
        private IntPtr allocate_adr_Path;
        private IntPtr allocate_adr_Monview;

        private void Form1_Load(object sender, EventArgs e)
        {
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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            m.OpenProcess(int.Parse(comboBox1.Text));
            label1.Text = m.ReadString(NameAdr);
            selectedProcessId = int.Parse(comboBox1.SelectedItem.ToString());

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
                m.WriteMemory(Drone_adr, "float", "8000");
                m.WriteMemory(FastZoom, "float", "200");
            }
            else
            {
                m.WriteMemory(Drone_adr, "float", "205");
                m.WriteMemory(FastZoom, "float", "80");

            }


        }
        string originalcode_LR = "D9 5C 24 38 FF 52 10";
        string originalcode_ALE = "D8 5C 24 0C DF E0";
        string originalcode_Monview = "8B 81 18 0C 00 00";
        string originalcode_Path = "39 5C 24 28 74 23";
        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (textBox2.Text != null && checkBox2.Checked)
            {
                m.WriteMemory("00FF2000", "float", textBox2.Text);
            }

            IntPtr processHandle = OpenProcess(PROCESS_ALL_ACCESS, false, selectedProcessId);
            Process ProcessbyID = Process.GetProcessById(selectedProcessId);
            allocate_adr_aoe = VirtualAllocEx(processHandle, IntPtr.Zero, 2048, MEM_COMMIT, PAGE_READWRITE);
            if (checkBox2.Checked)
            {
                textBox2.Enabled = false;
                IntPtr baseModuleadr = ProcessbyID.MainModule.BaseAddress;
                m.WriteMemory("00581F41", "bytes", "0F B7 0D 00 20 FF 00"); // ¾ÃÐÎÕÅä¡Å ºÑ¿ä¡Å

                // Assembly code for fstp dword ptr [esp+38]
                byte[] assemblyCode = new byte[]
                {
                    0xD8,0x25,0x00,0x20,0xFF,0x00,0xD8,0x5C,0x24,0x0C,0xDF,0xE0,
                    0xE9, 0x00, 0x00, 0x00, 0x00  // jmp 0x00000000 (to be replaced later)
                };

                // Calculate the jump offset for the first jmp instruction
                int jumpOffset = (int)baseModuleadr + 0x1E6F76 - ((int)allocate_adr_aoe + assemblyCode.Length + 0);
                BitConverter.GetBytes(jumpOffset).CopyTo(assemblyCode, assemblyCode.Length - 4);

                // Write the initial assembly code to the allocated address
                m.WriteMemory(allocate_adr_aoe.ToString("X"), "bytes", BitConverter.ToString(assemblyCode).Replace('-', ' '));

                // Assembly code for jmp to allocate_adr with nop 2
                byte[] jmpCode = new byte[]
                {
                    0xE9, 0x00, 0x00, 0x00, 0x00,
                    0x90
                };

                // Calculate the jump offset for the second jmp instruction
                int jmpOffset2 = (int)allocate_adr_aoe - ((int)baseModuleadr + 0x1E6F70 + jmpCode.Length - 1);
                BitConverter.GetBytes(jmpOffset2).CopyTo(jmpCode, 1);  // Offset is from the next instruction (E9), not the beginning

                // Write the second jmp instruction to the specified address (004EBB27)
                m.WriteMemory("005E6F70", "bytes", BitConverter.ToString(jmpCode).Replace('-', ' '));
            }
            else
            {
                m.WriteMemory("005E6F70", "bytes", originalcode_ALE);
                textBox2.Enabled = true;
                if (allocate_adr_aoe != IntPtr.Zero)
                {
                    processHandle = OpenProcess(PROCESS_ALL_ACCESS, false, selectedProcessId);
                    VirtualFreeEx(processHandle, allocate_adr_aoe, 0, 0x8000);
                    allocate_adr_aoe = IntPtr.Zero;
                }

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

                // Calculate the jump offset for the first jmp instruction
                int jumpOffset = (int)baseModuleadr + 0xDED1E - ((int)allocate_adr + assemblyCode.Length + 0);
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
                int jmpOffset2 = (int)allocate_adr - ((int)baseModuleadr + 0xDED17 + jmpCode.Length - 2);
                BitConverter.GetBytes(jmpOffset2).CopyTo(jmpCode, 1);  // Offset is from the next instruction (E9), not the beginning

                // Write the second jmp instruction to the specified address (004EBB27)
                m.WriteMemory("004DED17", "bytes", BitConverter.ToString(jmpCode).Replace('-', ' '));
            }
            else
            {
                m.WriteMemory("004DED17", "bytes", originalcode_LR);
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
                    await UpdateListViewItemsAsync(listView2);
                }
                if (listView3.Items.Count > 0)
                {
                    await UpdateListViewItemsAsync(listView3);
                }
                if (listView4.Items.Count > 0)
                {
                    await UpdateListViewItemsAsync(listView4);
                }
                if (listView5.Items.Count > 0)
                {
                    await UpdateListViewItemsAsync(listView5);
                }
                if (listView6.Items.Count > 0)
                {
                    await UpdateListViewItemsAsync(listView6);
                }
                if (listView7.Items.Count > 0)
                {
                    await UpdateListViewItemsAsync(listView7);
                }
                if (listView8.Items.Count > 0)
                {
                    await UpdateListViewItemsAsync(listView8);
                }
                if (listView9.Items.Count > 0)
                {
                    await UpdateListViewItemsAsync(listView9);
                }
                if (listView10.Items.Count > 0)
                {
                    await UpdateListViewItemsAsync(listView10);
                }


                if (backgroundWorker1.CancellationPending)
                {
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
                m.WriteMemory(Superpot, "byte", "01");
            }
            else
            {
                m.WriteMemory(Superpot, "byte", "02");

            }
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox5.Checked)
            {
                m.FreezeValue(HpFreeze_1, "2bytes", "65533");
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
                0xC7, 0x44, 0x24, 0x1C, 0x00, 0x00, 0x30, 0xC1,
                0xC7, 0x44, 0x24, 0x20, 0x00, 0x00, 0x30, 0xC1,
                0xC7, 0x44, 0x24, 0x24, 0x00, 0x00, 0x30, 0xC1,
                0x39, 0x5C, 0x24, 0x28,
                0x0F, 0x84, 0x1D, 0x00, 0x00, 0x00, // je 0x0000001D (to be replaced later)
                0xE9, 0x1A, 0x00, 0x00, 0x00 // jmp 0x0000001A (to be replaced later)
                };

                // Calculate the jump offsets for the je and jmp instructions
                int jumpOffset1 = (int)baseModuleadr + 0x35A6D - ((int)allocate_adr_Path + assemblyCode.Length - 5);
                int jumpOffset2 = (int)baseModuleadr + 0x35A4A - ((int)allocate_adr_Path + assemblyCode.Length + 0);

                // Replace the jump offsets in the assembly code
                BitConverter.GetBytes(jumpOffset1).CopyTo(assemblyCode, assemblyCode.Length - 9);
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
                int jmpOffset2 = (int)allocate_adr_Path - ((int)baseModuleadr + 0x35A44 + jmpCodemy.Length - 1);
                BitConverter.GetBytes(jmpOffset2).CopyTo(jmpCodemy, 1);  // Offset is from the next instruction (E9), not the beginning

                m.WriteMemory("00435A44", "bytes", BitConverter.ToString(jmpCodemy).Replace('-', ' '));
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
                m.WriteMemory("00435A44", "bytes", originalcode_Path);

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
            await Task.Delay(0);
            m.WriteMemory("00434BBD", "bytes", "90 90");
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
                float previousX = float.MinValue;
                float previousZ = float.MinValue;
                float num = mem.ReadFloat(CurrentX);
                float followY = mem.ReadFloat(CurrentY);
                float num2 = mem.ReadFloat(CurrentZ);
                m.ReadInt("MINIA.EXE+7EB454");
                mem.ReadInt("MINIA.EXE+7EB454");
                int num3 = mem.ReadInt("MINIA.EXE+7EB454");
                float followXnew = num - 25f;
                float followZnew = num2 - 35f;
                if (mem.Read2Byte("MINIA.EXE+7EA568") == 1 && m.Read2Byte("MINIA.EXE+7EA568") != 3)
                {
                    if (followXnew != previousX || followZnew != previousZ)
                    {

                        mem.ReadInt("MINIA.EXE+7EB454");
                        m.WriteMemory(getadr + "+4", "float", followXnew.ToString());
                        m.WriteMemory(getadr + "+C", "float", followY.ToString());
                        m.WriteMemory(getadr + "+14", "float", followZnew.ToString());
                        m.WriteMemory(LeftClick, "byte", "63");
                        previousX = followXnew;
                        previousZ = followZnew;
                        Thread.Sleep(10);
                        m.WriteMemory(LeftClick, "byte", "01");
                    }
                }
                else
                {
                    m.WriteMemory(LeftClick, "byte", "01");
                    if (!checkBox8.Checked)
                    {
                        if (mem.Read2Byte("MINIA.EXE+7EA568") != 3)
                        {
                            for (int i = 0; i < 5; i++)
                            {
                                m.WriteMemory("MINIA.EXE+7EA6B0", "int", num3.ToString());
                                m.WriteMemory("MINIA.EXE+7EB454", "int", num3.ToString());
                                m.WriteMemory(forceattack_adr, "int", "5");
                            }
                        }
                    }
                    else if (checkBox8.Checked && mem.Read2Byte("MINIA.EXE+7EA568") != 1)
                    {
                        m.WriteMemory(LeftClick, "byte", "01");
                        List<int> list = new List<int>();
                        for (int j = 12490212; j <= 12492500; j += 0xB0)
                        {
                            if (m.Read2Byte(j.ToString("x")) != 65535)
                            {
                                int num4 = j + 2;
                                int item = mem.Read2Byte(j.ToString("x"));
                                int item2 = mem.Read2Byte(num4.ToString("x"));
                                list.Add(item);
                                list.Add(item2);
                            }
                        }
                        for (int k = 0x00BDC86C; k <= 0x00BDC890; k += 4)
                        {
                            if (m.Read2Byte(k.ToString("x")) == 65535)
                            {
                                continue;
                            }
                            int num5 = k + 2;
                            int num6 = m.Read2Byte(k.ToString("x"));
                            int num7 = m.Read2Byte(num5.ToString("x"));
                            bool flag = false;

                            foreach (int item3 in list)
                            {
                                if (item3 == num7)
                                {
                                    flag = true;
                                    break;
                                }
                            }

                            if (!flag)
                            {
                                m.WriteMemory(prevskill1_adr, "byte", num6.ToString("x"));
                                m.WriteMemory(prevskill2_adr, "byte", num7.ToString("x"));
                                m.WriteMemory(forceattack_adr, "int", "5");
                                m.Read2Byte(k.ToString("x"));
                                m.Read2Byte(num5.ToString("x"));
                            }
                        }
                    }
                    previousX = num;
                    previousZ = num2;
                }
                Thread.Sleep(1);
            }
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
                m.WriteMemory("00581F41", "bytes", "0F B7 0D 00 20 FF 00"); // ¾ÃÐÎÕÅä¡Å ºÑ¿ä¡Å

                // Assembly code for fstp dword ptr [esp+38]
                byte[] assemblyCode = new byte[]
                {
                    0x89,0x0D,0x00,0x50,0xFF,0x00,0x8B,0x81,0x18,0x0C,0x00,0x00,0xE9,
                    0x00, 0x00, 0x00, 0x00  // jmp 0x00000000 (to be replaced later)
                };

                // Calculate the jump offset for the first jmp instruction
                int jumpOffset = (int)baseModuleadr + 0x84916 - ((int)allocate_adr_Monview + assemblyCode.Length + 0);
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
                int jmpOffset2 = (int)allocate_adr_Monview - ((int)baseModuleadr + 0x84910 + jmpCode.Length - 1);
                BitConverter.GetBytes(jmpOffset2).CopyTo(jmpCode, 1);  // Offset is from the next instruction (E9), not the beginning

                // Write the second jmp instruction to the specified address (004EBB27)
                m.WriteMemory("00484910", "bytes", BitConverter.ToString(jmpCode).Replace('-', ' '));
            }
            else
            {
                m.WriteMemory("00484910", "bytes", originalcode_Monview);
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
            m.WriteMemory("00434BBD", "bytes", "90 90"); // bypass attacking
            int MonsterHP = m.ReadInt("00FF5000,A90");
            int MonsterID = m.ReadInt("00FF5000,C18");

            int[] valuesToWrite = { 9, 7, 13 };
            m.WriteMemory("00434774", "bytes", originalcode_Path);
            while (checkBox9.Checked)
            {
                try
                {
                    if (MonsterHP >= 1020 && m.Read2Byte("MINIA.EXE+7EA568") != 3)
                    {

                        m.WriteMemory("MiniA.exe+7EA6B0", "int", MonsterID.ToString());
                        m.WriteMemory("MiniA.exe + 7EB454", "int", MonsterID.ToString());
                        m.WriteMemory("MiniA.exe+7EA698", "int", "5");

                        // Cycle through the values in order  
                        foreach (int value in valuesToWrite)
                        {
                            m.WriteMemory("00BEA60A", "2bytes", value.ToString());
                            await Task.Delay(10); // Adjust the delay as needed
                        }


                        MonsterID = m.ReadInt("00FF5000,C18");

                    }
                    //else 
                    //{
                    //    m.WriteMemory("00434774", "bytes", BitConverter.ToString(jmpCodemy).Replace('-', ' '));
                    //    m.WriteMemory(getadr + "+4", "float", GetX1.ToString());
                    //    m.WriteMemory(getadr + "+C", "float", GetY1.ToString());
                    //    m.WriteMemory(getadr + "+14", "float", GetZ1.ToString());
                    //    m.WriteMemory(LeftClick, "byte", "63");
                    //    await Task.Delay(100);
                    //    m.WriteMemory("00434774", "bytes", originalcode_Path);
                    //}
                }


                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }



                // Delay outside the if condition to control the loop speed
                await Task.Delay(10); // Adjust the delay as needed
            }
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

        private void checkBox11_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox11.Checked)
            {
                m.WriteMemory("004EBF92", "bytes", "90 90 90 90");
            }
            else
            {
                m.WriteMemory("004EBF92", "bytes", "D9 44 24 44");
            }
        }

        private void checkBox12_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox12.Checked)
            {
                m.WriteMemory("005E0A91", "bytes", "EB");
            }
            else
            {
                m.WriteMemory("005E0A91", "bytes", "74");
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
                    MessageBox.Show($"à«¿{comboBox2.SelectedItem}{saveID}àÃ\u0e35ÂºÃ\u0e49ÍÂ", "Save Complete");
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
                    MessageBox.Show($"âËÅ´{comboBox2.SelectedItem}{saveID}àÃ\u0e35ÂºÃ\u0e49ÍÂ", "Load Complete");
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
                        break;
                    }
                    ListViewItem listViewItem = listView.Items[currentIndex];
                    await Task.Delay(10);
                    float newX = float.Parse(listViewItem.SubItems[1].Text);
                    float newY = float.Parse(listViewItem.SubItems[2].Text);
                    float newZ = float.Parse(listViewItem.SubItems[3].Text);
                    m.WriteMemory(ZoomAdr, "float", "1");
                    m.WriteMemory(AngleAdr, "float", "75");
                    m.FreezeValue(AltButton, "byte", "63");
                    m.FreezeValue(LeftClick, "byte", "63");
                    m.WriteMemory(getadr + "+4", "float", newX.ToString());
                    m.WriteMemory(getadr + "+C", "float", newY.ToString());
                    m.WriteMemory(getadr + "+14", "float", newZ.ToString());
                    while (!(currentX >= newX - 20f) || !(currentX <= newX + 20f) || !(currentY >= newY - 20f) || !(currentY <= newY + 20f) || !(currentZ >= newZ - 20f) || !(currentZ <= newZ + 20f))
                    {
                        currentX = m.ReadFloat(CurrentX);
                        currentY = m.ReadFloat(CurrentY);
                        currentZ = m.ReadFloat(CurrentZ);
                        await Task.Delay(100);
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
                    m.UnfreezeValue(AltButton);
                    m.UnfreezeValue(LeftClick);
                    m.WriteMemory(LeftClick, "byte", "01");
                    m.WriteMemory(AltButton, "byte", "01");
                    if (checkBox14.Checked)
                    {
                        int j;
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
                            for (j = 0; j < numberOfIterations; j++)
                            {
                                await AutoSkills();
                                await Task.Delay(100);
                            }
                        }
                        if (checkBox15.Checked && int.TryParse(textBox4.Text, out j))
                        {
                            m.WriteMemory("00435A44", "bytes", originalcode_Path);
                            for (int u2 = 0; u2 < j; u2++)
                            {
                                m.WriteMemory(Spacebar, "byte", "63");
                                await Task.Delay(50);
                                m.WriteMemory(Spacebar, "byte", "01");
                                await Task.Delay(50);
                            }
                            m.WriteMemory("00435A44", "bytes", BitConverter.ToString(jmpCodemy).Replace('-', ' '));
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
            for (int i = 12437492; i <= 12437528; i += 4)
            {
                int idskilltype1 = m.ReadByte(i.ToString("X"));
                int num = i + 2;
                int idskilltype2 = m.ReadByte(num.ToString("X"));
                m.ReadByte(prevskill1_adr);
                int prevskill2 = m.ReadByte(prevskill2_adr);
                await Task.Delay(300);
                if (m.Read2Byte("MiniA.exe+7DE3F0") == 0 && idskilltype2 != prevskill2 && idskilltype1 != 255 && idskilltype2 != 255 && m.Read2Byte("MiniA.exe+7DE3F0") != 3)
                {
                    m.WriteMemory(Skilluse1_adr, "byte", idskilltype1.ToString("x"));
                    m.WriteMemory(Skilluse2_adr, "byte", idskilltype2.ToString("x"));
                    await Task.Delay(300);
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
    }
}
