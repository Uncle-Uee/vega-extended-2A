using Adventure.ScriptableObjects;
using UnityEngine;

namespace Adventure.General.System
{
    public class DeadZone : MonoBehaviour
    {
        #region VARIABLES

        [Header("Required ScriptableObjects")]
        public ManagersSo ManagersSo;

        #endregion

        #region UNITY METHODS

        private void OnTriggerEnter(Collider other)
        {
            if (!other.CompareTag("Player")) return;
            other.transform.position = ManagersSo.CheckpointManager.RespawnAtActiveCheckpoint();
        }

        #endregion

        #region METHODS

        #endregion
    }
}