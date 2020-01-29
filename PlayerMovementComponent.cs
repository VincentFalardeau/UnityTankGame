using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerMovementComponent : MonoBehaviour
{
    public KeyCode[] movementKeys;
    public GameObject[] delimiters;

    //Les tranformations se feront selon le temps reel
    public float movementSpeed = 1f;
    public float turnSpeed = 1f;

    private float minX, maxX, minZ, maxZ;
    private float prevX, prevY;

    private Action[] commands;

    private void Start()
    {
        if (delimiters.Length > 1)
        {
            // Limites en X:
            if (delimiters[0].transform.position.x > delimiters[1].transform.position.x)
            {
                maxX = delimiters[0].transform.position.x;
                minX = delimiters[1].transform.position.x;
            }
            else
            {
                maxX = delimiters[1].transform.position.x;
                minX = delimiters[0].transform.position.x;
            }

            // Limites en Z:
            if (delimiters[0].transform.position.z > delimiters[1].transform.position.z)
            {
                maxZ = delimiters[0].transform.position.z;
                minZ = delimiters[1].transform.position.z;
            }
            else
            {
                maxZ = delimiters[1].transform.position.z;
                minZ = delimiters[0].transform.position.z;
            }
        }
    }

    private void Awake()
    {
        CreateCommands();
        Debug.Assert(movementKeys.Length == commands.Length);
    }

    private void Update()
    {
        for (int i = 0; i < movementKeys.Length; i++)
        {
            if (Input.GetKey(movementKeys[i]))
                commands[i].Invoke();
        }
    }

    private void CreateCommands()
    {
        //0 : foward
        //1 : left
        //2 : backward
        //3 : right
        commands = new Action[]
        {
            () => Advance(movementSpeed),
            () => Turn(-turnSpeed),
            () => Advance(-movementSpeed),
            () => Turn(turnSpeed)
        };
    }

    private void Advance(float amount)
    {
        prevX = transform.position.x;
        prevY = transform.position.y;
        transform.Translate(Vector3.forward * amount * Time.deltaTime);
        if (transform.position.x > maxX || transform.position.x < minX || transform.position.z > maxZ || transform.position.z < minZ)
        {
            transform.Translate(Vector3.forward * -amount * Time.deltaTime);
        }
    }

    private void Turn(float amount)
    {
        transform.Rotate(Vector3.up * amount * Time.deltaTime);
    }
}
