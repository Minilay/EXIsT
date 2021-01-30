using System;
using UnityEngine;

namespace _Scripts
{
    public class Parallax : MonoBehaviour
    {
        private float _length, _startPos;
        public Camera cam;
        public float parallaxEffect;
        private void Start()
        {
            _startPos = transform.position.x;
            _length = GetComponent<SpriteRenderer>().bounds.size.x;
        }

        private void FixedUpdate()
        {
            var temp = cam.transform.position.x * (1 - parallaxEffect);
            var dist = (cam.transform.position.x * parallaxEffect);

            transform.position = new Vector3(_startPos + dist, transform.position.y, transform.position.z);

            if (temp > _startPos + _length) _startPos += _length;
            else if (temp < _startPos - _length) _startPos -= _length;
        }
    }
}
