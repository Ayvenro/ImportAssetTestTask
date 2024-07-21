using System;
using UnityEngine;

namespace _Project.CodeBase.Logic.NPC
{
    public class NPCAnimationController : MonoBehaviour
    {
        [SerializeField] private Animator animator;
        [SerializeField] private NPCMovementController npcMovementController;

        private int _animationIdSpeed;
        private int _animationIdDance;
        private int _animationIdMotionSpeed;

        private void Awake()
        {
            CalculateAnimateId();
            npcMovementController.OnSpeedChange += BlendIdleWalk;
            npcMovementController.OnSpeedMultiplierChanged += f => animator.SetFloat(_animationIdSpeed, f);
            npcMovementController.OnEndofPath += EnableDanceAnimation;
        }

        private void BlendIdleWalk(float speed)
        {
            animator.SetFloat(_animationIdSpeed, speed);
        }

        private void EnableDanceAnimation()
        {
            animator.SetBool(_animationIdDance, true);
        }

        private void CalculateAnimateId()
        {
            _animationIdDance = Animator.StringToHash("Dance");
            _animationIdSpeed = Animator.StringToHash("Speed");
            _animationIdMotionSpeed = Animator.StringToHash("MotionSpeed");
        }
    }
}