using System;
using Pathfinding;
using UnityEngine;

namespace _Project.CodeBase.Logic.NPC
{
    public class NPCAnimationController : MonoBehaviour
    {
        [SerializeField] private Animator animator;
        [SerializeField] private AIPath aiPath;

        private int _animationIdIsWalking;
        private int _animationIdIsDancing;

        private void Awake()
        {
            CalculateAnimateId();
        }

        private void Update()
        {
            if (aiPath.hasPath)
            {
                animator.SetBool(_animationIdIsWalking, aiPath.velocity.magnitude > 0.01f);
            }

            if (aiPath.reachedEndOfPath)
            {
                EnableDanceAnimation();
            }
        }

        private void IsWalking(bool state)
        {
            animator.SetBool(_animationIdIsWalking, state);
        }

        private void EnableDanceAnimation()
        {
            animator.SetBool(_animationIdIsDancing, true);
        }

        private void CalculateAnimateId()
        {
            _animationIdIsDancing = Animator.StringToHash("isDancing");
            _animationIdIsWalking = Animator.StringToHash("isWalking");
        }
    }
}