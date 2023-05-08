namespace PCSX2FFXAutoRender
{
    using System.Linq;
    using System.Windows;
    using System.Windows.Controls;

    public partial class MainWindowView : Window
    {
        public MainWindowView()
        {
            ViewModel = new MainWindowViewModel();
            InitializeComponent();
            ViewModel.SetTextBoxes(new[] { pcsx2Location, processName, ffxLocation });
        }

        public MainWindowViewModel ViewModel { get; }

        private void OnChangeText_SetProcessName(object sender, TextChangedEventArgs e)
        {
            ViewModel.SetProcessPath(processName.Text);
        }

        private void OnClick_SetExe(object sender, RoutedEventArgs e)
        {
            ViewModel.SetPCSX2EXEPath();
        }

        private void OnClick_SetIso(object sender, RoutedEventArgs e)
        {
            ViewModel.SetFFXISOPath();
        }

        private void OnClick_Start(object sender, RoutedEventArgs e)
        {
            var b = (Button)sender;

            ViewModel.StartReadingMemory(b.Name == quickStart.Name ? 0 : 15);
        }

        private void OnClick_Stop(object sender, RoutedEventArgs e)
        {
            ViewModel.StopReadingMemory();
        }
    }
}