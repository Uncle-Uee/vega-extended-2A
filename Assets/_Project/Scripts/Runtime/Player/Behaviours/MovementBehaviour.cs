using UnityEngine;

namespace Adventure.Player
{
    public class MovementBehaviour : MonoBehaviour
    {
        #region VARIABLES

        [Header("Required Components")]
        public CharacterController Controller;

        [Header("Player Entity")]
        public PlayerEntity PlayerEntity;

        [Header("Controller Properties")]
        public float MoveSpeed = 2.0f;
        public float RotationSpeed = 5f;
        public float JumpHeight = 1.0f;
        public float Gravity = -9.81f;

        [Header("Flags")]
        public bool GroundedPlayer;
        public bool CanDoubleJump;

        private Transform _cameraTransform;

        private Vector3 _playerVelocity;

        #endregion

        #region UNITY METHODS

        private void Awake()
        {
            _cameraTransform = Camera.main.transform;
        }

        #endregion

        #region METHODS

        public void Movement(Vector2 input, bool jump)
        {
            if ((PlayerEntity.IsLightAttacking || PlayerEntity.IsHeavyAttacking || PlayerEntity.IsBlocking) && Controller.isGrounded)
            {
                Controller.Move(Vector3.zero);
                return;
            }

            GroundedPlayer = Controller.isGrounded;
            if (GroundedPlayer && _playerVelocity.y < 0)
            {
                _playerVelocity.y = 0f;
            }

            Vector3 move = new Vector3(input.x, 0, input.y);
            move = move.x * _cameraTransform.right + move.z * _cameraTransform.forward;
            move.y = 0f;
            Controller.Move(move * (Time.deltaTime * MoveSpeed));

            if (move != Vector3.zero)
            {
                transform.forward = move;
            }

            // Changes the height position of the player..
            if (jump && GroundedPlayer)
            {
                CanDoubleJump = true;
                _playerVelocity.y += Mathf.Sqrt(JumpHeight * -3.0f * Gravity);
            }

            if (jump && !GroundedPlayer && CanDoubleJump)
            {
                CanDoubleJump = false;

                _playerVelocity.y += Mathf.Abs(_playerVelocity.y) + Mathf.Sqrt(JumpHeight * -3.0f * Gravity);
            }

            _playerVelocity.y += Gravity * Time.deltaTime;
            Controller.Move(_playerVelocity * Time.deltaTime);

            Rotate(input);
        }

        private void Rotate(Vector2 input)
        {
            if (input == Vector2.zero) return;
            float targetAngle = Mathf.Atan2(input.x, input.y) * Mathf.Rad2Deg + _cameraTransform.transform.eulerAngles.y;
            Quaternion rotation = Quaternion.Euler(0f, targetAngle, 0f);

            transform.rotation = Quaternion.Lerp(transform.rotation, rotation, RotationSpeed * Time.deltaTime);
        }

        #endregion
    }
}