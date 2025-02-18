using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TextEditor;
using static System.Net.Mime.MediaTypeNames;

namespace Szovegszerkeszto
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private DocumentManager _documentManager;
        public MainWindow()
        {
            InitializeComponent();

            _documentManager = new DocumentManager(body);

            if (_documentManager.OpenDocument())
            {
                status.Text = "doc loaded";
            }
        }

        private void toolbar_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox source = e.OriginalSource as ComboBox;
            if (source == null) return;
            switch (source.Name)
            {
                case "fonts": _documentManager.ApplyToSelection(TextBlock.FontFamilyProperty, source.SelectedItem); break;
                case "fontsize": _documentManager.ApplyToSelection(TextBlock.FontSizeProperty, Convert.ToDouble(source.SelectedItem)); break;
            }
            body.Focus();
        }

        private void body_SelectionChanged(object sender, RoutedEventArgs e)
        {

        }
    }
}