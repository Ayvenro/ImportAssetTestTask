using System;
using UnityEngine;
using Pathfinding;

namespace _Project.CodeBase.Logic.NPC
{
    public class NPCMovementController : MonoBehaviour
    {
        private const string GuestEndPointTag = "GuestEndPoint";
        private Transform _targetPosition;
        
        private CharacterController _controller;
        private Seeker _seeker;

        public Path path;

        private float speed = 2;

        private float nextWaypointDistance = 3;

        private int currentWaypoint = 0;

        private bool reachedEndOfPath;

        private float _animationBlend;
        
        public event Action<float> OnSpeedChange;
        public event Action<float> OnSpeedMultiplierChanged;
        
        public event Action OnEndofPath;
        
        public void Awake()
        {
            _targetPosition = GameObject.FindGameObjectWithTag(GuestEndPointTag).transform;
            _seeker = GetComponent<Seeker>();
            _controller = GetComponent<CharacterController>();
            _seeker.StartPath(transform.position, _targetPosition.position, OnPathComplete);
        }
        
         public void Update () {
        if (path == null) {
            return;
        }
        reachedEndOfPath = false;
        float distanceToWaypoint;
        while (true) {
            distanceToWaypoint = Vector3.Distance(transform.position, path.vectorPath[currentWaypoint]);
            if (distanceToWaypoint < nextWaypointDistance) {
                if (currentWaypoint + 1 < path.vectorPath.Count) {
                    currentWaypoint++;
                } else {
                    reachedEndOfPath = true;
                    OnEndofPath?.Invoke();
                    break;
                }
            } else {
                break;
            }
        }
        var speedFactor = reachedEndOfPath ? Mathf.Sqrt(distanceToWaypoint/nextWaypointDistance) : 1f;
        Vector3 dir = (path.vectorPath[currentWaypoint] - transform.position).normalized;
        Vector3 velocity = dir * speed * speedFactor;
        transform.rotation = Quaternion.LookRotation(velocity);
        _controller.SimpleMove(velocity);
        _animationBlend = Mathf.Lerp(_animationBlend, speed, Time.deltaTime * speedFactor);
        if (_animationBlend < 0.01f) _animationBlend = 0f;
        OnSpeedMultiplierChanged?.Invoke(_animationBlend);
         }

        private void OnPathComplete(Path p)
        {
            Debug.Log("A path was calculated. Did it fail with an error? " + p.error);

            if (!p.error) {
                path = p;
                currentWaypoint = 0;
            }
        }
    }
}