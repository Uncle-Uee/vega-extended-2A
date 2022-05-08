using Adventure.ScriptableObjects;
using UnityEngine;

namespace Adventure.DeadZones
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
            print(other.name);
            print(ManagersSo.CheckpointManager.RespawnAtActiveCheckpoint());
            other.gameObject.transform.position = ManagersSo.CheckpointManager.RespawnAtActiveCheckpoint();
        }

        #endregion
    }
}