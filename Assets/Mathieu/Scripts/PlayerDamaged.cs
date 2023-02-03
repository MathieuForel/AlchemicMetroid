using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    public void Update()
    {
        this.gameObject.GetComponent<SpriteRenderer>().color = new Color(_SpriteRenderer.color.r, PlayerHP / PlayerMaxHP, PlayerHP / PlayerMaxHP);
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "EnemyBullet")
        {
            PlayerHP -= 1;
        }

        if(PlayerHP == 0)
        {
            SceneManager.LoadScene("Level1");
        }
    }
}
