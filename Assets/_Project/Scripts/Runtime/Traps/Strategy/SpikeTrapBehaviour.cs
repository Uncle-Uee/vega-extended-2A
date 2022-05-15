using Adventure.Traps;
using DG.Tweening;
using UnityEngine;

namespace Adventure
{
    public class SpikeTrapBehaviour : TrapBehaviour
    {
        #region VARIABLES

        [Header("Lerp Properties")]
        public float LerpDuration = 1.5f;
        public Vector3 TargetPosition = new Vector3(0f, 0f, 0f);

        [Header("Tween Properties")]
        public Ease TrapEase = Ease.Linear;

        #endregion

        #region UNITY METHODS

        #endregion

        #region METHODS

        public override void TrapEffect()
        {
            SpikeTrapTween();
        }

        private void SpikeTrapTween()
        {
            transform.DOLocalMove(TargetPosition, LerpDuration).SetLoops(-1, LoopType.Yoyo).SetEase(TrapEase);
        }

        #endregion
    }
}