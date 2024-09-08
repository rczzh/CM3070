using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGun : MonoBehaviour
{
    enum GunType { Straight, Spin };

    [Header("Bullet Attributes")]
    public GameObject bullet;
    public float bulletSpeed = 1f;
    //public bool invert = false;

    [Header("Gun Attributes")]
    [SerializeField] private GunType gunType;
    [SerializeField] private float firingRate = 1f;
    [SerializeField] private bool autoShoot = false;

    private GameObject spawnedBullet;

    private float timer = 0f;

    // time in between attack windows
    public float attackDelay = 2f;
    private float attackDelayTimer = 0f;

    // duration of attack window
    public float attackWindow = 1f;
    private float attackWindowTimer = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        attackDelayTimer += Time.deltaTime;

        // if auto shoot is enabled
        if (autoShoot && transform.position.x >= 3 && transform.position.x <= 17.5)
        {
            if (attackDelayTimer >= attackDelay)
            {
                attackWindowTimer += Time.deltaTime;

                if (timer >= 1 / firingRate)
                {
                    Fire();
                    timer = 0;
                }

                if (attackWindowTimer >= attackWindow)
                {
                    attackDelayTimer = 0;
                    attackWindowTimer = 0;
                    timer = 0;
                }
            }
        }
    }

    public void Fire()
    {
        if (bullet)
        {
            spawnedBullet = Instantiate(bullet, transform.position, Quaternion.identity);
            spawnedBullet.GetComponent<EnemyBullet>().bulletSpeed = bulletSpeed;
            spawnedBullet.transform.rotation = transform.rotation;
        }
    }
}
