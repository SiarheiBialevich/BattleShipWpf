using System;
using System.Resources;
using System.Windows.Threading;

namespace BattleShipWpf
{
   class BattleShipVM : ViewModelBase
   {
      DispatcherTimer timer;
      DateTime startTime;

      string time = "";

      public CellVM[][] OurMap { get; private set; }
      public CellVM[][] EnemyMap { get; private set; }

      public string Time {
         get => time;
         private set => Set( ref time, value); 
      }

      public BattleShipVM()
      {
         timer = new DispatcherTimer();
         timer.Interval = TimeSpan.FromMilliseconds(100);
         timer.Tick += Timer_Tick;

         OurMap = MapFabrica();
         EnemyMap = MapFabrica();
      }

      CellVM[][] MapFabrica()
      {
         var map = new CellVM[10][];
         for (int i = 0; i < 10; i++)
         {
            map[i] = new CellVM[10];
            for (int j = 0; j < 10; j++)
            {
               map[i][j] = new CellVM();
            }
         }

         return map;
      }

      private void Timer_Tick(object? sender, EventArgs e)
      {
         var now = DateTime.Now;
         var dt = now - startTime;
         Time = dt.ToString(@"mm\:ss");

      }

      public void Start()
      {
         startTime = DateTime.Now;
         timer.Start();
      }

      public void Stop()
      {
         timer.Stop();
      }
   }

   internal class CellVM : ViewModelBase
   {
   }
}
