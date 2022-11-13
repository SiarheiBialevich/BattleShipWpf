using System;
using System.Windows;

namespace BattleShipWpf;

internal class CellVM : ViewModelBase
{
   static Random rnd = new Random();

   public int Angle { get; } = rnd.Next(-5, 5);
   public int AngleX { get; } = rnd.Next(-5, 5);
   public int AngleY { get; } = rnd.Next(-5, 5);
   public float ScaleX { get; } = 1 + rnd.Next(-15, 3) / 100.0f;
   public float ScaleY { get; } = 1 + rnd.Next(-15, 3) / 100.0f;
   public float ShiftX { get; } = rnd.Next(-20, 20) / 10.0f;
   public float ShiftY { get; } = rnd.Next(-20, 20) / 10.0f;
   
   
   private bool _ship, _shot;

   public CellVM(char state = '*')
   {
      _ship = state == 'X';
   }

   public Visibility Miss => _shot && !_ship ? Visibility.Visible : Visibility.Collapsed;
      
   public Visibility Shot => _shot && _ship ? Visibility.Visible : Visibility.Collapsed;

   public void ToShot()
   {
      _shot = true;
      Notify("Miss", "Shot");
   }

   public void ToShip()
   {
      _ship = true;
   }
      
}