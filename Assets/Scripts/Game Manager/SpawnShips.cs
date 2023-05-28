using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class SpawnShips : MonoBehaviour
{
    [SerializeField] private List<GameObject> _ships = new List<GameObject>();
    [SerializeField] private List<Transform> _spawnPlaces = new List<Transform>();
    [SerializeField] private CoinWallet _wallet;
    [SerializeField] private PlayerUI _playerUI;
    private int _birdShipPrice = 4;
    private int _speedShipPrice = 6;
    private int _colonianShipPrice = 8;
    private int _pirateBoatPrice = 7;
    private int _pirateShipPrice = 10;

    public void CreateBirdShip()
    {
        if (_wallet._coin >= _birdShipPrice)
        {
            SetSpawnPosition(_ships[0].name, _spawnPlaces[0].position, Quaternion.Euler(0f, -90f, 0f));
            _wallet.Decrease—oinCount(_birdShipPrice);
        }
        else
            StartCoroutine(_playerUI.PurchaseInfo(_birdShipPrice - _wallet._coin));
    }

    public void CreateSpeedShip()
    {
        if (_wallet._coin >= _speedShipPrice)
        {
            SetSpawnPosition(_ships[1].name, _spawnPlaces[1].position, Quaternion.Euler(0f, -90f, 0f));
            _wallet.Decrease—oinCount(_speedShipPrice);
        }
        else
            StartCoroutine(_playerUI.PurchaseInfo(_speedShipPrice - _wallet._coin));
    }

    public void CreateColonianShip()
    {
        if (_wallet._coin >= _colonianShipPrice)
        {
            SetSpawnPosition(_ships[2].name, _spawnPlaces[2].position, Quaternion.Euler(0f, 180f, 0f));
            _wallet.Decrease—oinCount(_pirateShipPrice);
        }
        else
            StartCoroutine(_playerUI.PurchaseInfo(_colonianShipPrice - _wallet._coin));
    }

    public void CreatePirateBoat()
    {
        if (_wallet._coin >= _pirateBoatPrice)
        {
            SetSpawnPosition(_ships[3].name, _spawnPlaces[3].position, Quaternion.Euler(0f, 90f, 0f));
            _wallet.Decrease—oinCount(_pirateShipPrice);
        }
        else
            StartCoroutine(_playerUI.PurchaseInfo(_pirateBoatPrice - _wallet._coin));
    }

    public void CreatePirateShip()
    {
        if (_wallet._coin >= _pirateShipPrice)
        {
            SetSpawnPosition(_ships[4].name, _spawnPlaces[4].position, Quaternion.identity);
            _wallet.Decrease—oinCount(_pirateShipPrice);
        }
        else
            StartCoroutine(_playerUI.PurchaseInfo(_pirateShipPrice - _wallet._coin));
    }

    private void SetSpawnPosition(string ship, Vector3 spawnPosition, Quaternion quaternion)
    {
        PhotonNetwork.Instantiate(ship, spawnPosition, quaternion);
    }
}