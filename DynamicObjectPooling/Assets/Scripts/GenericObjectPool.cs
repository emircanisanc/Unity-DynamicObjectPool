using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GenericObjectPool : MonoBehaviour
{
    [SerializeField] protected GenericPoolItem prefab;
    [SerializeField] protected Queue<GenericPoolItem> pool;
    [SerializeField] protected int poolLimit;

    void Awake()
    {
        pool = new Queue<GenericPoolItem>();
    }


    # region SpawnObject
    protected GenericPoolItem SpawnObject()
    {
        if(pool.Count > 0)
        {
            var obj = pool.Dequeue();
            obj.transform.position = transform.position;
            obj.EnableObject();
            return obj;
        }
        else
        {
            var obj = Instantiate(prefab.gameObject, transform.position, prefab.transform.rotation).GetComponent<GenericPoolItem>();
            obj._OnItemDestroyed = GetBackToPool;
            return obj;
        }
    }
    protected GenericPoolItem SpawnObject(Vector3 position)
    {
        if(pool.Count > 0)
        {
            var obj = pool.Dequeue();
            obj.transform.position = position;
            obj.EnableObject();
            return obj;
        }
        else
        {
            var obj = Instantiate(prefab.gameObject, position, prefab.transform.rotation).GetComponent<GenericPoolItem>();
            obj._OnItemDestroyed = GetBackToPool;
            return obj;
        }
    }
    protected GenericPoolItem SpawnObject(Vector3 position, Quaternion rotation)
    {
        if(pool.Count > 0)
        {
            var obj = pool.Dequeue();
            obj.transform.position = position;
            obj.EnableObject();
            return obj;
        }
        else
        {
            var obj = Instantiate(prefab.gameObject, position, rotation).GetComponent<GenericPoolItem>();
            obj._OnItemDestroyed = GetBackToPool;
            return obj;
        }
    }
    # endregion

    
    public void GetBackToPool(GenericPoolItem obj)
    {
        if(poolLimit <= pool.Count)
        {
            DestroyImmediate(obj.gameObject);
        }
        else
        {
            obj.DisableObject();
            obj.transform.position = transform.position;
            pool.Enqueue(obj);
        }
        
    }

}
