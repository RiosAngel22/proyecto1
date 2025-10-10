using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private GameObject[] objectPool;
    [SerializeField] private int poolsize = 5;

    private List<GameObject> pooledObjects;

    public int Poolsize { get => poolsize;}

    private void Start()
    {
        pooledObjects = new List<GameObject>();

        for (int i = 0; i < poolsize; i++) {
            //si nuestra piscina tiene mas de un solo objeto, usamos un index random, si es uno solo el index no sera problema
            int r = Random.Range(0, objectPool.Length);
            GameObject obj = Instantiate(objectPool[r]);
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
