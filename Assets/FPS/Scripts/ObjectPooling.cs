using System;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooling : MonoBehaviour
{
    [SerializeField] private int dimension;
    [SerializeField] private GameObject cube;
    [SerializeField] private GameObject[,] cubesArray;
    private Vector3 cubePos;
    [SerializeField] private bool can;

    private void Awake()
    {
        int noOfCubes = dimension * dimension;
        cubesArray = new GameObject[dimension,dimension];
        for (int i = 0; i < dimension; i++)
        {
            for (int j = 0; j < dimension; j++)
            {
                GameObject instantiatedCube = Instantiate(cube);
                cubesArray[i,j] = instantiatedCube;
                cube.SetActive(false);
            }
        }
    }

    private void Start()
    {
        Array.Clear(cubesArray, 0, dimension * dimension);
        Debug.Log(cubesArray);
    }

    private void Update()
    {
        if (!can)
        {
            can = true;
            dimensionArrangement();
        }
    }
    private void dimensionArrangement()
    {
        cubePos = new Vector3(0, 0, 0);
        //int index = 0;
        //for (int i = 0; i < dimension; i++)
        //{
        //    for (int j = 0; j <= dimension; j++)
        //    {
        //        if (cubesArray[i + j].activeSelf)
        //            continue;
        //        Debug.Log("i " + i + " : " + "j " + j);
        //        cubesInList[i + j].transform.position = new Vector3(i , j , 0);
        //        cubesInList[i + j].SetActive(true);
        //        index++;
        //    }
        //}
        for (int i = 0; i < dimension; i++)
        {
            for (int j = 0; j < dimension; j++)
            {
                cubesArray[i, j].transform.position = new Vector3(i, j, 0);
                cubesArray[i, j].SetActive(true);
            }
        }
    }
}
