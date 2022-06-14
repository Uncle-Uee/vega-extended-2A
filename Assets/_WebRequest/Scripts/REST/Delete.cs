using System.Collections;
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

        [Header("REST Properties")]
        public string URL = "https://6271a93ac455a64564b62dd2.mockapi.io/players";

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
            using (UnityWebRequest request = UnityWebRequest.Delete($@"{URL}\{Player.ID}"))
            {
                request.method = "DELETE";
                yield return request.SendWebRequest();

                if (request.result != UnityWebRequest.Result.Success)
                {
                    print("Failed to Delete Player!");
                }
                else
                {
                    print("Successfully Deleted Player!");
                }
            }
        }

        #endregion
    }
}