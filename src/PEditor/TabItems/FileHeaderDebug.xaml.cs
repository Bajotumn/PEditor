using System.Linq;
using System.Windows.Controls;
using PeNet;

namespace PEditor.TabItems
{
    /// <summary>
    /// Interaction logic for FileHeaderDebug.xaml
    /// </summary>
    public partial class FileHeader : UserControl
    {
        public FileHeader()
        {
            InitializeComponent();
        }

        public void SetFileHeader(PeFile peFile)
        {
            var fileHeader = peFile.ImageNtHeaders.FileHeader;
            var machine = fileHeader.Machine;
            var characteristics = fileHeader.Characteristics;

            tbMachine.Text = $"{((ulong)machine).ToHexString()} <-> {machine}";
            tbNumberOfSections.Text = fileHeader.NumberOfSections.ToHexString();
            tbTimeDateStamp.Text = fileHeader.TimeDateStamp.ToHexString();
            tbPointerToSymbolTable.Text = fileHeader.PointerToSymbolTable.ToHexString();
            tbNumberOfSymbols.Text = fileHeader.NumberOfSymbols.ToHexString();
            tbSizeOfOptionalHeader.Text = fileHeader.SizeOfOptionalHeader.ToHexString();
            tbCharacteristics.Text =
                $"{((ulong)characteristics).ToHexString()}\n\n{characteristics}";
        }

        public void SetDebug(PeFile peFile)
        {
            // Clean
            tbDebugCharacteristics.Text = string.Empty;
            tbDebugTimeDateStamp.Text = string.Empty;
            tbDebugMajorVersion.Text = string.Empty;
            tbDebugMinorVersion.Text = string.Empty;
            tbDebugType.Text = string.Empty;
            tbDebugSizeOfData.Text = string.Empty;
            tbDebugAddressOfRawData.Text = string.Empty;
            tbDebugPointerToRawData.Text = string.Empty;

            if(peFile.ImageDebugDirectory == null)
                return;

            // Set
            tbDebugCharacteristics.Text = peFile.ImageDebugDirectory.First().Characteristics.ToString();
            tbDebugTimeDateStamp.Text = peFile.ImageDebugDirectory.First().TimeDateStamp.ToHexString();
            tbDebugMajorVersion.Text = peFile.ImageDebugDirectory.First().MajorVersion.ToHexString();
            tbDebugMinorVersion.Text = peFile.ImageDebugDirectory.First().MinorVersion.ToHexString();
            tbDebugType.Text = peFile.ImageDebugDirectory.First().Type.ToHexString();
            tbDebugSizeOfData.Text = peFile.ImageDebugDirectory.First().SizeOfData.ToHexString();
            tbDebugAddressOfRawData.Text = peFile.ImageDebugDirectory.First().AddressOfRawData.ToHexString();
            tbDebugPointerToRawData.Text = peFile.ImageDebugDirectory.First().PointerToRawData.ToHexString();
        }
    }
}
