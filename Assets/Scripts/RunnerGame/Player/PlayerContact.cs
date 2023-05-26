using Events;
using UnityEngine;

namespace RunnerGame.Player
{
    public class PlayerContact : MonoBehaviour
    {
        [SerializeField] private GameEvent onGameStateChange;
        
        private void OnCollisionEnter(Collision collision)
        {
            if (collision.transform.CompareTag("Sea"))
            {
                onGameStateChange.RaiseGameState(GameState.GameOver);
            }
            else if (collision.transform.CompareTag("Finish"))
            {
                onGameStateChange.RaiseGameState(GameState.Won);
            }
        }
    }
}