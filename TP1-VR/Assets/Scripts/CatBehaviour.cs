using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatBehaviour : MonoBehaviour
{
    [SerializeField] GameObject fx;
    AudioSource collisionSound;
    public GameObject worldObject;

    void Start()
    {
        worldObject = GameObject.Find("World");
    }
    void Update()
    {
        collisionSound = worldObject.GetComponent<AudioSource>();
    }
    void OnTriggerEnter(Collider other)
    { 
        if (other.tag == "Player")
        {
            worldObject.SendMessage("AddHit");
            Instantiate(fx, transform.position, Quaternion.identity);
            if (collisionSound != null)
            {
                collisionSound.Play();
            }
            Destroy(gameObject);
        }
    }
}
