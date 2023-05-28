using UnityEngine;
using Photon.Pun;

public class ShipManager : MonoBehaviour
{
    [SerializeField] private Explosion _shipExplosion;
    
    private protected void Movement(CharacterController character, Vector3 targetPoint, int speed)
    {
        character.Move(Time.deltaTime * targetPoint * speed);
    }

    private protected void ApplyDamage(Collision collision, PhotonView photonView, GameObject ship, int damage)
    {
        if (collision.gameObject.layer == 8)
        {
            Destroy(ship);
            var player = collision.gameObject.GetComponent<PhotonView>();

            if (player.Owner != photonView.Owner)
            {
                Cannonball.applyDamage(damage);
                player.RPC("TakeDamage", RpcTarget.Others, damage);//return all viewers(only UI)
            }
        }
    }

    private void DestroyShip(GameObject ship)
    {
        _shipExplosion.ShowEffect(ship.transform.position);
        Destroy(ship);
    }
}

