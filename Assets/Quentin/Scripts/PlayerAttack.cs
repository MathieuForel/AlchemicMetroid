using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [Header("Input type")]
    [SerializeField] private InputController input = null;

    [Header("Attack values")]
    [SerializeField, Range(0f, 20f)] private float attackDmg = 5f;
    [SerializeField, Range(0f, 20f)] private float attackRadius = 2f;
    [SerializeField, Range(0f, 20f)] private float attackSpeed = 1f;

    public Transform partToRotate; //partie du player qui va tourner en fonction de la direction regardée
    public GameObject currentHitObject;

    //private var
    private bool isAttacking;
    private bool canAttack;
    private Rigidbody2D body;
    private Vector2 attackSide;
    private Vector3 attackSphere;
    private float attackRange = 1f;

    //sphere cast info
    private float sphereRadius;
    private float maxDistance;
    public LayerMask layerMask;
    private Vector3 origin;
    private Vector3 direction;


    private void Awake() 
    {
        body = GetComponent<Rigidbody2D>();
        canAttack = true;
        attackSphere = transform.position;
    }

    private void Update() 
    {
        isAttacking |= input.RetreiveAttackInput();

        origin = transform.position;
        direction = attackSphere;
        sphereRadius = attackRadius;
        maxDistance = attackRange;
        RaycastHit hit;
        if(Physics.SphereCast(origin, sphereRadius, direction, out hit, maxDistance, layerMask, QueryTriggerInteraction.UseGlobal))
        {
            currentHitObject = hit.transform.gameObject;
        }
    }

    private void FixedUpdate() 
    {
        RotatePlayer();
        attackSide = GetComponent<Move>().getDirection;
        if(isAttacking)
        {
            isAttacking = false;
            Attack();
        }

    }

    //déclenche la séquence d'attaque
    private void Attack()
    {
        if(canAttack == true && currentHitObject.tag == "Enemy")
        {
            canAttack = false;
            StartCoroutine(AttackCooldown());
            if(attackSide.x > 0f)
            {
                
                Debug.Log("Right");
            }
            else
            {
                Debug.Log("Left");
            }
        }
        
    }

    //Cooldown avant de pouvoir attaquer a nouveau
    IEnumerator AttackCooldown()
    {
        Debug.Log("Attaque");
        yield return new WaitForSeconds(attackSpeed);
        canAttack = true;
        Debug.Log("Reset");
    }

    //change la sens du sprite et de la zone d'attaque 
    private void RotatePlayer()
    {
        if(attackSide.x > 0f)
            {
                partToRotate.rotation = Quaternion.Euler(0f, 0f, 0f);
                attackRange = 1f;
                attackSphere = transform.position;
                attackSphere.x = attackSphere.x + attackRange;
                
            }
        if(attackSide.x < 0f)
            {
                partToRotate.rotation = Quaternion.Euler(0f, 180f, 0f);
                attackRange = -1f;
                attackSphere = transform.position;
                attackSphere.x = attackSphere.x + attackRange;
            }
    }

    private void OnDrawGizmosSelected() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackSphere, attackRadius);
    }
}
