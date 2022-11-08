using System;
using System.Resources;
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

      public MapVM OurMap { get; private set; }
      public MapVM EnemyMap { get; private set; }

      public string Time
      {
         get => _time;
         private set => Set(ref _time, value);
      }

      public BattleShipVM()
      {
         _timer = new DispatcherTimer();
         _timer.Interval = TimeSpan.FromMilliseconds(100);
         _timer.Tick += Timer_Tick;

         OurMap = new MapVM(_ourMap);
         EnemyMap = new MapVM(_ourMap);

         FillShip();
      }

      private void Timer_Tick(object? sender, EventArgs e)
      {
         var now = DateTime.Now;
         var dt = now - _startTime;
         Time = dt.ToString(@"mm\:ss");
      }

      public void ShotToOurMap(int x, int y)
      {
         OurMap[x, y].ToShot();
      }

      void FillShip()
      {
         var ships = OurMap.Ships;
         ships.Add(new ShipVM { Rang = 4, Pos = (1, 1) });
         ships.Add(new ShipVM { Rang = 3, Pos = (6, 1), Direct = DirectionShip.Vertical });
         ships.Add(new ShipVM { Rang = 3, Pos = (8, 1), Direct = DirectionShip.Vertical });
         ships.Add(new ShipVM { Rang = 2, Pos = (1, 3) });
         ships.Add(new ShipVM { Rang = 2, Pos = (1, 5) });
         ships.Add(new ShipVM { Rang = 2, Pos = (4, 3), Direct = DirectionShip.Vertical });
         ships.Add(new ShipVM { Rang = 1, Pos = (1, 9) });
         ships.Add(new ShipVM { Rang = 1, Pos = (2, 7) });
         ships.Add(new ShipVM { Rang = 1, Pos = (4, 7) });
         ships.Add(new ShipVM { Rang = 1, Pos = (8, 9) });
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
   }
}