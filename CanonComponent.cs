using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanonComponent : MonoBehaviour
{
    public Transform ExitPoint;
    public KeyCode shootKey;
    public GameObject projectileToShoot;

    private Vector3 previousPosition;

    void Update()
    {
        if (Input.GetKeyUp(shootKey))
            Shoot();
        previousPosition = transform.position;
    }

    private void Shoot()
    {
        var projectile = Instantiate(projectileToShoot, ExitPoint.position, transform.rotation);
        projectile.GetComponentInChildren<ProjectieMovementComponent>().displacementPerSecond += (transform.position - previousPosition).magnitude / Time.deltaTime;
    }
}
