using System.Collections.Generic;
using Events;
using RunnerGame.WayParts;
using UnityEngine;

namespace RunnerGame.Managers
{
    public class WaySpawnManager : MonoBehaviour
    {
        [SerializeField] private GameObject wayPart;
        [SerializeField] private GameEvent onGameStateChange;

        public List<GameObject> wayParts = new List<GameObject>();

        private GameObject currentWayPart;
        private GameObject lastWayPart;

        public void SpawnWayPart()
        {
            GameObject spawnedWayPart = Instantiate(wayPart,
                new Vector3(wayPart.transform.position.x, wayPart.transform.position.y, wayParts.Count),
                Quaternion.identity);
            spawnedWayPart.name = $"WayPart{wayParts.Count}";

            if (wayParts.Count > 0)
            {
                spawnedWayPart.transform.localScale = wayParts[wayParts.Count - 1].transform.localScale;
            }

            currentWayPart = spawnedWayPart;
            wayParts.Add(spawnedWayPart);

            if (wayParts.Count > 1)
            {
                lastWayPart = wayParts[wayParts.Count - 2];
            }
        }

        public void SnapWayPart(float hangover, float direction)
        {
            if (currentWayPart == null) return;

            Destroy(currentWayPart.GetComponent<WayPartMovement>());
            Destroy(currentWayPart.GetComponent<GameEventListener>());

            float newXSize = currentWayPart.transform.localScale.x - Mathf.Abs(hangover);
            float fallingPartSize = currentWayPart.transform.localScale.x - newXSize;

            if (newXSize < 0)
            {
                onGameStateChange.RaiseGameState(GameState.GameOver);
                return;
            }

            float newXPosition = (-hangover / 2f) + lastWayPart.transform.position.x;
            currentWayPart.transform.localScale = new Vector3(newXSize, currentWayPart.transform.localScale.y,
                currentWayPart.transform.localScale.z);
            currentWayPart.transform.position = new Vector3(newXPosition, currentWayPart.transform.position.y,
                currentWayPart.transform.position.z);

            float partEdge = currentWayPart.transform.position.x + (fallingPartSize * -direction);
            float fallingPartXPosition = partEdge + newXSize * -direction;

            SpawnFallingPart(fallingPartXPosition, currentWayPart.transform.position.z, fallingPartSize);
            currentWayPart = null;

            SpawnWayPart();
        }

        private void SpawnFallingPart(float positionX, float positionZ, float scaleX)
        {
            var part = Instantiate(wayPart.gameObject);
            Destroy(part.GetComponent<WayPartMovement>());
            Destroy(part.GetComponent<GameEventListener>());
            part.transform.localScale = new Vector3(scaleX, transform.localScale.y, transform.localScale.z);
            part.transform.position = new Vector3(positionX, transform.position.y, positionZ);
            part.AddComponent<Rigidbody>().useGravity = true;
            Destroy(part, 1f);
        }
    }
}