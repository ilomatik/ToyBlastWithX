using System;
using System.Collections.Generic;
using GridGame.Tiles;
using UnityEngine;

namespace GridGame.Managers
{
    public class MatchManager : MonoBehaviour
    {
        public static MatchManager Instance;
        
        private static Tile[,] tileMatrix;
        public List<Tile> tileNeighbours;

        private void Awake()
        {
            Instance = this;
        }

        public static void SetTileMatrix(Tile[,] tiles)
        {
            tileMatrix = tiles;
        }

        public void CheckMatch(Tile tile)
        {
            tileNeighbours = new List<Tile>();
            Vector2Int[] directions = { Vector2Int.down, Vector2Int.left, Vector2Int.up, Vector2Int.right };
            FindNeighbours(tile);
            
            void FindNeighbours(Tile pivotTile)
            {
                if (!tileNeighbours.Contains(pivotTile)) tileNeighbours.Add(pivotTile);
                
                pivotTile.SetIsChecked(true);
                
                foreach (Vector2Int direction in directions)
                {
                    int tempX = pivotTile.GetTileXPosition() + direction.x;
                    int tempY = pivotTile.GetTileYPosition() + direction.y;

                    if (tempX < 0 || tempY < 0 || tempX >= tileMatrix.GetLength(0) || tempY >= tileMatrix.GetLength(1))
                    {
                        continue;
                    }

                    Tile tempTile = tileMatrix[tempX, tempY];

                    if (tempTile == null) continue;
                    if (tileNeighbours.Contains(tempTile)) continue;
                    if (!tempTile.IsMatchable()) continue;
                    
                    tileNeighbours.Add(tempTile);
                    tileMatrix[tempX, tempY].SetIsChecked(true);
                    FindNeighbours(tempTile);
                }
            }

            if (tileNeighbours.Count >= 3)
            {
                foreach (Tile tileNeighbour in tileNeighbours)
                {
                    tileNeighbour.ToggleImage();
                }
            }
        }
    }
}