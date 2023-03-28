using System;
using System.Collections.Generic;

using System.Text;
using System.ComponentModel;

namespace CSharpHowTo_book
{
    namespace NotifyingClients
    {
        class MyDataClass : INotifyPropertyChanged
        {
            public event PropertyChangedEventHandler PropertyChanged;
            protected void OnPropertyChanged(string propertyName)
            {
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new
                    PropertyChangedEventArgs(propertyName));
                }
            }
            private int _tag = 0;
            public int Tag
            {
                get { return _tag; }
                set 
                { 
                    _tag = value;
                    OnPropertyChanged("Tag");
                }
            }
        }
    }
}
