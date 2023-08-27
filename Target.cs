using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    private Rigidbody rigid;

    private GameManager gameManagerScript;

    private float minSpeed = 12f;
    private float maxSpeed = 16f;
    private float maxTorque = 10;

    private float xPos = 4;
    private float yPos = -2;

    [SerializeField] int targetPoint;

    [SerializeField] ParticleSystem explosionEffect;

    void Start()
    {
        rigid = GetComponent<Rigidbody>();

        rigid.AddForce(RandomForce(), ForceMode.Impulse);
        rigid.AddTorque(RandomTorque(), RandomTorque(), RandomTorque(), ForceMode.Impulse);

        transform.position = RandomPos();

        gameManagerScript = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    private void OnMouseEnter()
    {
        if (Input.GetMouseButton(0))
        {
            gameManagerScript.UpdateScore(targetPoint);
            Instantiate(explosionEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
    Vector3 RandomForce()
    {
        return Vector3.up * Random.Range(minSpeed, maxSpeed);
    } 
    float RandomTorque()
    {
        return Random.Range(-maxTorque, maxTorque);
    }
    Vector3 RandomPos()
    {
        return new Vector3(Random.Range(-xPos, xPos), yPos);
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
        if (!gameObject.CompareTag("Bad"))
        {
            gameManagerScript.LivesCount();
        }
    }
}
