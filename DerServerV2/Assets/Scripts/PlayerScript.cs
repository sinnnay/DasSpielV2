﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour {

    public float raycastDistance = 400;
    public GameObject slightForwardPoint;
    public GameObject bulletPrefab;
    public Transform bulletSpawn;
    public float bulletSpeed;
    public float distToWallAhead;
    public int score;

    void Start () { 
    }
	

	void Update () {

        RaycastHit hit;
        Ray landingRay = new Ray(transform.position, Vector3.Normalize(slightForwardPoint.transform.position - transform.position));
        
        if(Physics.Raycast(landingRay, out hit, raycastDistance))
        {
           
            if (hit.collider.gameObject.tag.Equals("Wall"))
            {
                distToWallAhead = hit.distance;
            }
        }
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
        }
    }

    public void Fire()
    {
        // Create the Bullet from the Bullet Prefab
        var bullet = (GameObject)Instantiate(
            bulletPrefab,
            bulletSpawn.position,
            bulletSpawn.rotation);

        // Add velocity to the bullet
        bullet.GetComponent<Rigidbody>().velocity = (bullet.transform.forward + bullet.transform.right) * bulletSpeed;

        // Destroy the bullet after 2 seconds
        Destroy(bullet, 4.0f);
    }
}
