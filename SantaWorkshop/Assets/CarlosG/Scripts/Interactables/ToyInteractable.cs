using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToyInteractable : IInteractable
{
    private bool _isTaken;
    private MeshRenderer _meshRenderer;
    private Rigidbody _rigidBody;
    private void Start()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
        _rigidBody = GetComponent<Rigidbody>();
    }
    public override void Interact(PlayerInteractionController player)
    {
        PlayerGrabController playerGrab = player.GetComponent<PlayerGrabController>();

        if (playerGrab.isGrabbing)
        {
            if (playerGrab.IsGrabbingInteractable(this))
            {
                _rigidBody.useGravity = true;
                _rigidBody.isKinematic = false;
                _isTaken = false;
                _meshRenderer.enabled = true;
                transform.SetParent(null);
                transform.localPosition = player.DropPoint.position;
                playerGrab.isGrabbing = false;
                playerGrab.objectInteractable = null;
            }
        }
        else
        {

            _rigidBody.useGravity = false;
            _rigidBody.isKinematic = true;
            _isTaken = true;
            _meshRenderer.enabled = true;
            transform.SetParent(player.DropPoint);
            transform.localPosition = Vector3.zero;
            playerGrab.isGrabbing = true;
            playerGrab.objectInteractable = this;

        }

        Debug.Log("I'm a toy");
    }


}
