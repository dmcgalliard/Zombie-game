using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class Enemy : MonoBehaviour
{
    public int enemyHP = 100;
    public Animator animator;
    public CapsuleCollider capsuleCollider;
    // Start is called before the first frame update
    public void TakeDamage(int damageAmount)
    {
        enemyHP -= damageAmount;
        if (enemyHP <= 0)
        {
            capsuleCollider.enabled = false;
            animator.SetTrigger("death");
            Destroy(gameObject, 10);
           
        }
        else
        {
            animator.SetTrigger("damage");
        }
    }
}
