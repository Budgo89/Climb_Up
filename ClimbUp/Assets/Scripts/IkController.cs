using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IkController : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    public string[] tags;
    private Transform curObj;

    public void OnAnimatorIK(int layerIndex)
    {
        if (Input.GetMouseButton(0))
        {
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out var hit, 100))
            {
                if (GetTag(hit.collider.transform.tag) && hit.rigidbody && !curObj)
                {
                    _animator.SetLookAtPosition(hit.transform.position);
                    _animator.SetLookAtWeight(1);
                }
            }
            else _animator.SetLookAtWeight(0);
        }
    }

    bool GetTag(string curTag)
    {
        bool result = false;
        foreach (string t in tags)
        {
            if (t == curTag) result = true;
        }
        return result;
    }
}
