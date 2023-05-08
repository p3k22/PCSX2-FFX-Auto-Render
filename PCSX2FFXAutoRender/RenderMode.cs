namespace PCSX2FFXAutoRender
{
    using System;
    using System.Linq;
    using System.Runtime.InteropServices;
    using System.Threading.Tasks;
    using System.Windows.Forms;

    public class RenderMode
    {
        public bool IsMonitoring { get; set; }

        public async void Monitor3()
        {
            while (IsMonitoring)
            {
                await Task.Delay(500);

                var renderValue = MemoryReader.RenderModeValue;
                Console.WriteLine($"RenderVal {renderValue}");
                if (renderValue == 0)
                {
                    var thisValue = MemoryReader.RenderModeValue;

                    while (thisValue == renderValue && renderValue == 0)
                    {
                        await Task.Delay(10);
                        var menuValue = MemoryReader.MainMenuValue;
                        var isOnAMenu = menuValue == 1;
                        thisValue = MemoryReader.RenderModeValue;
                        Console.WriteLine($"New RenderVal {thisValue}");
                        if (thisValue != renderValue || isOnAMenu)
                        {
                            if (MemoryReader.SphereGridValue == 1)
                                continue;
                            if (!isOnAMenu)
                                await Task.Delay(500);
                            PressF9();
                            await Task.Delay(10);
                            break;
                        }
                    }
                }
                else if (renderValue == 1)
                {
                    var thisValue = MemoryReader.RenderModeValue;

                    while (thisValue == renderValue && renderValue == 1)
                    {
                        await Task.Delay(10);
                        var menuValue = MemoryReader.MainMenuValue;
                        var isOffMenus = menuValue == 0;
                        thisValue = MemoryReader.RenderModeValue;
                        Console.WriteLine($"New RenderVal {thisValue}");
                        if (thisValue != renderValue || isOffMenus || MemoryReader.SphereGridValue == 1)
                        {
                            if (!isOffMenus || MemoryReader.SphereGridValue == 1)
                                await Task.Delay(500);
                            PressF9();
                            await Task.Delay(10);
                            break;
                        }
                    }
                }
            }
        }

        [DllImport("User32.dll")]
        private static extern int SetForegroundWindow(IntPtr point);

        private static void PressF9()
        {
            if (MemoryReader.Pcsx2 == null)
                return;
            var h = MemoryReader.Pcsx2.MainWindowHandle;
            SetForegroundWindow(h);
            SendKeys.SendWait("{F9}");
            Console.WriteLine($"Pressing F9");
        }
    }
}