using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LossZone : MonoBehaviour
{
    [SerializeField] Image _scroll;
    [SerializeField] Button _restart;
    [SerializeField] Text _text;

    private void OnTriggerEnter(Collider other)
    {
         if(other)
         {
            Time.timeScale = 0;
            _scroll.gameObject.SetActive(true);
            _restart.gameObject.SetActive(true);
            _text.text = "Fail";
         }
    }
}
