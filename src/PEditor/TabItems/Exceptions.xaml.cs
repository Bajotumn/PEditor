﻿using System.Linq;
using System.Windows.Controls;
using PeNet;

namespace PEditor.TabItems
{
    /// <summary>
    /// Interaction logic for Exceptions.xaml
    /// </summary>
    public partial class Exceptions : UserControl
    {
        private PeFile _peFile;

        public Exceptions()
        {
            InitializeComponent();
        }

        private void lbRuntimeFunctions_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var listBox = sender as ListBox;
            if (listBox == null) return;
            dynamic selected = listBox.SelectedItem;
            if (selected == null) return;

            // Convert string of format 0x... to an integer.
            var funcStart = ((string) selected.FunctionStart).ToIntFromHexString();
            var funcEnd = ((string) selected.FunctionEnd).ToIntFromHexString();
            var uw = ((string) selected.UnwindInfo).ToIntFromHexString();

            // Find the RUNTIME_FUNCTION which was selected.
            var rt = _peFile.ExceptionDirectory.First(x => x.FunctionStart == funcStart
                                                         && x.FunctionEnd == funcEnd
                                                         && x.UnwindInfo == uw
                );

            // Set the UNWIND_INFO properties.
            tbUIVersion.Text = rt.ResolvedUnwindInfo.Version.ToHexString();
            tbUIFlags.Text = rt.ResolvedUnwindInfo.Flags.ToHexString();
            tbUISizeOfProlog.Text = rt.ResolvedUnwindInfo.SizeOfProlog.ToHexString();
            tbUICountOfCodes.Text = rt.ResolvedUnwindInfo.CountOfCodes.ToHexString();
            tbUIFrameRegister.Text = rt.ResolvedUnwindInfo.FrameRegister.ToHexString();
            tbUIFrameOffset.Text = rt.ResolvedUnwindInfo.FrameOffset.ToHexString();
            tbUIExHandlerFuncEntry.Text = rt.ResolvedUnwindInfo.ExceptionHandler.ToHexString();
            // TODO: Display exception data somehow.
            // https://www.osronline.com/article.cfm^article=469.htm
            //tbUIExData.Text = string.Format("", rt.ResolvedUnwindInfo.ExceptionData);

            // Set the UNWIND_CODE structures for the UNWIND_INFO
            lbUnwindCode.Items.Clear();
            foreach (var uc in rt.ResolvedUnwindInfo.UnwindCode)
            {
                lbUnwindCode.Items.Add(new
                {
                    CodeOffset = uc.CodeOffset.ToHexString(),
                    UnwindOp = uc.UnwindOp.ToString(),
                    FrameOffset = uc.FrameOffset.ToHexString()
                });
            }
        }


        public void SetException(PeFile peFile)
        {
            _peFile = peFile;
            lbRuntimeFunctions.Items.Clear();

            if (peFile.Is32Bit || peFile.ExceptionDirectory == null)
                return;

            foreach (var rt in peFile.ExceptionDirectory)
            {
                lbRuntimeFunctions.Items.Add(new
                {
                    FunctionStart = rt.FunctionStart.ToHexString(),
                    FunctionEnd = rt.FunctionEnd.ToHexString(),
                    UnwindInfo = rt.UnwindInfo.ToHexString()
                });
            }
        }

    }
}
