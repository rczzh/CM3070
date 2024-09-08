using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject spawnController;

    public float playerHealth = 3;
    public int playerMaxHealth = 3;

    public float playerSpeed = 30.0f;
    public float playerDamage = 3.5f;
    public float playerShotSpeed = 5;
    public float playerFireRate = 3.5f;

    public float playerIFramesDuration = 0.5f;
    public float playerIFrameTimer = 0;
    public bool playerIsInvincible = false;

    public AudioSource src;
    public AudioClip sfx;

    public GameObject itemDescription;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(spawnController);
    }

    // Update is called once per frame
    void Update()
    {
        if (playerIsInvincible == true)
        {
            playerIFrameTimer += Time.deltaTime;
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
        }
        else
        {
            gameObject.GetComponent <BoxCollider2D>().enabled = true;
        }

        if (playerIFrameTimer >= playerIFramesDuration)
        {
            playerIsInvincible = false;
            playerIFrameTimer = 0;
        }
    }

    public void IncreaseSpeed(float value) { playerSpeed += value; }

    public void IncreaseDamage(float value) { playerDamage += value; }

    public void IncreaseShotSpeed(float value) { playerShotSpeed += value; }

    public void IncreaseFireRate(float value) { playerFireRate += value; }

    public void IncreaseMaxHealth(int value) { playerMaxHealth += value; }

    public void HealPlayer(float value)
    {
        if (playerHealth >= playerMaxHealth)
        {
            playerHealth = playerMaxHealth;
        }

        if (playerHealth < playerMaxHealth)
        {
            playerHealth += value;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        EnemyBullet bullet = collision.GetComponent<EnemyBullet>();

        if (bullet != null)
        {
            Destroy(bullet.gameObject);
            playerHealth -= 1;
            playerIsInvincible = true;

            src.clip = sfx;
            src.Play();
        }

        Enemy enemy = collision.GetComponent<Enemy>();
        if (enemy != null)
        {
            Destroy(enemy.gameObject);
            playerHealth -= 1;
            playerIsInvincible = true;

            src.clip = sfx;
            src.Play();
        }

        if (playerHealth <= 0)
        {
            //hide player ship. Illusion of being destroyed
            gameObject.transform.localScale = new Vector3(0, 0, 0);
        }

        Item item = collision.GetComponent<Item>();
        if (item != null)
        {
            gameObject.GetComponent<Inventory>().AddItem(item.itemID);

            // non heart items
            if (item.itemID != 601)
            {
                Vector2 pos = Camera.main.ViewportToWorldPoint(new Vector2(0.5f, 0.5f));
                var itemCard = Instantiate(itemDescription, pos, Quaternion.identity);
                var itemName = itemCard.transform.GetChild(0).GetComponent<TextMesh>();
                itemName.text = item.itemName;
                var itemDesc = itemCard.transform.GetChild(1).GetComponent<TextMesh>();
                itemDesc.text = item.itemDescription;
            }
           
            if (item.increaseSpeed)
            {
                IncreaseSpeed(item.increaseSpeedValue);
            }

            if (item.increaseShotSpeed)
            {
                IncreaseShotSpeed(item.increaseShotSpeedValue);
            }

            if (item.increaseDamage)
            {
                IncreaseDamage(item.increaseDamageValue);
            }

            if (item.increaseFireRate)
            {
                IncreaseFireRate(item.increaseFireRateValue);
            }

            if (item.healPlayer)
            {
                HealPlayer(1);
            }

            Destroy(item.gameObject);
        }
    }
}
