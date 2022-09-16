using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    [SerializeField] private Vector3 m_SpawnPosition;
    [SerializeField] private float m_SpawnInterval;

    private PlatformPool _pool;

    private void Awake()
    {
        _pool = gameObject.GetComponent<PlatformPool>();
    }

    void Start()
    {
        StartCoroutine(PlatformSpawnRoutine());
    }

    private IEnumerator PlatformSpawnRoutine()
    {
        while (true)
        {
            var newPlatform = _pool.GetPlatformFromPool();
            newPlatform.transform.position = m_SpawnPosition;
            newPlatform.transform.parent = gameObject.transform;
            newPlatform.GetComponent<PlatformMover>().StartMoving();

            yield return new WaitForSeconds(m_SpawnInterval);
        }
    }

    public void OnPlatformReachedEnd(GameObject platform)
    {
        _pool.ReturnPlatformToPool(platform);
    }
}
