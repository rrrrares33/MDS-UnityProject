using UnityEngine;
using UnityEngine.UI;

namespace Gameplay
{
    public class HealthBar : MonoBehaviour
    {
        public Image fillBar;
        public float health;

        public void LoseHealth(int value)
        {
            if (health <= 0)
                return;

            health = health - value;
            fillBar.fillAmount = health / 100;

            if(health<=0)
            {

            }
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Return))
                LoseHealth(25);
        }
    }
}
