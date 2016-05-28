using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using PathologicalGames;

public enum ObjectType
{
    UI_CHARACTER = 1,
    CHARACTER = 2,

    UI_SLIDER = 3,
    UI_ITEM = 4
}

[System.Serializable]
public class ObjectConfig
{
    public ObjectType _type;
    public GameObject _object;
}

public class ManagerObject : MonoSingleton<ManagerObject>
{
    public List<ObjectConfig> listObjectConfig;
    public Dictionary<ObjectType, GameObject> dicListObject;

    void Awake()
    {
        InitDictionary();
    }

    public void InitDictionary()
    {
        dicListObject = new Dictionary<ObjectType, GameObject>();

        foreach (ObjectConfig var in listObjectConfig)
        {
            dicListObject.Add(var._type, var._object);
        }
    }

    public GameObject GetObjectByType(ObjectType type)
    {
        if (dicListObject.ContainsKey(type))
        {
            return dicListObject[type];
        }
#if UNITY_EDITOR
        Debug.Log("khong co trong list !!");
#endif
        return null;
    }

    public GameObject SpawnObjectByType(ObjectType type)
    {
        GameObject objSpawn = GetObjectByType(type);
        SpawnPool pool = PoolManager.Pools["Object"];
        if (pool != null && objSpawn != null)
        {
            return pool.Spawn(objSpawn).gameObject;
        }
#if UNITY_EDITOR
        Debug.Log("khong spawn duoc!");
#endif
        return null;
    }

    public GameObject SpawnObjectByType(ObjectType type, Transform parent)
    {
        GameObject objSpawn = GetObjectByType(type);
        SpawnPool pool = PoolManager.Pools["Object"];
        if (pool != null && objSpawn != null)
        {
            return pool.Spawn(objSpawn, parent).gameObject;
        }
#if UNITY_EDITOR
        Debug.Log("khong spawn duoc!");
#endif
        return null;
    }

    public void DespawnObject(GameObject obj, string poolName)
    {
        if (PoolManager.Pools.ContainsKey(poolName))
        {
            SpawnPool pool = PoolManager.Pools[poolName];
            if (pool.IsSpawned(obj.transform))
            {
                pool.Despawn(obj.transform);
            }
        }
        else
        {
#if UNITY_EDITOR
            Debug.Log(poolName + "khong co trong pool");
#endif
        }
    }

    public void DespawnAllObject(string poolName)
    {
        if (PoolManager.Pools.ContainsKey(poolName))
        {
            SpawnPool pool = PoolManager.Pools[poolName];
            pool.DespawnAll();
        }
        else
        {
#if UNITY_EDITOR
            Debug.Log(poolName + "khong co trong pool");
#endif
        }
    }
}
