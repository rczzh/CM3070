using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elite201Controller : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 1;

    [SerializeField] private float amp = 1, freq = 1;
    [SerializeField] private bool inPlace = false;

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

        if (pos.x <= 15 && !inPlace)
        {
            inPlace = true;
            pos.x = 15;
        }

        // move up and down
        if (inPlace)
        {
            timer += Time.fixedDeltaTime;
            transform.position = new Vector2(pos.x, initY + Mathf.Sin(timer * freq) * amp);
        }
        else
        {
            pos.x -= movementSpeed * Time.fixedDeltaTime;
            transform.position = pos;
        }
    }
}
