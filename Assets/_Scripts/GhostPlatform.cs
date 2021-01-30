using UnityEngine;

namespace _Scripts
{
    public class GhostPlatform : MonoBehaviour
    {
        [Header("Inspector")]
        public GameObject filled;
        public BoxCollider2D physicalPlatform;
        [Header("Dynamic")]
        private Jason _player;
        [SerializeField]
        private bool _isActive = false;
        private bool _isNull = true;




        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.transform.CompareTag("Player"))
            {
                _player = collision.gameObject.GetComponent<Jason>();
                _isNull = false;
            }
        }
        private void OnTriggerExit2D(Collider2D collision)
        {

            if (collision.transform.CompareTag("Player"))
            {
                _isNull = true;
            }
        }

        private void Update() => OnCheck();
        private void OnCheck()
        {

            if (!_isNull)
            {
                if (_player.active && (!_player.isDashing))
                {
                    filled.SetActive(true);
                    _player.PlatformMode(true);
                    _isActive = true;
                }
            }
            if(_isActive && !_player.active)
            {
                filled.SetActive(false);
                _player.PlatformMode(false);
                _isActive = false;
            }
        }
    }
}
