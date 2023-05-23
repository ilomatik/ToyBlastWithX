using System.Collections.Generic;
using UnityEngine;

namespace RunnerGame.Managers
{
    public class WaySpawnManager : MonoBehaviour
    {
        [SerializeField] private GameObject wayPart;

        public List<GameObject> wayParts = new List<GameObject>();

        [ContextMenu("SpawnWayPart")]
        public void SpawnWayPart()
        {
            GameObject spawnedWayPart = Instantiate(wayPart, new Vector3(wayParts.Count, 0f, 0f), Quaternion.identity);
            spawnedWayPart.name = $"WayPart{wayParts.Count}";
            
            if (wayParts.Count > 0)
            {
                spawnedWayPart.transform.localScale = wayParts[wayParts.Count - 1].transform.localScale;
            }

            wayParts.Add(spawnedWayPart);
        }
    }
}