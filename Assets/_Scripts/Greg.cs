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
        dir = speed;
        rigid = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        rigid.velocity = new Vector2(dir, rigid.velocity.y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.CompareTag("Obstacle"))
        {
            StartCoroutine(changeDir());
        }
    }
    private IEnumerator changeDir()
    {
        rigid.velocity = Vector2.zero;
        Debug.Log("Start");
        yield return new WaitForSeconds(1);
        Debug.Log("changed");
        dir = -dir;
    }
}
