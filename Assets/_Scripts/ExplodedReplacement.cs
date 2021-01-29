using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodedReplacement: MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject explodedVersion;


    void Replacement()
    {
        GameObject go = Instantiate<GameObject>(explodedVersion);
        go.transform.position = transform.position;
        Destroy(gameObject);
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            Replacement();
        }
    }
}
