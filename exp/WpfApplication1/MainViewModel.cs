using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows;
using System.Windows.Data;
using WpfApplication1.Annotations;

namespace WpfApplication1
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private Item _selectedItem;
        private int _nextItem = 2;
        private readonly Timer _addItem;
        private CollectionViewSource _source;

        public ObservableCollection<Item> Items { get; set; } = new ObservableCollection<Item>();

        public CollectionViewSource Source
        {
            get { return _source ?? (_source = new CollectionViewSource() {Source = Items}); }
            set
            {
                _source = value;
                OnPropertyChanged();
            }
        }

        public ICollectionViewLiveShaping ShapingItems => Source.View as ICollectionViewLiveShaping;

        public Item SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                if (Equals(value, _selectedItem)) return;
                _selectedItem = value;
                OnPropertyChanged();
            }
        }

        public MainViewModel()
        {
            ShapingItems.LiveSortingProperties.Add("Other");
            ShapingItems.IsLiveSorting = true;

            Items.Add(new Item() { ID = 1, Name = "Item 1" });
            
            _addItem = new Timer(ob => AddItem(), null, (int) new TimeSpan(0, 0, 0, 5).TotalMilliseconds, Timeout.Infinite);
        }

        private void AddItem()
        {
            Application.Current.Dispatcher.BeginInvoke(new Action(() =>
            {
                try
                {
                    if (_nextItem > 10)
                    {
                        var r = new Random();
                        var change = r.Next(0, Items.Count - 1);
                        Items[change].Other = Item.Random(5);
                        return;
                    }

                    Items.Add(new Item() { ID = _nextItem, Name = $"Item {_nextItem}"});

                    

                    _nextItem++;
                }
                finally
                {
                    _addItem.Change((int) new TimeSpan(0, 0, 0, 4).TotalMilliseconds, Timeout.Infinite);
                }
            }));
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            Console.WriteLine("DriverRosterStatusViewModel.OnPropertyChanged(prop: " + propertyName + ")");

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}