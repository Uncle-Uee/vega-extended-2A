using Adventure.ScriptableObjects;
using UnityEngine;

namespace Adventure.General.System
{
    public class Checkpoint : MonoBehaviour
    {
        #region VARIABLES

        [Header("Required ScriptableObjects")]
        public ManagersSo ManagersSo;
        public EventsSo EventsSo;

        [Header("Checkpoint Properties")]
        public bool IsStartPoint = false;

        [Header("Effects")]
        public ParticleSystem CheckpointEffect;

        #endregion

        #region PROPERTIES

        public Vector3 SpawnPosition { get; private set; }

        #endregion

        #region UNITY METHODS

        private void Start()
        {
            SpawnPosition = transform.position;
            if (IsStartPoint) ManagersSo.CheckpointManager.RegisterStartingPoint(this);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!other.CompareTag("Player")) return;
            // Here Register the Checkpoint
            if (CheckpointEffect)
            {
                CheckpointEffect.transform.position = SpawnPosition;
                CheckpointEffect.Play(true);
            }

            if (!IsStartPoint) EventsSo.OnRegisterCheckpoint(this);
        }

        #endregion

        #region METHODS

        #endregion
    }
}