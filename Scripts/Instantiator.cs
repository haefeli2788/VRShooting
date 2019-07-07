using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Instantiator : MonoBehaviour
{
    public GameObject cube;

    Vector3 GeneratedPosition()
    {
        int x, y, z;
        x = UnityEngine.Random.Range(-20, 20);
        y = UnityEngine.Random.Range(5, 20);
        z = UnityEngine.Random.Range(0, 20);
        return new Vector3(x, y, z);
    }

    void Start()
    {
        for (int i = 0; i < 30; i++)
        {
            GameObject new_cube = Instantiate(cube, GeneratedPosition(), Quaternion.identity);
            new_cube.transform.GetChild(0).GetChild(0).GetComponent<Text>().text = "" + (i + 1);
            new_cube.transform.GetComponent<Renderer>().material.color = UnityEngine.Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
        }
    }



}
