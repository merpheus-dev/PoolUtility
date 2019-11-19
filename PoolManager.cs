using System.Collections.Generic;
using System.Linq;

namespace Subtegral.PoolUtility
{
    public class PoolManager
    {
        private List<GenericPool<PoolableObject>> pools;

        private static PoolManager _instance;

        public static PoolManager GetInstance()
        {
            if (_instance == null)
            {
                _instance = new PoolManager();
            }
            return _instance;
        }

        public static void GenerateNewPool<T>(T target) where T : PoolableObject
        {
            if (_instance.pools.Any(x => x.GetPoolType() == target))
                throw new System.Exception("This type is already pooled!");
            _instance.pools.Add(new GenericPool<PoolableObject>(target));
        }

        public static T RequestSpawnForType<T>(T targetType, SpawnDataContainer container) where T : PoolableObject
        {
            return _instance.pools.Find(x => x.GetPoolType() == targetType).Spawn(container) as T;
        }

        public static void DespawnObject<T>(T targetType,T instance) where T : PoolableObject
        {
            _instance.pools.Find(x=>x.GetPoolType()==targetType).Despawn(instance);
        }

        private PoolManager()
        {
            pools = new List<GenericPool<PoolableObject>>();
        }
    }
}