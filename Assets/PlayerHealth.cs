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

        Vector3 headsetPosition = InputTracking.GetLocalPosition(XRNode.Head);
        transform.position = new Vector3(headsetPosition.x, headsetPosition.y, headsetPosition.z);
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
