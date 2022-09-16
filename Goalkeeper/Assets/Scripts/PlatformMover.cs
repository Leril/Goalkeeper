using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMover : MonoBehaviour
{
    [SerializeField] private float m_DestroyPosition;
    [SerializeField] private float m_MoveSpeed = 1;


    public void StartMoving()
    {
        StartCoroutine(PlatformMove());
    }

    private IEnumerator PlatformMove()
    {
        while (transform.position.z > m_DestroyPosition)
        {
            transform.Translate(Vector3.back*m_MoveSpeed*Time.deltaTime);
            yield return null;
        }
        ReturnToPool();
    }

    private void ReturnToPool()
    {
        GetComponentInParent<PlatformSpawner>().OnPlatformReachedEnd(gameObject);
    }
}
