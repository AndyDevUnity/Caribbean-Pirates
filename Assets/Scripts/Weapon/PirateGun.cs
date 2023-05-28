using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;

public class PirateGun : MonoBehaviour
{
    [SerializeField] private Explosion _bulletExplosion;
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private Trajectory _trajectory;
    [SerializeField] private Transform _shotPoint;
    [SerializeField] private float _shootrate;
    private PhotonView _photonView;
    private Camera _mainCamera;
    private Vector3 _shotTarget;
    [Header("Reloading")]
    [SerializeField] private Image _reloadingProgress;
    [SerializeField] private GameObject _reloadingIcon;


    private void Start()
    {
        _mainCamera = Camera.main;
        _photonView = GetComponent<PhotonView>();
        _shootrate = Time.time + 8.5f;
    }

    private void Update()
    {
        if (_photonView.IsMine)
        {
            if (Input.GetKeyDown(KeyCode.Space) && Time.time > _shootrate)
                Shooting();

            ChangeShootingTarget();
            ReloadingGun();
        }
    }

    private void ChangeShootingTarget()
    {
        float hitPoint;
        Ray ray = _mainCamera.ScreenPointToRay(Input.mousePosition);
        new Plane(Vector3.up, Vector3.zero).Raycast(ray, out hitPoint);
        Vector3 mouseInWorld = ray.GetPoint(hitPoint);
        _shotTarget = (mouseInWorld - _shotPoint.position);
    }

    private void Shooting()
    {
        var bullet = PhotonNetwork.Instantiate(_bulletPrefab.name, _shotPoint.position, Quaternion.identity).GetComponent<Cannonball>();
        bullet.MoveCannonball(_shotTarget);
        float shotDelay = 4f;
        _shootrate = Time.time + shotDelay;
        _bulletExplosion.ShowEffect(_shotPoint.position);

    }

    private void ReloadingGun()
    {
        _reloadingProgress.fillAmount = _shootrate - Time.time;

        if (Time.time < _shootrate)
        {
            _reloadingIcon.SetActive(true);
            _trajectory.gameObject.SetActive(false);
        }
        else
        {
            _reloadingIcon.SetActive(false);
            _trajectory.gameObject.SetActive(true);
            _trajectory.ShowTrajectory(_shotPoint.position, _shotTarget);
        }
    }
}