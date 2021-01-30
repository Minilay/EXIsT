using System.Collections.Generic;
using UnityEngine;

namespace _Scripts
{
    public class Explosion : MonoBehaviour
    {
        public float force;
        public List<Rigidbody2D> pieces;
        private void Awake()
        {
            foreach(Rigidbody2D go in pieces)
            {
                go.AddExplosionForce(force, transform.position,0.1f);
            }

            Destroy(this.gameObject, 2f);
        }
    }
}
