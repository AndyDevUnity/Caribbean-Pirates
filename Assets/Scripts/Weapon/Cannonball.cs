using UnityEngine;
using Photon.Pun;
using System;

public class Cannonball : MonoBehaviour
{
    [SerializeField] private Explosion _bulletExplosion;
    private PhotonView _photonView;
    private Rigidbody _rigidbody;
    private int _damage = 10;
    public static Action<int> applyDamage;

    private void Awake()
    {
        _photonView = GetComponent<PhotonView>();
        _rigidbody = GetComponent<Rigidbody>();
    }

    public void MoveCannonball(Vector3 target) => _rigidbody.AddForce(target, ForceMode.VelocityChange);

    internal void DestroyCannonball(GameObject item)
    {
        Destroy(item);
        _bulletExplosion.ShowEffect(item.transform.position);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 6)
        {
            DestroyCannonball(gameObject);
        }
        else if (collision.gameObject.layer == 7)
        {
            var ship = collision.gameObject.GetComponent<PhotonView>();
            if (ship.Owner != _photonView.Owner)
                DestroyCannonball(collision.gameObject);
            else
                DestroyCannonball(gameObject);
        }
        else if (collision.gameObject.layer == 8)
        {
            var player = collision.gameObject.GetComponent<PhotonView>();

            if (player.Owner != _photonView.Owner)
            {
                DestroyCannonball(gameObject);
                applyDamage?.Invoke(_damage);
                player.RPC("TakeDamage", RpcTarget.Others, _damage);
            }
        }
    }
}