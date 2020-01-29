using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(TeamComponent))]
public class DestroyOnTouchComponent : MonoBehaviour
{
    private Vector3 initialPosition;
    public GameObject SpawnOnDestroy;
    
    private void OnCollisionEnter(Collision collision)
    {
        destruction(collision);
    }

    private void OnCollisionStay(Collision collision)
    {
        destruction(collision);
    }

    private void OnCollisionExit(Collision collision)
    {
        destruction(collision);
    }

    [System.Obsolete]
    private void destruction(Collision collision)
    {
        if (collision.gameObject.GetComponent<TeamComponent>() != null && collision.gameObject.GetComponent<TeamComponent>().team != gameObject.GetComponent<TeamComponent>().team)
        {
            //Debug.Log("tank de "+ gameObject.GetComponent<TeamComponent>().team + " meurt");
            Destroy(collision.gameObject);
            if(SpawnOnDestroy != null)
            {
                Instantiate(SpawnOnDestroy, transform.position, transform.rotation);
                Destroy(gameObject, SpawnOnDestroy.GetComponent<ParticleSystem>().duration);
            }
            Destroy(gameObject);
        }
        else if (collision.gameObject.GetComponent<Terrain>() != null)
        {
            //ICI, il faut compter
            Destroy(gameObject);
        }
    }


    private void Start()
    {
        initialPosition = transform.position;
    }
}
