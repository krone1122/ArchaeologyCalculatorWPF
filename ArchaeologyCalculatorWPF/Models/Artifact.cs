using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArchaeologyCalculatorWPF.Models
{
    public class Artifact : INotifyPropertyChanged
    {
        private string? _name;
        private int _quantityOwned;
        private ObservableCollection<Material>? _materials;
        private string? _results;

        public string? Name 
        { 
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged("Name");
            }
        }

        public int QuantityOwned
        {
            get { return _quantityOwned; }
            set
            {
                _quantityOwned = value;
                OnPropertyChanged("QuantityOwned");
            }
        }

        public ObservableCollection<Material>? Materials
        {
            get { return _materials; }
            set
            {
                _materials = value;
                OnPropertyChanged("Materials");
            }
        }

        public string? Results 
        { 
            get { return _results; }
            set
            {
                _results = value;
                OnPropertyChanged("Results");
            }
        }


        public event PropertyChangedEventHandler? PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public Artifact()
        {
            Materials = new ObservableCollection<Material>();
        }
    }
}
