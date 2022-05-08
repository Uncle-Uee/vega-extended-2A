using Adventure.Managers;
using UnityEngine;

namespace Adventure.ScriptableObjects
{
    [CreateAssetMenu(fileName = "ManagersSo", menuName = "ScriptableObjects/ManagersSo", order = 90)]
    public class ManagersSo : ScriptableObject
    {
        #region VARIABLES

        [Header("Checkpoint Manager")]
        public CheckpointManager CheckpointManager;

        #endregion
    }
}