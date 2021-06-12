#pragma warning disable 0649

using Behaviours;
using UnityEngine;

namespace Gameplay
{
    [RequireComponent(typeof(Animator))]
    [RequireComponent(typeof(SpriteRenderer))]
    public class EnemyAI : MonoBehaviour
    {
        [SerializeField] private float movementSpeed = 5.0f;
        [SerializeField] private float stoppingDistance = 2.0f;
        [SerializeField] private float retreatDistance = 1.0f;
        [SerializeField] private float startAttackInterval = 2.0f;
        [SerializeField] private GameObject target;
    
        private Animator _animator;
        private SpriteRenderer _renderer;
    
        private float _attackInterval;
        private bool _hasTarget;

        private void Start()
        {
            _animator = GetComponent<Animator>();
            _renderer = GetComponent<SpriteRenderer>();
        
            _attackInterval = startAttackInterval;
            _hasTarget = target != null;
        }

        private void Update()
        {
            if (!_hasTarget)
            {
                return;
            }
        
            Move();
            Attack();
        }

        private void Move()
        {
            var targetPosition = target.transform.position;
            var distance = Vector2.Distance(transform.position, targetPosition);
            var localTargetPointX = transform.InverseTransformPoint(targetPosition).x;
        
            _animator.SetBool(AnimatorParams.IsRunning, true);
            if (localTargetPointX != 0.0f)
            {
                _renderer.flipX = localTargetPointX < 0.0f;
            }
        
            if (distance > stoppingDistance)
            {
                Follow(target.transform.position);
            }
            else if (distance <= retreatDistance)
            {
                RunAwayFrom(target.transform.position);
            }
            else
            {
                _animator.SetBool(AnimatorParams.IsRunning, false);
            }
        }

        private void Follow(Vector2 targetPosition)
        {
            transform.position = Vector2.MoveTowards(
                transform.position,
                targetPosition,
                movementSpeed * Time.deltaTime);
        }

        private void RunAwayFrom(Vector2 targetPosition)
        {
            transform.position = Vector2.MoveTowards(
                transform.position,
                targetPosition,
                -movementSpeed * Time.deltaTime);
        }

        private void Attack()
        {
            if (_attackInterval <= 0)
            {
                // TODO
                _attackInterval = startAttackInterval;
            }
            else
            {
                _attackInterval -= Time.deltaTime;
            }
        }
    }
}
