using RunnerGame;
using UnityEngine;
using UnityEngine.Events;

namespace Events
{
    public class GameEventListener : MonoBehaviour
    {
        public GameEvent Event;
        public UnityEvent Response;
        public UnityEvent<float, float> ResponseFloats;
        public UnityEvent<GameState> ResponseGameState;

        private void OnEnable()
        {
            Event.RegisterListener(this);
        }

        private void OnDisable()
        {
            Event.UnregisterListener(this);
        }

        public void OnEventRaised()
        {
            Response.Invoke();
        }

        public void OnEventFloatsRaised(float firstValue, float secondValue)
        {
            ResponseFloats.Invoke(firstValue, secondValue);
        }

        public void OnEventGameStateRaised(GameState gameState)
        {
            ResponseGameState.Invoke(gameState);
        }
    }
}