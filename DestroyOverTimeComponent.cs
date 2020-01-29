using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOverTimeComponent : MonoBehaviour
{
    public float destroyTime;
    private float elapsedTime;

    void Update()
    {
        elapsedTime += Time.deltaTime;
        if (elapsedTime > destroyTime)
            Destroy(gameObject);
    }
}
