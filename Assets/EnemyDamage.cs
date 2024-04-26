using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public int damage = 10;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        //Debug.Log("Collision Detected with " + collision.gameObject.name);
        if (collision.gameObject.CompareTag("Player"))
        {
          //  Debug.Log("Player collided. Attempting to apply damage.");
            playerHealth.TakeDamage(damage);
        }
    }
}
