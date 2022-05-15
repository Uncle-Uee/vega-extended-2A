using UnityEngine;

namespace Adventure.Player
{
    public class AnimationController : MonoBehaviour
    {
        #region VARIABLES

        [Header("Required Components")]
        public Animator Animator;

        [Header("Player Entity")]
        public PlayerEntity PlayerEntity;

        private readonly int IsMoving = Animator.StringToHash("IsMoving");
        private readonly int IsBlocking = Animator.StringToHash("IsBlocking");
        private readonly int IsLightAttacking = Animator.StringToHash("IsLightAttacking");
        private readonly int IsHeavyAttacking = Animator.StringToHash("IsHeavyAttacking");
        private readonly int Defeat = Animator.StringToHash("Defeat");

        #endregion

        #region METHODS

        public void SetIsMoving(bool value)
        {
            Animator.SetBool(IsMoving, value);
        }

        public void SetIsLightAttacking(bool value)
        {
            Animator.SetBool(IsLightAttacking, value);
        }

        public void StopLightAttacking()
        {
            PlayerEntity.IsLightAttacking = false;
            SetIsLightAttacking(false);
        }

        public void SetIsHeavyAttacking(bool value)
        {
            Animator.SetBool(IsHeavyAttacking, value);
        }

        public void StopHeavyAttacking()
        {
            PlayerEntity.IsHeavyAttacking = false;
            SetIsHeavyAttacking(false);
        }

        public void SetIsBlocking(bool value)
        {
            Animator.SetBool(IsBlocking, value);
        }

        public void StopBlocking()
        {
            PlayerEntity.IsBlocking = false;
            SetIsBlocking(false);
        }

        public void OnDefeat()
        {
            Animator.SetTrigger(Defeat);
        }

        public void ResetAnimator()
        {
            Animator.Rebind();
        }

        #endregion
    }
}