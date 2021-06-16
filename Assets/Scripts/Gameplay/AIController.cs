#pragma warning disable 0649

using UnityEngine;
using Utils;
using Vector2 = UnityEngine.Vector2;

namespace Gameplay
{
    public class AIController : CharacterController2D
    {
        [SerializeField] private float stoppingDistance = 2.0f;
        [SerializeField] private float retreatDistance = 1.8f;

        private Transform _target;
        private bool _hasTarget;

        protected override void Start()
        {
            base.Start();
            
            var enemyMask = LayerMask.NameToLayer(Layers.Enemy.ToString());
            Physics2D.IgnoreLayerCollision(enemyMask, enemyMask);
            
            _target = GameObject.FindGameObjectWithTag(Tags.Player).GetComponent<Transform>();
            _hasTarget = _target != null;
        }

        protected override void Update()
        {
            base.Update();
            if (IsDead)
            {
                Destroy(gameObject);
            }
            MoveToTarget();
        }

        private void MoveToTarget()
        {
            if (!_hasTarget)
            {
                return;
            }
            
            var thisTransform = transform;
            var targetPosition = (Vector2) _target.position;
            
            var distance = Vector2.Distance(thisTransform.position, targetPosition);
            var orientation = distance > stoppingDistance ? 1.0f :
                distance <= retreatDistance ? -1.0f : 0.0f;
            IsAttacking = orientation == 0.0f;
            
            MoveDirection = orientation * (Vector2) transform.InverseTransformPoint(targetPosition).normalized;
            MoveDirection.x *= Mathf.Sign(thisTransform.localScale.x);
        }
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag(Tags.Player))
            {
                other.GetComponent<PlayerController>()
                    .ReceiveDamage(new Damage(other.transform.position, 1, 5.0f));
            }
        }

        public void SetTarget(Transform newTarget)
        {
            _target = newTarget;
        }
    }
}
