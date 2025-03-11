using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exploder : MonoBehaviour
{
    [SerializeField] private float _force;
    [SerializeField] private float _radius;

    public void Explode(List<Rigidbody> rigidbodies)
    {
        foreach (Rigidbody rigidbody in rigidbodies)
        {
            rigidbody.AddExplosionForce(_force, rigidbody.transform.position, _radius);
        }
    }

    

}
