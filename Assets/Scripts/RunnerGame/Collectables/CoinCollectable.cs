using UnityEngine;

namespace RunnerGame.Collectables
{
    public class CoinCollectable : CollectableBase
    {
        public override void OnCollect()
        {
            Debug.Log("CoinCollectable collected");
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