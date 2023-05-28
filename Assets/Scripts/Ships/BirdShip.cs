using UnityEngine;
using Photon.Pun;

public class BirdShip : ShipManager
{
    private CharacterController _characterController;
    private PhotonView _photonView;
    private int _speed = 15;
    private int _damage = 15;

    private void Start()
    {
        _characterController = GetComponent<CharacterController>();
        _photonView = GetComponent<PhotonView>();
    }

    private void FixedUpdate()
    {
        Movement(_characterController, -transform.right, _speed);
    }

    private void OnCollisionEnter(Collision collision)
    {
        ApplyDamage(collision, _photonView, gameObject, _damage);
    }
}
