#pragma warning disable 0649

using Gameplay;
using TMPro;
using UnityEngine;

namespace Managers
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private PlayerController player;
        [SerializeField] private TextMeshProUGUI healthUI;
    
        private void Update()
        {
            var newHealthText = "Health: " + player.GetHealth();
            if (newHealthText != healthUI.text)
            {
                healthUI.SetText(newHealthText);
            }
        }
    }
}
