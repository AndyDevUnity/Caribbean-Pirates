using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField] private GameObject _explosion;

    public void ShowEffect(Vector3 position)
    {
        var explosion = Instantiate(_explosion, position, Quaternion.identity);
        Destroy(explosion, 1.2f);
    }
}