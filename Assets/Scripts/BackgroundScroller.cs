using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
    [SerializeField] private float scrollSpeed = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(-scrollSpeed * Time.deltaTime, 0);

        if (transform.position.x < -10)
        {
            transform.position = new Vector3(30, transform.position.y);
        }
    }
}
