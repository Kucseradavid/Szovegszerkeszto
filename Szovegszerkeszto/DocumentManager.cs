using System.IO;
using System.Reflection.Metadata;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;
using Microsoft.Win32;

namespace TextEditor
{
    public class DocumentManager
    {
        private string _currentFile;
        private RichTextBox _richTextBox;
        public DocumentManager(RichTextBox textBox)
        {
            _richTextBox = textBox;
        }


        public bool OpenDocument()
        {
            OpenFileDialog dialog = new OpenFileDialog();

            //dialog.Filter = "Rich Text Document | *.rtf | Text Document | *.txt";

            if (dialog.ShowDialog() ?? false)
            {
                _currentFile = dialog.FileName;

                using (Stream stream = dialog.OpenFile())
                {
                    TextRange range = new TextRange
                    (
                        _richTextBox.Document.ContentStart,
                        _richTextBox.Document.ContentEnd
                    );

                    range.Load(stream, DataFormats.Rtf);
                }

                return true;
            }

            return false;
        }


        public bool SaveDocument()
        {
            if (string.IsNullOrEmpty(_currentFile)) return SaveDocumentAs();
            else
            {
                using (Stream stream = new FileStream(_currentFile, FileMode.Create))
                {
                    TextRange range = new TextRange
                    (
                        _richTextBox.Document.ContentStart,
                        _richTextBox.Document.ContentEnd
                    );

                    range.Save(stream, DataFormats.Rtf);
                }

                return true;
            }
        }


        public bool SaveDocumentAs()
        {
            SaveFileDialog dialog = new SaveFileDialog();

            if (dialog.ShowDialog() ?? false)
            {
                _currentFile = dialog.FileName;
                return SaveDocument();
            }

            return false;
        }


        public void ApplyToSelection(DependencyProperty property, object value)
        {
            if (value != null)
            {
                //double v = Convert.ToDouble(value);
                _richTextBox.Selection.ApplyPropertyValue(property, value);
            }
                
        }
    }
}