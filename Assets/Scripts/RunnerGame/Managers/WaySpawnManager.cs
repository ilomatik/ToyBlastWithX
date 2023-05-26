using System.Collections.Generic;
using Events;
using RunnerGame.WayParts;
using UnityEngine;

namespace RunnerGame.Managers
{
    public class WaySpawnManager : MonoBehaviour
    {
        [SerializeField] private GameObject wayPart;
        [SerializeField] private GameObject emptyWayPart;
        [SerializeField] private float tolerance;
        [SerializeField] private GameEvent onSpawnWayPart;
        [SerializeField] private GameEvent onAlmostPerfectSnap;
        [SerializeField] private int levelWayAmount;
        

        public List<GameObject> wayParts = new List<GameObject>();

        private GameObject currentWayPart;
        private GameObject lastWayPart;
        private int defaultWayPartCount;
        private int perfectSnapCounter;

        private void OnEnable()
        {
            defaultWayPartCount = wayParts.Count;
        }

        private void SpawnWayPart()
        {
            if (wayParts.Count > levelWayAmount - 1) return;
            
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
                spawnedWayPart.GetComponent<WayPartMovement>().SetPreviousWayPart(lastWayPart);
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
                return;
            }

            if (hangover >= tolerance)
            {
                onAlmostPerfectSnap.RaiseFloat(0.05f * perfectSnapCounter);
                perfectSnapCounter++;
            }
            else
            {
                perfectSnapCounter = 0;
            }

            float newXPosition = (-hangover / 2f)  + lastWayPart.transform.position.x * direction;
            Vector3 position = currentWayPart.transform.position;
            var newPos = new Vector3(newXPosition, position.y, position.z);

            onSpawnWayPart.RaisePosition(newPos);

            Vector3 localScale = currentWayPart.transform.localScale;
            localScale = new Vector3(newXSize, localScale.y, localScale.z);
            currentWayPart.transform.localScale = localScale;
            position = newPos;
            currentWayPart.transform.position = position;

            float partEdge = position.x + (fallingPartSize * -direction);
            float fallingPartXPosition = partEdge + newXSize * -direction;

            SpawnFallingPart(fallingPartXPosition, position.z, fallingPartSize);
            currentWayPart = null;

            SpawnWayPart();
        }

        private void SpawnFallingPart(float positionX, float positionZ, float scaleX)
        {
            GameObject part = Instantiate(emptyWayPart);
            Vector3 emptyWayPartScale = emptyWayPart.transform.localScale;
            
            part.transform.localScale = new Vector3(scaleX, emptyWayPartScale.y,emptyWayPartScale.z);
            part.transform.position = new Vector3(positionX, transform.position.y, positionZ);
            
            Destroy(part, 2f);
        }

        public void OnGameStart(GameState gameState)
        {
            if (gameState != GameState.Play) return;

            int temp = wayParts.Count;
            for (int i = defaultWayPartCount - 1; i < temp; i++)
            {
                Destroy(wayParts[defaultWayPartCount - 1]);
                wayParts.RemoveAt(defaultWayPartCount - 1);
            }

            SpawnWayPart();
        }
    }
}