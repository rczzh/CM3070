using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovePattern104 : MonoBehaviour
{
    private Enemy enemyStats;
    private float maxHealth;

    private float leaveSpeed = 15;
    private bool jettison = false;

    // Start is called before the first frame update
    void Start()
    {
        enemyStats = GetComponent<Enemy>();
        maxHealth = enemyStats.enemyHp;
    }

    // Update is called once per frame
    void Update()
    {
        enemyStats = GetComponent<Enemy>();
        float currentEnemyHp = enemyStats.enemyHp;

        if (currentEnemyHp < maxHealth / 5)
        {
            jettison = true;
        }
    }

    private void FixedUpdate()
    {
        if (jettison)
        {
            Vector2 pos = transform.position;
            pos.x -= leaveSpeed * Time.fixedDeltaTime;
            transform.position = pos;
        }
    }
}
