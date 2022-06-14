using System;
using System.Collections;
using System.IO;
using UnityEngine;
using UnityEngine.Networking;

namespace WebRequest
{
    public class DownloadLargeFiles : MonoBehaviour
    {
        #region VARIABLES

        [Header("URL")]
        public string SourceURL = "https://opengameart.org/content/it-takes-a-hero";
        public string FileURL = "https://opengameart.org/sites/default/files/it_takes_a_hero.wav";

        [Header("Progress")]
        [Range(0f, 1f)]
        public float Progress = 0f;

        #endregion

        #region METHODS

        public void StartDownloadLargeFile()
        {
            StartCoroutine(DownloadLargeFileRoutine());
        }

        private IEnumerator DownloadLargeFileRoutine()
        {
            string filename = Path.GetFileName(FileURL);
            string destination = Path.Combine(Application.dataPath, "Downloads");
            if (!Directory.Exists(destination)) Directory.CreateDirectory(destination);
            
            using (UnityWebRequest request = new UnityWebRequest(FileURL))
            {
                using (request.downloadHandler = new DownloadHandlerFile(Path.Combine(destination, filename)))
                {
                    StartCoroutine(ProgressRoutine(request));
                    yield return request.SendWebRequest();

                    if (request.result != UnityWebRequest.Result.Success)
                    {
                        print(request.error);
                    }
                    else
                    {
#if UNITY_EDITOR
                        print($"Download Successful - {filename}");
                        UnityEditor.AssetDatabase.Refresh();
#endif
                    }
                }
            }
        }

        private IEnumerator ProgressRoutine(UnityWebRequest request)
        {
            Progress = 0f;
            while (!request.isDone)
            {
                Progress = request.downloadProgress;
                yield return null;
            }

            Progress = 1f;
        }

        #endregion
    }
}