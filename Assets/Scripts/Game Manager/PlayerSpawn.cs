using UnityEngine;
using Photon.Pun;

public class PlayerSpawn : MonoBehaviour
{
    [SerializeField] private GameObject _playerPrefab;
    private Camera _mainCamera;

    private void Start()
    {
        _mainCamera = Camera.main;

        if (PhotonNetwork.IsMasterClient)
        {
            SelectPlayerCamera(new Vector3(0f, 490.5f, -5.5f), Quaternion.Euler(75f, 0f, 0f));
            CreatePlayer(_playerPrefab, new Vector3(0f, 0f, 69.4f), Quaternion.identity);
        }
        else
        {
            SelectPlayerCamera(new Vector3(0f, 490.5f, 198f), Quaternion.Euler(81.65f, 180f, 0f));
            CreatePlayer(_playerPrefab, new Vector3(0f, 0f, 182.7f), Quaternion.Euler(0f, 180f, 0f));
        }
    }

    private void CreatePlayer(GameObject item, Vector3 position, Quaternion rotation)
    {
        PhotonNetwork.Instantiate(item.name, position, rotation);
    }

    private void SelectPlayerCamera(Vector3 position, Quaternion rotation)
    {
        _mainCamera.transform.position = position;
        _mainCamera.transform.rotation = rotation;
    }
}
