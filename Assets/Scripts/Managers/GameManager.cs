#pragma warning disable 0649

using Dungeon;
using UnityEngine;
using Utils;

namespace Managers
{
    public class GameManager : Singleton<GameManager>
    {
        [SerializeField] private GameObject player;
        [SerializeField] private DungeonGenerator generator;

        private void Start()
        {
            generator.GenerateDungeon();
            Instantiate(player, Vector3.zero, Quaternion.identity);
        }
    }
}
