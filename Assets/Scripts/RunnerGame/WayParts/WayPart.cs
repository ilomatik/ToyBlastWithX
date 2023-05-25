using UnityEngine;

namespace RunnerGame.WayParts
{
    public class WayPart : MonoBehaviour
    {
        private void OnEnable()
        {
            GetComponent<MeshRenderer>().material.color = GetRandomColor();
        }

        private Color GetRandomColor()
        {
            return new Color(Random.Range(0, 1f), Random.Range(0, 1f), Random.Range(0, 1f));
        }
    }
}