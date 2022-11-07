using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace BattleShipWpf
{
   internal class ViewModelBase : INotifyPropertyChanged
   {
      public event PropertyChangedEventHandler PropertyChanged;

      protected void Set<T>(ref T field, T value, [CallerMemberName] string propName = "")
      {
         if (!field.Equals(value))
         {
            field = value;
            PropertyChanged(this, new PropertyChangedEventArgs(propName));
         }
      }

      protected void Notify(params string[] names)
      {
         foreach (var name in names)
         {
            PropertyChanged(this, new PropertyChangedEventArgs(name));
         }
      }
   }
}