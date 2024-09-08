using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D playerRigidBody;
    private Player playerStats;

    private float speed;
    Vector2 move;
   
    // Start is called before the first frame update
    void Start()
    {
        playerRigidBody = GetComponent<Rigidbody2D>();
        playerStats = GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        speed = playerStats.playerSpeed;
        move = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
    }

    private void FixedUpdate()
    {
        playerRigidBody.AddForce((speed * 1000) * Time.deltaTime * move);

        // setting boundaries to stop player from leaving the scene
        Vector2 pos = transform.position;

        if (pos.x <= 1f)
        {
            pos.x = 1f;
        }

        if (pos.x >= 16.75f)
        {
            pos.x = 16.75f;
        }

        if (pos.y <= 1.5f)
        {
            pos.y = 1.5f;
        }

        if (pos.y >= 8.5)
        {
            pos.y = 8.5f;
        }

        transform.position = pos;
    }
}
