using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Dungeon
{
    public static class WallGenerator
    {
        public static void CreateWalls(TilemapVisualizer visualizer, ICollection<Vector2Int> floorPositions)
        {
            CreateBasicWalls(
                visualizer,
                FindWallsIn(floorPositions, Direction2D.CardinalDirectionList),
                floorPositions);
            CreateCornerWalls(
                visualizer,
                FindWallsIn(floorPositions, Direction2D.DiagonalDirectionList),
                floorPositions);
        }

        private static IEnumerable<Vector2Int> FindWallsIn(
            ICollection<Vector2Int> floorPositions,
            IReadOnlyCollection<Vector2Int> directions) 
        {
            var wallPositions = new HashSet<Vector2Int>();
        
            foreach (var position in floorPositions)
            {
                foreach (var direction in directions)
                {
                    var neighbourPosition = position + direction;
                    if (!floorPositions.Contains(neighbourPosition))
                    {
                        wallPositions.Add(neighbourPosition);
                    }
                }
            }

            return wallPositions;
        }

        private static void CreateBasicWalls(
            TilemapVisualizer visualizer,
            IEnumerable<Vector2Int> wallPositions,
            ICollection<Vector2Int> floorPositions)
        {
            foreach (var position in wallPositions)
            {
                visualizer.PaintSingleBasicWall(
                    position, 
                    Direction2D.CardinalDirectionList
                        .Aggregate(
                            "", 
                            (current, direction) => 
                                current + (floorPositions.Contains(position + direction) ? "1" : "0")));
            }
        }

        private static void CreateCornerWalls(
            TilemapVisualizer visualizer,
            IEnumerable<Vector2Int> wallPositions,
            ICollection<Vector2Int> floorPositions)
        {
            foreach (var position in wallPositions)
            {
                visualizer.PaintSingleCornerWall(
                    position,
                    Direction2D.TotalDirectionList
                        .Aggregate(
                            "",
                            (current, direction) =>
                                current + (floorPositions.Contains(position + direction) ? "1" : "0")));
            }
        }
    }
}
