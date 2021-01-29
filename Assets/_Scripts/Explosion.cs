using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    // Start is called before the first frame update
    public float force;
    public List<Rigidbody2D> pieces;
    private void Awake()
    {
        foreach(Rigidbody2D go in pieces)
        {
            go.AddExplosionForce(force, transform.position);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
