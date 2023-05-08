namespace PCSX2FFXAutoRender
{
    using Microsoft.Win32;

    using System.Linq;

    public static class RegistryEditor
    {
        private const string DomainName = "P3kFFXPCSX2";

        private const string ValueFromName = "value";

        private static readonly string[] Lookups = { "processName", "pcsx2Location", "ffxLocation" };

        public static string[] ReadRegistry()
        {
            var values = new[] { "pcsx2", "C:\\pcsx2.exe", "C:\\FFX.iso" };
            for (var i = 0; i < Lookups.Length; i++)
            {
                var key = Registry.LocalMachine.OpenSubKey("Software", true);
                if (key != null)
                {
                    key = key.OpenSubKey(DomainName, true);

                    if (key != null)
                    {
                        key = key.OpenSubKey(Lookups[i], true);
                        var value = key?.GetValue(ValueFromName);
                        if (value != null)
                        {
                            values[i] = value.ToString();
                        }
                    }
                }
            }

            return values;
        }

        public static void WriteRegistry(string[] values)
        {
            for (var i = 0; i < Lookups.Length; i++)
            {
                var key = Registry.LocalMachine.OpenSubKey("Software", true);
                if (key != null)
                {
                    key.CreateSubKey(DomainName);
                    key = key.OpenSubKey(DomainName, true);

                    if (key != null)
                    {
                        key.CreateSubKey(Lookups[i]);
                        key = key.OpenSubKey(Lookups[i], true);
                        key?.SetValue(ValueFromName, $"{values[i]}");
                    }
                }
            }
        }
    }
}