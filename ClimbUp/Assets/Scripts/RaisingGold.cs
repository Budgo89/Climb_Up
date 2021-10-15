using UnityEngine;

public class RaisingGold : MonoBehaviour
{
    private GoldController gold;

    private void Awake()
    {
        gold = Camera.main.GetComponent<GoldController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        gameObject.SetActive(false);
        gold.AccrualOfGold();
    }
}
