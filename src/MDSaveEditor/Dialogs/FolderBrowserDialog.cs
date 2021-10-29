using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Interop;

namespace MDSaveEditor.Dialogs
{
    public class FolderBrowserDialog : IFolderBrowserDialog
    {
        public FolderBrowserDialog()
        {
            SelectedFolders = new List<string>();
        }

        /// <summary>
        /// Gets/sets the title of the dialog
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Gets/sets folder in which dialog will be open.
        /// </summary>
        public string InitialFolder { get; set; }

        /// <summary>
        /// Gets/sets directory in which dialog will be open
        /// if there is no recent directory available.
        /// </summary>
        public string DefaultFolder { get; set; }

        /// <summary>
        /// Gets selected folder.
        /// </summary>
        public string SelectedFolder
        {
            get => SelectedFolders != null && SelectedFolders.Count >= 1 ? SelectedFolders[0] : string.Empty;
        }

        /// <summary>
        /// Gets selected folders when AllowMultiSelect is true.
        /// </summary>
        public List<string> SelectedFolders { get; private set; }

        public bool AllowMultiSelect { get; set; }

        /// <summary>
        /// Shows the folder browser dialog with a the default owner
        /// </summary>
        /// System.Windows.Forms.DialogResult.OK if the user clicks OK in the dialog box;
        /// otherwise, System.Windows.Forms.DialogResult.Cancel.
        /// </returns>
        public bool? ShowDialog()
        {
            return ShowDialog(owner: new WindowWrapper(GetHandleFromWindow(GetDefaultOwnerWindow())));
        }

        /// <summary>
        /// Shows the folder browser dialog with a the specified owner
        /// </summary>
        /// <param name="owner">Any object that implements IWin32Window to own the folder browser dialog</param>
        /// <returns>
        /// System.Windows.Forms.DialogResult.OK if the user clicks OK in the dialog box;
        /// otherwise, System.Windows.Forms.DialogResult.Cancel.
        /// </returns>
        public bool? ShowDialog(IWin32Window owner)
        {
            SelectedFolders.Clear();
            if (Environment.OSVersion.Version.Major >= 6)
            {
                return ShowVistaDialog(owner);
            }
            else
            {
                return false;
            }
        }
        private bool? ShowVistaDialog(IWin32Window owner)
        {
            var frm = (NativeMethods.IFileOpenDialog)(new NativeMethods.FileOpenDialogRCW());
            frm.GetOptions(out uint options);
            options |= NativeMethods.FOS_PICKFOLDERS |
                       NativeMethods.FOS_FORCEFILESYSTEM |
                       NativeMethods.FOS_NOVALIDATE |
                       NativeMethods.FOS_NOTESTFILECREATE |
                       NativeMethods.FOS_DONTADDTORECENT;

            if (AllowMultiSelect)
                options |= NativeMethods.FOS_ALLOWMULTISELECT;

            frm.SetOptions(options);
            if (this.InitialFolder != null)
            {
                var riid = new Guid("43826D1E-E718-42EE-BC55-A1E261C37BFE"); //IShellItem
                if (NativeMethods.SHCreateItemFromParsingName
                   (this.InitialFolder, IntPtr.Zero, ref riid,
                    out NativeMethods.IShellItem directoryShellItem) == NativeMethods.S_OK)
                {
                    frm.SetFolder(directoryShellItem);
                }
            }
            if (this.DefaultFolder != null)
            {
                var riid = new Guid("43826D1E-E718-42EE-BC55-A1E261C37BFE"); //IShellItem
                if (NativeMethods.SHCreateItemFromParsingName
                   (this.DefaultFolder, IntPtr.Zero, ref riid,
                    out NativeMethods.IShellItem directoryShellItem) == NativeMethods.S_OK)
                {
                    frm.SetDefaultFolder(directoryShellItem);
                }
            }
            if (this.Title != null)
            {
                frm.SetTitle(this.Title);
            }
            if (frm.Show(owner.Handle) == NativeMethods.S_OK)
            {
                if (AllowMultiSelect)
                {
                    frm.GetResults(out NativeMethods.IShellItemArray shellItemArray);
                    shellItemArray.GetCount(out uint numFolders);
                    for (uint i = 0; i < numFolders; i++)
                    {
                        shellItemArray.GetItemAt(i, out NativeMethods.IShellItem shellItem);
                        if (shellItem.GetDisplayName(NativeMethods.SIGDN_FILESYSPATH,
                        out IntPtr pszString) == NativeMethods.S_OK)
                        {
                            if (pszString != IntPtr.Zero)
                            {
                                try
                                {
                                    this.SelectedFolders.Add(Marshal.PtrToStringAuto(pszString));
                                }
                                finally
                                {
                                    Marshal.FreeCoTaskMem(pszString);
                                }
                            }
                        }
                    }
                    return true;
                }
                else if (!AllowMultiSelect && frm.GetResult(out NativeMethods.IShellItem shellItem) == NativeMethods.S_OK)

                {
                    if (shellItem.GetDisplayName(NativeMethods.SIGDN_FILESYSPATH,
                        out IntPtr pszString) == NativeMethods.S_OK)
                    {
                        if (pszString != IntPtr.Zero)
                        {
                            try
                            {
                                this.SelectedFolders.Add(Marshal.PtrToStringAuto(pszString));
                                return true;
                            }
                            finally
                            {
                                Marshal.FreeCoTaskMem(pszString);
                            }
                        }
                    }
                }
            }
            return false;
        }
        //private DialogResult ShowLegacyDialog(IWin32Window owner)
        //{
        //    System.Windows.Forms.FolderBrowserDialog folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
        //    if (folderBrowserDialog.ShowDialog(owner) == DialogResult.OK)
        //    {
        //        SelectedFolders.Add(folderBrowserDialog.SelectedPath);
        //        return DialogResult.OK;
        //    }

        //    return DialogResult.Cancel;
        //}

        private IntPtr GetHandleFromWindow(Window window)
        {
            if (window == null)
                return IntPtr.Zero;
            return new WindowInteropHelper(window).Handle;
        }

        private Window GetDefaultOwnerWindow()
        {
            Window defaultWindow = null;

            // TODO: Detect active window and change to that instead
            if (Application.Current != null && Application.Current.MainWindow != null)
            {
                defaultWindow = Application.Current.MainWindow;
            }
            return defaultWindow;
        }

        /// <summary>
        /// Dispose the object
        /// </summary>
        public void Dispose() { } //just to have possibility of Using statement.
    }
}
