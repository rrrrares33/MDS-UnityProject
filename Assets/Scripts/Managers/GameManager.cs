#pragma warning disable 0649

using Dungeon;
using Gameplay;
using UnityEngine;
using Utils;

namespace Managers
{
    public class GameManager : Singleton<GameManager>
    {
        [SerializeField] private DungeonGenerator generator;
        
        [SerializeField] private GameObject playerAvatar;
        [SerializeField] private GameObject playerWeapon;
        [SerializeField] private GameObject mainCamera;
        
        [SerializeField] private GameObject[] enemies;
        [SerializeField] private int enemiesCount;

        protected override void Awake()
        {
            base.Awake();
            generator.GenerateDungeon();
            
            var player = Instantiate(playerAvatar);

            var weapon = Instantiate(playerWeapon);
            weapon.transform.parent = player.transform;
            player.GetComponent<PlayerController>().SetWeapon(weapon.GetComponent<Weapon>());

            var playerCamera = Instantiate(mainCamera);
            playerCamera.transform.parent = player.transform;
            playerCamera.transform.localPosition = new Vector3(0.0f, 0.0f, -10.0f);

            for (var _ = 0; _ < enemiesCount; ++_)
            {
                var enemy = Instantiate(enemies[Random.Range(0, enemies.Length)]);
                enemy.GetComponent<AIController>().SetTarget(player.GetComponent<Transform>());
            }
        }
        
        private T Instantiate<T>(T original, Vector3? position = null) where T : Object
        {
            return Instantiate(original, position ?? generator.GetRandomFloorPosition(), Quaternion.identity);
        }
    }
}
