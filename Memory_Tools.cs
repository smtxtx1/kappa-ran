using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Capybara_Ran
{
    public struct MemoryPointer
    {
        private long _address;

        public MemoryPointer(long address)
        {
            _address = address;
        }

        public static implicit operator MemoryPointer(long value)
        {
            return new MemoryPointer(value);
        }
        public static implicit operator UIntPtr(MemoryPointer value)
        {
            return new UIntPtr((ulong)value._address);
        }
        // แปลง int เป็น MemoryPointer
        public static implicit operator MemoryPointer(int value)
        {
            return new MemoryPointer(value);
        }
        public static implicit operator MemoryPointer(UIntPtr value)
        {
            return new MemoryPointer((long)value.ToUInt64());
        }
        public static implicit operator MemoryPointer(IntPtr value)
        {
            return new MemoryPointer(value.ToInt64());
        }
        // แปลง MemoryPointer เป็น int
        public static explicit operator int(MemoryPointer value)
        {
            return (int)value._address;
        }
        public static implicit operator long(MemoryPointer value)
        {
            return value._address;
        }

        public static implicit operator IntPtr(MemoryPointer value)
        {
            return new IntPtr(value._address);
        }

        // Operator สำหรับการบวก MemoryPointer กับ int
        public static MemoryPointer operator +(MemoryPointer a, int b)
        {
            return new MemoryPointer(a._address + b);
        }

        // Operator สำหรับการบวก int กับ MemoryPointer
        public static MemoryPointer operator +(int a, MemoryPointer b)
        {
            return new MemoryPointer(a + b._address);
        }
        public static MemoryPointer operator +(MemoryPointer a, MemoryPointer b)
        {
            return new MemoryPointer(a._address + b._address);
        }

        public static MemoryPointer operator +(MemoryPointer a, long b)
        {
            return new MemoryPointer(a._address + b);
        }

        public override string ToString()
        {
            return $"0x{_address:X}";
        }
    }
    internal static class Memory_Tools
    {
        [DllImport("kernel32.dll", EntryPoint = "VirtualQueryEx")]
        public static extern UIntPtr Native_VirtualQueryEx(IntPtr hProcess, UIntPtr lpAddress,
    out MEMORY_BASIC_INFORMATION32 lpBuffer, UIntPtr dwLength);


        [DllImport("kernel32.dll", EntryPoint = "VirtualQueryEx")]
        public static extern UIntPtr Native_VirtualQueryEx(IntPtr hProcess, UIntPtr lpAddress,
    out MEMORY_BASIC_INFORMATION64 lpBuffer, UIntPtr dwLength);



        [DllImport("kernel32.dll")]
        public static extern void GetSystemInfo(out SYSTEM_INFO lpSystemInfo);
        [DllImport("kernel32")]
        public static extern bool IsWow64Process(IntPtr hProcess, out bool lpSystemInfo);
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern IntPtr OpenProcess(uint dwDesiredAccess, bool bInheritHandle, uint dwProcessId);

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern UIntPtr VirtualAllocEx(IntPtr hProcess, UIntPtr lpAddress, uint dwSize, uint flAllocationType, uint flProtect);

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool WriteProcessMemory(IntPtr hProcess, UIntPtr lpBaseAddress, byte[] lpBuffer, int nSize, out UIntPtr lpNumberOfBytesWritten);

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool WriteProcessMemory(IntPtr hProcess, UIntPtr lpBaseAddress, byte[] lpBuffer, uint nSize, out UIntPtr lpNumberOfBytesWritten);


        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool ReadProcessMemory(IntPtr hProcess, UIntPtr lpBaseAddress, [Out] byte[] lpBuffer, int dwSize, out UIntPtr lpNumberOfBytesRead);

        [DllImport("kernel32.dll")]
        public static extern IntPtr CreateRemoteThread(IntPtr hProcess, UIntPtr lpThreadAttributes, uint dwStackSize, UIntPtr lpStartAddress, UIntPtr lpParameter, uint dwCreationFlags, UIntPtr lpThreadId);

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern uint WaitForSingleObject(IntPtr hHandle, uint dwMilliseconds);

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool GetExitCodeThread(IntPtr hThread, out uint lpExitCode);

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool VirtualFreeEx(IntPtr hProcess, UIntPtr lpAddress, uint dwSize, uint dwFreeType);

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool CloseHandle(IntPtr hObject);

        // used for memory allocation
        public const uint PROCESS_ALL_ACCESS = 0x001F0FFF;
        const uint MEM_FREE = 0x10000;
        const uint MEM_COMMIT = 0x00001000;
        const uint MEM_RESERVE = 0x00002000;
        const uint PAGE_EXECUTE_READWRITE = 0x40;
        const uint MEM_RELEASE = 0x00008000;
        const uint PAGE_READWRITE = 0x04;
        const uint PAGE_GUARD = 0x100;
        public const uint PAGE_NOACCESS = 0x01;

        const uint MEM_PRIVATE = 0x20000;
        const uint MEM_IMAGE = 0x1000000;
        const uint MEM_MAPPED = 0x40000;


        const uint PAGE_READONLY = 0x02;
        const uint PAGE_WRITECOPY = 0x08;
        const uint PAGE_EXECUTE_WRITECOPY = 0x80;
        const uint PAGE_EXECUTE = 0x10;
        const uint PAGE_EXECUTE_READ = 0x20;

        public static byte[] ReadBytes(IntPtr hProcess, MemoryPointer address, int length)
        {
            byte[] buffer = new byte[length];
            UIntPtr bytesRead;
            if (ReadProcessMemory(hProcess, address, buffer, buffer.Length, out bytesRead))
            {
                return buffer;
            }
            throw new Exception("Failed to read memory");
        }
        public static IntPtr ReadPointer(IntPtr hProcess, MemoryPointer address)
        {
            int pointerValue = ReadInt(hProcess, address);
            return new IntPtr(pointerValue);
        }
        public static int ReadInt(IntPtr hProcess, MemoryPointer address)
        {
            byte[] buffer = new byte[4];
            UIntPtr bytesRead;
            if (ReadProcessMemory(hProcess, address, buffer, buffer.Length, out bytesRead))
            {
                return BitConverter.ToInt32(buffer, 0);
            }
            throw new Exception("Failed to read memory");
        }
        public static int Read2Bytes(IntPtr hProcess, MemoryPointer address)
        {
            byte[] buffer = new byte[2];
            UIntPtr bytesRead;
            if (ReadProcessMemory(hProcess, address, buffer, buffer.Length, out bytesRead))
            {
                return BitConverter.ToInt16(buffer, 0);
            }
            throw new Exception("Failed to read memory");
        }
        public static string ReadString(IntPtr hProcess, MemoryPointer address, int maxLength)
        {
            byte[] buffer = ReadBytes(hProcess, address, maxLength);
            int nullTerminatorIndex = Array.IndexOf(buffer, (byte)0);
            if (nullTerminatorIndex != -1)
            {
                return Encoding.Default.GetString(buffer, 0, nullTerminatorIndex);
            }
            return Encoding.Default.GetString(buffer);
        }
        public static float ReadFloat(IntPtr hProcess, MemoryPointer address)
        {
            byte[] buffer = new byte[4];
            UIntPtr bytesRead;
            if (ReadProcessMemory(hProcess, (UIntPtr)address, buffer, buffer.Length, out bytesRead))
            {
                return BitConverter.ToSingle(buffer, 0);
            }
            throw new Exception("Failed to read memory");
        }
        public static void WritePointer(IntPtr hProcess, MemoryPointer address, IntPtr value)
        {
            byte[] buffer = BitConverter.GetBytes(value.ToInt32());
            UIntPtr bytesWritten;
            if (!WriteProcessMemory(hProcess, address, buffer, buffer.Length, out bytesWritten))
            {
                throw new Exception("Failed to write memory");
            }
        }

        public static void WriteInt(IntPtr hProcess, MemoryPointer address, uint value)
        {
            byte[] buffer = BitConverter.GetBytes(value);
            UIntPtr bytesWritten;
            if (!WriteProcessMemory(hProcess, address, buffer, buffer.Length, out bytesWritten))
            {
                throw new Exception("Failed to write memory");
            }
        }

        public static void WriteFloat(IntPtr hProcess, MemoryPointer address, float value)
        {
            byte[] buffer = BitConverter.GetBytes(value);
            UIntPtr bytesWritten;
            if (!WriteProcessMemory(hProcess, address, buffer, buffer.Length, out bytesWritten))
            {
                throw new Exception("Failed to write memory");
            }
        }

        public static void WriteBytes(IntPtr hProcess, MemoryPointer address, byte[] buffer)
        {
            UIntPtr bytesWritten;
            if (!WriteProcessMemory(hProcess, address, buffer, buffer.Length, out bytesWritten))
            {
                throw new Exception("Failed to write memory");
            }
        }
        public static uint CallExternalThiscallFunction(IntPtr processHD,UIntPtr functionAddress, UIntPtr thisPointer, uint argc, uint[] args)
        {
            IntPtr processHandle = processHD;

            uint callerSize = (uint)(5 + (1 + 4) * argc + 1 + 4 + 1);
            UIntPtr callerAddress = VirtualAllocEx(processHandle, UIntPtr.Zero, callerSize, MEM_COMMIT | MEM_RESERVE, PAGE_EXECUTE_READWRITE);
            //Console.WriteLine($"caller_address = {callerAddress}");

            byte[] callerBytes = new byte[callerSize];
            int offset = 0;

            // Move 'this' pointer to ECX
            callerBytes[offset++] = 0xB9; // mov ecx,
            Buffer.BlockCopy(BitConverter.GetBytes((uint)thisPointer.ToUInt32()), 0, callerBytes, offset, 4);
            offset += 4;

            // Push arguments in reverse order (right to left)
            for (int i = 0; i < argc; i++)
            {
                callerBytes[offset++] = 0x68; // push
                Buffer.BlockCopy(BitConverter.GetBytes(args[argc - i - 1]), 0, callerBytes, offset, 4);
                offset += 4;
            }

            // Call the function
            callerBytes[offset++] = 0xE8; // call

            uint relativeAddress = (uint)(functionAddress.ToUInt64() - (callerAddress.ToUInt64() + (uint)offset) - 4);

            //uint relativeAddress = (uint)functionAddress.ToInt64() - ((uint)callerAddress.ToInt64() + offset) - 4;
            Buffer.BlockCopy(BitConverter.GetBytes(relativeAddress), 0, callerBytes, offset, 4);
            offset += 4;

            // Return
            callerBytes[offset] = 0xC3; // ret

            UIntPtr bytesWritten;
            WriteProcessMemory(processHandle, callerAddress, callerBytes, callerSize, out bytesWritten);

            IntPtr threadHandle = CreateRemoteThread(processHandle, UIntPtr.Zero, 0, callerAddress, UIntPtr.Zero, 0, UIntPtr.Zero);

            while (WaitForSingleObject(threadHandle, 0) != 0) { }



            uint result = 0;

            GetExitCodeThread(threadHandle, out result);

            CloseHandle(threadHandle);
            VirtualFreeEx(processHandle, callerAddress, 0, MEM_RELEASE);
            //CloseHandle(processHandle);

            return result;
        }

        public static uint FloatToUInt(float value)
        {
            byte[] bytes = BitConverter.GetBytes(value);
            //Console.WriteLine(BitConverter.ToUInt32(bytes, 0));
            return BitConverter.ToUInt32(bytes, 0);
        }
        public static UIntPtr AllocateMemoryForVariable(IntPtr hProcess, int size) // 4 bytes for a 32-bit integer
        {
            UIntPtr address = VirtualAllocEx(hProcess, UIntPtr.Zero, (uint)size,
                                             MEM_COMMIT | MEM_RESERVE, PAGE_READWRITE);

            if (address == UIntPtr.Zero)
            {
                int error = Marshal.GetLastWin32Error();
                throw new Exception($"Failed to allocate memory. Error code: {error}");
            }

            return address;
        }


        public static UIntPtr CreateCodeCave(IntPtr hProcess, bool Is64Bit, UIntPtr TargetHook_Address, byte[] newBytes, int replaceCount, int size = 0x1000)
        {

            if (replaceCount < 5)
                return UIntPtr.Zero; // returning UIntPtr.Zero instead of throwing an exception
                                     // to better match existing code

            UIntPtr theCode;
            theCode = TargetHook_Address;
            UIntPtr address = theCode;

            // if x64 we need to try to allocate near the address so we dont run into the +-2GB limit of the 0xE9 jmp

            UIntPtr caveAddress = UIntPtr.Zero;
            UIntPtr prefered = address;

            for (var i = 0; i < 10 && caveAddress == UIntPtr.Zero; i++)
            {
                caveAddress = VirtualAllocEx(hProcess, FindFreeBlockForRegion(hProcess, Is64Bit, prefered, (uint)size), (uint)size, MEM_COMMIT | MEM_RESERVE, PAGE_EXECUTE_READWRITE);

                if (caveAddress == UIntPtr.Zero)
                    prefered = UIntPtr.Add(prefered, 0x10000);
            }

            // Failed to allocate memory around the address we wanted let windows handle it and hope for the best?
            if (caveAddress == UIntPtr.Zero)
                caveAddress = VirtualAllocEx(hProcess, UIntPtr.Zero, (uint)size, MEM_COMMIT | MEM_RESERVE,
                                             PAGE_EXECUTE_READWRITE);

            int nopsNeeded = replaceCount > 5 ? replaceCount - 5 : 0;

            // (to - from - 5)
            int offset = (int)((long)caveAddress - (long)address - 5);

            byte[] jmpBytes = new byte[5 + nopsNeeded];
            jmpBytes[0] = 0xE9;
            BitConverter.GetBytes(offset).CopyTo(jmpBytes, 1);

            for (var i = 5; i < jmpBytes.Length; i++)
            {
                jmpBytes[i] = 0x90;
            }

            byte[] caveBytes = new byte[5 + newBytes.Length];
            offset = (int)(((long)address + jmpBytes.Length) - ((long)caveAddress + newBytes.Length) - 5);

            newBytes.CopyTo(caveBytes, 0);
            caveBytes[newBytes.Length] = 0xE9;
            BitConverter.GetBytes(offset).CopyTo(caveBytes, newBytes.Length + 1);

            WriteBytes(hProcess, caveAddress, caveBytes);
            WriteBytes(hProcess, address, jmpBytes);

            return caveAddress;
        }

        public static byte[] CalculateOriginalCode(UIntPtr Start_je, UIntPtr Final_je)
        {
            List<byte> originalCode = new List<byte>();
            // Calculate the offset for JE instruction
            long offset = (long)Final_je - ((long)Start_je + 6); // +6 for the size of JE instruction

            // Add JE instruction
            originalCode.Add(0x0F);  // First byte of JE
            originalCode.Add(0x84);  // Second byte of JE
            originalCode.AddRange(BitConverter.GetBytes((int)offset));

            return originalCode.ToArray();
        }
        public static UIntPtr CreateCodeCave_With_je(IntPtr hProcess, bool Is64Bit, UIntPtr TargetHook_Address, byte[] newBytes, int replaceCount, int size = 0x1000, UIntPtr OriginalJumpAddress = default(UIntPtr))
        {
            if (replaceCount < 5)
                return UIntPtr.Zero;

            UIntPtr theCode = TargetHook_Address;
            UIntPtr address = theCode;

            // Allocate memory for the code cave
            UIntPtr caveAddress = UIntPtr.Zero;
            UIntPtr prefered = address;
            for (var i = 0; i < 10 && caveAddress == UIntPtr.Zero; i++)
            {
                caveAddress = VirtualAllocEx(hProcess, FindFreeBlockForRegion(hProcess, Is64Bit, prefered, (uint)size), (uint)size, MEM_COMMIT | MEM_RESERVE, PAGE_EXECUTE_READWRITE);
                if (caveAddress == UIntPtr.Zero)
                    prefered = UIntPtr.Add(prefered, 0x10000);
            }

            if (caveAddress == UIntPtr.Zero)
                caveAddress = VirtualAllocEx(hProcess, UIntPtr.Zero, (uint)size, MEM_COMMIT | MEM_RESERVE, PAGE_EXECUTE_READWRITE);

            int nopsNeeded = replaceCount > 5 ? replaceCount - 5 : 0;

            // Calculate the offset for the initial jump to the code cave
            int offset = (int)((long)caveAddress - (long)address - 5);
            byte[] jmpBytes = new byte[5 + nopsNeeded];
            jmpBytes[0] = 0xE9;
            BitConverter.GetBytes(offset).CopyTo(jmpBytes, 1);
            for (var i = 5; i < jmpBytes.Length; i++)
            {
                jmpBytes[i] = 0x90; // NOP
            }

            // Prepare the code cave bytes
            List<byte> caveBytes = new List<byte>(newBytes);

            if (OriginalJumpAddress != default(UIntPtr))
            {
                // If we have a conditional jump, we need to adjust it
                long originalJumpOffset = (long)OriginalJumpAddress - ((long)address + replaceCount);
                long newJumpOffset = originalJumpOffset - ((long)caveAddress + newBytes.Length + 6 - ((long)address + replaceCount));

                caveBytes.AddRange(new byte[] { 0x0F, 0x84 }); // JE opcode
                caveBytes.AddRange(BitConverter.GetBytes((int)newJumpOffset));

                // Add a jump back to the original code for the case when the condition is not met
                long returnAddress = (long)address + replaceCount;
                long returnOffset = returnAddress - ((long)caveAddress + caveBytes.Count + 5);

                caveBytes.Add(0xE9); // JMP opcode
                caveBytes.AddRange(BitConverter.GetBytes((int)returnOffset));
            }
            else
            {
                // If no conditional jump, just add a regular jump back to the original code
                offset = (int)(((long)address + jmpBytes.Length) - ((long)caveAddress + newBytes.Length) - 5);
                caveBytes.Add(0xE9); // JMP opcode
                caveBytes.AddRange(BitConverter.GetBytes(offset));
            }

            // Write the code cave and the initial jump
            WriteBytes(hProcess, caveAddress, caveBytes.ToArray());
            WriteBytes(hProcess, address, jmpBytes);

            return caveAddress;
        }

        // Restore และ dealloc 
        public static bool RestoreCodeCave(IntPtr hProcess, UIntPtr TargetHook_Address_Original_Restore, UIntPtr NewMem_Addr, byte[] original, int dwSize = 0x1000)
        {

            // Restore original code
            WriteBytes(hProcess, TargetHook_Address_Original_Restore, original);

            // Verify if original code is restored correctly
            byte[] checkBytes = new byte[original.Length];
            ReadProcessMemory(hProcess, TargetHook_Address_Original_Restore, checkBytes, checkBytes.Length, out _);
            if (!checkBytes.SequenceEqual(original))
            {
                Console.WriteLine("Failed to restore original code.");
                return false;
            }

            // Dealloc memory
            bool result = VirtualFreeEx(hProcess, NewMem_Addr, (uint)UIntPtr.Zero, MEM_RELEASE);
            if (!result)
            {
                int error = Marshal.GetLastWin32Error();
                Console.WriteLine($"VirtualFreeEx failed. Error code: {error}");
                return false;
            }

            Console.WriteLine("CodeCave successfully restored and deallocated.");
            return true;
        }
        public static void deAllocatedMemory(IntPtr hProcess, UIntPtr address)
        {
            bool result = VirtualFreeEx(hProcess, address, (uint)UIntPtr.Zero, MEM_RELEASE);
            if (!result)
            {
                int error = Marshal.GetLastWin32Error();
                throw new Exception($"Failed to free memory. Error code: {error}");
            }
        }

        public static bool IsAddressHooked(IntPtr hProcess, UIntPtr targetAddress)
        {
            byte[] buffer = new byte[5];
            UIntPtr bytesRead;

            // อ่าน 5 ไบต์แรกจากตำแหน่งเป้าหมาย
            if (!ReadProcessMemory(hProcess, targetAddress, buffer, buffer.Length, out bytesRead))
            {
                int error = Marshal.GetLastWin32Error();
                throw new Exception($"Failed to read process memory. Error code: {error}");
            }

            // ตรวจสอบว่าไบต์แรกเป็น 0xE9 (opcode สำหรับ JMP) หรือไม่
            return buffer[0] == 0xE9;
        }

        public static bool RestoreUnhook_IF_IsHooked(IntPtr hProcess, UIntPtr TargetHook_Address_Original_Restore, byte[] original)
        {

            // Restore original code
            WriteBytes(hProcess, TargetHook_Address_Original_Restore, original);

            // Verify if original code is restored correctly
            byte[] checkBytes = new byte[original.Length];
            ReadProcessMemory(hProcess, TargetHook_Address_Original_Restore, checkBytes, checkBytes.Length, out _);
            if (!checkBytes.SequenceEqual(original))
            {
                Console.WriteLine("Failed to restore original code.");
                return false;
            }

            Console.WriteLine("CodeCave successfully restored and deallocated.");
            return true;
        }

        private static UIntPtr FindFreeBlockForRegion(IntPtr hProcess, bool Is64Bit, UIntPtr baseAddress, uint size)
        {

            UIntPtr minAddress = UIntPtr.Subtract(baseAddress, 0x70000000);
            UIntPtr maxAddress = UIntPtr.Add(baseAddress, 0x70000000);

            UIntPtr ret = UIntPtr.Zero;
            UIntPtr tmpAddress = UIntPtr.Zero;

            GetSystemInfo(out SYSTEM_INFO si);

            if (Is64Bit)
            {
                if ((long)minAddress > (long)si.maximumApplicationAddress ||
                    (long)minAddress < (long)si.minimumApplicationAddress)
                    minAddress = si.minimumApplicationAddress;

                if ((long)maxAddress < (long)si.minimumApplicationAddress ||
                    (long)maxAddress > (long)si.maximumApplicationAddress)
                    maxAddress = si.maximumApplicationAddress;
            }
            else
            {
                minAddress = si.minimumApplicationAddress;
                maxAddress = si.maximumApplicationAddress;
            }

            MEMORY_BASIC_INFORMATION mbi;

            UIntPtr current = minAddress;
            UIntPtr previous = current;

            while (VirtualQueryEx(hProcess, Is64Bit, current, out mbi).ToUInt64() != 0)
            {
                if ((long)mbi.BaseAddress > (long)maxAddress)
                    return UIntPtr.Zero;  // No memory found, let windows handle

                if (mbi.State == MEM_FREE && mbi.RegionSize > size)
                {
                    if ((long)mbi.BaseAddress % si.allocationGranularity > 0)
                    {
                        // The whole size can not be used
                        tmpAddress = mbi.BaseAddress;
                        int offset = (int)(si.allocationGranularity -
                                           ((long)tmpAddress % si.allocationGranularity));

                        // Check if there is enough left
                        if ((mbi.RegionSize - offset) >= size)
                        {
                            // yup there is enough
                            tmpAddress = UIntPtr.Add(tmpAddress, offset);

                            if ((long)tmpAddress < (long)baseAddress)
                            {
                                tmpAddress = UIntPtr.Add(tmpAddress, (int)(mbi.RegionSize - offset - size));

                                if ((long)tmpAddress > (long)baseAddress)
                                    tmpAddress = baseAddress;

                                // decrease tmpAddress until its alligned properly
                                tmpAddress = UIntPtr.Subtract(tmpAddress, (int)((long)tmpAddress % si.allocationGranularity));
                            }

                            // if the difference is closer then use that
                            if (Math.Abs((long)tmpAddress - (long)baseAddress) < Math.Abs((long)ret - (long)baseAddress))
                                ret = tmpAddress;
                        }
                    }
                    else
                    {
                        tmpAddress = mbi.BaseAddress;

                        if ((long)tmpAddress < (long)baseAddress) // try to get it the cloest possible 
                                                                  // (so to the end of the region - size and
                                                                  // aligned by system allocation granularity)
                        {
                            tmpAddress = UIntPtr.Add(tmpAddress, (int)(mbi.RegionSize - size));

                            if ((long)tmpAddress > (long)baseAddress)
                                tmpAddress = baseAddress;

                            // decrease until aligned properly
                            tmpAddress =
                                UIntPtr.Subtract(tmpAddress, (int)((long)tmpAddress % si.allocationGranularity));
                        }

                        if (Math.Abs((long)tmpAddress - (long)baseAddress) < Math.Abs((long)ret - (long)baseAddress))
                            ret = tmpAddress;
                    }
                }

                if (mbi.RegionSize % si.allocationGranularity > 0)
                    mbi.RegionSize += si.allocationGranularity - (mbi.RegionSize % si.allocationGranularity);

                previous = current;
                current = new UIntPtr(((ulong)mbi.BaseAddress) + (ulong)mbi.RegionSize);

                if ((long)current >= (long)maxAddress)
                    return ret;

                if ((long)previous >= (long)current)
                    return ret; // Overflow
            }

            return ret;
        }
        private static UIntPtr VirtualQueryEx(IntPtr hProcess, bool Is64Bit, UIntPtr lpAddress, out MEMORY_BASIC_INFORMATION lpBuffer)
        {
            UIntPtr retVal;

            // TODO: Need to change this to only check once.
            if (Is64Bit || IntPtr.Size == 8)
            {
                // 64 bit
                MEMORY_BASIC_INFORMATION64 tmp64 = new MEMORY_BASIC_INFORMATION64();
                retVal = Native_VirtualQueryEx(hProcess, lpAddress, out tmp64, new UIntPtr((uint)Marshal.SizeOf(tmp64)));

                lpBuffer.BaseAddress = tmp64.BaseAddress;
                lpBuffer.AllocationBase = tmp64.AllocationBase;
                lpBuffer.AllocationProtect = tmp64.AllocationProtect;
                lpBuffer.RegionSize = (long)tmp64.RegionSize;
                lpBuffer.State = tmp64.State;
                lpBuffer.Protect = tmp64.Protect;
                lpBuffer.Type = tmp64.Type;
                return retVal;
            }
            MEMORY_BASIC_INFORMATION32 tmp32 = new MEMORY_BASIC_INFORMATION32();

            retVal = Native_VirtualQueryEx(hProcess, lpAddress, out tmp32, new UIntPtr((uint)Marshal.SizeOf(tmp32)));

            lpBuffer.BaseAddress = tmp32.BaseAddress;
            lpBuffer.AllocationBase = tmp32.AllocationBase;
            lpBuffer.AllocationProtect = tmp32.AllocationProtect;
            lpBuffer.RegionSize = tmp32.RegionSize;
            lpBuffer.State = tmp32.State;
            lpBuffer.Protect = tmp32.Protect;
            lpBuffer.Type = tmp32.Type;

            return retVal;
        }

        public static async Task<UIntPtr> AoBScan_Target_Module(IntPtr hProcess, bool Is64bit, ProcessModule targetModule, byte[] aobPattern, bool readable, bool writable, bool executable, bool mapped)
        {
            var results = await Task.Run(() =>
            {
                var memRegionList = new List<MemoryRegionResult>();

                SYSTEM_INFO sys_info = new SYSTEM_INFO();
                GetSystemInfo(out sys_info);

                UIntPtr proc_min_address = sys_info.minimumApplicationAddress;
                UIntPtr proc_max_address = sys_info.maximumApplicationAddress;

                long start = (long)targetModule.BaseAddress;
                long end = start + targetModule.ModuleMemorySize;

                Debug.WriteLine("[DEBUG] memory scan starting... (start:0x" + start.ToString(MSize(Is64bit)) + " end:0x" + end.ToString(MSize(Is64bit)) + " time:" + DateTime.Now.ToString("h:mm:ss tt") + ")");
                UIntPtr currentBaseAddress = new UIntPtr((ulong)start);

                MEMORY_BASIC_INFORMATION memInfo = new MEMORY_BASIC_INFORMATION();

                //Debug.WriteLine("[DEBUG] start:0x" + start.ToString("X8") + " curBase:0x" + currentBaseAddress.ToUInt64().ToString("X8") + " end:0x" + end.ToString("X8") + " size:0x" + memInfo.RegionSize.ToString("X8") + " vAloc:" + VirtualQueryEx(mProc.Handle, currentBaseAddress, out memInfo).ToUInt64().ToString());

                // ปรับส่วนนี้เพื่อให้แน่ใจว่าเราไม่ออกนอกขอบเขตของ module
                if (currentBaseAddress.ToUInt64() < (ulong)start)
                    currentBaseAddress = new UIntPtr((ulong)start);

                while (VirtualQueryEx(hProcess, Is64bit, currentBaseAddress, out memInfo).ToUInt64() != 0 &&
                    currentBaseAddress.ToUInt64() < (ulong)end &&
                    currentBaseAddress.ToUInt64() + (ulong)memInfo.RegionSize > currentBaseAddress.ToUInt64())
                {

                    // เพิ่มการตรวจสอบนี้ที่นี่
                    if (memInfo.BaseAddress.ToUInt64() >= (ulong)end)
                        break;


                    bool isValid = memInfo.State == MEM_COMMIT;
                    isValid &= memInfo.BaseAddress.ToUInt64() < (ulong)proc_max_address.ToUInt64();
                    isValid &= ((memInfo.Protect & PAGE_GUARD) == 0);
                    isValid &= ((memInfo.Protect & PAGE_NOACCESS) == 0);
                    isValid &= (memInfo.Type == MEM_PRIVATE) || (memInfo.Type == MEM_IMAGE);
                    if (mapped)
                        isValid &= (memInfo.Type == MEM_MAPPED);

                    if (isValid)
                    {
                        bool isReadable = (memInfo.Protect & PAGE_READONLY) > 0;

                        bool isWritable = ((memInfo.Protect & PAGE_READWRITE) > 0) ||
                                          ((memInfo.Protect & PAGE_WRITECOPY) > 0) ||
                                          ((memInfo.Protect & PAGE_EXECUTE_READWRITE) > 0) ||
                                          ((memInfo.Protect & PAGE_EXECUTE_WRITECOPY) > 0);

                        bool isExecutable = ((memInfo.Protect & PAGE_EXECUTE) > 0) ||
                                            ((memInfo.Protect & PAGE_EXECUTE_READ) > 0) ||
                                            ((memInfo.Protect & PAGE_EXECUTE_READWRITE) > 0) ||
                                            ((memInfo.Protect & PAGE_EXECUTE_WRITECOPY) > 0);

                        isReadable &= readable;
                        isWritable &= writable;
                        isExecutable &= executable;

                        isValid &= isReadable || isWritable || isExecutable;
                    }

                    if (!isValid)
                    {
                        currentBaseAddress = new UIntPtr(memInfo.BaseAddress.ToUInt64() + (ulong)memInfo.RegionSize);
                        continue;
                    }

                    MemoryRegionResult memRegion = new MemoryRegionResult
                    {
                        CurrentBaseAddress = currentBaseAddress,
                        RegionSize = memInfo.RegionSize,
                        RegionBase = memInfo.BaseAddress
                    };

                    currentBaseAddress = new UIntPtr(memInfo.BaseAddress.ToUInt64() + (ulong)memInfo.RegionSize);

                    //Console.WriteLine("SCAN start:" + memRegion.RegionBase.ToString() + " end:" + currentBaseAddress.ToString());
                    
                    // เพิ่มการตรวจสอบนี้เพื่อให้แน่ใจว่าเราไม่เกินขอบเขตของ module
                    if (currentBaseAddress.ToUInt64() >= (ulong)end)
                        break;

                    if (memRegionList.Count > 0)
                    {
                        var previousRegion = memRegionList[memRegionList.Count - 1];

                        if ((long)previousRegion.RegionBase + previousRegion.RegionSize == (long)memInfo.BaseAddress)
                        {
                            memRegionList[memRegionList.Count - 1] = new MemoryRegionResult
                            {
                                CurrentBaseAddress = previousRegion.CurrentBaseAddress,
                                RegionBase = previousRegion.RegionBase,
                                RegionSize = previousRegion.RegionSize + memInfo.RegionSize
                            };

                            continue;
                        }
                    }

                    memRegionList.Add(memRegion);
                }

                ConcurrentBag<long> bagResult = new ConcurrentBag<long>();

                Parallel.ForEach(memRegionList,
                         (item, parallelLoopState, index) =>
                         {
                             long[] compareResults = CompareScan(hProcess, item, aobPattern);

                             foreach (long result in compareResults)
                             {
                                 bagResult.Add(result);
                                 parallelLoopState.Stop(); // หยุดทันทีที่พบผลลัพธ์แรก
                             }
                         });

                Debug.WriteLine("[DEBUG] memory scan completed. (time:" + DateTime.Now.ToString("h:mm:ss tt") + ")");

                //return bagResult.ToList().OrderBy(c => c).AsEnumerable();
                // แทนที่ return bagResult.ToList().OrderBy(c => c).AsEnumerable();
                return bagResult.FirstOrDefault();
            });


            return results != 0 ? new UIntPtr((ulong)results) : UIntPtr.Zero;
        }

        private static long[] CompareScan(IntPtr hProcess, MemoryRegionResult item, byte[] aobPattern)
        {


            //IntPtr buffer = Marshal.AllocHGlobal((int)item.RegionSize);
            // สร้าง byte array ขนาดเท่ากับ RegionSize
            byte[] buffer = new byte[(int)item.RegionSize];
            bool success = ReadProcessMemory(hProcess, item.CurrentBaseAddress, buffer, (int)item.RegionSize, out UIntPtr bytesRead);

            if (!success)
            {
                throw new Exception($"Failed to read process memory. Error: {Marshal.GetLastWin32Error()}");
            }


            List<long> results = new List<long>();

            for (int i = 0; i <= buffer.Length - aobPattern.Length; i++)
            {
                if (CompareBytes(buffer, i, aobPattern))
                {
                    results.Add((long)item.CurrentBaseAddress + i);
                }
            }


            return results.ToArray();
        }

        private static bool CompareBytes(byte[] haystack, int offset, byte[] needle)
        {
            if (needle.Length > (haystack.Length - offset))
                return false;

            for (int i = 0; i < needle.Length; i++)
            {
                if (haystack[offset + i] != needle[i])
                    return false;
            }

            return true;
        }

        private static int FindPattern(byte[] body, int bodyLength, byte[] pattern, byte[] masks, int start = 0)
        {
            int foundIndex = -1;

            if (bodyLength <= 0 || pattern.Length <= 0 || start > bodyLength - pattern.Length ||
                pattern.Length > bodyLength) return foundIndex;

            for (int index = start; index <= bodyLength - pattern.Length; index++)
            {
                if (((body[index] & masks[0]) == (pattern[0] & masks[0])))
                {
                    var match = true;
                    for (int index2 = pattern.Length - 1; index2 >= 1; index2--)
                    {
                        if ((body[index + index2] & masks[index2]) == (pattern[index2] & masks[index2])) continue;
                        match = false;
                        break;

                    }

                    if (!match) continue;

                    foundIndex = index;
                    break;
                }
            }

            return foundIndex;
        }


        public struct SYSTEM_INFO
        {
            public ushort processorArchitecture;
            ushort reserved;
            public uint pageSize;
            public UIntPtr minimumApplicationAddress;
            public UIntPtr maximumApplicationAddress;
            public IntPtr activeProcessorMask;
            public uint numberOfProcessors;
            public uint processorType;
            public uint allocationGranularity;
            public ushort processorLevel;
            public ushort processorRevision;
        }
        public struct MEMORY_BASIC_INFORMATION
        {
            public UIntPtr BaseAddress;
            public UIntPtr AllocationBase;
            public uint AllocationProtect;
            public long RegionSize;
            public uint State;
            public uint Protect;
            public uint Type;
        }
        public struct MEMORY_BASIC_INFORMATION32
        {
            public UIntPtr BaseAddress;
            public UIntPtr AllocationBase;
            public uint AllocationProtect;
            public uint RegionSize;
            public uint State;
            public uint Protect;
            public uint Type;
        }
        public struct MEMORY_BASIC_INFORMATION64
        {
            public UIntPtr BaseAddress;
            public UIntPtr AllocationBase;
            public uint AllocationProtect;
            public uint __alignment1;
            public ulong RegionSize;
            public uint State;
            public uint Protect;
            public uint Type;
            public uint __alignment2;
        }

        struct MemoryRegionResult
        {
            public UIntPtr CurrentBaseAddress { get; set; }
            public long RegionSize { get; set; }
            public UIntPtr RegionBase { get; set; }

        }

        private static string MSize(bool Is64bit)
        {
            if (Is64bit)
                return ("x16");
            else
                return ("x8");
        }
    }
}
