using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandsIgnoreCharacter : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Collider[] colliders = GetComponentsInChildren<Collider>();
        for (int i = 0; i < colliders.Length; i++)
        {
            Physics.IgnoreCollision(colliders[i], transform.parent.GetComponent<CharacterController>());
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}