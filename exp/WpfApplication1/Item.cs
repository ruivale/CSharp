using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using WpfApplication1.Annotations;

namespace WpfApplication1
{
    public class Item : INotifyPropertyChanged
    {
        private int _id;
        private string _name;
        private string _other;

        public int ID
        {
            get { return _id; }
            set
            {
                if (value == _id) return;
                _id = value;
                OnPropertyChanged();
            }
        }
        public string Name
        {
            get { return _name; }
            set
            {
                if (value == _name) return;
                _name = value;
                OnPropertyChanged();
            }
        }

        public string Other
        {
            get { return _other; }
            set
            {
                if (value == _other) return;
                _other = value;
                OnPropertyChanged();
            }
        }

        public Item()
        {
            Other = Random(10);
        }

        internal static string Random(int length)
        {
            const string allowedChars = "1234567890ABCDEFGHJKLMNOPQRSTUVWXYZ";
            var chars = new char[length];
            var rd = new Random();

            for (var i = 0; i < length; i++)
            {
                chars[i] = allowedChars[rd.Next(0, allowedChars.Length)];
            }

            return new string(chars);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}