using System.Collections.Generic;
using MultiScene.General;
using MultiScene.Managers;
using UnityEngine;
using UnityEngine.UI;

namespace MultiScene.UI
{
    public class TitleUI : MonoBehaviour
    {
        public Button Level1Button;
        public Button Level2Button;
        public Button MultiLoadButton;

        private void OnEnable()
        {
            Level1Button.onClick.AddListener(OnLevel1Button);
            Level2Button.onClick.AddListener(OnLevel2Button);
            MultiLoadButton.onClick.AddListener(OnMultiLoadButton);
        }
        
        private void OnDisable()
        {
            Level1Button.onClick.RemoveAllListeners();
            Level2Button.onClick.RemoveAllListeners();
        }

        private void OnLevel1Button()
        {
            ScenesManager.Instance.LoadAWorldScene_FromTitle(SceneIndex.Level_1);
        }

        private void OnLevel2Button()
        {
            ScenesManager.Instance.LoadAWorldScene_FromTitle(SceneIndex.Level_2);
        }

        private void OnMultiLoadButton()
        {
            ScenesManager.Instance.LoadWorldScenes_FromTitle(new List<SceneIndex>
            {
                SceneIndex.Level_1, SceneIndex.Level_2
            });
        }
    }
}