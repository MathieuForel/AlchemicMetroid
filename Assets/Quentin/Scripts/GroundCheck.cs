using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{   
    public bool isGrounded { get; private set; }
    public float friction { get; private set; }
    private PhysicsMaterial2D material;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        EvaluateCollision(collision);
        RetreiveFriction(collision);
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        EvaluateCollision(collision);
        RetreiveFriction(collision);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        isGrounded = false;
        friction = 0;
    }

    private void EvaluateCollision(Collision2D collision)
    {
        for (int i = 0; i < collision.contactCount; i++)
        {
            Vector2 normal = collision.GetContact(i).normal;
            isGrounded |= normal.y >= 0.9f;
        }
    }

    private void RetreiveFriction(Collision2D collision)
    {
        material = collision.rigidbody.sharedMaterial;

        friction = 0;

        if(material != null)
        {
            friction = material.friction;
        }
    }

    public bool GetIsGrounded()
    {
        return isGrounded;
    }

    public float GetFriction()
    {
        return friction;
    }
}
