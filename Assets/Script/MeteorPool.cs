using System.Collections.Generic;
using UnityEngine;

public enum MeteorSize { Large, Small }

public class MeteorPool : MonoBehaviour
{
    public static MeteorPool Instance;
    public GameObject largeMeteorPrefab;
    public GameObject smallMeteorPrefab;

    public int largeCount = 15;
    public int smallCount = 30;

    private Queue<GameObject> largePool = new Queue<GameObject>();
    private Queue<GameObject> smallPool = new Queue<GameObject>();

    void Awake()
    {
        Instance = this;

        Prewarm(largePool, largeMeteorPrefab, largeCount);
        Prewarm(smallPool, smallMeteorPrefab, smallCount);
    }

    // Inicializar pool
    void Prewarm(Queue<GameObject> pool, GameObject prefab, int count)
    {
        for (int i = 0; i < count; i++){
            GameObject obj = Instantiate(prefab);
            obj.SetActive(false);
            pool.Enqueue(obj);
        }
    }

    // 
    public GameObject Get(MeteorSize size)
    {
        Queue<GameObject> pool = GetPool(size);
        GameObject obj;

        if (pool.Count > 0)
            obj = pool.Dequeue();
        else
            obj = Instantiate(GetPrefab(size));

        obj.SetActive(true);
        return obj;
    }

    public void Return(GameObject obj, MeteorSize size)
    {
        obj.SetActive(false);
        GetPool(size).Enqueue(obj);
    }

    Queue<GameObject> GetPool(MeteorSize size)
    {
        return size == MeteorSize.Large ? largePool : smallPool;
    }

    GameObject GetPrefab(MeteorSize size)
    {
        return size == MeteorSize.Large ? largeMeteorPrefab : smallMeteorPrefab;
    }
}