using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Dungeon
{
    public abstract class DungeonGenerator : MonoBehaviour
    {
        [SerializeField] protected TilemapVisualizer visualizer;
        [SerializeField] protected Vector2Int startPosition = Vector2Int.zero;

        protected ICollection<Vector2Int> FloorPositions;

        public void GenerateDungeon()
        {
            visualizer.Clear();
            RunProceduralGeneration();
            visualizer.ResetScale();
        }

        protected abstract void RunProceduralGeneration();

        public Vector2 GetRandomFloorPosition()
        {
            return (Vector2) FloorPositions.ElementAt(Random.Range(0, FloorPositions.Count))
                   * visualizer.ScaleMultiplier;
        }
    }
}
