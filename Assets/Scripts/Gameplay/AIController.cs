#pragma warning disable 0649

using UnityEngine;
using Vector2 = UnityEngine.Vector2;

namespace Gameplay
{
    public class AIController : CharacterController2D
    {
        [SerializeField] private float stoppingDistance = 2.0f;
        [SerializeField] private float retreatDistance = 1.8f;

        [SerializeField] private GameObject target;
        private bool _hasTarget;

        protected override void Start()
        {
            base.Start();
            
            _hasTarget = target != null;
        }

        private void Update()
        {
            if (!_hasTarget)
            {
                return;
            }

            Move();
        }

        private void Move()
        {
            var targetPosition = (Vector2) target.transform.position;
            var distance = Vector2.Distance(transform.position, targetPosition);
            var orientation = distance > stoppingDistance ?
                1.0f : distance <= retreatDistance ?
                    -1.0f : 0.0f;
            
            MoveDirection = orientation * (Vector2) transform.InverseTransformPoint(targetPosition).normalized;
        }
    }
}
