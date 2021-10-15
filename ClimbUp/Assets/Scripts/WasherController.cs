using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WasherController : MonoBehaviour
{
    [SerializeField] private GameObject _washerLeft;
    [SerializeField] private GameObject _washerRight;
    [SerializeField] private GameObject _player;

    private void Update()
    {
        float dist = Vector3.Distance(_washerLeft.transform.position, _washerRight.transform.position);
        if (dist >= 2)
        {
            _player.GetComponent<RagdollController>().enabled = false;
        }
    }
}
