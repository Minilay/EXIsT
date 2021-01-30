using UnityEngine;

namespace _Scripts
{
    public class ExplodedReplacement: MonoBehaviour
    {
        public GameObject explodedVersion;

        private void OnCollisionEnter2D(Collision2D collision)
        {

            if(collision.transform.CompareTag("Player"))
            {
                if(collision.gameObject.GetComponent<Jason>().isShifting)
                {
                    Replacement();
                }
            }
        }
        void Replacement()
        {
            GameObject go = Instantiate(explodedVersion);
            go.transform.position = transform.position;
            Destroy(gameObject);
        }
    }
}
