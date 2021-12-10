using System.Windows.Controls;
using PeNet;

namespace PEditor.TabItems
{
    /// <summary>
    /// Interaction logic for DosNtHeader.xaml
    /// </summary>
    public partial class DosNtHeader : UserControl
    {
        public DosNtHeader()
        {
            InitializeComponent();
        }

        public void SetDosHeader(PeFile peFile)
        {
            var magic = peFile.ImageDosHeader.E_magic;

            tbe_magic.Text = magic == 0x5A4D ? $"{magic.ToHexString()} <-> MZ" : magic.ToHexString();
            tbe_cblp.Text = peFile.ImageDosHeader.E_cblp.ToHexString();
            tbe_cp.Text = peFile.ImageDosHeader.E_cp.ToHexString();
            tbe_crlc.Text = peFile.ImageDosHeader.E_crlc.ToHexString();
            tbe_cparhdr.Text = peFile.ImageDosHeader.E_cparhdr.ToHexString();
            tbe_minalloc.Text = peFile.ImageDosHeader.E_minalloc.ToHexString();
            tbe_maxalloc.Text = peFile.ImageDosHeader.E_maxalloc.ToHexString();
            tbe_ss.Text = peFile.ImageDosHeader.E_ss.ToHexString();
            tbe_sp.Text = peFile.ImageDosHeader.E_sp.ToHexString();
            tbe_csum.Text = peFile.ImageDosHeader.E_csum.ToHexString();
            tbe_ip.Text = peFile.ImageDosHeader.E_ip.ToHexString();
            tbe_cs.Text = peFile.ImageDosHeader.E_cs.ToHexString();
            tbe_lfarlc.Text = peFile.ImageDosHeader.E_lfarlc.ToHexString();
            tbe_ovno.Text = peFile.ImageDosHeader.E_ovno.ToHexString();
            tbe_res.Text = peFile.ImageDosHeader.E_res.ToHexString();
            tbe_oemid.Text = peFile.ImageDosHeader.E_oemid.ToHexString();
            tbe_oeminfo.Text = peFile.ImageDosHeader.E_oeminfo.ToHexString();
            tbe_res2.Text = peFile.ImageDosHeader.E_res2.ToHexString();
            tbe_lfanew.Text = peFile.ImageDosHeader.E_lfanew.ToHexString();
        }

        public void SetNtHeader(PeFile peFile)
        {
            tbSignature.Text = peFile.ImageNtHeaders.Signature.ToHexString();
        }
    }
}
