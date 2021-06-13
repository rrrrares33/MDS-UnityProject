using Dungeon;
using NUnit.Framework;
using UnityEngine;

namespace Tests.EditMode
{
    public class Direction2DTests
    {
        [Test]
        public void Right()
        {
            Assert.AreEqual(new Vector2Int(1, 0), Direction2D.Right);
        }

        [Test]
        public void Up()
        {
            Assert.AreEqual(new Vector2Int(0, 1), Direction2D.Up);
        }
        
        [Test]
        public void Left()
        {
            Assert.AreEqual(new Vector2Int(-1, 0), Direction2D.Left);
        }
        
        [Test]
        public void Down()
        {
            Assert.AreEqual(new Vector2Int(0, -1), Direction2D.Down);
        }
        
        [Test]
        public void UpRight()
        {
            Assert.AreEqual(new Vector2Int(1, 1), Direction2D.Up + Direction2D.Right);
        }

        [Test]
        public void UpLeft()
        {
            Assert.AreEqual(new Vector2Int(-1, 1), Direction2D.Up + Direction2D.Left);
        }
        
        [Test]
        public void DownLeft()
        {
            Assert.AreEqual(new Vector2Int(-1, -1), Direction2D.Down + Direction2D.Left);
        }
        
        [Test]
        public void DownRight()
        {
            Assert.AreEqual(new Vector2Int(1, -1), Direction2D.Down + Direction2D.Right);
        }
    }
}
