using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Viscosity : MonoBehaviour
{

    public bool _Is_Attracting = true;

    public GameObject attractedTo;

    public float strengthOfAttraction = 5.0f;
    public float _Mass;

    public Rigidbody rigidBody;


    private void Start()
    {
        rigidBody.mass = _Mass;
    }

    void Update()
    {
        if (_Is_Attracting == true)
        {
            Vector3 direction = attractedTo.transform.position - transform.position;
            rigidBody.AddForce(strengthOfAttraction * direction);
        }
    }

    public void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Player"))
        {
            _Is_Attracting = false;
        }

    }

}
