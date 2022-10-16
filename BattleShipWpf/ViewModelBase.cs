using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace BattleShipWpf
{
   internal class ViewModelBase : INotifyPropertyChanged
   {
      public event PropertyChangedEventHandler PropertyChanged;

      protected void Set<T>(ref T field, T value, [CallerMemberName] string propName = "") where T: IEquatable<T>
      {
         if (!field.Equals(value))
         {
            field = value;
            PropertyChanged(this, new PropertyChangedEventArgs(propName));
         }
      }

      protected void Fire(params string[] names)
      {
         foreach (var name in names)
         {
            PropertyChanged(this, new PropertyChangedEventArgs(name));
         }
      }
   }
}