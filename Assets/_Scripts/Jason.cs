using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jason : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("Inspector")]
    public float speed;
    [Header("Dynamic")]
    public Rigidbody2D rigid;
    public Vector2 dir;
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        dir = new Vector2(
            Input.GetAxisRaw("Horizontal") * speed ,
            Input.GetAxisRaw("Vertical") * speed 
            );

        if(dir.x > 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        if(dir.x < 0)
        {
            transform.localScale = Vector3.one;
        }

        rigid.velocity = dir;
       
    }
}
