using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class MoveFowardComponent : MonoBehaviour
{
    private Rigidbody rigidbody;
    public float power = 30;
    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
        Debug.Assert(rigidbody != null);
    }

    //addForce prend en prarmetre un vector3 qui indique quelle force appliquer sur le corps solide
    //* utilise l'espace absolu
    private void Start()
    {
        rigidbody.AddForce(power * transform.forward);
    }

}
