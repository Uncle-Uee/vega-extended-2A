using UnityEngine;

namespace Adventure.Traps
{
    public abstract class TrapBase : MonoBehaviour
    {
        #region VARIABLES

        [Header("Trap Behaviour")]
        public TrapBehaviour TrapBehaviour;

        #endregion

        #region METHODS

        public abstract void TrapEffect();

        #endregion
    }
}