using System;
using System.Resources;
using System.Windows;
using System.Windows.Threading;

namespace BattleShipWpf
{
   class BattleShipVM : ViewModelBase
   {
      DispatcherTimer _timer;
      DateTime _startTime;

      string _time = "";

      private string _ourMap =
         @"
**********
*XXXX***X*
******X***
XX*XX***XX
******X***
*XXX******
*****XXX**
**********
***X******
**********
";

      public CellVM[][] OurMap { get; private set; }
      public CellVM[][] EnemyMap { get; private set; }

      public string Time {
         get => _time;
         private set => Set( ref _time, value); 
      }

      public BattleShipVM()
      {
         _timer = new DispatcherTimer();
         _timer.Interval = TimeSpan.FromMilliseconds(100);
         _timer.Tick += Timer_Tick;

         OurMap = MapFabrica(_ourMap);
         EnemyMap = MapFabrica(_ourMap);
      }

      CellVM[][] MapFabrica(string str)
      {
         var mp = str.Split("\r\n", StringSplitOptions.RemoveEmptyEntries);
         var map = new CellVM[10][];
         for (int i = 0; i < 10; i++)
         {
            map[i] = new CellVM[10];
            for (int j = 0; j < 10; j++)
            {
               map[i][j] = new CellVM(mp[i][j]);
            }
         }

         return map;
      }

      private void Timer_Tick(object? sender, EventArgs e)
      {
         var now = DateTime.Now;
         var dt = now - _startTime;
         Time = dt.ToString(@"mm\:ss");

      }

      public void Start()
      {
         _startTime = DateTime.Now;
         _timer.Start();
      }

      public void Stop()
      {
         _timer.Stop();
      }

      public void ShotToOurMap(int x, int y)
      {
         OurMap[y][x].ToShot();
      }
   }

   internal class CellVM : ViewModelBase
   {
      private bool _ship, _shot;

      public CellVM(char state)
      {
         _ship = state == 'X';
      }

      public Visibility Miss => _shot && !_ship ? Visibility.Visible : Visibility.Collapsed;
      
      public Visibility Shot => _shot && _ship ? Visibility.Visible : Visibility.Collapsed;

      public void ToShot()
      {
         _shot = true;
         Fire("Miss", "Shot");
      }
   }
}
