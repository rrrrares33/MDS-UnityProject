using UnityEngine;

namespace Gameplay
{
    public class PlayerController : CharacterController2D
    {
        protected override void Start()
        {
            base.Start();
            
            var playerMask = LayerMask.NameToLayer("Player");
            Physics2D.IgnoreLayerCollision(playerMask, playerMask);
        }
        
        protected override void Update()
        {
            base.Update();
            if (!IsDead)
            {
                ProcessInputs();
            }
        }

        private void ProcessInputs()
        {
            var moveX = Input.GetAxisRaw("Horizontal");
            var moveY = Input.GetAxisRaw("Vertical");
            MoveDirection = new Vector2(moveX, moveY).normalized;
            
            if (Input.GetButtonDown("Fire1"))
            {
                IsAttacking = true;
            }
        }
    }
}
