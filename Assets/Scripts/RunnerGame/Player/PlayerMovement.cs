using DG.Tweening;
using UnityEngine;

namespace RunnerGame.Player
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private Transform playerStartPoint;
        
        private bool isMoving;

        private void FixedUpdate()
        {
            if (!isMoving) return;
            
            transform.Translate(Vector3.forward * Time.deltaTime);
        }

        public void OnGameStart(GameState gameState)
        {
            transform.position = playerStartPoint.position;
            isMoving = gameState == GameState.Play;
        }

        public void SetPlayerXPosition(Vector3 position)
        {
            transform.DOMoveX(position.x, 0.1f).SetEase(Ease.Linear);
        }
    }
}