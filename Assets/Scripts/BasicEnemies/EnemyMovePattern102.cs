using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovePattern102 : MonoBehaviour
{
    float originY;

    public float movementSpeed = 5;
    public float amp = 1, freq = 1;
    public bool inverted = false;

    // Start is called before the first frame update
    void Start()
    {
        originY = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        Vector2 pos = transform.position;

        float sin = Mathf.Sin(pos.x * freq) * amp;

        if (inverted)
        {
            sin *= -1;
        }

        pos.x -= movementSpeed * Time.fixedDeltaTime;
        pos.y = sin + originY;

        if (pos.x <= -1)
        {
            Destroy(gameObject);
        }

        transform.position = pos;
    }
}
