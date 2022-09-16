using UnityEngine;
using UnityEngine.Pool;

public class PlatformPool : MonoBehaviour
{
    [SerializeField] private GameObject m_PlatformPrefab;
    [SerializeField] private int m_DefaultPoolCapacity = 10;
    [SerializeField] private int m_MaximumPoolCapacity = 1000;
    private ObjectPool<GameObject> _pool;

    private void Awake()
    {
        _pool = new ObjectPool<GameObject>(CreatePlatformForPool, 
            OnGetPlatformFromPool,
            OnReleasePlatformToPool,
            OnDestroyPlatformFromPool,
            defaultCapacity: m_DefaultPoolCapacity,
            maxSize: m_MaximumPoolCapacity);
    }

    public GameObject GetPlatformFromPool()
    {
        return _pool.Get();
    }

    public void ReturnPlatformToPool(GameObject platform)
    {
        _pool.Release(platform);
    }

    private GameObject CreatePlatformForPool()
    {
        return Instantiate(m_PlatformPrefab);
    }

    private void OnGetPlatformFromPool(GameObject platform)
    {
        platform.SetActive(true);
    }

    private void OnReleasePlatformToPool(GameObject platform)
    {
        platform.SetActive(false);
    }

    private void OnDestroyPlatformFromPool(GameObject platform)
    {
        Destroy(platform);
    }
}
