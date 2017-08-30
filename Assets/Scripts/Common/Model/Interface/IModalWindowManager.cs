using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Common
{
    public interface IModalWindowManager
    {
        IModalWindow DisplayInfoWindow(string title, string message);

        void DisplayOkWindow(string title, string message, Action<DialogResult> resultCallBack);

        void DisplayYesNoWindow(string title, string message, Action<DialogResult> resultCallBack);

        void DisplayYesNoCancelWindow(string title, string message, Action<DialogResult> resultCallBack);         
    }
}
