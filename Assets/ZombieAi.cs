using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieAi : MonoBehaviour
{
    public GameObject Target;
    public float speed = 1.5f;
    private Animator animator; // Reference to the Animator component

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>(); // Get the Animator component
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(Target.transform);
        Vector3 oldPosition = transform.position;
        transform.position = Vector3.MoveTowards(transform.position, Target.transform.position, speed * Time.deltaTime);

        // Check if the zombie's position has changed
        if (oldPosition != transform.position)
        {
            animator.SetBool("isMoving", true); // Set the "isMoving" boolean to true
        }
        else
        {
            animator.SetBool("isMoving", false); // Set the "isMoving" boolean to false
        }
    }
}