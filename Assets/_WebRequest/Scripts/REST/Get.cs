using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

namespace WebRequest
{
    public class Get : MonoBehaviour
    {
        #region VARIABLES

        [Header("Player Properties")]
        public Player Player;
        public Players MyPlayers;

        public List<Player> AllPlayers = new List<Player>();

        [Header("REST Properties")]
        public string URL = "https://6271a93ac455a64564b62dd2.mockapi.io/players";

        #endregion

        #region UNITY METHODS

        private void Start()
        {
            // StartCoroutine(GetAllPlayersRequest());
            StartCoroutine(GetAPlayerRequest());
        }

        #endregion

        #region METHODS

        private IEnumerator GetAllPlayersRequest()
        {
            using (UnityWebRequest request = UnityWebRequest.Get($"{URL}"))
            {
                request.method = "GET";
                yield return request.SendWebRequest();

                if (request.result != UnityWebRequest.Result.Success)
                {
                    print("Failed to Create Player!");
                }
                else
                {
                    string json = request.downloadHandler.text;
                    print(json);

                    AllPlayers.Clear();
                    JsonUtility.FromJsonOverwrite(json, AllPlayers);

                    print("Successfully Created Player!");
                }
            }
        }

        private IEnumerator GetAPlayerRequest()
        {
            using (UnityWebRequest request = UnityWebRequest.Get($@"{URL}\{Player.ID}"))
            {
                request.method = "GET";
                yield return request.SendWebRequest();

                if (request.result != UnityWebRequest.Result.Success)
                {
                    print("Failed to Create Player!");
                }
                else
                {
                    string json = request.downloadHandler.text;
                    print(json);
                    
                    JsonUtility.FromJsonOverwrite(json, Player);

                    print("Successfully Created Player!");
                }
            }
        }

        #endregion
    }
}