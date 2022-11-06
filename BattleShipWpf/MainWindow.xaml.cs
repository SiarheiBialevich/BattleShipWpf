using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace BattleShipWpf
{
   /// <summary>
   /// Interaction logic for MainWindow.xaml
   /// </summary>
   public partial class MainWindow : Window
   {
      BattleShipVM bs = new BattleShipVM();
      private Random rnd = new Random();
      public MainWindow()
      {
         InitializeComponent();
         DataContext = bs;
      }

      private void Border_MouseDown(object sender, MouseButtonEventArgs e)
      {
         var brd = sender as Border;
         var cellVM = brd.DataContext as CellVM;
         cellVM.ToShot();

         var x = rnd.Next(10);
         var y = rnd.Next(10);
         bs.ShotToOurMap(x, y);
      }
   }
}
