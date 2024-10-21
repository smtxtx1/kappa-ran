using Memory;
using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Loader
{
    internal class CodeCave
    {
        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern bool VirtualFree(IntPtr lpAddress, uint dwSize, uint dwFreeType);

        private const uint MEM_RELEASE = 0x8000;

        public static int CreateCodeCave(byte[] freezebytesX, string gameAddress, int address, int replaceCount, int size, Mem m)
        {
            UIntPtr codecavebase = m.CreateCodeCave(gameAddress, freezebytesX, replaceCount, size);
            UIntPtr codecaveAllocAddress = UIntPtr.Add(codecavebase, freezebytesX.Length);
            address = (int)codecaveAllocAddress - 6;
            Debug.WriteLine("Read Allocated Memory: 0x" + address.ToString("X") + "\r\n" + codecaveAllocAddress);

            // Deallocate the memory once you are done with it
            DeallocateCodeCave(codecavebase);

            return address;
        }

        public static void DeallocateCodeCave(UIntPtr codecavebase)
        {
            if (codecavebase != UIntPtr.Zero)
            {
                // Convert UIntPtr to IntPtr by first converting to ulong and then to IntPtr
                IntPtr intPtrBase = new IntPtr((long)codecavebase.ToUInt64());

                bool result = VirtualFree(intPtrBase, 0, MEM_RELEASE);
                if (!result)
                {
                    int errorCode = Marshal.GetLastWin32Error();
                    Debug.WriteLine("Failed to deallocate memory. Error code: " + errorCode);
                }
                else
                {
                    Debug.WriteLine("Memory deallocated successfully.");
                }
            }
        }
    }
}
