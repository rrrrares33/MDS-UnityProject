using System.Collections.Generic;
using UnityEngine;

namespace Dungeon
{
    public abstract class DungeonGenerator : MonoBehaviour
    {
        [SerializeField] protected TilemapVisualizer visualizer;
        [SerializeField] protected Vector2Int startPosition = Vector2Int.zero;

        public void GenerateDungeon()
        {
            visualizer.Clear();
            RunProceduralGeneration();
        }

        protected abstract void RunProceduralGeneration();
    }
}
