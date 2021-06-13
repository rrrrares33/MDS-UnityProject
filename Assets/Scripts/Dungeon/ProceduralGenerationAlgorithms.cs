using System.Collections.Generic;
using UnityEngine;

namespace Dungeon
{
    public static class ProceduralGeneration
    {
        public static IEnumerable<Vector2Int> SimpleRandomWalk(Vector2Int startPosition, int walkLength)
        {
            var path = new HashSet<Vector2Int>
            {
                startPosition
            };
            var currentPosition = startPosition;

            for (var _ = 0; _ < walkLength; ++_)
            {
                currentPosition += Direction2D.GetRandomCardinalDirection();
                path.Add(currentPosition);
            }

            return path;
        }

        public static List<Vector2Int> RandomWalkCorridor(Vector2Int startPosition, int corridorLength)
        {
            var corridor = new List<Vector2Int>
            {
                startPosition
            };
            var currentPosition = startPosition;
            var direction = Direction2D.GetRandomCardinalDirection();
        
            for (var _ = 0; _ < corridorLength; ++_)
            {
                currentPosition += direction;
                corridor.Add(currentPosition);
            }

            return corridor;
        }

        public static ICollection<BoundsInt> BinarySpacePartitioning(
            BoundsInt spaceToSplit,
            int minWidth,
            int minHeight,
            int minLengthMultiplier)
        {
            var roomQueue = new Queue<BoundsInt>();
            var roomList = new List<BoundsInt>();
        
            roomQueue.Enqueue(spaceToSplit);
            while (roomQueue.Count > 0)
            {
                var room = roomQueue.Dequeue();
                if (room.size.x < minWidth || room.size.y < minHeight)
                {
                    continue;
                }
            
                if (Random.value < 0.5f)
                {
                    if (room.size.y >= minHeight * 2)
                    {
                        Split(false, roomQueue, room, minLengthMultiplier * minWidth);
                    }
                    else if (room.size.x >= minWidth * 2)
                    {
                        Split(true, roomQueue, room, minLengthMultiplier * minHeight);
                    }
                    else
                    {
                        roomList.Add(room);
                    }
                }
                else
                {
                    if (room.size.x >= minWidth * 2)
                    {
                        Split(true, roomQueue, room, minLengthMultiplier * minHeight);
                    }
                    else if (room.size.y >= minHeight * 2)
                    {
                        Split(false, roomQueue, room, minLengthMultiplier * minWidth);
                    }
                    else
                    {
                        roomList.Add(room);
                    }
                }
            }

            return roomList;
        }

        private static void Split(bool vertical, Queue<BoundsInt> roomQueue, BoundsInt room, int minLength)
        {
            var split = Random.Range(
                Mathf.Max(minLength, 1),
                (vertical ? room.size.x : room.size.y) - minLength);
        
            roomQueue.Enqueue(new BoundsInt
            {
                position = room.min,
                size = new Vector3Int(
                    vertical ? split : room.size.x,
                    vertical ? room.size.y : split,
                    room.size.z)
            });
            roomQueue.Enqueue(new BoundsInt
            {
                position = new Vector3Int(
                    room.min.x + (vertical ? split : 0),
                    room.min.y + (vertical ? 0 : split),
                    room.min.z),
                size = new Vector3Int(
                    room.size.x - (vertical ? split : 0),
                    room.size.y - (vertical ? 0 : split),
                    room.size.z)
            });
        }
    }

    public static class Direction2D
    {
        public static readonly Vector2Int Right = new Vector2Int(1, 0);
        public static readonly Vector2Int Up = new Vector2Int(0, 1);
        public static readonly Vector2Int Left = new Vector2Int(-1, 0);
        public static readonly Vector2Int Down = new Vector2Int(0, -1);
    
        public static readonly List<Vector2Int> CardinalDirectionList = new List<Vector2Int>
        {
            Right,
            Up,
            Left,
            Down
        };
        public static readonly List<Vector2Int> DiagonalDirectionList = new List<Vector2Int>
        {
            Up + Right,
            Up + Left,
            Down + Left,
            Down + Right
        };
        public static readonly List<Vector2Int> TotalDirectionList = new List<Vector2Int>
        {
            Right,
            Up + Right,
            Up,
            Up + Left,
            Left,
            Down + Left,
            Down,
            Down + Right
        };

        public static Vector2Int GetRandomCardinalDirection()
        {
            return CardinalDirectionList[Random.Range(0, CardinalDirectionList.Count)];
        }
    }
}
