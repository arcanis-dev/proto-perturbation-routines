using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StockController : MonoBehaviour {
    public List<GameObject> cubes;
    public int cubesNumber;

    public void UpdateCubesNumber() {
        this.cubesNumber = this.cubes.Count;
    }

    public GameObject GetCubeByColor(string color) {
        GameObject cubeByColor = null;
        if (this.cubesNumber > 0) {
            foreach (var item in this.cubes) {
                if (item.GetComponent<CubeScript>().color == color) {
                    cubeByColor = item;
                }
            }
        }

        return cubeByColor;
    }

}
