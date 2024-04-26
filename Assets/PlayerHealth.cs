using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class PlayerHealth : MonoBehaviour
{
    public int health;
    public int maxHealth = 100;
    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;

    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
