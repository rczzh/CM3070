using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    public bool trackingPlayer = false;

    GameObject playerTarget;
    Vector2 direction;

    // Start is called before the first frame update
    void Start()
    {
        playerTarget = GameObject.FindWithTag("Player");
        direction = playerTarget.transform.position - transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerTarget != null && trackingPlayer)
        {
            direction = playerTarget.transform.position - transform.position;
            transform.rotation = Quaternion.FromToRotation(-Vector3.right, direction);
        }
    }
}
