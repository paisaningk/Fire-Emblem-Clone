using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class GridManager : MonoBehaviour
{
   [SerializeField] private int width;
   [SerializeField] private int height;
   [SerializeField] private Tile tilePrefab;
   [SerializeField] private Transform cam;

   public void Start()
   {
      GenerateGrid();
   }

   private void GenerateGrid()
   {
      for (int x = 0; x < width; x++)
      {
         for (int y = 0; y < height; y++)
         {
            var spawnTile = Instantiate(tilePrefab, new Vector3(x, y), quaternion.identity);
            spawnTile.name = $"Tile {x} {y}";

            var isOffset = (x % 2 == 0 && y % 2 != 0) || (x % 2 != 0 && y % 2 == 0);
            spawnTile.Init(isOffset);
            spawnTile.transform.parent = gameObject.transform;
         }
      }

      cam.transform.position = new Vector3((float) width / 2 - 0.5f, (float) height / 2 - 0.5f,-10);
   }
}
