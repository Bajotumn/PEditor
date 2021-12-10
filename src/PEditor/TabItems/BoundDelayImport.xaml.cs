using System.Windows.Controls;
using PeNet;

namespace PEditor.TabItems
{
    /// <summary>
    /// Interaction logic for DebugBoundImport.xaml
    /// </summary>
    public partial class DebugBoundImport : UserControl
    {
        public DebugBoundImport()
        {
            InitializeComponent();
        }

        public void SetBoundImport(PeFile peFile)
        {
            // Clean
            tbBoundImportNumberOfModuleForwarderRefs.Text = string.Empty;
            tbBoundImportOffsetModuleName.Text = string.Empty;
            tbBoundImportTimeDateStamp.Text = string.Empty;

            if (peFile.ImageBoundImportDescriptor == null)
                return;

            // Set
            tbBoundImportNumberOfModuleForwarderRefs.Text =
                peFile.ImageBoundImportDescriptor.NumberOfModuleForwarderRefs.ToHexString();
            tbBoundImportOffsetModuleName.Text = peFile.ImageBoundImportDescriptor.OffsetModuleName.ToHexString();
            tbBoundImportTimeDateStamp.Text = peFile.ImageBoundImportDescriptor.TimeDateStamp.ToHexString();
        }

        public void SetDelayImport(PeFile peFile)
        {
            // Clean
            grAttr.Text = string.Empty;
            szName.Text = string.Empty;
            phmod.Text = string.Empty;
            pIAT.Text = string.Empty;
            pINT.Text = string.Empty;
            pBoundIAT.Text = string.Empty;
            pUnloadIAT.Text = string.Empty;
            dwTimeStamp.Text = string.Empty;

            if (peFile.ImageDelayImportDescriptor == null)
                return;

            // Set
            grAttr.Text = peFile.ImageDelayImportDescriptor.GrAttrs.ToHexString();
            szName.Text = peFile.ImageDelayImportDescriptor.SzName.ToHexString();
            phmod.Text = peFile.ImageDelayImportDescriptor.Phmod.ToHexString();
            pIAT.Text = peFile.ImageDelayImportDescriptor.PIat.ToHexString();
            pINT.Text = peFile.ImageDelayImportDescriptor.PInt.ToHexString();
            pBoundIAT.Text = peFile.ImageDelayImportDescriptor.PBoundIAT.ToHexString();
            pUnloadIAT.Text = peFile.ImageDelayImportDescriptor.PUnloadIAT.ToHexString();
            dwTimeStamp.Text = peFile.ImageDelayImportDescriptor.DwTimeStamp.ToHexString();

        }
    }
}
