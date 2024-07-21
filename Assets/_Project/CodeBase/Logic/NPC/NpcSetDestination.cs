using System;
using UnityEngine;
using Pathfinding;

namespace _Project.CodeBase.Logic.NPC
{
    public class NpcSetDestination : MonoBehaviour
    {
        private const string GuestEndPointTag = "GuestEndPoint";
        private Transform _targetPosition;
        
        private CharacterController _controller;
        private Seeker _seeker;

        private Path _path;
        
   
        public void Awake()
        {
            _targetPosition = GameObject.FindGameObjectWithTag(GuestEndPointTag).transform;
            _seeker = GetComponent<Seeker>();
            _controller = GetComponent<CharacterController>();
            _seeker.StartPath(transform.position, _targetPosition.position, OnPathComplete);
        }

        private void OnPathComplete(Path p)
        {
            Debug.Log("A path was calculated. Did it fail with an error? " + p.error);

            if (!p.error) {
                _path = p;
            }
        }
    }
}