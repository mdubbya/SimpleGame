using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common
{
    public interface IModalWindow
    {
        void DisplayAsOkWindow(string title, string message, Action<DialogResult> resultCallBack);
        void DisplayAsInfoWindow(string title, string message);
        void DisplayAsYesNoWindow(string title, string message, Action<DialogResult> resultCallBack);
        void DisplayAsYesNoCancelWindow(string title, string message, Action<DialogResult> resultCallBack);
        void Close();
    }
}
