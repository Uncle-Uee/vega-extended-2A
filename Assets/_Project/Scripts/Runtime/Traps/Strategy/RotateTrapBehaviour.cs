using DG.Tweening;
using UnityEngine;

namespace Adventure.Traps
{
    public class RotateTrapBehaviour : TrapBehaviour
    {
        #region VARIABLES

        [Header("Rotation Properties")]
        public Vector3 TargetRotation = new Vector3(0f, 0f, 180f);


        [Header("Tween Properties")]
        public float TimeToTween = 1f;
        public float DelayBetweenRotations = 1f;
        public Ease RotationEase = Ease.Linear;

        private Sequence _rotateSequence;

        #endregion

        #region METHODS

        public override void TrapEffect()
        {
            RotateTrapTween();
        }

        private void RotateTrapTween()
        {
            if (_rotateSequence == null)
            {
                _rotateSequence = DOTween.Sequence();
                // Required For Adding Pause Intervals
                _rotateSequence.Pause();
            }

            _rotateSequence
                .Append(transform.DORotate(TargetRotation, TimeToTween))
                .AppendInterval(DelayBetweenRotations)
                .Append(transform.DORotate(Vector3.zero, TimeToTween))
                .AppendInterval(DelayBetweenRotations)
                .SetLoops(-1)
                .SetEase(RotationEase);

            _rotateSequence.Play();
        }

        #endregion
    }
}