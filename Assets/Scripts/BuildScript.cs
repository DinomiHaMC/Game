using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

public class BuildScript : MonoBehaviour
{
    [SerializeField] private InventoryScript _inv;
    [SerializeField] private Transform _pos;
    [SerializeField] private ItemScript _wood;
    [SerializeField] private ItemScript _thread;

    [SerializeField] private List<GameObject> _buildList = new List<GameObject>();
    [SerializeField] private List<GameObject> _visualObjList = new List<GameObject>();

    [SerializeField] private int _buildObject = 0;
    [SerializeField] private float _scrollSpeed;
    [SerializeField] private bool _buildMode;

    public int BuildObject { get => _buildObject; set => _buildObject = value; }
    public bool BuildMode { get => _buildMode; set => _buildMode = value; }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.B))
        {
            _buildMode = !_buildMode;
        }

        if (_buildMode)
        {
            if (Input.GetKeyUp(KeyCode.Alpha1) || _buildObject == -1)
            {
                _visualObjList[1].SetActive(false);
                _visualObjList[2].SetActive(false);
                _visualObjList[3].SetActive(false);
                _buildObject = 0;
                _visualObjList[0].SetActive(true);
            }

            else if (Input.GetKeyUp(KeyCode.Alpha2))
            {
                _visualObjList[0].SetActive(false);
                _visualObjList[2].SetActive(false);
                _visualObjList[3].SetActive(false);
                _buildObject = 1;
                _visualObjList[1].SetActive(true);
            }

            else if (Input.GetKeyUp(KeyCode.Alpha3))
            {
                _visualObjList[0].SetActive(false);
                _visualObjList[1].SetActive(false);
                _visualObjList[3].SetActive(false);
                _buildObject = 2;
                _visualObjList[2].SetActive(true);
            }

            else if (Input.GetKeyUp(KeyCode.Alpha4))
            {
                _visualObjList[0].SetActive(false);
                _visualObjList[1].SetActive(false);
                _visualObjList[2].SetActive(false);
                _buildObject = 3;
                _visualObjList[3].SetActive(true);
            }

                var scroll = Input.mouseScrollDelta.y;
            int stepOffset = 1;

            if (scroll != 0)
            {
                _visualObjList[_buildObject].transform.Rotate(0, -scroll * _scrollSpeed, 0, Space.World);
            }

            if (Input.GetKeyDown(KeyCode.X))
            {
                _pos.Translate(Vector3.forward * stepOffset);
            }

            else if (Input.GetKeyDown(KeyCode.Z))
            {
                _pos.Translate(Vector3.back * stepOffset);
            }

            if (Input.GetMouseButtonUp(1) && _inv.WoodCount > 0 && _buildObject != 3)
            {
                Instantiate(_buildList[_buildObject], _pos.position, _visualObjList[_buildObject].transform.rotation);
                _inv.RemoveItem(_wood, 1);
            }
            else if (Input.GetMouseButtonUp(1) && _inv.WoodCount >= 2 && _inv.ThreadCount >= 2 && _buildObject == 3)
            {
                Instantiate(_buildList[_buildObject], _pos.position, _visualObjList[_buildObject].transform.rotation);
                _inv.RemoveItem(_wood, 2);
                _inv.RemoveItem(_thread, 2);
            }
        }

        else
        {
            if(_visualObjList[_buildObject])
            {
                _visualObjList[_buildObject].SetActive(false);
                _buildObject = -1;
            }
        }
    }
}
