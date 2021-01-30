using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update

    public SteamVR_Action_Vector2 movementAction;
    private CharacterController characterController;

    public float speed = 2.5f;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
 
    }

    // Update is called once per frame
    void Update()
    {
        Transform hmdTransform = Player.instance.hmdTransform;

        characterController.height = Mathf.Clamp(hmdTransform.localPosition.y, 1, 2);
        characterController.center = new Vector3(hmdTransform.localPosition.x, characterController.height / 2 + characterController.skinWidth, hmdTransform.localPosition.z);

        Vector3 direction = hmdTransform.TransformDirection(new Vector3(movementAction.axis.x, 0, movementAction.axis.y));
        characterController.Move(Time.deltaTime * speed * Vector3.ProjectOnPlane(direction, Vector3.up) - new Vector3(0, 3f, 0) * Time.deltaTime);
    }
}