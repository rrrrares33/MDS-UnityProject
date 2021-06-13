#pragma warning disable 0649

using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using Random = UnityEngine.Random;

namespace Dungeon
{
    public class TilemapVisualizer : MonoBehaviour
    {
        [SerializeField] private Tilemap floorTilemap;
        [SerializeField] private Tilemap wallTilemap;
        [SerializeField] private List<TileBase> floorTiles;
        [SerializeField] private List<TileBase> wallTop;
        [SerializeField] private List<TileBase> wallLeft;
        [SerializeField] private List<TileBase> wallRight;
        [SerializeField] private List<TileBase> wallBottom;
        [SerializeField] private List<TileBase> wallFull;
        [SerializeField] private List<TileBase> wallInnerCornerDownLeft;
        [SerializeField] private List<TileBase> wallInnerCornerDownRight;
        [SerializeField] private List<TileBase> wallDiagonalCornerDownLeft;
        [SerializeField] private List<TileBase> wallDiagonalCornerDownRight;
        [SerializeField] private List<TileBase> wallDiagonalCornerUpLeft;
        [SerializeField] private List<TileBase> wallDiagonalCornerUpRight;

        public void PaintFloorTiles(IEnumerable<Vector2Int> floorPositions)
        {
            PaintTiles(floorTilemap, floorTiles, floorPositions);
        }

        private static void PaintTiles(
            Tilemap tilemap,
            IReadOnlyList<TileBase> tiles,
            IEnumerable<Vector2Int> positions)
        {
            foreach (var position in positions)
            {
                PaintSingleTile(tilemap, tiles[Random.Range(0, tiles.Count)], position);
            }
        }

        private static void PaintSingleTile(Tilemap tilemap, TileBase tile, Vector2Int position)
        {
            tilemap.SetTile(tilemap.WorldToCell((Vector3Int) position), tile);
        }

        internal void PaintSingleBasicWall(Vector2Int wallPosition, string binaryType)
        {
            var intType = Convert.ToInt32(binaryType, 2);
            TileBase tile = null;
            var tileIsNull = true;
        
            if (WallTypes.WallTop.Contains(intType))
            {
                tile = wallTop[Random.Range(0, wallTop.Count)];
                tileIsNull = false;
            }
            else if (WallTypes.WallLeft.Contains(intType))
            {
                tile = wallLeft[Random.Range(0, wallLeft.Count)];
                tileIsNull = false;
            }
            else if (WallTypes.WallRight.Contains(intType))
            {
                tile = wallRight[Random.Range(0, wallRight.Count)];
                tileIsNull = false;
            }
            else if (WallTypes.WallBottom.Contains(intType))
            {
                tile = wallBottom[Random.Range(0, wallBottom.Count)];
                tileIsNull = false;
            }
            else if (WallTypes.WallFull.Contains(intType))
            {
                tile = wallFull[Random.Range(0, wallFull.Count)];
                tileIsNull = false;
            }

            if (tileIsNull)
            {
                return;
            }

            PaintSingleTile(wallTilemap, tile, wallPosition);
        }

        internal void PaintSingleCornerWall(Vector2Int wallPosition, string binaryType)
        {
            var intType = Convert.ToInt32(binaryType, 2);
            TileBase tile = null;
            var tileIsNull = true;
        
            if (WallTypes.WallInnerCornerDownLeft.Contains(intType))
            {
                tile = wallInnerCornerDownLeft[Random.Range(0, wallInnerCornerDownLeft.Count)];
                tileIsNull = false;
            }
            else if (WallTypes.WallInnerCornerDownRight.Contains(intType))
            {
                tile = wallInnerCornerDownRight[Random.Range(0, wallInnerCornerDownRight.Count)];
                tileIsNull = false;
            }
            else if (WallTypes.WallDiagonalCornerDownLeft.Contains(intType))
            {
                tile = wallDiagonalCornerDownLeft[Random.Range(0, wallDiagonalCornerDownLeft.Count)];
                tileIsNull = false;
            }
            else if (WallTypes.WallDiagonalCornerDownRight.Contains(intType))
            {
                tile = wallDiagonalCornerDownRight[Random.Range(0, wallDiagonalCornerDownRight.Count)];
                tileIsNull = false;
            }
            else if (WallTypes.WallDiagonalCornerUpLeft.Contains(intType))
            {
                tile = wallDiagonalCornerUpLeft[Random.Range(0, wallDiagonalCornerUpLeft.Count)];
                tileIsNull = false;
            }
            else if (WallTypes.WallDiagonalCornerUpRight.Contains(intType))
            {
                tile = wallDiagonalCornerUpRight[Random.Range(0, wallDiagonalCornerUpRight.Count)];
                tileIsNull = false;
            }
            else if (WallTypes.WallFullEightDirections.Contains(intType))
            {
                tile = wallFull[Random.Range(0, wallFull.Count)];
                tileIsNull = false;
            }
            else if (WallTypes.WallBottomEightDirections.Contains(intType))
            {
                tile = wallBottom[Random.Range(0, wallBottom.Count)];
                tileIsNull = false;
            }

            if (tileIsNull)
            {
                return;
            }

            PaintSingleTile(wallTilemap, tile, wallPosition);
        }

        public void Clear()
        {
            floorTilemap.ClearAllTiles();
            wallTilemap.ClearAllTiles();
        }
    }
}
