using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Smoke : MonoBehaviour
{

    public float _Force_X;
    public float _Force_Y;
    public float _Force_Z;

    public Rigidbody _Rdb;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        _Rdb.velocity = new Vector3(_Force_X, _Force_Y, _Force_Z);

        if(_Rdb.velocity.x != _Force_X || _Rdb.velocity.y != _Force_Y || _Rdb.velocity.z != _Force_Z)
        {
            _Rdb.velocity = new Vector3(_Force_X, _Force_Y, _Force_Z);
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Box"))
        {

            int _Side = Random.Range(1, 9);

            switch (_Side)
            {
                case 1:
                    Random_X();
                    break;
                case 2:
                    Random_Y();
                    break;
                case 3:
                    Random_Z();
                    break;
                case 4:
                    Random_Y();
                    break;
                case 5:
                    Random_X();
                    break;
                case 6:
                    Random_Z();
                    break;
                case 7:
                    Random_Z();
                    break;
                case 8:
                    Random_Y();
                    break;
                case 9:
                    Random_X();
                    break;
            }

        }

        if (collision.gameObject.CompareTag("Smoke_Particle"))
        {

            int _Side = Random.Range(1, 9);

            switch (_Side)
            {
                case 1:
                    Random_X();
                    break;
                case 2:
                    Random_Y();
                    break;
                case 3:
                    Random_Z();
                    break;
                case 4:
                    Random_Y();
                    break;
                case 5:
                    Random_X();
                    break;
                case 6:
                    Random_Z();
                    break;
                case 7:
                    Random_Z();
                    break;
                case 8:
                    Random_Y();
                    break;
                case 9:
                    Random_X();
                    break;
            }

        }
    }

    void Random_X()
    {
        if (_Force_X > 0)
        {
            _Force_X = -_Force_X;
        }
        else
        {
            _Force_X = _Force_X * -1;
        }
    }

    void Random_Y()
    {
        if (_Force_Y > 0)
        {
            _Force_Y = -_Force_Y;
        }
        else
        {
            _Force_Y = _Force_Y * -1;
        }
    }

    void Random_Z()
    {
        if (_Force_Z > 0)
        {
            _Force_Z = -_Force_Z;
        }
        else
        {
            _Force_Z = _Force_Z * -1;
        }
    }

    public void Add_Force(float Value)
    {

        if (_Force_X > 0)
        {
            _Force_X += Value;
        }
        else
        {
            _Force_X -= Value;
        }

        if (_Force_Y > 0)
        {
            _Force_Y += Value;
        }
        else
        {
            _Force_Y -= Value;
        }

        if (_Force_Z > 0)
        {
            _Force_Z += Value;
        }
        else
        {
            _Force_Z -= Value;
        }

    }

    public void Remove_Force(float Value)
    {

        if (_Force_X > 0)
        {
            _Force_X -= Value;
        }
        else
        {
            _Force_X += Value;
        }

        if (_Force_Y > 0)
        {
            _Force_Y -= Value;
        }
        else
        {
            _Force_Y += Value;
        }

        if (_Force_Z > 0)
        {
            _Force_Z -= Value;
        }
        else
        {
            _Force_Z += Value;
        }

    }

}
