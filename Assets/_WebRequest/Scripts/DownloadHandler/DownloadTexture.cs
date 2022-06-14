using System.Collections;
using System.IO;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

namespace WebRequest
{
    public class DownloadTexture : MonoBehaviour
    {
        #region VARIABLES

        [Header("URL")]
        public string SourceURL = "https://opengameart.org/content/sara-trevor-puck-anime-portrait-and-expressions";
        public string ImageURL = "https://opengameart.org/sites/default/files/portrait21.png";

        [Header("UI Image")]
        public Image ImageDisplay;

        #endregion

        #region METHODS

        public void StartDownloadTexture()
        {
            // StartCoroutine(DownloadTextureRoutine_TextureHandler());
            StartCoroutine(DownloadTextureRoutine_RequestTexture());
        }

        private IEnumerator DownloadTextureRoutine_TextureHandler()
        {
            string filename = Path.GetFileName(ImageURL);
            string destination = Path.Combine(Application.dataPath, "Downloads");
            if (!Directory.Exists(destination)) Directory.CreateDirectory(destination);

            using (UnityWebRequest request = new UnityWebRequest(ImageURL))
            {
                using (DownloadHandlerTexture downloadHandlerTexture = new DownloadHandlerTexture(true))
                {
                    request.downloadHandler = downloadHandlerTexture;
                    yield return request.SendWebRequest();

                    if (request.result != UnityWebRequest.Result.Success)
                    {
                        print($"Download Unsuccessful - {filename}");
                        yield break;
                    }

                    Texture2D downloadedTexture = downloadHandlerTexture.texture;
                    Sprite sprite = Sprite.Create(downloadedTexture, new Rect(0, 0, downloadedTexture.width, downloadedTexture.height), Vector2.zero, 1f);
                    ImageDisplay.sprite = sprite;

                    File.WriteAllBytes(Path.Combine(destination, filename), downloadHandlerTexture.data);
#if UNITY_EDITOR
                    print($"Download Successful - {filename}");
                    UnityEditor.AssetDatabase.Refresh();
#endif
                }
            }
        }

        private IEnumerator DownloadTextureRoutine_RequestTexture()
        {
            string filename = Path.GetFileName(ImageURL);
            string destination = Path.Combine(Application.dataPath, "Downloads");
            if (!Directory.Exists(destination)) Directory.CreateDirectory(destination);

            using (UnityWebRequest request = UnityWebRequestTexture.GetTexture(ImageURL, false))
            {
                yield return request.SendWebRequest();

                if (request.result != UnityWebRequest.Result.Success)
                {
                    print($"Download Unsuccessful - {filename}");
                    yield break;
                }

                Texture2D downloadedTexture = DownloadHandlerTexture.GetContent(request);
                Sprite sprite = Sprite.Create(downloadedTexture, new Rect(0, 0, downloadedTexture.width, downloadedTexture.height), Vector2.zero, 1f);
                ImageDisplay.sprite = sprite;

                // Not sure if you should Encode to a specified format
                // byte[] textureData = downloadedTexture.EncodeToPNG();
                // File.WriteAllBytes(Path.Combine(destination, filename), textureData);

                File.WriteAllBytes(Path.Combine(destination, filename), request.downloadHandler.data);
#if UNITY_EDITOR
                print($"Download Successful - {filename}");
                UnityEditor.AssetDatabase.Refresh();
#endif
            }
        }

        #endregion
    }
}