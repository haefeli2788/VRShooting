﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Example : MonoBehaviour {

	// Use this for initialization
	void Start () {

        Debug.Log("[Start]");
		
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKey(KeyCode.Space))
        {
            Debug.Log("[UPdate] Space Key Pressed");
        }
		
	}
}
