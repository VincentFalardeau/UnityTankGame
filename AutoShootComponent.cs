using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoShootComponent : MonoBehaviour
{
    public Transform ExitPoint;
    public KeyCode shootKey;
    public GameObject projectileToShoot;
    public int shootTime;
    private float elapsedTime;

    private Vector3 previousPosition;

    void Update()
    {
        elapsedTime += Time.deltaTime;
        if (elapsedTime > shootTime)
        {
            Shoot();
            elapsedTime = 0;
        }
           
            
        previousPosition = transform.position;
    }

    private void Shoot()
    {
        var projectile = Instantiate(projectileToShoot, ExitPoint.position + new Vector3(0, 0, 20), transform.rotation);
        projectile.GetComponentInChildren<ProjectieMovementComponent>().displacementPerSecond += (transform.position - previousPosition).magnitude / Time.deltaTime;
    }
}
