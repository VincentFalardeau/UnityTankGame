using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ObjectSpawnerComponent : MonoBehaviour
{
    public Transform ExitPoint;
    public GameObject ObjectToSpawn;
    public float SpawnTime;
    public int minX, maxX;
    private Vector3 previousPosition;
    private float elapsedTime;
    private System.Random random;
    

    public void Start()
    {
        random = new System.Random();
        elapsedTime = 0;
    }

    void Update()
    {
        elapsedTime += Time.deltaTime;
        if (elapsedTime > SpawnTime)
        {
            Spawn();
            elapsedTime = 0;
        }
            

        previousPosition = transform.position;
    }

    private void Spawn()
    {
        GameObject newObject = Instantiate(ObjectToSpawn, new Vector3(0, ExitPoint.position.y, ExitPoint.position.z) + new Vector3((float)random.Next(minX, maxX),0,0), transform.rotation);
    }
}
