﻿/***********************************************************************
Copyright 2016 Stefan Hausotte

Licensed under the Apache License, Version 2.0 (the "License");
you may not use this file except in compliance with the License.
You may obtain a copy of the License at

    http://www.apache.org/licenses/LICENSE-2.0

Unless required by applicable law or agreed to in writing, software
distributed under the License is distributed on an "AS IS" BASIS,
WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
See the License for the specific language governing permissions and
limitations under the License.

*************************************************************************/

using System;
using System.Deployment.Application;
using System.Windows;
using Microsoft.Win32;
using PeNet;

namespace PEditor
{
    /// <summary>
    ///     Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static PeFile _peFile;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void MenuOpen_Click(object sender, RoutedEventArgs e)
        {
            var openFileDialog = new OpenFileDialog
            {
                Multiselect = false
            };

            if (openFileDialog.ShowDialog() != true)
                return;

            var file = openFileDialog.FileName;
            FileOpen(file);
        }

        private void MenuExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void FileOpen(string file)
        {
            // Set status bar location for the file.
            tbStatusBarLocation.Text = file;

            // Parse the PE file
            if (!PeFile.IsPEFile(file))
            {
                ShowInvalidPeFileMsgBox();
                return;
            }

            _peFile = new PeFile(file);

            // Set all FileInfo fields.
            FileInfo.SetFileInfo(_peFile);

            // Set the DOS header fields
            DosNtHeader.SetDosHeader(_peFile);

            // Set the PE File fields
            DosNtHeader.SetNtHeader(_peFile);

            // Set the File header
            FileHeaderDebug.SetFileHeader(_peFile);

            // Set the Debug directory.
            FileHeaderDebug.SetDebug(_peFile);

            // Set the Optional header
            OptionalHeader.SetOptionalHeader(_peFile);

            // Set the imports.
            Imports.SetImports(_peFile);

            // Set the exports.
            Exports.SetExports(_peFile);

            // Set the resources.
            Resource.SetResources(_peFile);

            // Set the sections.
            SectionHeaders.SetSections(_peFile);

            // Set the Exception (only for x64)
            Exceptions.SetException(_peFile);

            // Set the Relocations.
            Relocation.SetRelocations(_peFile);

            // Set the Digital Signature information.
            Signature.SetDigSignature(_peFile);

            // Set the Bound Import directory.
            DebugBoundImport.SetBoundImport(_peFile);

            // Set the Delay Import descriptor.
            DebugBoundImport.SetDelayImport(_peFile);

            // Set the TLS directory.
            TlsDirectory.SetTlsDirectory(_peFile);

            // Set the Load Config Directory
            LoadConfig.SetLoadConfig(_peFile);

            // Set the Data Directory View
            DirectoryView.SetDirectoryView(_peFile);
        }

        private void ShowInvalidPeFileMsgBox()
        {
            MessageBox.Show("Not a valid PE file.", "Invalid Format", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void MenuHelp_Click(object sender, RoutedEventArgs e)
        {
            var version = "DEBUG";

            if (ApplicationDeployment.IsNetworkDeployed)
            {
                version = ApplicationDeployment.CurrentDeployment.CurrentVersion.ToString(4);
            }

            MessageBox.Show($"PEditor\nVersion {version}\nCopyright by Secana 2016", "About");
        }
    }
}