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

        [Header("Player Controls")]
        public InputActionReference JumpAction;
        public InputActionReference LookAction;
        public InputActionReference MovementAction;


        [Header("Input Properties")]
        public Vector2 MoveInput;
        public Vector2 MouseDelta;
        public bool Jump;

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
            Jump = JumpAction.action.triggered;
            MoveInput = MovementAction.action.ReadValue<Vector2>();
        }

        #endregion

        #region BEHAVIOUR METHODS

        private void Movement()
        {
            MovementBehaviour.Movement(MoveInput, Jump);
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
        }

        public override void DoOnDestroy()
        {
            _playerControls.Dispose();
            MovementAction.action.Dispose();
            LookAction.action.Dispose();
            JumpAction.action.Dispose();
        }

        #endregion
    }
}