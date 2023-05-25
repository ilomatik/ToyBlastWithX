using UnityEngine;

namespace RunnerGame.Collectables
{
    public abstract class CollectableBase : ScriptableObject
    {
        public int amount;
        public GameObject destroyParticle;

        public abstract void OnCollect();
        public abstract void OnSpawnParticle(Transform position);
    }
}