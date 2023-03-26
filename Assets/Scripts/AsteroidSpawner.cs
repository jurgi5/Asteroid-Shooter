using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    public GameObject asteroidPrefab;
    public int numAsteroids;
    public float spawnRadius;
    public float asteroidSpeed;
    public float maxY = 5f;
    public float minY = -5f;
    public float maxX = 9f;
    public float minX = -9f;

    

    void Start()
    {
        for (int i = 0; i < numAsteroids; i++)
        {
            Vector3 position = Random.insideUnitSphere * spawnRadius;
            position.x = Mathf.Clamp(position.x, minX, maxX);
            position.y = Mathf.Clamp(position.y, minY, maxY);
            GameObject asteroid = Instantiate(asteroidPrefab, position, Quaternion.identity) as GameObject;
            asteroid.GetComponent<Rigidbody>().velocity = Random.onUnitSphere * asteroidSpeed;
        }
    }

    void FixedUpdate()
    {
        GameObject[] asteroids = GameObject.FindGameObjectsWithTag("Asteroid");
        for (int i = 0; i < asteroids.Length; i++)
        {
            for (int j = i + 1; j < asteroids.Length; j++)
            {
                Vector3 direction = asteroids[j].transform.position - asteroids[i].transform.position;
                float distance = direction.magnitude;
                float minDistance = asteroids[i].transform.localScale.x + asteroids[j].transform.localScale.x;
                if (distance < minDistance)
                {
                    Vector3 force = direction.normalized * (minDistance - distance) * asteroidSpeed;
                    asteroids[i].GetComponent<Rigidbody>().AddForce(-force);
                    asteroids[j].GetComponent<Rigidbody>().AddForce(force);
                }
            }
        }
    }





}
