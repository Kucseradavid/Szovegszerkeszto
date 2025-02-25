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
    /// Interaction logic for CustomToolbar.xaml
    /// </summary>
    public partial class CustomToolbar : UserControl
    {
        public bool IsSynchronizing { get; private set; }

        public CustomToolbar()
        {
            InitializeComponent();
        }

        private void FontsizeFeltolt(object sender, RoutedEventArgs e)
        {
            for (int i = 8; i <= 48; i += 2)
            {
                fontsize.Items.Add(i);
            }
        }

        private void SetFontSize(double size)
        {
            fontsize.SelectedValue = size;
        }

        private void SetFontWeight(FontWeight weight)
        {
            boldbtn.IsChecked = weight == FontWeights.Bold;
        }

        private void SetFontStyle(FontStyle style)
        {
            italicbtn.IsChecked = style == FontStyles.Italic;
        }

        private void SetTextDecoration(TextDecorationCollection decoration)
        {
            underlinebtn.IsChecked = decoration == TextDecorations.Underline;
        }

        private void SetFontFamily(FontFamily family)
        {
            fonts.SelectedItem = family;
        }

        private void Synchronize<T>(TextSelection selection, DependencyProperty property, Action<T> methodToCall)
        {
            object value = selection.GetPropertyValue(property);
            if (value != DependencyProperty.UnsetValue) methodToCall((T)value);
        }

        public void SynchronizeWith(TextSelection selection)
        {
            IsSynchronizing = true;

            Synchronize<double>(selection, TextBlock.FontSizeProperty, SetFontSize);
            Synchronize<FontWeight>(selection, TextBlock.FontWeightProperty, SetFontWeight);
            Synchronize<FontStyle>(selection, TextBlock.FontStyleProperty, SetFontStyle);
            Synchronize<TextDecorationCollection>(selection, TextBlock.TextDecorationsProperty, SetTextDecoration);
            Synchronize<FontFamily>(selection, TextBlock.FontFamilyProperty, SetFontFamily);

            IsSynchronizing = false;
        } //27. oldal pdfben - nem működik
    }
}
