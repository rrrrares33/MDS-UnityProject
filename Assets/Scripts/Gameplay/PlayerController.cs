using Behaviours;
using Managers;
using UnityEngine;

namespace Gameplay
{
    public class PlayerController : CharacterController2D
    {
        private void Update()
        {
            ProcessInputs();
        }

        private void ProcessInputs()
        {
            var moveX = Input.GetAxisRaw("Horizontal");
            var moveY = Input.GetAxisRaw("Vertical");

            MoveDirection = new Vector2(moveX, moveY).normalized;
        }
    }
}
