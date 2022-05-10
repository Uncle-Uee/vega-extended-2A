using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using Directory = System.IO.Directory;
using File = System.IO.File;
using Input = UnityEngine.Input;

namespace Adventure
{
    public class TakeScreenshot : MonoBehaviour
    {
        #region VARIABLES

        [Header("Canvases")]
        public List<Canvas> ParentCanvases = new List<Canvas>();

        private bool _takeScreenshot;

        #endregion

        #region PROPERTIES

        private string ScreenshotPath
        {
            get
            {
                string path = Path.Combine(Application.persistentDataPath, "Screenshots");
                if (!Directory.Exists(path)) Directory.CreateDirectory(path);
                int count = Directory.GetFiles(path).Length;
                return Path.Combine(path, $"Screenshot-{count + 1}.png");
            }
        }

        #endregion

        #region UNITY METHODS

        private void OnEnable()
        {
            RenderPipelineManager.endCameraRendering += EndCameraRendering;
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.P))
            {
                // _takeScreenshot = true;
                // SimpleScreenshot();
                StartCoroutine(ScreenshotRoutine());
            }
        }

        private void OnDisable()
        {
            RenderPipelineManager.endCameraRendering -= EndCameraRendering;
        }

        #endregion

        #region METHODS

        /// <summary>
        /// Take a Generic Screenshot
        /// </summary>
        /// <param name="size"></param>
        public void SimpleScreenshot(int size = 1)
        {
            ScreenCapture.CaptureScreenshot(ScreenshotPath, size);
        }

        /// <summary>
        /// Take a Screenshot that Includes the UI
        /// </summary>
        /// <returns></returns>
        public IEnumerator ScreenshotRoutine()
        {
            #region GET AND DISABLE ALL ACTIVE UI

            List<Canvas> activeCanvases = new List<Canvas>();
            foreach (Canvas canvas in ParentCanvases)
            {
                if (!canvas.isActiveAndEnabled) continue;
                activeCanvases.Add(canvas);
                canvas.enabled = false;
            }

            #endregion

            yield return new WaitForEndOfFrame();
            ScreenshotHelper();


            #region ACTIVATE ALL THE PREVIOUS DISABLED UI

            yield return null;
            foreach (Canvas canvas in activeCanvases)
            {
                canvas.enabled = true;
            }

            #endregion
        }

        /// <summary>
        /// Take a Screenshot and Exclude the UI
        /// </summary>
        /// <param name="context"></param>
        /// <param name="renderCamera"></param>
        private void EndCameraRendering(ScriptableRenderContext context, Camera renderCamera)
        {
            if (!_takeScreenshot) return;
            _takeScreenshot = false;
            ScreenshotHelper();
        }

        #endregion

        #region METHOD HELPERS

        private void ScreenshotHelper()
        {
            print("Taking Screenshot");
            int width = Screen.width;
            int height = Screen.height;

            Texture2D screenshot = new Texture2D(width, height, TextureFormat.ARGB32, false);
            Rect rect = new Rect(0, 0, width, height);
            screenshot.ReadPixels(rect, 0, 0);
            screenshot.Apply();

            byte[] bytes = screenshot.EncodeToPNG();
            print(ScreenshotPath);
            File.WriteAllBytes(ScreenshotPath, bytes);
        }

        #endregion
    }
}