using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Interop;

namespace MDSaveEditor.Dialogs
{
    class WindowWrapper : IWin32Window
    {
        private readonly IntPtr _hwnd;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="handle">Handle to wrap</param>
        public WindowWrapper(IntPtr handle)
        {
            _hwnd = handle;
        }

        /// <summary>
        /// Original ptr
        /// </summary>
        public IntPtr Handle
        {
            get { return _hwnd; }
        }
    }
}
