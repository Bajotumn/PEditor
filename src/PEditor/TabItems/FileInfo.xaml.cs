using System.Diagnostics;
using System.Windows.Controls;
using System.Windows.Navigation;
using PeNet;

namespace PEditor
{
    /// <summary>
    /// Interaction logic for FileInfo.xaml
    /// </summary>
    public partial class FileInfo : UserControl
    {
        public FileInfo()
        {
            InitializeComponent();
        }

        public void SetFileInfo(PeFile peFile, string filePath)
        {
            tbLocation.Text = filePath;
            tbSize.Text = $"{peFile.FileSize} Bytes";
            tbMD5.Text = peFile.Md5;
            tbSHA1.Text = peFile.Sha1;
            tbSHA256.Text = peFile.Sha256;
            tbImpHash.Text = peFile.ImpHash;
        }

        private void Hyperlink_RequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            Process.Start(new ProcessStartInfo(e.Uri.AbsoluteUri));
            e.Handled = true;
        }
    }
}
