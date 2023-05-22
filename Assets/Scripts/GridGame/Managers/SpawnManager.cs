using GridGame.Tiles;
using UnityEngine;

namespace GridGame.Managers
{
    public class SpawnManager : MonoBehaviour
    {
        [SerializeField] private int gridWidth;
        [SerializeField] private int gridHeight;
        [SerializeField] private Tile tilePrefab;
        [SerializeField] private Transform cam;

        private Tile[,] tiles;

        private void Start()
        {
            GenerateGrid();
        }

        //TODO: Call that function from GameManager
        internal void GenerateGrid()
        {
            tiles = new Tile[gridWidth, gridWidth];
            
            for (var x = 0; x < gridWidth; x++)
            {
                for (var y = 0; y < gridHeight; y++)
                {
                    Tile spawnTile = Instantiate(tilePrefab, new Vector3(x + 0.1f * x, y + 0.1f * y),
                        Quaternion.identity);
                    spawnTile.name = $"Tile{x}{y}";
                    spawnTile.SetTilePosition(x, y);
                    tiles[x, y] = spawnTile;
                }
            }

            MatchManager.Instance.SetTileMatrix(tiles);
            int camZPosition = gridWidth >= gridHeight ? gridWidth : gridHeight;
            cam.position = new Vector3(gridWidth / 2f - 0.5f, gridHeight / 2f - 0.5f, camZPosition * -2f);
        }
    }
}