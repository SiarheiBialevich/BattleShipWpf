namespace BattleShipWpf;

enum DirectionShip
{
   Horisont,
   Vertical
}
internal class ShipVM : ViewModelBase
{
   private int _rang = 1;
   private (int x, int y) _pos;
   private DirectionShip _dir = DirectionShip.Horisont;

   public DirectionShip Direct
   {
      get => _dir;
      set => Set(ref _dir, value, "Angle");
   }
   public int Rang
   {
      get => _rang;
      set => Set(ref _rang, value, "RangView");
   }

   public int RangView => Rang * App.CellSize - 5;
   public int Angle => _dir == DirectionShip.Horisont ? 0 : 90;
   public (int, int) Pos
   {
      get => _pos;
      set => Set(ref _pos, value, "X", "Y");
   }
   public int X => _pos.x * App.CellSize + 3;
   public int Y => _pos.y * App.CellSize + 3;

}