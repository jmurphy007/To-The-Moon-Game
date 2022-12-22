using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class generate : MonoBehaviour
{
    [SerializeField]
    private GameObject[] _prefabs;
    // Create an empty prefab list to use in the generator, can be set to however many the user wants.
    [SerializeField]
    private int Height;
    // Input for the maximum height the objects will generate at
    [SerializeField]
    private int Range;
    // Input for how far away the objects can generate at
    [SerializeField]
    private int Density;
    // Input for how dense the objects will generate at (larger numbers are not recommended)

    private float startY;

    // Start is called before the first frame update
    void Start()
    {
        startY = transform.position.y;
        int Length = _prefabs.Length;
        /* Gets the length of the array of prefabs that the user entered before starting the game
         Then makes an instance of each object based on the height, range, and density parameters*/
        for (int h = 0; h < Height; h++)
        {
            for (int i = 0; i < Length; i++)
            {
                for (int j = 0; j < Density; j++)
                {
                    Instantiate(_prefabs[i], new Vector3(Random.Range(-(Range), Range), Random.Range(startY, (startY + Height)), Random.Range(-(Range), Range)), (Quaternion.identity * _prefabs[i].transform.localRotation));
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
