using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    void OnHitBullet() {
        Destroy(gameObject);


    }

}
