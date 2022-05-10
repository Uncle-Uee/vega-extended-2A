using Adventure.General.System;
using Adventure.ScriptableObjects;
using UnityEngine;

namespace Adventure.Managers
{
    public class CheckpointManager : MonoBehaviour
    {
        #region VARIABLES

        [Header("Required ScriptableObjects")]
        public ManagersSo ManagersSo;
        public EventsSo EventsSo;

        [Header("Active Checkpoint")]
        public Checkpoint StartingPoint;
        public Checkpoint ActiveCheckpoint;

        #endregion

        #region UNITY METHODS

        private void Awake()
        {
            ManagersSo.CheckpointManager = this;
        }

        private void OnEnable()
        {
            EventsSo.RegisterCheckpoint += RegisterCheckpoint;
        }

        private void OnDisable()
        {
            EventsSo.RegisterCheckpoint -= RegisterCheckpoint;
        }

        #endregion

        #region METHODS

        private void RegisterCheckpoint(Checkpoint checkpoint)
        {
            ActiveCheckpoint = checkpoint;
        }

        public void RegisterStartingPoint(Checkpoint checkpoint)
        {
            StartingPoint = checkpoint;
        }

        public Vector3 RespawnAtActiveCheckpoint()
        {
            return ActiveCheckpoint ? ActiveCheckpoint.SpawnPosition : StartingPoint.SpawnPosition;
        }

        #endregion
    }
}