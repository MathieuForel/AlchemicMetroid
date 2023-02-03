using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectEnemy : MonoBehaviour
{
    [SerializeField] private GameObject player;
    private GameObject enemy;

    public void Start()
    {
        player = GameObject.FindWithTag("Player").gameObject;
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.isTrigger != true && collider.gameObject.tag == "Enemy")
        {
            enemy = collider.gameObject;
            player.GetComponent<PlayerAttack>().Attack(enemy);
        }
    }
}
