using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(SpriteRenderer))]
public class CharacterController2D : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 500.0f;

    private Animator _animator;
    private Rigidbody2D _rb;
    private SpriteRenderer _renderer;
    private Vector2 _moveDirection;
    
    private static readonly int IsRunning = Animator.StringToHash("IsRunning");

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _rb = GetComponent<Rigidbody2D>();
        _renderer = GetComponent<SpriteRenderer>();
    }
    
    private void Update()
    {
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
        _rb.velocity = Time.deltaTime * movementSpeed * _moveDirection;
        _animator.SetBool(IsRunning, !_rb.velocity.Equals(Vector2.zero));
    }
}
