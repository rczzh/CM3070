using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovePattern103 : MonoBehaviour
{
    public float movementSpeed = 100;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        gameObject.transform.Rotate(0f, 0f, movementSpeed * Time.deltaTime);
    }
}
