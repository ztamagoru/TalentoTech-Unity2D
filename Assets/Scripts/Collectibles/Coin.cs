using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : Collectibles
{
    private void Start()
    {
        value = 5;
    }

    protected override void Collect()
    {
        Debug.Log($"Coin collected! Value: {value}");
        Destroy(gameObject);
    }
}
