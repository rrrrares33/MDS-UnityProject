#pragma warning disable 0649

using System.Collections.Generic;
using System.Linq;
using Data.SimpleRandomWalk;
using UnityEngine;

namespace Dungeon
{
    public class SimpleRandomWalkDungeonGenerator : DungeonGenerator
    {
        [SerializeField] protected SimpleRandomWalkData simpleRandomWalkData;

        protected override void RunProceduralGeneration()
        {
            var floorPositions = GetRandomWalkPath(startPosition, simpleRandomWalkData);
            visualizer.PaintFloorTiles(floorPositions);
            WallGenerator.CreateWalls(visualizer, floorPositions);
        }

        protected static ICollection<Vector2Int> GetRandomWalkPath(
            Vector2Int position,
            SimpleRandomWalkData simpleRandomWalkParams)
        {
            var floorPositions = new HashSet<Vector2Int>();
            var currentPosition = position;
        
            for (var _ = 0; _ < simpleRandomWalkParams.Iterations; ++_)
            {
                floorPositions.UnionWith(
                    ProceduralGeneration.SimpleRandomWalk(currentPosition, simpleRandomWalkParams.WalkLength)
                );
            
                if (simpleRandomWalkParams.StartEachIterationRandomly)
                {
                    currentPosition = floorPositions.ElementAt(Random.Range(0, floorPositions.Count));
                }
            }

            return floorPositions;
        }
    }
}
