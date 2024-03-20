using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieAi : MonoBehaviour
{
    public GameObject Target;
    public float speed = 1.5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(Target.transform);
        transform.position = Vector3.MoveTowards(transform.position, Target.transform.position, speed * Time.deltaTime);
    }
}
