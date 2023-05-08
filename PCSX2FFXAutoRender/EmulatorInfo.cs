namespace PCSX2FFXAutoRender
{
    using System.Diagnostics;
    using System.Linq;

    public class EmulatorInfo
    {
        public EmulatorInfo()
        {
            var regValues = RegistryEditor.ReadRegistry();
            ProcessName = regValues[0];
            ExeLocation = regValues[1];
            IsoLocation = regValues[2];
        }

        public string ExeLocation { get; set; }

        public string IsoLocation { get; set; }

        public string ProcessName { get; set; }

        public void AutoStartEmulator()
        {
            if (Process.GetProcessesByName(ProcessName).Length == 0)
            {
                var arg = " --fullscreen ";
                var path = $"{ExeLocation}";
                Process.Start(path, $"\"{IsoLocation}\" {arg}");
            }
        }
    }
}