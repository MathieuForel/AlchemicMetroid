using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamaged : MonoBehaviour
{
    public float PlayerMaxHP;
    public float PlayerHP;

    public SpriteRenderer _SpriteRenderer;
    public void Start()
    {
        PlayerHP = PlayerMaxHP;
        _SpriteRenderer = this.gameObject.GetComponent<SpriteRenderer>();
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "EnemyBullet")
        {
            PlayerHP -= 1;
            this.gameObject.GetComponent<SpriteRenderer>().color = new Color(1/PlayerHP, _SpriteRenderer.color.g, _SpriteRenderer.color.b);
        }

        if(PlayerHP == 0)
        {

        }
    }
}
