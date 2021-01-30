using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodedReplacement: MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject explodedVersion;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.CompareTag("Player"))
        {
            if(collision.gameObject.GetComponent<Jason>().isDash)
            {
                Replacement();
            }
        }
    }
    void Replacement()
    {
        GameObject go = Instantiate<GameObject>(explodedVersion);
        go.transform.position = transform.position;
        Destroy(gameObject);
    }
}
