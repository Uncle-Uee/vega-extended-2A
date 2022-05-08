using System;
using Adventure.Checkpoints;
using UnityEngine;

namespace Adventure.ScriptableObjects
{
    [CreateAssetMenu(fileName = "EventsSo", menuName = "ScriptableObjects/EventsSo", order = 90)]
    public class EventsSo : ScriptableObject
    {
        #region CHECKPOINT EVENTS AND METHODS

        [Header("Checkpoint Events")]
        public Action<Checkpoint, bool> RegisterCheckpoint;

        public void OnRegisterCheckPoint(Checkpoint checkpoint, bool isStartPoint = false)
        {
            RegisterCheckpoint?.Invoke(checkpoint, isStartPoint);
        }

        #endregion
    }
}