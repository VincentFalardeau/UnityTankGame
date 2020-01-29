using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnTerrainCollision : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Terrain>() != null)
        {
            Destroy(gameObject);
        }
    }
}
