using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiftInteractable : IInteractable
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

        if (playerGrab.IsGrabbing)
        {
            if (playerGrab.IsGrabbingInteractable(this))
            {
                _rigidBody.useGravity = true;
                _rigidBody.isKinematic = false;
                _isTaken = false;

                transform.SetParent(null);
                transform.localPosition = player.DropPoint.position;
                playerGrab.objectInteractable = null;
            }
        }
        else
        {

            _rigidBody.useGravity = false;
            _rigidBody.isKinematic = true;
            _isTaken = true;

            transform.SetParent(player.DropPoint);
            transform.localPosition = Vector3.zero;
            playerGrab.objectInteractable = this;

        }

        Debug.Log("I'm a gift");
    }
}
