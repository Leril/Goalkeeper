using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMover : MonoBehaviour
{
    [SerializeField] internal float m_MoveSpeed = 1;
    void Start()
    {
        StartCoroutine("PlatformMove");
    }

    private IEnumerator PlatformMove()
    {
        while (transform.position.z > -10f)
        {
            transform.Translate(Vector3.back*m_MoveSpeed*Time.deltaTime);
            yield return null;
        }
        Destroy(gameObject);
    }
}
