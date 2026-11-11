using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform Player;
    public float attackRange = 3f;
    public LayerMask attackLayer;
    public float walkSpeed = 3f;
    public bool facingLeft = true;

    public Transform detectPoint;
    public float distance; 
    public LayerMask targetLayer;

    void Update()
    {
        Collider2D hitInfo = Physics2D.OverlapCircle(transform.position, attackRange, attackLayer);
        if(hitInfo == true)
        {
            if(Player.position.x > transform.position.x && facingLeft) 
            {
                transform.eulerAngles = new Vector3(0f, -180f, 0f);
                facingLeft = false;
            }
            else if(Player.position.x < transform.position.x && facingLeft == false)
            {
                transform.eulerAngles = new Vector3(0f, 0f, 0f);
                facingLeft = true;
            }
        }
        else
        {
            transform.Translate(Vector2.left * Time.deltaTime * walkSpeed);
            RaycastHit2D coolInfo = Physics2D.Raycast(detectPoint.position, Vector2.down, distance, targetLayer);
        
            if(coolInfo == false)
            {
                if(facingLeft == true)
                {
                    transform.eulerAngles = new Vector3(0f, -180f, 0f);
                    facingLeft = false;
                }
                else 
                {
                    transform.eulerAngles = new Vector3(0f, 0f, 0f);
                    facingLeft = true;
                }
            }
        }    
    }

    private void OnDrawGizmosSelected() 
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, attackRange);    

        if(detectPoint == null)
        {
            return;
        }

        Gizmos.color = Color.yellow;
        Gizmos.DrawRay(detectPoint.position, Vector2.down * distance);
    }
}