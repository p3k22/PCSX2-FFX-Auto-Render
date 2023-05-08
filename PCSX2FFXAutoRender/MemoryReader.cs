namespace PCSX2FFXAutoRender
{
    using System;
    using System.Diagnostics;
    using System.Linq;
    using System.Windows;

    public static class MemoryReader
    {
        public static string CurrentProcessName;

        public static Process Pcsx2;

        private static VAMemory memory;

        public static int ExpMenuValue => GetValueAtOffset(0x240B16D0);

        //public static int MainMenuValue => GetValueAtOffset(0x20703FF3);
        public static int MainMenuValue => GetValueAtOffset(0x20323950);

        //public static int RenderModeValue => GetValueBaseOffset(0x119CFEB);
        public static int RenderModeValue => GetValueBaseOffset(0x8D78D7);

        public static int SphereGridValue => GetValueAtOffset(0x20326438);
        //public static int SphereGridValue => GetValueBaseOffset(0x8E1FC6);

        private static int GetValueAtOffset(int offset)
        {
            GetProcessMemory();
            try
            {
                if (Pcsx2?.MainModule != null)
                {
                    var pntOffset = new IntPtr(offset);
                    return memory.ReadByte(pntOffset);
                }
            }
            catch (Exception e)
            {
                if (Application.Current.MainWindow != null)
                {
                    Application.Current.MainWindow.Close();
                    Console.Write(e.ToString());
                }
            }

            return 0;
        }

        private static int GetValueBaseOffset(int offset)
        {
            GetProcessMemory();
            try
            {
                if (Pcsx2?.MainModule != null)
                {
                    var baseAddress = Pcsx2.MainModule.BaseAddress;
                    var baseOffset1 = IntPtr.Add(baseAddress, offset);
                    var value = memory.ReadByte(baseOffset1);
                    return value;
                }
            }
            catch (Exception e)
            {
                if (Application.Current.MainWindow != null)
                {
                    Application.Current.MainWindow.Close();
                    Console.Write(e.ToString());
                }
            }

            return 0;
        }

        private static void GetProcessMemory()
        {
            if (Pcsx2 == null)
            {
                var process = Process.GetProcessesByName(CurrentProcessName);
                if (process.Length > 0)
                {
                    Pcsx2 = process[0];
                }
            }

            if (memory == null)
            {
                memory = new VAMemory(CurrentProcessName);
            }
        }
    }
}