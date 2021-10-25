using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Common.Dto
{
    public abstract class BaseNotifyDto<T> : BaseEntityDto<T>, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public bool SetField<T>(ref T field, T value, [CallerMemberName] string propertyName = "")
        {
            if (EqualityComparer<T>.Default.Equals(field, value))
                return false;

            field = value;
            OnPropertyChanged(propertyName);

            return true;
        }

        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        //Ejemplos de Implementacion de Notificaciones
        //private string name;
        //public string Name
        //{
        //    get => name;
        //    set => SetField(ref name, value);
        //}

        //private string customerNameValue;
        //public string CustomerName
        //{
        //    get => this.customerNameValue;
        //    set
        //    {
        //        if (value != this.customerNameValue)
        //        {
        //            this.customerNameValue = value;
        //            NotifyPropertyChanged();
        //        }
        //    }
        //}
    }
}
