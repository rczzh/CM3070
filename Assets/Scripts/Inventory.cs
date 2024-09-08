using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private List<int> items = new() {};
    private int playerScore = 0;

    public void AddItem(int itemID)
    {
        items.Add(itemID);
        if (itemID == 501)
        {
            Transform twinGuns = this.gameObject.transform.GetChild(2);
            Transform singleGun = this.gameObject.transform.GetChild(1);

            singleGun.gameObject.SetActive(false);
            twinGuns.gameObject.SetActive(true);
        }

        if (itemID == 503)
        {
            Player player = gameObject.GetComponent<Player>();
            player.IncreaseMaxHealth(2);
        }
    }

    public void UpdateInventory(int scoreAmount)
    {
        //Debug.Log("Updating Inventory");
        if (items.Contains(502))
        {
            //Debug.Log("Item 502");
            playerScore += scoreAmount;
            if (playerScore >= 500)
            {
                var leftOverScore = playerScore - 500;
                playerScore = leftOverScore;

                Player player = gameObject.GetComponent<Player>();
                player.IncreaseSpeed(0.4f);
                player.IncreaseShotSpeed(1f);
                player.IncreaseDamage(0.5f);
                player.IncreaseFireRate(0.35f);
            }
        }

        if (items.Contains(503))
        {
            Player player = gameObject.GetComponent<Player>();
            var randomInt = Random.Range(0, 100);
            if (randomInt <= 5)
            {
                player.HealPlayer(1);
            }
        }
    }
}
