using UnityEngine;

namespace RunnerGame.Collectables
{
    public class StarCollectable : CollectableBase
    {
        public override void OnCollect()
        {
            Debug.Log("StarCollectable collected");
        }

        public override void OnSpawnParticle(Transform position)
        {
            if (destroyParticle != null)
            {
                Instantiate(destroyParticle, position.position, Quaternion.identity);
            }
        }
    }
}