using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;

public class EnemySpawner : BaseSpawnPatterns
{
    public static EnemySpawner instance;

    private int stage = 1;
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
                SpawnHorizontalGroup(enemies[1], 10);
            }

            if (stage == 2)
            {
                SpawnVerticalGroup(enemies[2], 4);
                SpawnVerticalGroup(enemies[3], 4);

                //meteorite
                SpawnRandom(enemies[4], 1, 10);
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
