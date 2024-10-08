using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;

public class EnemySpawner2 : BaseSpawnPatterns
{
    public static EnemySpawner2 instance;

    [SerializeField] private int stage = 1;
    [SerializeField] private List<GameObject> enemies = new();
    [SerializeField] private List<GameObject> elites = new();

    [SerializeField] private float timeInterval = 2;
    [SerializeField] private float timeIntervalTimer = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Awake()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        timeIntervalTimer += Time.deltaTime;

        if (timeIntervalTimer >= timeInterval)
        {

            if (stage == 1)
            {
                SpawnRandom(enemies[0], 10, 5);
            }

            if (stage == 2)
            {
                SpawnRandom(enemies[2], 4, 10);
                SpawnTwoLanes(enemies[1], 3, 8);

                //spawn meteorite
                SpawnRandom(enemies[3], 1, 10);
            }

            if (stage == 3)
            {
                SpawnBoss(elites[0]);
            }

            stage++;
            timeIntervalTimer = 0;
        }
    }
}
