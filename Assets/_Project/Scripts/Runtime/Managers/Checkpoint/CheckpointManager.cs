using Adventure.Checkpoints;
using Adventure.ScriptableObjects;
using UnityEngine;

namespace Adventure.Managers
{
    public class CheckpointManager : ManagersBase
    {
        #region VARIABLES

        [Header("Required ScriptableObjects")]
        public ManagersSo ManagersSo;
        public EventsSo EventsSo;

        [Header("Active Checkpoint")]
        public Checkpoint StartCheckpoint;
        public Checkpoint ActiveCheckPoint;

        #endregion

        #region UNITY METHODS

        private void Awake()
        {
            ManagersSo.CheckpointManager = this;
        }

        private void OnEnable()
        {
            EventsSo.RegisterCheckpoint += RegisterActiveCheckpoint;
        }

        private void OnDisable()
        {
            EventsSo.RegisterCheckpoint -= RegisterActiveCheckpoint;
        }

        #endregion

        #region METHODS

        private void RegisterActiveCheckpoint(Checkpoint checkpoint, bool isStartPoint = false)
        {
            if (isStartPoint) StartCheckpoint = checkpoint;
            else ActiveCheckPoint = checkpoint;
        }

        public Vector3 RespawnAtActiveCheckpoint()
        {
            return ActiveCheckPoint ? ActiveCheckPoint.SpawnPosition : StartCheckpoint.SpawnPosition;
        }

        #endregion
    }
}