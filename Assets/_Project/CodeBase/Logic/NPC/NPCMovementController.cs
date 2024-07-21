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

        public float speed = 2;

        public float nextWaypointDistance = 3;

        private int currentWaypoint = 0;

        public bool reachedEndOfPath;

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
                    break;
                }
            } else {
                break;
            }
        }
        var speedFactor = reachedEndOfPath ? Mathf.Sqrt(distanceToWaypoint/nextWaypointDistance) : 1f;
        Vector3 dir = (path.vectorPath[currentWaypoint] - transform.position).normalized;
        Vector3 velocity = dir * speed * speedFactor;
        _controller.SimpleMove(velocity);
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