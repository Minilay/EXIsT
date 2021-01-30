using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostPlatform : MonoBehaviour
{
    [Header("Inspector")]
    public GameObject empty;
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
    private void Update()
    {
        if (player != null)
        {
            active = player.Active && (!player.isShifting);
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
