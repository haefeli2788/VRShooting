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
        //var count = 0;
       // if (count == int.Parse(GameObject.GetChild(0).GetChild(0).GetComponent<Text>().text) - 1){
            Destroy(gameObject);
       // count++;

      // }
    }
}