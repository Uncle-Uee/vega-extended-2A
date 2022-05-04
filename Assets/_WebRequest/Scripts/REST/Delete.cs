using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using WebRequest;

namespace WebRequest
{
    public class Delete : MonoBehaviour
    {
        #region VARIABLES

        [Header("Player Properties")]
        public Player Player;

        #endregion

        #region UNITY METHODS

        private void Start()
        {
            StartCoroutine(DeleteRequest());
        }

        #endregion

        #region METHODS

        private IEnumerator DeleteRequest()
        {
            using (UnityWebRequest request = UnityWebRequest.Delete($"https://6271a93ac455a64564b62dd2.mockapi.io/players{Player.ID}"))
            {
                yield return request.SendWebRequest();

                if (request.result != UnityWebRequest.Result.Success)
                {
                    print("Failed to Create Player!");
                }
                else
                {
                    print("Successfully Created Player!");
                }
            }
        }

        #endregion
    }
}