using UnityEngine;
using UnityEngine.UI;

namespace MultiScene.UI
{
    public class InGameUI : MonoBehaviour
    {
        public Canvas CurrentCanvas;
        public PauseUI PauseUI;

        public Button PauseButton;

        private void OnEnable()
        {
            PauseButton.onClick.AddListener(OnPauseButton);
        }

        private void OnDisable()
        {
            PauseButton.onClick.RemoveAllListeners();
        }

        private void OnPauseButton()
        {
            CurrentCanvas.enabled = false;
            PauseUI.CurrentCanvas.enabled = true;
        }
    }
}