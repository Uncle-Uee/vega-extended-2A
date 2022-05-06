using System.Collections;
using Adventure.Player;
using UnityEngine;

namespace Adventure.Traps
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

        private void Awake()
        {
            _delay = new WaitForSeconds(DelayBetweenRotations);
        }

        private void Start()
        {
            StartCoroutine(RotateTileRoutine(Rotation.x, Rotation.y));
        }

        #endregion

        #region METHODS

        /// <summary>
        /// Rotate Tile on Z Axis using Lerp<br/>
        /// </summary>
        /// <param name="a">Start Value</param>
        /// <param name="b">Target Value</param>
        /// <returns></returns>
        private IEnumerator RotateTileRoutine(float a, float b)
        {
            // The Right Way to Lerp in Unity with Examples by John
            // https://gamedevbeginner.com/the-right-way-to-lerp-in-unity-with-examples/#right_way_to_use_lerp<br/>

            // PRE COROUTINE - SETUP FOR COROUTINE
            float elapsedTimed = 0f;
            float zRotation = 0f;

            while (elapsedTimed < TimeToLerp)
            {
                // COROUTINE
                zRotation = Mathf.LerpAngle(a, b, EaseInOutSine(elapsedTimed / TimeToLerp));

                transform.rotation = Quaternion.Euler(0f, 0f, zRotation);

                elapsedTimed += Time.deltaTime;

                yield return null;
            }

            // POST COROUTINE - AFTER THE COROUTINE EXECUTED
            transform.rotation = Quaternion.Euler(0f, 0f, b);

            yield return _delay;

            StartCoroutine(RotateTileRoutine(b, a));
        }

        #endregion

        #region HELPER METHODS

        private float EaseInOutSine(float t)
        {
            return t * t * (3f - 2f * t);
        }

        #endregion
    }
}