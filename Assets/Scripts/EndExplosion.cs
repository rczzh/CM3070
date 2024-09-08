using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyExplosion : MonoBehaviour
{
    public void ExplosionDone()
    {
        Destroy(gameObject);
    }
}
