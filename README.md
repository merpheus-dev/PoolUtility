# Pool Utility

Pooling Utility is a simple and powerful pooling system for Unity.
It is generic, so any object that implements base classes can be pooled easily.

## Usage
1) Inherit your monobehaviour object from *PoolableObject* class.

```C#
public class MyAwesomeEnemy:PoolableObject
{
    //Logic
}
```
2) Inherit a data container from *SpawnDataContainer* for injecting data to your Monobehaviour class.
```C#
public class EnemySpawnData:SpawnDataContainer
{
    public Vector3 SpawnPosition;
}
```

3) Use *PoolManager* to pool your object.

```C#
[SerializeField] private MyAwesomeEnemy prefab;

private void Start()
{
    PoolManager.GetInstance().GenerateNewPool(prefab);
}
```

Then you can spawn/despawn your prefab clones from the pool as follows:
```C#
//Request spawn
var spawnedObject = PoolManager.RequestSpawnForType(prefab,dataContainer);

//Request despawn
PoolManager.DespawnObject(prefab, spawnedObject);
```
