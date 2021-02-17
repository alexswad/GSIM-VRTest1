using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class Bullet : MonoBehaviour
{

    private float created;
    // Start is called before the first frame update
    void Start()
    {
        created = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (created < Time.time - 5) 
            Destroy(gameObject);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.GetComponent<Balloon>() != null)
            collision.collider.gameObject.SendMessage("ApplyDamage");

        Destroy(gameObject);
    }
}
