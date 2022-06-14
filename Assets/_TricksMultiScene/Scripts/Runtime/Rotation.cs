using UnityEngine;

namespace MultiScene.Misc
{
    public class Rotation : MonoBehaviour
    {
        public float RotationSpeed = 15f;

        private void Update()
        {
            transform.Rotate(0f, RotationSpeed * Time.deltaTime, 0f);
        }
    }
}