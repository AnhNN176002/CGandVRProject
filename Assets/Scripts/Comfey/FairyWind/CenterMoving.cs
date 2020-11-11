using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CenterMoving : MonoBehaviour
{
    // Start is called before the first frame update
    Transform target;
    Transform transform;
    public float speed;
    Rigidbody rigidbody;
    void Start()
    {
        transform = GetComponent<Transform>();
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>().GetChild(0).GetComponent<Transform>();
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Vector3.Distance(transform.position, target.position) >= 0.1f)
        {
            transform.position = Vector3.Lerp(transform.position, target.position, speed * Time.deltaTime);
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        print(other.gameObject.name);
        if (other.CompareTag("Player"))
        {
            Destroy(transform.parent.gameObject);
        }
    }
}
