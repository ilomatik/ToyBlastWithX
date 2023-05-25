using Events;
using UnityEngine;

namespace RunnerGame.Managers
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private GameEvent onGameStateChange;

        private void Start()
        {
            onGameStateChange.RaiseGameState(GameState.Start);
        }
    }
}