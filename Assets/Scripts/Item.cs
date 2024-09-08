using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public int itemID;
    public string itemName;
    public string itemDescription;
    public int itemWeight;

    public bool increaseSpeed;
    public bool increaseDamage;
    public bool increaseFireRate;
    public bool increaseShotSpeed;
    public bool healPlayer;

    public float increaseSpeedValue;
    public float increaseDamageValue;
    public float increaseFireRateValue;
    public float increaseShotSpeedValue;

    private void FixedUpdate()
    {
        //item moves towards player slowly
        int movementSpeed = 1;

        Vector2 pos = transform.position;
        pos.x -= movementSpeed * Time.fixedDeltaTime;
        transform.position = pos;

        if (pos.x < -1)
        {
            Destroy(gameObject);
        }
    }
}
