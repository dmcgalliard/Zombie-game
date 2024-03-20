using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class FireAK : MonoBehaviour
{
    public GameObject bullet;
    public Transform spawnPoint;
    public float fireSpeed = 40;

    void Start()
    {
        XRGrabInteractable grabbable = GetComponent<XRGrabInteractable>();
        grabbable.activated.AddListener(StartFireAkBullets);
    }

    void StartFireAkBullets(ActivateEventArgs arg)
    {
        StartCoroutine(FireAkBullets());
    }

    public IEnumerator FireAkBullets() 
    { 
        for (int i = 0; i < 8; i++) {
            GameObject spawnedBullet = Instantiate(bullet);
            spawnedBullet.transform.position = spawnPoint.position;
            spawnedBullet.GetComponent<Rigidbody>().velocity = spawnPoint.forward * fireSpeed;
            Destroy(spawnedBullet, 5);

            yield return new WaitForSeconds(0.1f); // Wait for 0.1 seconds before spawning the next bullet
        }
    }

}