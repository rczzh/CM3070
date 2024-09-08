using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using static UnityEditor.PlayerSettings;

public class Enemy : MonoBehaviour
{
    [SerializeField] private bool isBoss;
    [SerializeField] private bool isMeteorite;

    [SerializeField] public float enemyHp;
    [SerializeField] private int enemyScore;

    EnemyGun[] guns;

    [SerializeField] GameObject explosion;
    [SerializeField] GameObject bulletExplosion;

    DropTable dropTable;

    // Start is called before the first frame update
    void Start()
    {
        //EnemySpawner.instance.AddEnemy();
        guns = GetComponentsInChildren<EnemyGun>();
        dropTable = GetComponent<DropTable>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x <= -1)
        {
            Destroy(gameObject);
            //EnemySpawner.instance.RemoveEnemy();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerBullet bullet = collision.GetComponent<PlayerBullet>();

        if (bullet != null)
        {
            Destroy(bullet.gameObject);
            Instantiate(bulletExplosion, bullet.transform.position, Quaternion.identity);
            enemyHp -= bullet.bulletDamage;
        }

        if (enemyHp <= 0)
        {
            Score.instance.AddScore(enemyScore);

            if (isBoss)
            {
                var spawnerController = GameObject.FindWithTag("SpawnerController").GetComponent<SpawnerControllerScript>();
                spawnerController.NextLevel();
                dropTable.dropItem();
                Destroy(transform.parent.gameObject);
            }
            else if (isMeteorite)
            {
                dropTable.dropItem();
            }
            else
            {
                dropTable.dropHeart();
            }

            Destroy(gameObject);
            Instantiate(explosion, transform.position, Quaternion.identity);
        }
    }

    public void Shoot()
    {
        foreach (EnemyGun gun in guns)
        {
            gun.Fire();
        }
    }

}
