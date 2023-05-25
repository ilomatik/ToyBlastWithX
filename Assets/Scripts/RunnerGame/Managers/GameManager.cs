using UnityEngine;

namespace RunnerGame.Managers
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private UIManager uiManager;
        [SerializeField] private WaySpawnManager waySpawnManager;

        private void Start()
        {
            SetGameState(GameState.Start);
            waySpawnManager.SpawnWayPart();
        }

        public void SetGameState(GameState gameState)
        {
            uiManager.SetGameUI(gameState);
        }
    }
}