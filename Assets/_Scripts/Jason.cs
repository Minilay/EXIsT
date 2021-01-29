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
    public bool Active;
    public bool platformMode;

    private SpriteRenderer spr;
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        Active = false;

        spr = GetComponentInChildren<SpriteRenderer>();
    }

    void Movement()
    {
        dir = new Vector2(
            Input.GetAxisRaw("Horizontal") * speed,
            Input.GetAxisRaw("Vertical") * speed
            );

        if (dir.x > 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        if (dir.x < 0)
        {
            transform.localScale = Vector3.one;
        }

        rigid.velocity = dir;
    }
    // Update is called once per frame
    void Update()
    {
        if(!platformMode)
        {
            Movement();
        }
        else
        {
            rigid.velocity = Vector3.zero;
        }
        //Activating the ghost
        if(Input.GetButtonDown("Jump"))
        {
            Active = true;
        }
        if(Input.GetButtonUp("Jump"))
        {
            Active = false;
        }

        //Platform Mode
        spr.enabled = platformMode ? false : true;

    }
}
