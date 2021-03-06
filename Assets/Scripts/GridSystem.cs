using System;
using Unity.Mathematics;
using UnityEngine;

[RequireComponent(typeof(MoveUnit))]
public class GridSystem : MonoBehaviour
{
    [SerializeField] private float cellSizeX;
    [SerializeField] private float cellSizeY;
    [SerializeField] private GameObject mainTerrain;

    internal void MoveUnitToPosition(GameObject unit)
    {
        unit.transform.position = GetPositionFromIndex(GetRaycastHit().point);
    }

    private RaycastHit GetRaycastHit()
    {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Physics.Raycast(ray, out var hit);
        return hit;
    }


    private Vector3 GetPositionFromIndex(Vector3 position)
    {
        GetCellIndex(position, out var indexX, out var indexY);
        GetCellCenterPos(indexX, indexY, out var newPosition);

        return newPosition;
    }

    private void GetCellIndex(Vector3 position, out int indexX, out int indexY)
    {
        Vector3 transformPosition = mainTerrain.transform.position;
        indexX = Mathf.FloorToInt((position.x - transformPosition.x) / cellSizeX);
        indexY = Mathf.FloorToInt((position.y - transformPosition.y) / cellSizeY);

    }

    private void GetCellCornerPos(int indexX, int indexY, out Vector3 position)
    {
        Vector3 transformPosition = mainTerrain.transform.position;
        position.x = (indexX * cellSizeX + transformPosition.x);
        position.y = (indexY * cellSizeY + transformPosition.y);
        position.z = 0.1f;
    }

    private void GetCellCenterPos(int indexX, int indexY,out Vector3 position)
    {
        GetCellCornerPos(indexX, indexY, out position);
            
        position.x += cellSizeX / 2;
        position.y += cellSizeX / 2;
    }
        
}