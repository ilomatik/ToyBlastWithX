using UnityEngine;

namespace GridGame.Managers
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private SpawnManager spawnManager;

        private void Start()
        {
            spawnManager.GenerateGrid();
        }
    }
}