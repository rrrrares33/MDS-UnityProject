#pragma warning disable 0649

using Gameplay;
using TMPro;
using UnityEngine;
using Utils;

namespace Managers
{
    public class GameManager : Singleton<GameManager>
    {
        [SerializeField] private PlayerController player;
        [SerializeField] private TextMeshProUGUI healthUI;
    
        private void Update()
        {
            var newHealthText = "Health: " + player.Health;
            if (newHealthText != healthUI.text)
            {
                healthUI.SetText(newHealthText);
            }
        }
    }
}
