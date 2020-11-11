using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailMoving : MonoBehaviour
{
    // Start is called before the first frame update
    private Transform transform;
    public Transform center;
    public int key;
    float timeCounter = 0;
    public float radius;
    public float speed;
    void Start()
    {
        transform = GetComponent<Transform>();
        // transform = center;
    }

    // Update is called once per frame
    void Update()
    {
        // if (radius > 0)
        // {
        timeCounter += Time.deltaTime;
        float x_orbit = key % 2 == 0 ? Mathf.Cos(timeCounter * speed) * (radius -= Time.deltaTime * 0.1f) : Mathf.Sin(timeCounter * speed) * (radius -= Time.deltaTime * 0.1f);
        float z_orbit = key % 2 == 0 ? Mathf.Sin(timeCounter * speed) * (radius -= Time.deltaTime * 0.1f) : Mathf.Cos(timeCounter * speed) * (radius -= Time.deltaTime * 0.1f);

        float x = center.position.x + x_orbit;
        float y = center.position.y;
        float z = center.position.z + z_orbit;
        transform.position = new Vector3(x, y, z);
        // }
        // else
        // {
        //     transform = center;
        // }
    }
}
