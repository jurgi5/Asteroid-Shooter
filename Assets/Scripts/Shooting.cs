using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject bulletPrefab;
    public GameObject asteroidPrefab;
    public float bulletSpeed;
    public float fireRate;
    public int maxBullets;
    public float bulletLifetime;
    public Transform[] gunPositions;
    public Transform bulletParent;
    public AudioSource emptySound;
    public AudioSource bulletSound;

    private float lastFiredTime;
    private int numBullets;

    void Start()
    {
        numBullets = maxBullets;
    }

    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time - lastFiredTime > 1f / fireRate)
        {
            if (numBullets > 0)
            {
                for (int i = 0; i < gunPositions.Length; i++)
                {
                    GameObject bullet = Instantiate(bulletPrefab, gunPositions[i].position, gunPositions[i].rotation, bulletParent) as GameObject;
                    bullet.GetComponent<Rigidbody>().velocity = gunPositions[i].forward * bulletSpeed;
                    Destroy(bullet, bulletLifetime);
                }
                numBullets--;
                lastFiredTime = Time.time;
                bulletSound.Play();
               
             
            }
            else
            {
                emptySound.Play();
                
             
            }
        }
        if (Time.time - lastFiredTime > 1f / fireRate && numBullets < maxBullets)
        {
            numBullets++;
        }


    }

    void OnGUI()
    {
        GUI.Label(new Rect(10, 10, 100, 20), "Bullets: " + numBullets);
        GUI.Label(new Rect(10, 30, 100, 20), "Cooldown: " + Mathf.Round((Time.time - lastFiredTime - 1f / fireRate) * 100f) / 100f);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Asteroid")
        {
            Destroy(other.gameObject);

            for (int i = 0; i < 5; i++)
            {
                Vector3 position = other.transform.position + Random.insideUnitSphere * 2f;
                GameObject asteroid = Instantiate(asteroidPrefab, position, Quaternion.identity) as GameObject;
                asteroid.GetComponent<Rigidbody>().velocity = Random.onUnitSphere * 2f;
            }
        }
    }
}
