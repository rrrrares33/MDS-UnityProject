using Behaviours;
using UnityEngine;

namespace Gameplay
{
    [RequireComponent(typeof(Animator))]
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(SpriteRenderer))]
    public abstract class CharacterController2D : MonoBehaviour
    {
        [SerializeField] protected float startMovementSpeed = 500.0f;
        private float _movementSpeed;

        protected Vector2 MoveDirection = Vector2.zero;

        private Animator _animator;
        private Rigidbody2D _rigidbody;
        private SpriteRenderer _renderer;

        protected virtual void Start()
        {
            _movementSpeed = startMovementSpeed;

            _animator = GetComponent<Animator>();
            _rigidbody = GetComponent<Rigidbody2D>();
            _renderer = GetComponent<SpriteRenderer>();
        }

        private void FixedUpdate()
        {
            Move();
        }

        private void Move()
        {
            if (MoveDirection.x != 0.0f)
            {
                _renderer.flipX = MoveDirection.x < 0.0f;
            }
            
            _rigidbody.velocity = Time.deltaTime * _movementSpeed * MoveDirection;
            _animator.SetBool(AnimatorParams.IsRunning, _rigidbody.velocity != Vector2.zero);
        }
    }
}
