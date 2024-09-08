using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropTable : MonoBehaviour
{
    public GameObject[] items;
    private int totalItemWeight;
    private int itemIndex;

    Item item;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < items.Length; i++)
        {
            item = items[i].GetComponent<Item>();
            totalItemWeight += item.itemWeight;
        }

        int randomNum = Random.Range(0, totalItemWeight);
        int processedWeight = 0;

        for (int i = 0; i < items.Length; i++)
        {
            item = items[i].GetComponent<Item>();
            processedWeight += item.itemWeight;

            if (processedWeight >= randomNum)
            {
                itemIndex = i;
                break;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void dropItem()
    {
        Instantiate(items[itemIndex], transform.position, Quaternion.identity);
    }

    public void dropHeart()
    {
        var randomInt = Random.Range(0, 100);
        if (randomInt <= 5)
        {
            Instantiate(items[itemIndex], transform.position, Quaternion.identity);
        }
    }
}
