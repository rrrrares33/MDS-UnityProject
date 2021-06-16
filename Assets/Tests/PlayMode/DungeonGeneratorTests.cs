using System.Collections;
using System.Linq;
using Data.SimpleRandomWalk;
using Dungeon;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests.PlayMode
{
    public class DungeonGeneratorTests
    {
        [UnityTest]
        public IEnumerator SimpleRandomWalkFloorIsNotIsolated()
        {
            Assert.AreEqual(true, EveryFloorTileHasNeighbours<SimpleRandomWalkDungeonGenerator>());
            yield break;
        }
        
        [UnityTest]
        public IEnumerator CorridorFirstFloorIsNotIsolated()
        {
            Assert.AreEqual(true, EveryFloorTileHasNeighbours<CorridorFirstDungeonGenerator>());
            yield break;
        }
        
        [UnityTest]
        public IEnumerator RoomFirstFloorIsNotIsolated()
        {
            Assert.AreEqual(true, EveryFloorTileHasNeighbours<RoomFirstDungeonGenerator>());
            yield break;
        }

        private static bool EveryFloorTileHasNeighbours<TGenerator>()
            where TGenerator : SimpleRandomWalkDungeonGenerator
        {
            var simpleRandomWalkData = ScriptableObject.CreateInstance<SimpleRandomWalkData>();
            simpleRandomWalkData.Iterations = 1000;
            simpleRandomWalkData.WalkLength = 1000;
            simpleRandomWalkData.StartEachIterationRandomly = true;
            
            var generator = new GameObject().AddComponent<TGenerator>();
            generator.SetSimpleRandomWalkData(simpleRandomWalkData);
            generator.GenerateDungeon(false);

            return generator.FloorPositions.Select(floorPosition =>
                Direction2D.CardinalDirectionList.Any(direction =>
                    generator.FloorPositions.Contains(floorPosition + direction)))
                .All(hasNeighbours => hasNeighbours);
        }
    }
}
