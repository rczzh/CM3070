using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float bulletSpeed = 1f;
    private Vector2 spawnPoint;
    float timer = 0f;

    // Start is called before the first frame update
    void Start()
    {
        spawnPoint = new Vector2(transform.position.x, transform.position.y);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        transform.position = Movement(timer);

        if (transform.position.x <= -1 || transform.position.x >= 20)
        {
            Destroy(this.gameObject);
        }

        if (transform.position.y >= 12 || transform.position.y <= -2)
        {
            Destroy(this.gameObject);
        }
    }

    private Vector2 Movement(float timer)
    {
        float x = timer * bulletSpeed * -transform.right.x;
        float y = timer * bulletSpeed * -transform.right.y;
        return new Vector2(x + spawnPoint.x, y + spawnPoint.y);
    }
}
