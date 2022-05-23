using System;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(GridSystem))]
public class MoveUnit : MonoBehaviour
{
    [SerializeField] private LayerMask layerUnit;
    [SerializeField] private List<GameObject> selectUnitList;
    private GridSystem gridSystem;
    private Camera cameraMain;

    private void Start()
    {
        cameraMain = Camera.main;
        gridSystem = GetComponent<GridSystem>();
    }

    private void Update()
    {
        CheckInput();
    }

    private void CheckInput()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            CommandAddUnit();
        }
        else if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            MoveUnits();
        }
    }

    private void CommandAddUnit()
    {
        AddUnitToSelectUnitList(GetHitFromLayerUnit().transform.gameObject);
    }
    
    private void AddUnitToSelectUnitList(GameObject other)
    {
        if (selectUnitList.Contains(other)) return;
        selectUnitList.Add(other);
    }
    
    private void MoveUnits()
    {
        foreach (var unit in selectUnitList)
        {
            gridSystem.MoveUnitToPosition(unit);
        }
    }
    
    private RaycastHit GetHitFromLayerUnit()
    {
        var ray = cameraMain.ScreenPointToRay(Input.mousePosition);
        Physics.Raycast(ray, out var hit, Mathf.Infinity, layerUnit);
        return hit;
    }
}