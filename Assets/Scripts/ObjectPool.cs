using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool<T> where T : MonoBehaviour
{
    private List<T> pooledObjects;
    private T prefab;

    public ObjectPool(T prefab, int defaultSize)
    {
        pooledObjects = new List<T>(defaultSize);
        this.prefab = prefab;
        for (int i = 0; i < defaultSize; i++)
        {
            T pooledObject = MonoBehaviour.Instantiate(prefab);
            pooledObject.gameObject.SetActive(false);
            pooledObjects.Add(pooledObject);
        }
    }

    public T GetPooledObject()
    {
        for (int i = 0; i < pooledObjects.Count; i++)
        {
            if (pooledObjects[i].gameObject.activeInHierarchy == false)
            {
                pooledObjects[i].gameObject.SetActive(true);
                return pooledObjects[i];
            }
        }

        T pooledObject = MonoBehaviour.Instantiate(prefab);
        pooledObject.gameObject.SetActive(true);
        pooledObjects.Add(pooledObject);
        return pooledObject;
    }
}
