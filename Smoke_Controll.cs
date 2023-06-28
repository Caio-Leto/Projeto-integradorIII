using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Smoke_Controll : MonoBehaviour
{

    public List<GameObject> _Inactive_Particles = new List<GameObject>();
    public List<GameObject> _Active_Particles = new List<GameObject>();
    public List<Smoke> _Inactive_Smoke_Scripts = new List<Smoke>();

    public float _Multiplier_X;
    public float _Multiplier_Y;
    public float _Multiplier_Z;

    public int _Particle_Counter;

    // Start is called before the first frame update
    void Start()
    {
        Show_Particle();
    }

    public void Show_Particle()
    {

        if (_Inactive_Particles.Count > 0)
        {
            _Inactive_Particles[0].SetActive(true);
            _Active_Particles.Add(_Inactive_Particles[0]);
            _Inactive_Smoke_Scripts[0]._Force_X = Random.Range(0, 5);
            _Inactive_Smoke_Scripts[0]._Force_Y = Random.Range(0, 5);
            _Inactive_Smoke_Scripts[0]._Force_Z = Random.Range(0, 5);
            _Inactive_Smoke_Scripts[0]._Force_X += _Multiplier_X;
            _Inactive_Smoke_Scripts[0]._Force_Y += _Multiplier_Y;
            _Inactive_Smoke_Scripts[0]._Force_Z += _Multiplier_Z;
            _Inactive_Particles.Remove(_Inactive_Particles[0]);
            _Inactive_Smoke_Scripts.Remove(_Inactive_Smoke_Scripts[0]);

            _Multiplier_X = _Multiplier_X + _Particle_Counter / 4;
            _Multiplier_Y = _Multiplier_Y + _Particle_Counter / 4;
            _Multiplier_Z = _Multiplier_Z + _Particle_Counter / 4;

            _Particle_Counter++;
            Show_Particle();
        }

    }

}
