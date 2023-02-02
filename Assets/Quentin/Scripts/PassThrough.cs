using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassThrough : MonoBehaviour
{
    [Header("Input type")]
    [SerializeField] private InputController input = null;

    private Collider2D colliderUp;
    private Collider2D colliderDown;

    private bool isCrouching;

    private void Update()
    {
        isCrouching |= input.RetreiveVerticalInput();
    }

    private void FixedUpdate() 
    {
        RayCheck();
    }
    public void RayCheck()
    {
        //regarde si il y a une plateforme autour de l'objet
        RaycastHit2D hitUp = Physics2D.Raycast(this.gameObject.transform.position, Vector2.up, Mathf.Infinity, LayerMask.GetMask("Ground"));
        RaycastHit2D hitDown = Physics2D.Raycast(this.gameObject.transform.position, Vector2.down, Mathf.Infinity, LayerMask.GetMask("Ground"));
        RaycastHit2D hitRight = Physics2D.Raycast(this.gameObject.transform.position, Vector2.right, Mathf.Infinity, LayerMask.GetMask("Ground"));
        RaycastHit2D hitLeft = Physics2D.Raycast(this.gameObject.transform.position, Vector2.left, Mathf.Infinity, LayerMask.GetMask("Ground"));

        //cas plateforme au dessus
        if (hitUp.distance > 0f && hitUp.distance <= 3f && hitUp.collider.tag == "Plateform")
        {
            //Debug.Log("distance to object " + hitUp.distance);
            colliderUp = hitUp.collider;
            StartCoroutine(ColliderCooldown(hitUp.collider));
        }
        //else{Debug.Log("Nothing upward");}

        //cas plateforme a droite
        if (hitRight.distance > 0f && hitRight.distance <= 3f && hitRight.collider.tag == "Plateform")
        {
            //Debug.Log("distance to object " + hitRight.distance);
            colliderUp = hitRight.collider;
            StartCoroutine(ColliderCooldown(hitRight.collider));
        }
        //else{Debug.Log("Nothing right");}

        //cas plateforme a gauche
        if (hitLeft.distance > 0f && hitLeft.distance <= 3f && hitLeft.collider.tag == "Plateform")
        {
            //Debug.Log("distance to object " + hitLeft.distance);
            colliderUp = hitLeft.collider;
            StartCoroutine(ColliderCooldown(hitLeft.collider));
        }
        //else{Debug.Log("Nothing left");}

        //cas plateforme en dessous
        if (hitDown.distance > 0f && hitDown.distance <= 3f && hitDown.collider.tag == "Plateform" && isCrouching)
        {
            //Debug.Log("distance to object " + hitDown.distance);
            colliderDown = hitDown.collider;
            isCrouching = false;
            StartCoroutine(ColliderCooldown(hitDown.collider));
        }
        //else{Debug.Log("Nothing downward");}

    }
    
    IEnumerator ColliderCooldown(Collider2D col)
    {
        col.enabled = false;
        yield return new WaitForSeconds(0.2f);
        col.enabled = true;
    }
}
