using DG.Tweening;
using UnityEngine;

// There was a problem about player prefab. When I add rigidbody component, it was starting to fly.
// Therefore I used cylinder

namespace RunnerGame.Player
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private Transform playerStartPoint;
        
        private bool isMoving;

        private void Update()
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
            transform.DOMoveX(position.x, 0.2f).SetEase(Ease.Linear);
        }
    }
}