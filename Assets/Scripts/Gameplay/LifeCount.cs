using UnityEngine;
using UnityEngine.UI;

namespace Gameplay
{
    public class LifeCount : MonoBehaviour
    {
        public Image[] lives;
        public int livesRemaining;

        public void LoseLife()
        {
            if (livesRemaining == 0)
                return;
            livesRemaining--;
            lives[livesRemaining].enabled = false;

            if (livesRemaining == 0)
            {
                
            }
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Return))
                LoseLife();
        }
    }
}
