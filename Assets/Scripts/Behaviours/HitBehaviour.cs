using UnityEngine;

namespace State_Machine
{
    public class HitBehaviour : StateMachineBehaviour
    {
        private static readonly int IsHit = Animator.StringToHash("IsHit");

        public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            animator.SetBool(IsHit, false);
        }
    }
}
