using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using System.Text;
using Memory;
using System.Runtime.InteropServices;
using System;
using System.Reflection.Emit;
using System.Windows.Forms.Automation;

namespace Kappa
{

    public partial class Form1 : Form
    {
        Mem m = new Mem();
        Mem mem = new Mem();
        public string Drone_adr = "MiniA.exe+2E94C50";
        public string FastZoom = "03294C5C";
        public string AOE_adr = "";
        public string LongRange_adr = "";
        public string NameAdr = "00BE82B8";
        public string IDadr = "00BE84A8";
        public float GetX1 = 0f;
        public float GetY1 = 0f;
        public float GetZ1 = 0f;
        public float GetX2 = 0f;
        public float GetY2 = 0f;
        public float GetZ2 = 0f;
        /// <summary>
        /// //////////////////
        /// </summary>
        public string CurrentX = "00BEA478";
        public string CurrentY = "00BEA47C";
        public string CurrentZ = "00BEA480";

        public string ZoomAdr = "MINIA.EXE+2E94CF4";

        public string AngleAdr = "03294CD4";

        public string RightArrow = "03294689";
        public string gotoX = "00BEA4BC";

        public string gotoY = "00BEA4C0";

        public string gotoZ = "00BEA4C4";
        /// <summary>
        /// //////
        /// </summary>
        /// 
        public float currentrange = 0.0f;
        public float currentrange2 = 0.0f;
        public string LeftClick = "032947C8";
        public string RightClick = "032947C9";

        public string AltButton = "32945F4";

        public string key1button = "032945BE";

        public string key2button = "032945BF";
        public string prevskill1_adr = "00BEA608";

        public string prevskill2_adr = "00BEA60A";

        public string Skilluse1_adr = "00BEA604";

        public string Skilluse2_adr = "00BEA606";

        public string forceattack_adr = "MINIA.EXE+7EA698";
        public string Spacebar = "32945F5";
        public string Superpot = "00770BBB";
        public string HpFreeze_1 = "MiniA.exe+7E8398";
        public string HpFreeze_2 = "MiniA.exe+7E839A";
        int selectedProcessId = -1;
        int selectedProcessId2 = -1;
        public Form1()
        {
            InitializeComponent();
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
                m.WriteMemory("00581F41", "bytes", "0F B7 0D 00 20 FF 00"); // æ√–Œ’≈‰°≈ ∫—ø‰°≈

                // Assembly code for fstp dword ptr [esp+38]
                byte[] assemblyCode = new byte[]
                {
                    0xD8,0x25,0x00,0x20,0xFF,0x00,0xD8,0x5C,0x24,0x0C,0xDF,0xE0,
                    0xE9, 0x00, 0x00, 0x00, 0x00  // jmp 0x00000000 (to be replaced later)
                };

                // Calculate the jump offset for the first jmp instruction
                int jumpOffset = (int)baseModuleadr + 0x1E5366 - ((int)allocate_adr_aoe + assemblyCode.Length + 0);
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
                int jmpOffset2 = (int)allocate_adr_aoe - ((int)baseModuleadr + 0x1E5360 + jmpCode.Length - 1);
                BitConverter.GetBytes(jmpOffset2).CopyTo(jmpCode, 1);  // Offset is from the next instruction (E9), not the beginning

                // Write the second jmp instruction to the specified address (004EBB27)
                m.WriteMemory("005E5360", "bytes", BitConverter.ToString(jmpCode).Replace('-', ' '));
            }
            else
            {
                m.WriteMemory("005E5360", "bytes", originalcode_ALE);
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
                int jumpOffset = (int)baseModuleadr + 0xEBB2E - ((int)allocate_adr + assemblyCode.Length + 0);
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
                int jmpOffset2 = (int)allocate_adr - ((int)baseModuleadr + 0xEBB27 + jmpCode.Length - 2);
                BitConverter.GetBytes(jmpOffset2).CopyTo(jmpCode, 1);  // Offset is from the next instruction (E9), not the beginning

                // Write the second jmp instruction to the specified address (004EBB27)
                m.WriteMemory("004EBB27", "bytes", BitConverter.ToString(jmpCode).Replace('-', ' '));
            }
            else
            {
                m.WriteMemory("004EBB27", "bytes", originalcode_LR);
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

        private void backgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {


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

            //MessageBox.Show(allocate_adr_Path.ToString("x"));
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
                int jumpOffset1 = (int)baseModuleadr + 0x3479D - ((int)allocate_adr_Path + assemblyCode.Length - 5);
                int jumpOffset2 = (int)baseModuleadr + 0x3477A - ((int)allocate_adr_Path + assemblyCode.Length + 0);

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
                int jmpOffset2 = (int)allocate_adr_Path - ((int)baseModuleadr + 0x34774 + jmpCodemy.Length - 1);
                BitConverter.GetBytes(jmpOffset2).CopyTo(jmpCodemy, 1);  // Offset is from the next instruction (E9), not the beginning

                m.WriteMemory("00434774", "bytes", BitConverter.ToString(jmpCodemy).Replace('-', ' '));
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
                m.WriteMemory("00434774", "bytes", originalcode_Path);

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
                m.WriteMemory("00581F41", "bytes", "0F B7 0D 00 20 FF 00"); // æ√–Œ’≈‰°≈ ∫—ø‰°≈

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
    }
}
