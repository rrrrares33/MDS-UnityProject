using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Dungeon
{
    public class CorridorFirstDungeonGenerator : SimpleRandomWalkDungeonGenerator
    {
        [SerializeField] private int corridorLength = 10;
        [SerializeField] private int corridorCount = 5;
        [SerializeField] [Range(0.1f, 1.0f)] private float roomPercent = 0.8f;

        protected override void RunProceduralGeneration()
        {
            GenerateCorridorFirst();
        }

        private void GenerateCorridorFirst()
        {
            var floorPositions = new HashSet<Vector2Int>();
            var possibleRoomPositions = new HashSet<Vector2Int>();
        
            CreateCorridors(floorPositions, possibleRoomPositions);
            
            var roomFloors = CreateRooms(possibleRoomPositions);
            CreateRoomsAtDeadEnds(roomFloors, FindDeadEnds(floorPositions));
            floorPositions.UnionWith(roomFloors);
        
            visualizer.PaintFloorTiles(floorPositions);
            WallGenerator.CreateWalls(visualizer, floorPositions);
        }

        private void CreateCorridors(ISet<Vector2Int> floorPositions, ISet<Vector2Int> possibleRoomPositions)
        {
            possibleRoomPositions.Add(startPosition);
            var currentPosition = startPosition;

            for (var _ = 0; _ < corridorCount; ++_)
            {
                var corridor = ProceduralGeneration.RandomWalkCorridor(currentPosition, corridorLength);
                floorPositions.UnionWith(corridor);
                currentPosition = corridor[corridor.Count - 1];
                possibleRoomPositions.Add(currentPosition);
            }
        }

        private static IEnumerable<Vector2Int> FindDeadEnds(ICollection<Vector2Int> floorPositions)
        {
            return
                from position in floorPositions
                where Direction2D.CardinalDirectionList
                    .Count(direction => floorPositions.Contains(position + direction)) == 1
                select position;
        }

        private ISet<Vector2Int> CreateRooms(ICollection<Vector2Int> possibleRoomPositions)
        {
            var roomPositions = new HashSet<Vector2Int>();
            var roomsToCreateCount = Mathf.RoundToInt(possibleRoomPositions.Count * roomPercent);

            var roomsToCreate = possibleRoomPositions
                .OrderBy(_ => Guid.NewGuid())
                .Take(roomsToCreateCount)
                .ToList();
            foreach (var roomPosition in roomsToCreate)
            {
                roomPositions.UnionWith(GetRandomWalkPath(roomPosition, simpleRandomWalkData));
            }

            return roomPositions;
        }

        private void CreateRoomsAtDeadEnds(ISet<Vector2Int> roomFloors, IEnumerable<Vector2Int> deadEnds)
        {
            foreach (var position in deadEnds)
            {
                if (!roomFloors.Contains(position))
                {
                    roomFloors.UnionWith(GetRandomWalkPath(position, simpleRandomWalkData));
                }
            }
        }
    }
}
