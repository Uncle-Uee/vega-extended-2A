using System.Collections;
using System.IO;
using UnityEngine;
using UnityEngine.Networking;

namespace WebRequest
{
    public class DownloadBuffer : MonoBehaviour
    {
        #region VARIABLES

        [Header("URL")]
        public string SourceURL = "https://opengameart.org/content/miniworld-sprites";
        public string FileURL = "https://opengameart.org/sites/default/files/miniworldsprites_1.zip";

        #endregion

        #region METHODS

        public void StartDownloadFile()
        {
            StartCoroutine(DownloadFileRoutine());
        }

        private IEnumerator DownloadFileRoutine()
        {
            // Warning!
            // The Download File Buffer Writes the Downloaded Data to Memory
            // This is not Recommended for Large Files.
            // Use the DownloadHandlerFile instead.
            //
            // To effectively use DownloadHandlerBuffer
            // You will need to then Write the Memory Stream (byte[] or string)
            // to a File using File.WriteAllBytes or File.WriteAllText
            
            string filename = Path.GetFileName(FileURL);
            string destination = Path.Combine(Application.dataPath, "Downloads");
            if (!Directory.Exists(destination)) Directory.CreateDirectory(destination);

            using (UnityWebRequest request = new UnityWebRequest(FileURL))
            {
                using (request.downloadHandler = new DownloadHandlerBuffer())
                {
                    yield return request.SendWebRequest();

                    if (request.result != UnityWebRequest.Result.Success)
                    {
                        print(request.error);
                    }
                    else
                    {
                        byte[] results = request.downloadHandler.data;
                        File.WriteAllBytes(Path.Combine(destination, filename), results);
#if UNITY_EDITOR
                        print($"Download Successful - {filename}");
                        UnityEditor.AssetDatabase.Refresh();
#endif
                    }
                }
            }
        }

        #endregion
    }
}