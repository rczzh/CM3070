using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovePattern101 : MonoBehaviour
{
    public float movementSpeed = 1;
    private float leaveSpeed = 15;

    [SerializeField] private bool stationary = false;

    [SerializeField] private float leaveTime = 2;
    [SerializeField] private float leaveTimer = 0;

    // Start is called before the first frame update
    void Start()
    {
        //initialMoveSpd = movementSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        Vector2 pos = transform.position;

        if (pos.x >= 20)
        {
            pos.x -= 3 * Time.fixedDeltaTime;
        }
        else
        {
            pos.x -= movementSpeed * Time.fixedDeltaTime;
        }

        if (stationary) 
        {
            if (pos.x <= 16 && leaveTimer <= leaveTime)
            {
                pos.x = 16;
                movementSpeed = 0;
                leaveTimer += Time.deltaTime;
            }
            
            if (leaveTimer > leaveTime)
            {
                movementSpeed = leaveSpeed;
            }
        }
        
        transform.position = pos;
    }
}
