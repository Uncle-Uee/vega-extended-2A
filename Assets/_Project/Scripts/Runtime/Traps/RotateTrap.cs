using System.Collections;
using UnityEngine;

namespace Adventure
{
    public class RotateTrap : MonoBehaviour
    {
        #region FIELDS

        [Header("Rotation Properties")]
        public Vector2 Rotation = new Vector2(0f, 180f);

        [Header("Lerp Properties")]
        public float TimeToLerp = 3f;
        public float DelayBetweenRotations = 1f;

        private WaitForSeconds _delay;

        #endregion

        #region UNITY METHODS

        private void Start()
        {
            _delay = new WaitForSeconds(DelayBetweenRotations);
            StartCoroutine(RotateTileRoutine(Rotation.x, Rotation.y));
        }

        #endregion

        #region METHODS

        #endregion

        private IEnumerator RotateTileRoutine(float a, float b)
        {
            // PRE COROUTINE - SETUP FOR COROUTINE
            float elapsedTimed = 0f;
            float zRotation = 0f;

            while (elapsedTimed < TimeToLerp)
            {
                // COROUTINE
                float t = elapsedTimed / TimeToLerp;
                t = t * t * (3f - 2f * t); // Easing Function
                zRotation = Mathf.LerpAngle(a, b, t);

                transform.rotation = Quaternion.Euler(0f, 0f, zRotation);

                elapsedTimed += Time.deltaTime;

                yield return null;
            }

            // POST COROUTINE - AFTER THE COROUTINE EXECUTED
            transform.rotation = Quaternion.Euler(0f, 0f, b);

            yield return _delay;

            StartCoroutine(RotateTileRoutine(b, a));
        }
    }
}