using MultiScene.Managers;
using UnityEngine;
using UnityEngine.UI;

namespace MultiScene.UI
{
    public class PauseUI : MonoBehaviour
    {
        public Canvas CurrentCanvas;
        public InGameUI InGameUI;

        public Button ResumeButton;
        public Button QuitButton;

        private void OnEnable()
        {
            ResumeButton.onClick.AddListener(OnResumeButton);
            QuitButton.onClick.AddListener(OnQuitButton);
        }

        private void OnDisable()
        {
            ResumeButton.onClick.RemoveAllListeners();
            QuitButton.onClick.RemoveAllListeners();
        }

        private void OnResumeButton()
        {
            CurrentCanvas.enabled = false;
            InGameUI.CurrentCanvas.enabled = true;
        }

        private void OnQuitButton()
        {
            CurrentCanvas.enabled = false;
            ScenesManager.Instance.UnloadAWorldScene_ToTitle();
        }
    }
}