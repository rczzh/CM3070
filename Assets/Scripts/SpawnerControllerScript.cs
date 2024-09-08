using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class SpawnerControllerScript : MonoBehaviour
{
    public int currentLevel = 0;
    public GameObject[] spawners;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(spawners[0]);
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void NextLevel()
    {
        currentLevel++;
        if (currentLevel < 3)
        {
            Debug.Log(currentLevel);
            Instantiate(spawners[currentLevel]);
        }
    }
}
