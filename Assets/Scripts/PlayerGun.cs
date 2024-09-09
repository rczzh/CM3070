using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGun : MonoBehaviour
{
    [Header("Bullet Attributes")]
    public GameObject bullet;
    private float bulletSpeed = 1f;
    private float bulletDamage = 1f;

    [Header("Gun Attributes")]
    private float firingRate = 1f;

    private GameObject spawnedBullet;

    public AudioSource src;
    public AudioClip sfx;

    bool shoot;
    float nextFire = 0f;

    Player playerStats;
    
    // Start is called before the first frame update
    void Start()
    {
        playerStats = GetComponentInParent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        bulletDamage = playerStats.playerDamage;
        bulletSpeed = playerStats.playerShotSpeed;
        firingRate = playerStats.playerFireRate;

        shoot = Input.GetKey(KeyCode.C);

        if (shoot) 
        {
            if (Time.time > nextFire)
            {
                nextFire = Time.time + 1 / firingRate;
                FireGun();

                src.clip = sfx;
                src.Play();
            }
        }
    }

    private void FireGun()
    {
        if (bullet)
        {
            spawnedBullet = Instantiate(bullet, transform.position, Quaternion.identity);
            spawnedBullet.GetComponent<PlayerBullet>().bulletSpeed = bulletSpeed;
            spawnedBullet.GetComponent<PlayerBullet>().bulletDamage = bulletDamage;
            //spawnedBullet.transform.rotation = transform.rotation;
        }
    }
}
