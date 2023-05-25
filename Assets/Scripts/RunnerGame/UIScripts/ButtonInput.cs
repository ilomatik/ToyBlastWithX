using Events;
using UnityEngine;

namespace RunnerGame
{
    public class ButtonInput : MonoBehaviour
    {
        [SerializeField] private GameEvent onStopCurrentWayPart;

        public void StopCurrentWayPart()
        {
            onStopCurrentWayPart.Raise();
        }
    }
}