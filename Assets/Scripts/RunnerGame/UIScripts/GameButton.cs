using Events;
using UnityEngine;

namespace RunnerGame.UIScripts
{
    public class GameButton : MonoBehaviour
    {
        [SerializeField] private GameEvent onGameStateChange;
        [SerializeField] private GameState nextState;

        public void OnButtonClick()
        {
            onGameStateChange.RaiseGameState(nextState);
        }
    }
}