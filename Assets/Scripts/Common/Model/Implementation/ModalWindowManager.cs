using System;
using UnityEngine;
using Zenject;

namespace Common
{
    public enum DialogResult
    {
        OK,
        Yes,
        No,
        Cancel
    }
    

    public enum ModalWindowType
    {
        Info,
        YesNo,
        YesNoCancel
    }

    public class ModalWindowManager : MonoBehaviour, IModalWindowManager
    {
        public GameObject infoWindowPrefab;
        public GameObject okWindowPrefab;
        public GameObject yesNoWindowPrefab;
        public GameObject yesNoCancelWindowPrefab;

        private Action<DialogResult> _okResultCallback;
        private Action<DialogResult> _yesNoResultCallback;
        private Action<DialogResult> _yesNoCancelResultCallback;

        public void DisplayOkWindow(string title, string message, Action<DialogResult> resultCallBack)
        {
            Instantiate(okWindowPrefab).GetComponent<IModalWindow>().DisplayAsOkWindow(title, message, resultCallBack);
        }

        public void DisplayYesNoWindow(string title, string message, Action<DialogResult> resultCallBack)
        {
             Instantiate(yesNoWindowPrefab).GetComponent<IModalWindow>().DisplayAsYesNoWindow(title, message, resultCallBack);
        }

        public void DisplayYesNoCancelWindow(string title, string message, Action<DialogResult> resultCallBack)
        {
            Instantiate(yesNoCancelWindowPrefab).GetComponent<IModalWindow>().DisplayAsYesNoCancelWindow(title, message, resultCallBack);
        }

        public IModalWindow DisplayInfoWindow(string title, string message)
        {
            IModalWindow infoWindow = Instantiate(infoWindowPrefab).GetComponent<IModalWindow>();
            infoWindow.DisplayAsInfoWindow(title, message);
            return infoWindow;
        }
    }
}
