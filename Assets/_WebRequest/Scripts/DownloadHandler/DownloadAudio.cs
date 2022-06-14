using System.Collections;
using System.IO;
using UnityEngine;
using UnityEngine.Networking;

namespace WebRequest
{
    public class DownloadAudio : MonoBehaviour
    {
        #region VARIABLES

        [Header("URL")]
        public string SourceURL = "https://opengameart.org/content/desert-loop-lo-fi-remaster";
        public string AudioURL = "https://opengameart.org/sites/default/files/desert_loops_2_0.mp3";

        [Header("Audio Source")]
        public AudioSource DownloadedAudioSource;

        #endregion

        #region METHODS

        public void StartDownloadAudioClip()
        {
            StartCoroutine(DownloadAudioClip_MultimediaRequest());
        }

        private IEnumerator DownloadAudioClip_MultimediaRequest()
        {
            string filename = Path.GetFileName(AudioURL);
            string destination = Path.Combine(Application.dataPath, "Downloads");
            if (!Directory.Exists(destination)) Directory.CreateDirectory(destination);

            using (UnityWebRequest request = UnityWebRequestMultimedia.GetAudioClip(AudioURL, AudioType.MPEG))
            {
                yield return request.SendWebRequest();
                if (request.result != UnityWebRequest.Result.Success)
                {
                    print($"Download Unsuccessful! - {filename}");
                    yield break;
                }

                DownloadedAudioSource.clip = DownloadHandlerAudioClip.GetContent(request);
                DownloadedAudioSource.Play();

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