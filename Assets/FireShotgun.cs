using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class FireShotgun : MonoBehaviour
{
    public GameObject bullet;
    public Transform spawnPoint;
    public float fireSpeed = 40;
    public int damageAmount = 10;

    // Start is called before the first frame update
    void Start()
    {
        XRGrabInteractable grabbable = GetComponent<XRGrabInteractable>();
        grabbable.activated.AddListener(FireShotgunBullets);
    }

    // Update is called once per frame
    void Update()
    {
      
    }

    public void FireShotgunBullets(ActivateEventArgs arg) { 

        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit)) {
            Enemy e = hit.transform.GetComponent<Enemy>();
            if (e != null)
            {
                e.TakeDamage(damageAmount);
                
            }
        }

        for (int i = 0; i < 9; i++) {
            GameObject spawnedBullet = Instantiate(bullet);
            spawnedBullet.transform.position = spawnPoint.position;

            // Add a small random offset to the direction for each bullet
            Vector3 direction = spawnPoint.forward;
            direction.x += Random.Range(-0.05f, 0.05f);
            direction.y += Random.Range(-0.05f, 0.05f);
            direction.z += Random.Range(-0.05f, 0.05f);
            direction.Normalize();

            spawnedBullet.GetComponent<Rigidbody>().velocity = direction * fireSpeed;
            Destroy(spawnedBullet, 5);
        }
    }

}
