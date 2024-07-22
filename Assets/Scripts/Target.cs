using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    private float minForceRange = 14.0f;
    private float maxForceRange = 16.0f;
    private float randomTorque = 10.0f;
    private float xRange = 4.0f;
    private float yPosition = -2.0f;
    public int pointValue;
    public Rigidbody rigidbody;
    private GameManager gameManager;
    public ParticleSystem explosionParticle;
    
    
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
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
        if (gameManager.isGameActive)
        {
            Destroy(gameObject);
            gameManager.ScoreToAddMethod(pointValue);
            Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);
        }
       

    }

    private void OnTriggerEnter(Collider other)
    {
        if (gameManager.isGameActive)
        {
            if (!gameObject.CompareTag("Bomb"))
            {
                Debug.Log("Hola");
                gameManager.GameOver();
            }
            Destroy(gameObject);
            gameManager.ScoreToAddMethod(-pointValue);
        }
       

       

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
