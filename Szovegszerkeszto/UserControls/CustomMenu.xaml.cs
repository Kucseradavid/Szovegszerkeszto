using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Szovegszerkeszto.UserControls
{
    /// <summary>
    /// Interaction logic for CustomMenu.xaml
    /// </summary>
    public partial class CustomMenu : UserControl
    {
        public CustomMenu()
        {
            InitializeComponent();
        }

        private void AboutClick(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show("-Aurora");
            MessageBox.Show("Mit kípzesz magadró hogy néked segíccség kű egy roadt szövgszerszesztűhőő hogy erre nem kípes egy normaalis embő", "Elbocsájtó, szép üzenet");
        }
    }
}
