using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Shooter : MonoBehaviour
{


    [SerializeField] GameObject bulletPrefab;
    [SerializeField] Transform gunBarrelEnd;


    private void Update()
    {
        Debug.Log(VolumeFromMic.MicLoudnessinDecibels);
        //Debug.Log(VolumeFromMic.MicLoudnessinDecibels > -40.0f);


        //調節して
        if (VolumeFromMic.MicLoudnessinDecibels > -40.0f)
        {
            Shoot();
        }
    }

//        if (Input.GetButtonDown("Fire1"))
//        {
//            Shoot();
//}
    //}


    private void Shoot()
    {
        Instantiate(bulletPrefab, gunBarrelEnd.position, gunBarrelEnd.rotation);

        //gunParticle.Play();
    }
}
