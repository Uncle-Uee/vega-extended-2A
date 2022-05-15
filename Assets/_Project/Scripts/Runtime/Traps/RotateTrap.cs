namespace Adventure.Traps
{
    public class RotateTrap : TrapBase
    {
        #region UNITY METHODS

        private void Start()
        {
            TrapEffect();
        }

        #endregion

        #region METHODS

        public override void TrapEffect()
        {
            TrapBehaviour.TrapEffect();
        }

        #endregion
    }
}