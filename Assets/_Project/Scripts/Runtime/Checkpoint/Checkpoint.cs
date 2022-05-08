using Adventure.ScriptableObjects;
using UnityEngine;

namespace Adventure.Checkpoints
{
    public class Checkpoint : MonoBehaviour
    {
        #region VARIABLES

        [Header("Required ScriptableObjects")]
        public EventsSo EventsSo;

        [Header("Checkpoint Properties")]
        public bool IsStartPoint = false;

        #endregion

        #region PROPERTIES

        public Vector3 SpawnPosition { get; private set; }

        #endregion

        #region UNITY METHODS

        private void Start()
        {
            SpawnPosition = transform.position;
            print(SpawnPosition);
            if (IsStartPoint) EventsSo.OnRegisterCheckPoint(this, IsStartPoint);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!other.CompareTag("Player")) return;
            if (!IsStartPoint) EventsSo.OnRegisterCheckPoint(this);
        }

        #endregion
    }
}