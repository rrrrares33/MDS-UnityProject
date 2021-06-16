using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Dungeon
{
    public abstract class DungeonGenerator : MonoBehaviour
    {
        [SerializeField] protected TilemapVisualizer visualizer;
        [SerializeField] protected Vector2Int startPosition = Vector2Int.zero;

        public ICollection<Vector2Int> FloorPositions { get; protected set; }

        public void GenerateDungeon(bool drawTiles = true)
        {
            if (drawTiles)
            {
                ClearDungeon();
            }
            
            RunProceduralGeneration();
            if (!drawTiles)
            {
                return;
            }

            visualizer.PaintFloorTiles(FloorPositions);
            WallGenerator.CreateWalls(visualizer, FloorPositions);
            visualizer.ResetScale();
        }

        public void ClearDungeon()
        {
            visualizer.Clear();
        }

        protected abstract void RunProceduralGeneration();

        public Vector2 GetRandomFloorPosition()
        {
            return (Vector2) FloorPositions.ElementAt(Random.Range(0, FloorPositions.Count))
                   * visualizer.ScaleMultiplier;
        }
    }
}
