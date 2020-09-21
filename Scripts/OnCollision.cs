using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnCollision : MonoBehaviour
{
    //public GameObject cube;

    public void OnHitBullet()
    {
        var count = 0;
        var cube = int.Parse(transform.GetChild(0).GetChild(0).GetComponent<Text>().text) - 1;
        if (count == cube){
            Destroy(gameObject);
            Debug.Log(cube);

       }
        count++;
    }
}