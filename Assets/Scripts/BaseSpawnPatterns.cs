using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseSpawnPatterns : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnRandom(GameObject enemy, int numbOfEnemies, float distance)
    {
        List<int> yValues = new() { 2, 3, 4, 5, 6, 7, 8 };
 
        for (int i = 0; i < numbOfEnemies; i++)
        {
            int yIndex = Random.Range(0, yValues.Count);
            int yValue = yValues[yIndex];

            Instantiate(enemy, new Vector2(20 + (i* distance), yValue), Quaternion.identity);

        }
    }

    public void SpawnHorizontalGroup(GameObject enemy, int numbOfEnemies)
    {
        List<int> yValues = new() { 2, 4, 6, 8 };

        for (int j = 0; j < 2; j++)
        {
            int index = Random.Range(0, yValues.Count);
            int yValue = yValues[index];

            for (int i = 0; i < numbOfEnemies; i++)
            {
                //spawns the enemy 20 units away. Off screen.
                Instantiate(enemy, new Vector2(20 + i * 5, yValue), Quaternion.identity);
            }

            //yValues.Remove(yValue);
        }
    }

    public void SpawnVerticalGroup(GameObject enemy, int numbOfEnemies)
    {
        List<int> yValues = new() { 2, 4, 6, 8 };

        for (int i = 0; i < 4; i++)
        {
            int index = Random.Range(0, yValues.Count);
            int yValue = yValues[index];

            Instantiate(enemy, new Vector2(20 + (i * 5), yValue), Quaternion.identity);

            yValues.Remove(yValue);
        }
    }

    public void SpawnTwoLanes(GameObject enemy, int numberOfEnemies, float distance)
    {
        List<int> yValues = new() { 2, 7 };

        for (int i = 0; i < numberOfEnemies; i++)
        {
            int index = Random.Range(0, yValues.Count);
            int yValue = yValues[index];

            Instantiate(enemy, new Vector2(20 + (i * distance), yValue), Quaternion.identity);
        }
    }

    public void SpawnBoss(GameObject enemy)
    {
        Instantiate(enemy, new Vector2(25, 5), Quaternion.identity);
    }
}
