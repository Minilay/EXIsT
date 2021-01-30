using UnityEngine;

namespace _Scripts
{
    public class GhostPlatform : MonoBehaviour
    {
        [Header("Inspector")]
        public GameObject filled;
        public BoxCollider2D physicalPlatform;
        [Header("Dynamic")]
        public bool active;
        public Jason player;

        private void Start()
        {
            active = false;
            player = null;
        }
    
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if(collision.transform.CompareTag("Player"))
            {
                player = collision.gameObject.GetComponent<Jason>();
            }
        }
        private void OnTriggerExit2D(Collider2D collision)
        {

            if(collision.transform.CompareTag("Player"))
            {
                player = null;
            }
        }
        private void Update() => OnCheck();

        private void OnCheck()
        {
            if (player != null)
            {
                active = player.active && (!player.isShifting);
            }

            if(player != null)
            {
                if (active)
                {
                    filled.SetActive(true);
                    player.platformMode = true;
                }
                else
                {
                    filled.SetActive(false);
                    player.platformMode = false;
                }
            }
        }
    }
}
