namespace PCSX2FFXAutoRender
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using System.Windows.Threading;

    using TextBox = System.Windows.Controls.TextBox;

    public class MainWindowViewModel
    {
        private bool _isReading;

        private DispatcherTimer _autoStartTimer;

        private TextBox[] _infoTextBoxes;

        public MainWindowViewModel()
        {
            Model = new MainWindowModel();
        }

        public MainWindowModel Model { get; }

        private async void Update()
        {
            while (_isReading)
            {
                await Task.Delay(1);

                Model.Update();
            }

            Model.GetNewDisplayValues();
        }

        public void SetFFXISOPath()
        {
            var fileDialog = new OpenFileDialog
                                 {
                                     Filter = @"All Files (*.iso*)|*.iso*", FilterIndex = 1, Multiselect = false
                                 };

            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                Model.EmulatorInfo.IsoLocation = fileDialog.FileName;
                _infoTextBoxes.Where(n => n.Name == "ffxLocation").ToArray()[0].Text = Model.EmulatorInfo.IsoLocation;
                Model.SetRegistryInfo();
            }
        }

        public void SetPCSX2EXEPath()
        {
            var fileDialog = new OpenFileDialog
                                 {
                                     Filter = @"All Files (*.exe*)|*.exe*", FilterIndex = 1, Multiselect = false
                                 };

            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                Model.EmulatorInfo.ExeLocation = fileDialog.FileName;
                _infoTextBoxes.Where(n => n.Name == "pcsx2Location").ToArray()[0].Text = Model.EmulatorInfo.ExeLocation;
                Model.SetRegistryInfo();
            }
        }

        public void SetProcessPath(string processName)
        {
            Model.EmulatorInfo.ProcessName = processName;
            _infoTextBoxes.Where(n => n.Name == "processName").ToArray()[0].Text = Model.EmulatorInfo.ProcessName;
            Model.SetRegistryInfo();
        }

        public void SetTextBoxes(IEnumerable<TextBox> emulatorInfoTextBoxes)
        {
            _infoTextBoxes = emulatorInfoTextBoxes as TextBox[] ?? emulatorInfoTextBoxes.ToArray();
            _infoTextBoxes.Where(n => n.Name == "processName").ToArray()[0].Text = Model.EmulatorInfo.ProcessName;
            _infoTextBoxes.Where(n => n.Name == "pcsx2Location").ToArray()[0].Text = Model.EmulatorInfo.ExeLocation;
            _infoTextBoxes.Where(n => n.Name == "ffxLocation").ToArray()[0].Text = Model.EmulatorInfo.IsoLocation;
        }

        public void StartReadingMemory(int secondsDelay)
        {
            _autoStartTimer = new DispatcherTimer();
            _autoStartTimer.Interval = new TimeSpan(0, 0, 0, secondsDelay);
            if (secondsDelay > 1)
            {
                _autoStartTimer.Tick += AutoStart;
                _autoStartTimer.Start();

                Model.EmulatorInfo.AutoStartEmulator();
            }
            else
            {
                var m = MemoryReader.MainMenuValue;
                if (MemoryReader.Pcsx2 != null)
                {
                    _autoStartTimer.Tick += AutoStart;
                    _autoStartTimer.Start();
                }
            }
        }

        public void StopReadingMemory()
        {
            _isReading = false;
            Model.RenderMode.IsMonitoring = false;
        }

        private void AutoStart(object sender, EventArgs e)
        {
            _isReading = true;
            Update();
                Model.RenderMode.IsMonitoring = true;
                Model.RenderMode.Monitor3();

                _autoStartTimer.Stop();
            _autoStartTimer.Tick -= AutoStart;
        }
    }
}