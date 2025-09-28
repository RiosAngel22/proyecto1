using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private GameObject objectPool;
    [SerializeField] private int poolsize = 5;

    private List<GameObject> pooledObjects;

    private void Start()
    {
        pooledObjects = new List<GameObject>();

        for (int i = 0; i < poolsize; i++) {
            GameObject obj = Instantiate(objectPool);
            obj.SetActive(false);
            pooledObjects.Add(obj);

        }
    }

    public GameObject GetPooledObjects()
    {
        foreach (GameObject obj in pooledObjects)
        {
            if (!obj.activeInHierarchy)
            {
                return obj;
            }
        }
        return null;
    }
}
