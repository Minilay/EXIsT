using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Greg : MonoBehaviour
{
    public float speed;
    public float dir;
    public Rigidbody2D rigid;

    private void Start()
    {
        dir = 1;
        rigid = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        rigid.velocity = new Vector2(dir * speed, rigid.velocity.y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.CompareTag("Obstacle"))
        {
            StartCoroutine(ChangeDir());
        }
    }
    private IEnumerator ChangeDir()
    {
        float tmp = dir;
        dir = 0;
        Debug.Log("Start");
        yield return new WaitForSeconds(1);
        Debug.Log("changed");
        dir = -tmp;
    }
}
