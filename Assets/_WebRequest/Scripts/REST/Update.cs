using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

namespace WebRequest
{
    public class Update : MonoBehaviour
    {
        #region VARIABLES

        [Header("Player Properties")]
        public Player Player;

        [Header("REST Properties")]
        public string URL = "https://6271a93ac455a64564b62dd2.mockapi.io/players";

        #endregion

        #region UNITY METHODS

        private void Start()
        {
            StartCoroutine(UpdateRequest());
        }

        #endregion

        #region METHODS

        private IEnumerator UpdateRequest()
        {
            string json = JsonUtility.ToJson(Player).Normalize();
            print(json);

            using (UnityWebRequest request = UnityWebRequest.Put($@"{URL}\{Player.ID}", json))
            {
                request.method = "PUT";
                request.SetRequestHeader("Content-Type", "application/json");
                yield return request.SendWebRequest();

                if (request.result != UnityWebRequest.Result.Success)
                {
                    print("Failed to Update Player!");
                }
                else
                {
                    print("Successfully Updated Player!");
                }
            }
        }

        #endregion
    }
}