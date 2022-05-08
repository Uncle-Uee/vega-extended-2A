using UnityEngine;

namespace Adventure.Effects
{
    public class CheckpointEffect : MonoBehaviour
    {
        #region VARIABLES

        [Header("Particle Systems")]
        public ParticleSystem ParticleSystem;

        #endregion

        #region UNITY METHODS

        private void OnEnable()
        {
            Play();
        }

        #endregion

        #region METHODS

        private void Play()
        {
            if (!ParticleSystem) return;
            ParticleSystem.Play(true);
        }

        #endregion
    }
}