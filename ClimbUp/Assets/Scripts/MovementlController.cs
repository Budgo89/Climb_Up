using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementlController : MonoBehaviour
{
    public string[] tags; // ������ �����, ������� ������� ����� �������
    public Camera _camera; // �������� ������ �����
    public enum ProjectMode { Project3D = 0, Project2D = 1 };
    public ProjectMode mode = ProjectMode.Project3D;
    public float step = 0.1f; // ��� ��� ��������� ������ � 3D
    private Transform curObj;
    private float mass;

    void Start()
    {
        if (mode == ProjectMode.Project2D) _camera.orthographic = true;
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

    void Update()
    {
        if (Input.GetMouseButton(0)) // ���������� ����� ������ ����
        {
            if (mode == ProjectMode.Project3D)
            {
                if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out var hit, 100))
                {
                    if (GetTag(hit.collider.transform.tag) && hit.rigidbody && !curObj)
                    {
                        curObj = hit.transform;
                        mass = curObj.GetComponent<Rigidbody>().mass;
                        //���������� ����� �������
                        curObj.GetComponent<Rigidbody>().mass = 0.0001f; // ������� �����, ����� �� ������� ������ �������
                        curObj.GetComponent<Rigidbody>().useGravity = false; // ������� ����������
                        curObj.GetComponent<Rigidbody>().freezeRotation = true; // ��������� ��������
                        //curObj.position += new Vector3(0, 0.5f, 0); // ������� ����������� ��������� ������                        
                    }
                }

                if (curObj)
                {
                    Vector3 cursorScreenPoint = new Vector3(hit.point.x, hit.point.y, hit.point.z);
                    curObj.GetComponent<Rigidbody>().MovePosition(new Vector3(cursorScreenPoint.x, cursorScreenPoint.y, curObj.position.z + Input.GetAxis("Mouse ScrollWheel") * step));
                }
            }
        }
        else if (curObj)
        {
            if (curObj.GetComponent<Rigidbody>())
            {
                curObj.GetComponent<Rigidbody>().freezeRotation = false;
                curObj.GetComponent<Rigidbody>().useGravity = true;
                curObj.GetComponent<Rigidbody>().mass = mass;
            }
            else
            {
                curObj.GetComponent<Rigidbody2D>().freezeRotation = false;
                curObj.GetComponent<Rigidbody2D>().mass = mass;
                curObj.GetComponent<Rigidbody2D>().gravityScale = 1;
            }
            curObj = null;
        }
    }
}
