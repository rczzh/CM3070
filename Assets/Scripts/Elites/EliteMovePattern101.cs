using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EliteMovePattern101 : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 1;

    [SerializeField] private float amp = 1, freq = 1;
    [SerializeField] private bool stationary = false;

    private float initY;
    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        initY = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void FixedUpdate()
    {
        Vector2 pos = transform.position;

        pos.x -= movementSpeed * Time.fixedDeltaTime;

        if (stationary && pos.x <= 15)
        {
            pos.x = 15;
            timer += Time.fixedDeltaTime;

            // move up and down
            transform.position = new Vector2(pos.x, initY + Mathf.Sin(timer * freq) * amp);
        }
        else
        {
            transform.position = pos;
        }
    }
}
