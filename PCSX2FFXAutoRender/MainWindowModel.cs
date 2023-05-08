namespace PCSX2FFXAutoRender
{
    using System.ComponentModel;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using System.Windows.Media;

    public class MainWindowModel : INotifyPropertyChanged
    {
        private readonly SolidColorBrush _badColour = new SolidColorBrush(Colors.HotPink);

        private readonly SolidColorBrush _goodColour = new SolidColorBrush(Colors.LawnGreen);

        private AddressValueDisplay _applicationRunningValueDisplay;

        private AddressValueDisplay _sphereGridMenuValueDisplay;

        private AddressValueDisplay _mainMenuValueDisplay;

        private AddressValueDisplay _renderModeValueDisplay;

        public MainWindowModel()
        {
            EmulatorInfo = new EmulatorInfo();
            MemoryReader.CurrentProcessName = EmulatorInfo.ProcessName;
            GetNewDisplayValues();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public AddressValueDisplay ApplicationRunningValueDisplay
        {
            get => _applicationRunningValueDisplay;
            set
            {
                _applicationRunningValueDisplay = value;
                OnPropertyChanged();
            }
        }

        public AddressValueDisplay SphereGridMenuValueDisplay
        {
            get => _sphereGridMenuValueDisplay;
            set
            {
                _sphereGridMenuValueDisplay = value;
                OnPropertyChanged();
            }
        }

        public AddressValueDisplay MainMenuValueDisplay
        {
            get => _mainMenuValueDisplay;
            set
            {
                _mainMenuValueDisplay = value;
                OnPropertyChanged();
            }
        }

        public AddressValueDisplay RenderModeValueDisplay
        {
            get => _renderModeValueDisplay;
            set
            {
                _renderModeValueDisplay = value;
                OnPropertyChanged();
            }
        }

        public EmulatorInfo EmulatorInfo { get; }

        public RenderMode RenderMode { get; set; }

        public void Update()
        {
            ApplicationRunningValueDisplay.Text = "Running";
            ApplicationRunningValueDisplay.Colour = _goodColour;

            MainMenuValueDisplay.Value = MemoryReader.MainMenuValue;
            var isOn = MainMenuValueDisplay.Value == 1;
            MainMenuValueDisplay.Text = "Main Menu Is Open: " + (isOn ? "True" : "False");
            MainMenuValueDisplay.Colour = isOn ? _goodColour : _badColour;

            SphereGridMenuValueDisplay.Value = MemoryReader.SphereGridValue;
            isOn = SphereGridMenuValueDisplay.Value == 1;
            SphereGridMenuValueDisplay.Text = "Sphere Grid Menu Is Open: " + (isOn ? "True" : "False");
            SphereGridMenuValueDisplay.Colour = isOn ? _goodColour : _badColour;

            RenderModeValueDisplay.Value = MemoryReader.RenderModeValue;
            isOn = RenderModeValueDisplay.Value == 0;
            RenderModeValueDisplay.Text = "Render Mode:" + (isOn ? " Hardware" : " Software");
            RenderModeValueDisplay.Colour = isOn ? _goodColour : _badColour;
        }

        public void GetNewDisplayValues()
        {
            MainMenuValueDisplay = new AddressValueDisplay
                                       {
                                           Colour = _badColour, Text = "Main Menu Is Open: False", Value = 0
                                       };
            SphereGridMenuValueDisplay = new AddressValueDisplay
                                             {
                                                 Colour = _badColour,
                                                 Text = "Sphere Grid Menu Is Open: False",
                                                 Value = 0
                                             };
            RenderModeValueDisplay = new AddressValueDisplay
                                         {
                                             Colour = _goodColour, Text = "Render Mode: Hardware ", Value = 0
                                         };

            ApplicationRunningValueDisplay = new AddressValueDisplay
                                                 {
                                                     Colour = _badColour, Text = "Stopped", Value = 0
                                                 };

            RenderMode = new RenderMode();
        }

        public void SetRegistryInfo()
        {
            RegistryEditor.WriteRegistry(
            new[] { EmulatorInfo.ProcessName, EmulatorInfo.ExeLocation, EmulatorInfo.IsoLocation });
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}