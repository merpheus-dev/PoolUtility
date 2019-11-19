using UnityEngine;

namespace Subtegral.PoolUtility
{
    public abstract class PoolableObject : MonoBehaviour
    {
        public abstract void OnWarmUp();
        public abstract void OnSpawn(SpawnDataContainer container);
        public abstract void OnDespawn();
    }
}