using UnityEngine;
using Utils;

namespace Gameplay
{
    public readonly struct Damage
    {
        public Vector3 Origin { get; }
        public int Amount { get; }
        public float PushForce { get; }

        public Damage(Vector3 origin, int amount, float pushForce)
        {
            Origin = origin;
            Amount = amount;
            PushForce = pushForce;
        }
    }
    
    [RequireComponent(typeof(Animator))]
    public class Weapon : MonoBehaviour
    {
        [SerializeField] private int startDamage = 1;
        private int _damage;
        
        [SerializeField] private float startPushForce = 2.0f;
        private float _pushForce;

        [SerializeField] private float startAttackInterval = 1.0f;
        private float _attackInterval;
        private float _lastAttackTime;

        public Animator Animator { get; set; }

        private void Start()
        {
            _damage = startDamage;
            _pushForce = startPushForce;
            _attackInterval = startAttackInterval;
            _lastAttackTime = -_attackInterval;

            Animator = GetComponent<Animator>();

            var character = GetComponent<CharacterController2D>();
            if (character != null)
            {
                Physics2D.IgnoreLayerCollision((int) Layers.Weapon, character.gameObject.layer);
            }
        }

        public void Use()
        {
            if (_attackInterval >= Time.time - _lastAttackTime)
            {
                return;
            }
            
            _lastAttackTime = Time.time;
            Animator.SetTrigger(AnimatorParams.Swing);
        }

        public void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.gameObject.CompareTag(Tags.Player) && !other.gameObject.CompareTag(Tags.Enemy))
            {
                return;
            }

            var target = other.gameObject.GetComponent<CharacterController2D>();
            if (target != null)
            {
                target.ReceiveDamage(new Damage(transform.position, _damage, _pushForce));
            }
        }
    }
}
