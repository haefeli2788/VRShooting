using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[RequireComponent(typeof(Text))]

public class Score : MonoBehaviour {
    Text uiText;
    public int Points { get; private set; }
	void Start ()
    {
        uiText = GetComponent<Text>();
	}
    public void AddScore(int addPoint)
    {
        Points += addPoint;
        uiText.text = string.Format("特点：{0:D3}点", Points);
	}
}
