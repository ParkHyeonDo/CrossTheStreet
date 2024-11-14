using System.Collections;
using System.Collections.Generic;
using UnityEditor.Search;
using UnityEngine;
using static ObjectPool;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool Instance;
    
    [System.Serializable]
    public class Pool
    {
        public string Name;
        public GameObject Prefab;
        public int Size;
    }

    public List<Pool> Pools = new List<Pool>();
    public Dictionary<string, Queue<GameObject>> PoolDict;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(this);

        PoolDict = new Dictionary<string, Queue<GameObject>>();
    }

    public void CreatePools()
    {
        foreach (var pool in Pools)
        {
            Queue<GameObject> queue = new Queue<GameObject>();
            for (int i = 0; i < pool.Size; i++)
            {
                GameObject obj = Instantiate(pool.Prefab, transform);
                obj.SetActive(false);
                queue.Enqueue(obj);
                
            }
            PoolDict.Add(pool.Name, queue);
        }
    }
        

    public GameObject SpawnFromPool(string name)
    {
      
        if (!PoolDict.ContainsKey(name)) 
        {
            return null;
        }

        Queue<GameObject> queue = PoolDict[name];
        int QueueCount = queue.Count;

        for (int i = 0; i < QueueCount; i++)
        {
            GameObject obj = queue.Dequeue();

            if (!obj.activeInHierarchy)
            {
                obj.SetActive(true);
                queue.Enqueue(obj);
                return obj; 
            }

            queue.Enqueue(obj);
        }

        return null;
    }


}
