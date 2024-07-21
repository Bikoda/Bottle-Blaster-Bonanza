using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    private float minForceRange = 12.0f;
    private float maxForceRange = 12.0f;
    private float randomTorque = 10.0f;
    private float xRange = 4.0f;
    private float yPosition = -2.0f;
    public Rigidbody rigidbody;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        rigidbody.AddForce(RandomRange(), ForceMode.Impulse);
        rigidbody.AddTorque(RandomTorque(), Random.Range(-randomTorque, randomTorque), Random.Range(-randomTorque, randomTorque), ForceMode.Impulse);
        transform.position = RandomPosition();
    }

    // Update is called once per frame
    void Update()
    {
        

    }

    private void OnMouseDown()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }

    Vector3 RandomRange()
    {
        return Vector3.up * Random.Range(minForceRange, maxForceRange);
    }

    float RandomTorque()
    {
        return Random.Range(-randomTorque, randomTorque);
    }

    Vector3 RandomPosition()
    { 
        return new Vector3(Random.Range(-xRange, xRange), yPosition);
    }
}
