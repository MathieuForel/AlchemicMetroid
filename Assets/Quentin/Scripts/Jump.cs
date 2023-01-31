using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    [Header("Input type")]
    [SerializeField] private InputController input = null;
    [Header("Jump values")]
    [SerializeField, Range(0f, 10f)] private float jumpHeight = 3f;
    [SerializeField, Range(0, 10)] private float maxAirJumps = 0;
    [SerializeField, Range(0f, 5f)] private float downwardMovementMultiplier = 3f;
    [SerializeField, Range(0f, 5f)] private float upwardMovementMultiplier = 1.7f;

    private Rigidbody2D body;
    private GroundCheck ground;
    private Vector2 velocity;

    private int jumpPhase;
    private float defaultGravityScale;

    private bool desiredJump;
    private bool isGrounded;

    //private Collider2D colliderUp;
    //private Collider2D colliderDown;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        ground = GetComponent<GroundCheck>();

        defaultGravityScale = 1f;
    }

    private void Update()
    {
        desiredJump |= input.RetreiveJumpInput();
    }

    private void FixedUpdate()
    {
        //RayCheck();
        isGrounded = ground.GetIsGrounded();
        velocity = body.velocity;

        if (isGrounded)
        {
            jumpPhase = 0;
        }

        if (desiredJump)
        {
            desiredJump = false;
            JumpAction();
        }

        if(body.velocity.y > 0)
        {
            body.gravityScale = upwardMovementMultiplier;
        }
        else if(body.velocity.y < 0)
        {
            body.gravityScale = downwardMovementMultiplier;
        }
        else if(body.velocity.y == 0)
        {
            body.gravityScale = defaultGravityScale;
        }

        body.velocity = velocity;
    }

    private void JumpAction()
    {
        if(isGrounded || jumpPhase < maxAirJumps)
        {
            jumpPhase += 1;
            float jumpSpeed = Mathf.Sqrt(-2f * Physics2D.gravity.y * jumpHeight);
            if(velocity.y > 0f)
            {
                jumpSpeed = Mathf.Max(jumpSpeed - velocity.y, 0f);
            }

            velocity.y += jumpSpeed;
        }
    }

    /*public void RayCheck()
    {
        //regarde si il y a une plateforme au dessus ou en dessous de l'objet
        RaycastHit2D hitUp = Physics2D.Raycast(this.gameObject.transform.position, Vector2.up, Mathf.Infinity, LayerMask.GetMask("Ground"));
        RaycastHit2D hitDown = Physics2D.Raycast(this.gameObject.transform.position, Vector2.down, Mathf.Infinity, LayerMask.GetMask("Ground"));

        //cas plateforme au dessus
        if (hitUp.distance > 0f && hitUp.distance <= 3f && hitUp.collider.tag == "Plateform")
        {
            Debug.Log("distance to object " + hitUp.distance);
            colliderUp = hitUp.collider;
        }
        else
        {
            Debug.Log("Nothing upward");
        }

        //cas plateforme en dessous
        if (hitDown.distance > 0f && hitDown.distance <= 3f && hitDown.collider.tag == "Plateform")
        {
            Debug.Log("distance to object " + hitDown.distance);
            colliderDown = hitDown.collider;
        }
        else
        {
            Debug.Log("Nothing downward");
        }
    }*/
}
