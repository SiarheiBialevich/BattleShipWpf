using System;
using System.Collections.Generic;

namespace BattleShipWpf;

internal class MapVM : ViewModelBase
{
   private readonly CellVM[,] _map;

   public CellVM this[int x, int y] => _map[y, x];

   public IReadOnlyCollection<IReadOnlyCollection<CellVM>> Map
   {
      get
      {
         var _map = new List<List<CellVM>>();
         for (var i = 0; i < 10; i++)
         {
            _map.Add(new List<CellVM>());
            for (var j = 0; j < 10; j++) _map[i].Add(this._map[i, j]);
         }

         return _map;
      }
   }

   public MapVM(string str) : this()
   {
      var mp = str.Split("\r\n", StringSplitOptions.RemoveEmptyEntries);
      for (var i = 0; i < 10; i++)
      for (var j = 0; j < 10; j++)
         _map[i, j].ToShip();
   }

   public MapVM()
   {
      _map = new CellVM[10, 10];
      for (var i = 0; i < 10; i++)
      for (var j = 0; j < 10; j++)
         _map[i, j] = new CellVM();

      FillMap();
   }

   private void FillMap()
   {
      var ps = new Dictionary<int, int>
      {
         [4] = 1,
         [3] = 2,
         [2] = 3,
         [1] = 4
      };

      for (var p = 0; p > 0; p--)
      {
         var k = ps[p];
      }
   }
}