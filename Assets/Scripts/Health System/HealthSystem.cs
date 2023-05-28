using UnityEngine;
using Photon.Pun;
using System;

public class HealthSystem : MonoBehaviour
{
    private int _health = 100;
    private int _minHP = 0;
    public static Action<int> takeDamage;

    [PunRPC]
    private void TakeDamage(int damage)
    {
        _health -= damage;
        takeDamage?.Invoke(damage);

        if (_health <= _minHP)
            PhotonNetwork.LeaveRoom();
    }
}
