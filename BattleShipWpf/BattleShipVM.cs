using System;
using System.Windows.Threading;

namespace BattleShipWpf
{
   class BattleShipVM : ViewModelBase
   {
      DispatcherTimer timer;
      DateTime startTime;

      string time = "";

      public string Time {
         get => time;
         private set => Set( ref time, value); 
      }

      public BattleShipVM()
      {
         timer = new DispatcherTimer();
         timer.Interval = TimeSpan.FromMilliseconds(100);
         timer.Tick += Timer_Tick;

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
}
