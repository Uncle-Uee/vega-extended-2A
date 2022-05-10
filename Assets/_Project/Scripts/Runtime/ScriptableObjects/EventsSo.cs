using System;
using Adventure.General.System;
using UnityEngine;

namespace Adventure.ScriptableObjects
{
    [CreateAssetMenu(fileName = "EventsSo", menuName = "ScriptableObjects/EventsSo", order = 90)]
    public class EventsSo : ScriptableObject
    {
        #region CHECKPOINT EVENTS AND METHODS

        public event Action<Checkpoint> RegisterCheckpoint;

        public void OnRegisterCheckpoint(Checkpoint checkpoint)
        {
            RegisterCheckpoint?.Invoke(checkpoint);
        }

        #endregion
    }
}