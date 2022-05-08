using System.Collections;
using DG.Tweening;
using UnityEngine;

namespace Adventure
{
    public class SpikeTrap : MonoBehaviour
    {
        #region VARIABLES

        [Header("Lerp Properties")]
        public float LerpDuration = 1.5f;
        public Vector3 StartPosition = new Vector3(0f, -.25f, 0f);
        public Vector3 TargetPosition = new Vector3(0f, 0f, 0f);

        [Header("Tween Properties")]
        public Ease TrapEase = Ease.Linear;

        #endregion

        #region UNITY METHODS

        private void Start()
        {
            // StartCoroutine(SpikeTrapRoutine(StartPosition, TargetPosition));
            SpikeTrapTween();
        }

        private IEnumerator SpikeTrapRoutine(Vector3 startPosition, Vector3 targetPosition)
        {
            // Pre Coroutine
            float elapsedTime = 0f;
            while (elapsedTime < LerpDuration)
            {
                // Coroutine
                transform.position = Vector3.Lerp(startPosition, targetPosition, elapsedTime / LerpDuration);
                elapsedTime += Time.deltaTime;
                yield return null;
            }

            transform.position = targetPosition;

            // Post Coroutine

            StartCoroutine(SpikeTrapRoutine(targetPosition, startPosition));
        }

        private void SpikeTrapTween()
        {
            transform.DOLocalMove(TargetPosition, LerpDuration).SetLoops(-1, LoopType.Yoyo).SetEase(TrapEase);
        }

        #endregion

        #region METHODS

        #endregion
    }
}