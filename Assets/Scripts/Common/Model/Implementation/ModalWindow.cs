using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

namespace Common
{
    public class ModalWindow : MonoBehaviour, IModalWindow
    {
        public Button okButton;
        public Button yesButton;
        public Button noButton;
        public Button cancelButton;
        public Text titleText;
        public Text messageText;
        public Canvas canvas;

        private Action<DialogResult> _resultCallback;
        private List<Canvas> _canvases;

        public void DisplayAsInfoWindow(string title, string message)
        {
            Initialize(title, message);
        }

        public void Close()
        {
            EnableOtherSelectableElements(true);
            Destroy(gameObject);
        }

        public void DisplayAsOkWindow(string title, string message, Action<DialogResult> resultCallBack)
        {
            Initialize(title, message, resultCallBack);
            okButton.onClick.AddListener(new UnityEngine.Events.UnityAction(OkButtonCallback));
        }

        public void DisplayAsYesNoWindow(string title, string message, Action<DialogResult> resultCallBack)
        {
            Initialize(title, message, resultCallBack);
            yesButton.onClick.AddListener(new UnityEngine.Events.UnityAction(YesButtonCallback));
            noButton.onClick.AddListener(new UnityEngine.Events.UnityAction(NoButtonCallback));
        }

        public void DisplayAsYesNoCancelWindow(string title, string message, Action<DialogResult> resultCallBack)
        {
            Initialize(title, message, resultCallBack);
            yesButton.onClick.AddListener(new UnityEngine.Events.UnityAction(YesButtonCallback));
            noButton.onClick.AddListener(new UnityEngine.Events.UnityAction(NoButtonCallback));
            cancelButton.onClick.AddListener(new UnityEngine.Events.UnityAction(CancelButtonCallback));
        }
        
        private void Initialize(string title, string message, Action<DialogResult> resultCallBack=null)
        {
            EnableOtherSelectableElements(false);            
            _resultCallback = resultCallBack;
            titleText.text = title;
            messageText.text = message;
        }

        private void EnableOtherSelectableElements(bool enable)
        {
            _canvases = _canvases==null ?  FindObjectsOfType<Canvas>().ToList() : _canvases;
            
            foreach (Canvas otherCanvas in _canvases)
            {
                otherCanvas.GetComponentsInChildren<Selectable>().ToList().ForEach(p => p.enabled = enable);
            }
            if (!enable)
            {
                canvas.GetComponentsInChildren<Selectable>().ToList().ForEach(p => p.enabled = true);
            }
        }

        private void OkButtonCallback()
        {
            _resultCallback(DialogResult.OK);
            Destroy(gameObject);
        }

        private void YesButtonCallback()
        {
            _resultCallback(DialogResult.Yes);
            Destroy(gameObject);
        }

        private void NoButtonCallback()
        {
            _resultCallback(DialogResult.No);
            Destroy(gameObject);
        }

        private void CancelButtonCallback()
        {
            _resultCallback(DialogResult.Cancel);
            Destroy(gameObject);
        }

        
    }
}
