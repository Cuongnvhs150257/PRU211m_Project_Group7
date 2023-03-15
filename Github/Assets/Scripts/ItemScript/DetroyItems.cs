using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetroyItems : MonoBehaviour
{
    public ItemEffect itemEffect;

    void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            itemEffect.Activate(collision.gameObject);
        }
    }
}
