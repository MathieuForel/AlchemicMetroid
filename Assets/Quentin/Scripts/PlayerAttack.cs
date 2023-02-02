using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [Header("Input type")]
    [SerializeField] private InputController input = null;

    [Header("Attack values")]
    [SerializeField, Range(0f, 20f)] private float AttackDmg = 5f;
    //[SerializeField, Range(0f, 20f)] private float AttackRadius = 2f;
    [SerializeField, Range(0f, 20f)] private float AttackSpeed = 1f;

    [Header("Rotating part")]
    public Transform partToRotate; //partie du player qui va tourner en fonction de la direction regardée

    [Header("Detection collision part")]
    public GameObject currentHitObject;
    [SerializeField] private GameObject attackCollider;
    
    //private script only var
    private bool isAttacking;
    private bool canAttack;
    private Rigidbody2D body;
    private Vector2 AttackSide;

    private void Awake() 
    {
        //attackCollider.enabled = false;
        attackCollider.SetActive(false);
        body = GetComponent<Rigidbody2D>();
        canAttack = true;
    }

    private void Update() 
    {
        isAttacking |= input.RetreiveAttackInput();
    }

    private void FixedUpdate() 
    {
        RotatePlayer();
        AttackSide = GetComponent<Move>().getDirection;
        if(isAttacking)
        {
            isAttacking = false;
            LaunchAttack();
        }

    }

    private void LaunchAttack()//déclenche la séquence d'attaque si le cooldown est terminé
    {
        if(canAttack == true)
        {
            canAttack = false;
            StartCoroutine(AttackCooldown());
            //attackCollider.enabled = true;
            attackCollider.SetActive(true);
            StartCoroutine(DeactiveAttackCollider());
        }
        
    }

    public void Attack(GameObject enemy)//Reçoit les informations de l'enemy touché et renvoie à ses stats
    {
        Debug.Log("touche");
        currentHitObject = enemy;
        enemy.GetComponent<EnemyStats>().TakeDamage(AttackDmg);
    }

    IEnumerator AttackCooldown()//Cooldown avant de pouvoir attaquer a nouveau
    {
        yield return new WaitForSeconds(AttackSpeed);
        canAttack = true;
    }
    
    IEnumerator DeactiveAttackCollider()//Désactivation rapide du collider d'attaque
    {
        yield return new WaitForSeconds(0.1f);
        //attackCollider.enabled = false;
        attackCollider.SetActive(false);
    }

    private void RotatePlayer()//change le sens du sprite et de la zone d'attaque
    {
        if(AttackSide.x > 0f)
            {
                partToRotate.rotation = Quaternion.Euler(0f, 0f, 0f);
            }
        if(AttackSide.x < 0f)
            {
                partToRotate.rotation = Quaternion.Euler(0f, 180f, 0f);
            }
    }
}
