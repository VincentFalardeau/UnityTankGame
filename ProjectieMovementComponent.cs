using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectieMovementComponent : MonoBehaviour
{
    public float displacementPerSecond = 3000f;
    private void Update() =>
        transform.Translate(Vector3.forward * displacementPerSecond * Time.deltaTime);
}
