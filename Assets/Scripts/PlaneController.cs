using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneController : MonoBehaviour
{
   
    public float speed = 100f;
    public float maxY = 15f;
    public float minY = -15f;
    public float maxX = 15f;
    public float minX = -15f;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            Vector3 position = transform.position;
            position.y += speed * Time.deltaTime;
            position.y = Mathf.Clamp(position.y, minY, maxY);
            transform.position = position;
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            Vector3 position = transform.position;
            position.y -= speed * Time.deltaTime;
            position.y = Mathf.Clamp(position.y, minY, maxY);
            transform.position = position;
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            Vector3 position = transform.position;
            position.x -= speed * Time.deltaTime;
            position.x = Mathf.Clamp(position.x, minX, maxX);
            transform.position = position;
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            Vector3 position = transform.position;
            position.x += speed * Time.deltaTime;
            position.x = Mathf.Clamp(position.x, minX, maxX);
            transform.position = position;
        }
    }
}
