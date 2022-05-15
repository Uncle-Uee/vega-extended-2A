using Adventure.Traps;

namespace Adventure
{
    public class SpikeTrap : TrapBase
    {
        #region METHODS

        private void Start()
        {
            TrapEffect();
        }

        #endregion

        public override void TrapEffect()
        {
            TrapBehaviour.TrapEffect();
        }
    }
}