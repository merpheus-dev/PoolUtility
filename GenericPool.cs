using System;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Subtegral.PoolUtility
{
    public class GenericPool<T> where T : PoolableObject
    {
        private Queue<T> pool;
        private readonly int _size;
        private readonly T _bluePrint;
        private static Transform _runtimeObjectHolder;

        public GenericPool(T obj, int size = 5)
        {
            pool = new Queue<T>();
            this._size = Mathf.Max(size, 2);
            _bluePrint = obj;
            InstantiateRuntimePoolContainer();
            PopulatePool();
        }

        private void InstantiateRuntimePoolContainer()
        {
            if (_runtimeObjectHolder == null)
                _runtimeObjectHolder = new GameObject("Pool").transform;
        }

        private void PopulatePool()
        {
            for (var i = 0; i < _size; i++)
            {
                var instance = Object.Instantiate(_bluePrint, _runtimeObjectHolder, true);
                instance.OnWarmUp();
                pool.Enqueue(instance);
            }
        }

        public T GetPoolType()
        {
            return _bluePrint;
        }

        public T Spawn(SpawnDataContainer container)
        {
            if (pool.Count < 2)
                PopulatePool();

            var dequeued = pool.Dequeue();
            dequeued.OnSpawn(container);
            return dequeued;
        }

        public void Despawn(T obj)
        {
            pool.Enqueue(obj);
            obj.OnDespawn();
        }
    }
}