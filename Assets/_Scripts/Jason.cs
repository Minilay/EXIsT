using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jason : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("Inspector")]
    public float speed;
    public float shiftTime;
    public float dashForce;
    public float startDashTime;

    [Header("Dynamic")]
    public Rigidbody2D rigid;
    public Vector2 dir;
    public bool Active;
    public bool platformMode;
    public bool isShifting;
    private float currentDashTime;
    
    private SpriteRenderer spr;
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        Active = false;

        spr = GetComponentInChildren<SpriteRenderer>();
        isShifting = false;
    }

    void Movement()
    {
        dir = new Vector2(
            Input.GetAxisRaw("Horizontal"),
            Input.GetAxisRaw("Vertical") 
            ) * speed;

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
        if(!platformMode && !isShifting)
        {
            Movement();
        }
        else
        {
            rigid.velocity = Vector3.zero;
        }
        //Activating the ghost
        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            isShifting = true;
            currentDashTime = startDashTime;
            rigid.velocity = Vector2.zero;
        }    
        if(Input.GetButtonDown("Jump"))
        {
            Active = true;
        }
        if(Input.GetButtonUp("Jump"))
        {
            Active = false;
        }
        if(isShifting)
        {
            rigid.velocity = dir.normalized * dashForce;
            currentDashTime -= Time.deltaTime;

            if(currentDashTime < 0)
            {
                isShifting = false;
            }
        }

        //Platform Mode
        spr.enabled = platformMode ? false : true;

    }
}
