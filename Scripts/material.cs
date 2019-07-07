using UnityEngine;
using System.Collections;

public class ExampleClass : MonoBehaviour
{
    Material m_Material;


    public Material[] randomMaterials;
    public GameObject[] gameObjects;

    void Start()
    {
        //Simple way: create int array for indicate assign material
        int[] indMat = new int[randomMaterials.Length];
        //Just in case we initialize an array
        for (int i = 0; i < randomMaterials.Length; i++)
        {
            indMat[i] = 0; //not assign material
        }
        foreach (GameObject wall in gameObjects)
        {
            int num = Random.Range(0, randomMaterials.Length);

            while (indMat[num] != 0)
            {
                num++;
                if (num >= randomMaterials.Length)
                {
                    num = 0;
                }
            }

            indMat[num] = 1;
           //wall.renderer.material = randomMaterials[num];
        }
    }
}