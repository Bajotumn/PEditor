using System.Windows.Controls;
using PeNet;

namespace PEditor.TabItems
{
    /// <summary>
    /// Interaction logic for Signature.xaml
    /// </summary>
    public partial class Signature : UserControl
    {
        public Signature()
        {
            InitializeComponent();
        }

        public void SetDigSignature(PeFile peFile)
        {
            // Clear all fields.
            cbCertIsSigned.IsChecked = false;
            cbCertIsValid.IsChecked = false;
            cbCertIsValidChain.IsChecked = false;
            tbCertLength.Text = string.Empty;
            tbCertRevision.Text = string.Empty;
            tbCertType.Text = string.Empty;

            cbX509Archived.IsChecked = false;
            cbX509HasPrivateKey.IsChecked = false;
            tbX509FriendlyName.Text = string.Empty;
            tbX509Issuer.Text = string.Empty;
            tbX509Thumbprint.Text = string.Empty;
            tbX509Version.Text = string.Empty;
            tbX509NotAfter.Text = string.Empty;
            tbX509NotBefore.Text = string.Empty;
            tbX509SerialNumber.Text = string.Empty;
            tbX509SignatureAlgorithm.Text = string.Empty;
            tbX509Subject.Text = string.Empty;
            tbX509PrivateKey.Text = string.Empty;
            tbX509PublicKey.Text = string.Empty;
            tbX509Extensions.Text = string.Empty;
            tbX509CrlUrls.Text = string.Empty;

            if (!peFile.IsSigned)
                return;

            cbCertIsValid.IsChecked = peFile.Authenticode.IsAuthenticodeValid;
            cbCertIsSigned.IsChecked = peFile.IsSigned;
            cbCertIsValidChain.IsChecked = peFile.HasValidCertChain(true);
            tbCertLength.Text = peFile.WinCertificate.DwLength.ToHexString();
            tbCertRevision.Text = peFile.WinCertificate.WRevision.ToHexString();
            tbCertType.Text = peFile.WinCertificate.WCertificateType.ToString();

            cbX509Archived.IsChecked = peFile.Pkcs7.Archived;
            cbX509HasPrivateKey.IsChecked = peFile.Pkcs7.HasPrivateKey;
            tbX509FriendlyName.Text = peFile.Pkcs7.FriendlyName;
            tbX509Issuer.Text = peFile.Pkcs7.Issuer.Replace(", ", "\n");
            tbX509Thumbprint.Text = peFile.Pkcs7.Thumbprint;
            tbX509Version.Text = peFile.Pkcs7.Version.ToString();
            tbX509NotBefore.Text = peFile.Pkcs7.NotBefore.ToLongDateString();
            tbX509NotAfter.Text = peFile.Pkcs7.NotAfter.ToLongDateString();
            tbX509SerialNumber.Text = peFile.Pkcs7.SerialNumber;
            tbX509SignatureAlgorithm.Text = peFile.Pkcs7.SignatureAlgorithm.FriendlyName;
            tbX509Subject.Text = peFile.Pkcs7.Subject.Replace(", ", "\n");
            tbX509PublicKey.Text = peFile.Pkcs7.PublicKey.EncodedKeyValue.Format(true);
            tbX509PrivateKey.Text = peFile.Pkcs7.PrivateKey?.ToXmlString(false);

            foreach (var x509Extension in peFile.Pkcs7.Extensions)
            {
                tbX509Extensions.Text += $"{x509Extension.Format(true)}\n";
            }

            foreach (var url in peFile.GetCrlUrlList().Urls)
            {
                tbX509CrlUrls.Text += $"{url}\n";
            }
        }
    }
}
