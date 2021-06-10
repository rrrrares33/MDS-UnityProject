using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Dungeon
{
    public class RoomFirstDungeonGenerator : SimpleRandomWalkDungeonGenerator
    {
        [SerializeField] private int minRoomWidth = 10;
        [SerializeField] private int minRoomHeight = 10;
        [SerializeField] private int dungeonWidth = 70;
        [SerializeField] private int dungeonHeight = 70;
        [SerializeField] [Range(0, 10)] private int offset = 1;
        [SerializeField] private bool useRandomWalk = true;
        [SerializeField] private bool fillDungeonArea = true;

        protected override void RunProceduralGeneration()
        {
            CreateRooms();
        }

        private void CreateRooms()
        {
            var roomList = ProceduralGeneration.BinarySpacePartitioning(
                new BoundsInt
                {
                    position = (Vector3Int) startPosition,
                    size = new Vector3Int(dungeonWidth, dungeonHeight, 0)
                },
                minRoomWidth,
                minRoomHeight,
                fillDungeonArea ? 1 : 0);

            var floorPositions = useRandomWalk ?
                CreateRandomRooms(roomList) :
                CreateSimpleRooms(roomList);
            floorPositions.UnionWith(ConnectRooms(roomList
                .Select(room => (Vector2Int) Vector3Int.RoundToInt(room.center))
                .ToList()));

            visualizer.PaintFloorTiles(floorPositions);
            WallGenerator.CreateWalls(visualizer, floorPositions);
        }

        private HashSet<Vector2Int> CreateSimpleRooms(IEnumerable<BoundsInt> roomList)
        {
            var floorPositions = new HashSet<Vector2Int>();
        
            foreach (var room in roomList)
            {
                for (var x = offset; x < room.size.x - offset; ++x)
                {
                    for (var y = offset; y < room.size.y - offset; ++y)
                    {
                        floorPositions.Add((Vector2Int) room.min + new Vector2Int(x, y));
                    }
                }
            }

            return floorPositions;
        }

        private HashSet<Vector2Int> CreateRandomRooms(IEnumerable<BoundsInt> roomList)
        {
            var floorPositions = new HashSet<Vector2Int>();
        
            foreach (var room in roomList)
            {
                var roomCenter = (Vector2Int) Vector3Int.RoundToInt(room.center);
                var roomFloor = GetRandomWalkPath(roomCenter, simpleRandomWalkData);

                foreach (var position in roomFloor)
                {
                    if (room.xMin + offset <= position.x && position.x <= room.xMax - offset &&
                        room.yMin + offset <= position.y && position.y <= room.yMax - offset)
                    {
                        floorPositions.Add(position);
                    }
                }
            }

            return floorPositions;
        }

        private static IEnumerable<Vector2Int> ConnectRooms(IList<Vector2Int> roomCenters)
        {
            var corridors = new HashSet<Vector2Int>();
            var currentRoomCenter = roomCenters[Random.Range(0, roomCenters.Count - 1)];
        
            roomCenters.Remove(currentRoomCenter);
            while (roomCenters.Count > 0)
            {
                var closestCenter = FindClosestPointTo(currentRoomCenter, roomCenters);
                roomCenters.Remove(closestCenter);
            
                var newCorridor = CreateCorridor(currentRoomCenter, closestCenter);
                currentRoomCenter = closestCenter;
                corridors.UnionWith(newCorridor);
            }

            return corridors;
        }

        private static Vector2Int FindClosestPointTo(Vector2Int currentRoomCenter, IEnumerable<Vector2Int> roomCenters)
        {
            var closestCenter = Vector2Int.zero;
            var length = float.MaxValue;

            foreach (var center in roomCenters)
            {
                var currentDistance = Vector2.Distance(center, currentRoomCenter);
                if (currentDistance >= length)
                {
                    continue;
                }
            
                length = currentDistance;
                closestCenter = center;
            }

            return closestCenter;
        }

        private static IEnumerable<Vector2Int> CreateCorridor(Vector2Int currentRoomCenter, Vector2Int destination)
        {
            var corridor = new HashSet<Vector2Int>
            {
                currentRoomCenter
            };
            var position = currentRoomCenter;

            while (position.y != destination.y)
            {
                position += position.y < destination.y ? Vector2Int.up : Vector2Int.down;
                corridor.Add(position);
            }

            while (position.x != destination.x)
            {
                position += position.x < destination.x ? Vector2Int.right : Vector2Int.left;
                corridor.Add(position);
            }

            return corridor;
        }
    }
}
