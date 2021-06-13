using Behaviours;
using UnityEngine;

namespace Gameplay
{
    [RequireComponent(typeof(Animator))]
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(SpriteRenderer))]
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private int startHealth = 6;
        [SerializeField] private int startDamage = 1;
        [SerializeField] private float startMovementSpeed = 500.0f;

        private Animator _animator;
        private Rigidbody2D _rb;
        private SpriteRenderer _renderer;

        private int _damage;
        private float _movementSpeed;

        private Vector2 _moveDirection;

        public int Health { get; private set; }

        bool isDead = false;

        private void Start()
        {
            _animator = GetComponent<Animator>();
            _rb = GetComponent<Rigidbody2D>();
            _renderer = GetComponent<SpriteRenderer>();

            Health = startHealth;
            _damage = startDamage;
            _movementSpeed = startMovementSpeed;
        }
    
        private void Update()
        {
            if (isDead)
                return;

            ProcessInputs();
        }

        private void FixedUpdate()
        {
            Run();
        }

        private void ProcessInputs()
        {
            var moveX = Input.GetAxisRaw("Horizontal");
            var moveY = Input.GetAxisRaw("Vertical");

            _moveDirection = new Vector2(moveX, moveY).normalized;

            if (moveX != 0.0f)
            {
                _renderer.flipX = moveX < 0.0f;
            }
        }

        private void Run()
        {
            _rb.velocity = Time.deltaTime * _movementSpeed * _moveDirection;
            _animator.SetBool(AnimatorParams.IsRunning, !_rb.velocity.Equals(Vector2.zero));
        }

        public void Die()
        {
            isDead = true;
            FindObjectOfType<LevelManager>().Restart();
        }
    }
}
