namespace PCSX2FFXAutoRender
{
    using System.ComponentModel;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using System.Windows.Media;

    public class AddressValueDisplay : INotifyPropertyChanged
    {
        private int _value;

        private SolidColorBrush _colour;

        private string _text;

        public event PropertyChangedEventHandler PropertyChanged;

        public int Value
        {
            get => _value;
            set
            {
                _value = value;
                OnPropertyChanged();
            }
        }

        public SolidColorBrush Colour
        {
            get => _colour;
            set
            {
                _colour = value;
                OnPropertyChanged();
            }
        }

        public string Text
        {
            get => _text;
            set
            {
                _text = value;
                OnPropertyChanged();
            }
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}