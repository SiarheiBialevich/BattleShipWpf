using System.Windows;

namespace BattleShipWpf
{
   /// <summary>
   /// Interaction logic for MainWindow.xaml
   /// </summary>
   public partial class MainWindow : Window
   {
      BattleShipVM bs = new BattleShipVM();
      public MainWindow()
      {
         InitializeComponent();
         DataContext = bs;
      }

      private void btnStart(object sender, RoutedEventArgs e)
      {
         bs.Start();
      }

      private void btnStop(object sender, RoutedEventArgs e)
      {
         bs.Stop();
      }
   }
}
