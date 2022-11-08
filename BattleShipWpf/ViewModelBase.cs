using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace BattleShipWpf
{
   internal class ViewModelBase : INotifyPropertyChanged
   {
      public event PropertyChangedEventHandler PropertyChanged; // или добавить сюда = delegate {}

      protected void Set<T>(ref T field, T value, [CallerMemberName] string propName = "")
      {
         if (!field.Equals(value))
         {
            field = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));//добавить сюда ?.Invoke
         }
      }
      
      protected void Set<T>(ref T field, T value, params string[] propNames)
      {
         if (!field.Equals(value))
         {
            field = value;
            foreach (var name in propNames)
               PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));//добавить сюда ?.Invoke
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