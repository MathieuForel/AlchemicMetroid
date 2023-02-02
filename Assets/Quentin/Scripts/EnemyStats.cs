using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    [SerializeField, Range(0f, 20f)] private float PV = 10f;

    public void TakeDamage(float damage)
    {
        PV -= damage;
        if(PV <= 0f)
        {
            Destroy(gameObject);
        }
    }
}
