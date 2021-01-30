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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Obstacle"))
        {
            StartCoroutine(changeDir());
        }
    }
    private IEnumerator changeDir()
    {
        float tmp = dir;
        dir = 0;
        yield return new WaitForSeconds(1);
        Debug.Log("changed");
        dir = -tmp;
        transform.localScale = new Vector3(dir, 1, 1);
    }
}
