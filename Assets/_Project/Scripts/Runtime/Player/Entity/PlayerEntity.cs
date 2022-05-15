using Adventure.General.Entity;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Adventure.Player
{
    public class PlayerEntity : EntityBase
    {
        #region VARIABLES

        [Header("Behaviours")]
        public MovementBehaviour MovementBehaviour;

        [Header("Controllers")]
        public AnimationController AnimationController;

        [Header("Movement Actions")]
        public InputActionReference JumpAction;
        public InputActionReference LookAction;
        public InputActionReference MovementAction;

        [Header("Attack Actions")]
        public InputActionReference LightAttackAction;
        public InputActionReference HeavyAttackAction;
        public InputActionReference BlockAction;


        [Header("Input Properties")]
        public Vector2 MoveInput;
        public bool IsJumping;
        public bool IsLightAttacking;
        public bool IsHeavyAttacking;
        public bool IsBlocking;

        private PlayerControls _playerControls;

        #endregion

        #region UNITY METHODS

        private void Awake()
        {
            DoOnAwake();
        }

        private void OnEnable()
        {
            DoOnEnable();
        }

        private void Update()
        {
            ProcessInput();
            Movement();
        }

        private void OnDisable()
        {
            DoOnDisable();
        }

        private void OnDestroy()
        {
            DoOnDestroy();
        }

        #endregion

        #region PROCESS INPUT METHODS

        private void ProcessInput()
        {
            IsJumping = JumpAction.action.triggered;
            MoveInput = MovementAction.action.ReadValue<Vector2>();

            AnimationController.SetIsMoving(MoveInput != Vector2.zero);

            if (!IsHeavyAttacking && !IsBlocking && LightAttackAction.action.triggered)
            {
                IsLightAttacking = true;
                AnimationController.SetIsLightAttacking(IsLightAttacking);
            }

            if (!IsLightAttacking && !IsBlocking && HeavyAttackAction.action.triggered)
            {
                IsHeavyAttacking = true;
                AnimationController.SetIsHeavyAttacking(IsHeavyAttacking);
            }

            if (!IsLightAttacking && !IsHeavyAttacking && BlockAction.action.triggered)
            {
                IsBlocking = true;
                AnimationController.SetIsBlocking(IsBlocking);
            }
        }

        #endregion

        #region BEHAVIOUR METHODS

        private void Movement()
        {
            MovementBehaviour.Movement(MoveInput, IsJumping);
        }

        #endregion

        #region UNITY EVENT METHODS

        public override void DoOnAwake()
        {
            _playerControls = new PlayerControls();
        }

        public override void DoOnEnable()
        {
            _playerControls.Enable();

            MovementAction.action.Enable();
            LookAction.action.Enable();
            JumpAction.action.Enable();

            LightAttackAction.action.Enable();
            HeavyAttackAction.action.Enable();
            BlockAction.action.Enable();
        }

        public override void DoOnStart()
        {
        }

        public override void DoOnDisable()
        {
            _playerControls.Disable();

            MovementAction.action.Disable();
            LookAction.action.Disable();
            JumpAction.action.Disable();

            LightAttackAction.action.Disable();
            HeavyAttackAction.action.Disable();
            BlockAction.action.Disable();
        }

        public override void DoOnDestroy()
        {
            _playerControls.Dispose();

            MovementAction.action.Dispose();
            LookAction.action.Dispose();
            JumpAction.action.Dispose();

            LightAttackAction.action.Dispose();
            HeavyAttackAction.action.Dispose();
            BlockAction.action.Dispose();
        }

        #endregion
    }
}