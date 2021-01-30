using UnityEngine;

namespace _Scripts
{
    public class CamFollow : MonoBehaviour
    {
        [Header("Inspector")]
        [SerializeField] private Transform pointOfInterest;
        [SerializeField] private Vector2 offset;
    
        [Range(0,1)]
        public float followRatio;
        private Vector2 _tmp;
    
        private void FixedUpdate()
        {
            _tmp = (pointOfInterest.position - transform.position) * followRatio + transform.position;
            transform.position = new Vector3(_tmp.x + offset.x, _tmp.y + offset.y, -1);
        }
    }
}
