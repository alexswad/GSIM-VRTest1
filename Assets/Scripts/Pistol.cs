using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class Pistol : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform barrelPivot;
    public SteamVR_Action_Boolean fireAction;


    public float bulletSpeed = 10f;

    private Interactable interactable;
    private AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        interactable = GetComponent<Interactable>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (interactable.attachedToHand != null)
        {
            if (fireAction[interactable.attachedToHand.handType].stateDown)
            {
                FireBullet();
            }
        }
    }

    void FireBullet()
    {
        GameObject bullet = GameObject.Instantiate(bulletPrefab, barrelPivot.position, barrelPivot.rotation * Quaternion.Euler(0, 90, 90));
        Physics.IgnoreCollision(bullet.GetComponent<Collider>(), gameObject.GetComponent<Collider>());
        bullet.GetComponent<Rigidbody>().velocity = barrelPivot.forward * bulletSpeed;

        audioSource.Play();
    }
}
