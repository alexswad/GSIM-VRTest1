using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class Pistol : MonoBehaviour
{
    public GameObject bulletPrefab;
    public GameObject muzzle;
    public SteamVR_Action_Boolean fireAction;

    private Interactable interactable;
    // Start is called before the first frame update
    void Start()
    {
        interactable = GetComponent<Interactable>();
    }

    // Update is called once per frame
    void Update()
    {
        if (interactable.attachedToHand != null)
        {
            if (fireAction[interactable.attachedToHand.handType].stateDown)
            {
                Debug.Log("yes");
                FireBullet();
            }
        }
    }

    void FireBullet()
    {
        GameObject bullet = GameObject.Instantiate(bulletPrefab, muzzle.transform.position, muzzle.transform.rotation);
        Physics.IgnoreCollision(bullet.GetComponent<Collider>(), gameObject.GetComponent<Collider>());
        bullet.GetComponent<Rigidbody>().AddForce(Quaternion.Euler(new Vector3(0, 90, 0)) * muzzle.transform.rotation.eulerAngles * 5f);
    }
}
