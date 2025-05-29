using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectibles : MonoBehaviour
{
    [SerializeField] protected int value;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Collect();
        }
    }

    protected virtual void Collect()
    {
        Destroy(gameObject);
    }
}
