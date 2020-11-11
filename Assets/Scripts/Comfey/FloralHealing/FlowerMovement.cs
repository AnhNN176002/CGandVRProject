using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    private Transform transform;
    public Transform target;

    float timeCounter = 0;
    public float radius = 10f;
    public float speed = 25;
    void Start()
    {
        transform = GetComponent<Transform>();
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        timeCounter += Time.deltaTime;
        float x = target.position.x + Mathf.Sin(timeCounter * speed) * (radius -= Time.deltaTime * 10);
        float y = target.position.y + Time.deltaTime;
        float z = target.position.z + Mathf.Cos(timeCounter * speed) * (radius -= Time.deltaTime * 10);
        transform.position = new Vector3(x, y, z);

    }
}
