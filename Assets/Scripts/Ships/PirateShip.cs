using UnityEngine;
using Photon.Pun;

public class PirateShip : ShipManager
{
    private CharacterController _characterController;
    private PhotonView _photonView;
    private int _speed = 10;
    private int _damage = 25;

    private void Start()
    {
        _characterController = GetComponent<CharacterController>();
        _photonView = GetComponent<PhotonView>();
    }

    private void FixedUpdate()
    {
        Movement(_characterController, transform.forward, _speed);
    }

    private void OnCollisionEnter(Collision collision)
    {
        ApplyDamage(collision, _photonView, gameObject, _damage);
    }
}
