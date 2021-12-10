using System.Windows.Controls;
using PeNet;

namespace PEditor.TabItems
{
    /// <summary>
    /// Interaction logic for SectionHeaders.xaml
    /// </summary>
    public partial class SectionHeaders : UserControl
    {
        public SectionHeaders()
        {
            InitializeComponent();
        }

        private void CleanSections()
        {
            dgSections.Items.Clear();
        }

        public void SetSections(PeFile peFile)
        {
            CleanSections();

            var num = 1;
            foreach (var sec in peFile.ImageSectionHeaders)
            {
                dgSections.Items.Add(new
                {
                    Number = num,
                    Name = sec.Name,
                    VSize = sec.VirtualSize.ToHexString(),
                    VAddress = sec.VirtualAddress.ToHexString(),
                    PSize = sec.SizeOfRawData.ToHexString(),
                    PAddress = sec.PointerToRawData.ToHexString(),
                    Flags = ((uint)sec.Characteristics).ToHexString(),
                    RFlags = sec.Characteristics.ToString()
                });
                num++;
            }
        }
    }
}
