using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VictoryZone : MonoBehaviour
{
    [SerializeField] Image _scroll;
    [SerializeField] Button _further;
    [SerializeField] Button _improvement;
    [SerializeField] Text _text;

    private void OnTriggerEnter(Collider other)
    {
        Time.timeScale = 0;
        _scroll.gameObject.SetActive(true);
        _further.gameObject.SetActive(true);
        _improvement.gameObject.SetActive(true);
        _text.text = "Completed";
    }
}
