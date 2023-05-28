using System.Collections;
using TMPro;
using UnityEngine;

public class CoinWallet : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _count;
    internal int _coin = 0;

    private void Start()
    {
        StartCoroutine(CoinReplenishment());
    }

    public void Decrease�oinCount(int price)
    {
        _coin -= price;
        Debug.Log($"�������� {price} ��, �������� {_coin} ��.");
    }

    private IEnumerator CoinReplenishment()
    {
        yield return new WaitForSeconds(2.5f);
        _coin++;
        _count.text = _coin.ToString();
        StartCoroutine(CoinReplenishment());
    }
}
