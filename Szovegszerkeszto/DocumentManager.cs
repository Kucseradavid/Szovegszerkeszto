using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
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
    }
}