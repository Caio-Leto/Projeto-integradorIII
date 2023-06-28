using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vazao : MonoBehaviour
{


    public bool _Is_Grounded;

    Rigidbody _Rdb;

    public float _Speed_Z;

    public Vector3 _Initial_Pos = new Vector3();

    // Start is called before the first frame update
    void Start()
    {
        _Rdb = GetComponent<Rigidbody>();
        _Initial_Pos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (_Is_Grounded == true)
        {
            _Rdb.velocity = new Vector3(_Rdb.velocity.x, _Rdb.velocity.y, _Speed_Z);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            _Is_Grounded = true;
        }

    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Filter_Limit"))
        {
            Invoke("Repos_Particles", 1);
        }

    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            _Is_Grounded = false;
        }
    }

    void Repos_Particles()
    {
        transform.position = _Initial_Pos;
        _Rdb.velocity = new Vector3(0,0,0);
    }

}
