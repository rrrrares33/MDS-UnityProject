#pragma warning disable 0649

using Behaviours;
using UnityEngine;

namespace Gameplay
{
    public abstract class CharacterController2D : MonoBehaviour
    {
        [SerializeField] private Weapon weapon;
        private bool _hasWeapon;
        
        [SerializeField] private float startMovementSpeed = 500.0f;
        private float _movementSpeed;

        [SerializeField] private int startHealth = 10;
        private int _health;

        [SerializeField] private float startPushRecoverySpeed = 0.2f;
        private float _pushRecoverySpeed;

        [SerializeField] private float startImmunityTime = 1.0f;
        private float _immunityTime;
        private float _lastImmunityTime;

        private static readonly Vector3 LeftFace = new Vector3(-1.0f, 1.0f, 1.0f);

        private Vector3 _pushDirection;
        
        protected Vector2 MoveDirection = Vector2.zero;
        protected bool IsAttacking;
        protected bool IsDead;

        private Animator _animator;
        private Rigidbody2D _rigidbody;
        private SpriteRenderer _renderer;

        protected virtual void Start()
        {
            _hasWeapon = weapon != null;
            
            _movementSpeed = startMovementSpeed;
            _health = startHealth;
            _pushRecoverySpeed = startPushRecoverySpeed;
            _immunityTime = startImmunityTime;
            _lastImmunityTime = _immunityTime;

            _animator = GetComponent<Animator>();
            _rigidbody = GetComponent<Rigidbody2D>();
            _renderer = GetComponent<SpriteRenderer>();
        }

        protected virtual void Update()
        {
            if (IsDead)
            {
                return;
            }
            
            if (IsAttacking)
            {
                Attack();
            }
        }

        protected virtual void FixedUpdate()
        {
            if (IsDead)
            {
                return;
            }
            
            Move();
        }

        private void Move()
        {
            if (MoveDirection.x != 0.0f)
            {
                transform.localScale = MoveDirection.x > 0.0f ? Vector3.one : LeftFace;
            }
            
            if (_pushDirection != Vector3.zero)
            {
                _pushDirection -= _pushDirection * _pushRecoverySpeed;
                MoveDirection += (Vector2) _pushDirection;
            }

            _rigidbody.velocity = Time.deltaTime * _movementSpeed * MoveDirection;
            _animator.SetBool(AnimatorParams.IsRunning, _rigidbody.velocity != Vector2.zero);
        }

        private void Attack()
        {
            IsAttacking = false;
            if (!_hasWeapon)
            {
                return;
            }

            weapon.Use();
        }

        public void ReceiveDamage(Damage damage)
        {
            if (_immunityTime >= Time.time - _lastImmunityTime)
            {
                return;
            }
            _lastImmunityTime = Time.time;

            _health -= damage.Amount;
            _pushDirection = (transform.position - damage.Origin).normalized * damage.PushForce;

            if (_health <= 0)
            {
                Die();
            }
        }

        private void Die()
        {
            _health = 0;
            IsDead = true;
            Destroy(_animator);
            Destroy(_rigidbody);
            Destroy(_renderer);
        }

        public void SetWeapon(Weapon newWeapon)
        {
            weapon = newWeapon;
        }
    }
}
