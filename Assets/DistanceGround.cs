using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceGround : MonoBehaviour
{

	public float height;
	RaycastHit hit;

    // Update is called once per frame
    void Update()
    {
	Ray ray = new Ray(transform.position, -Vector3.up);
	Debug.DrawRay(transform.position, Vector3.down * height, Color.red);
	
	if (Physics.Raycast(ray, out hit))
	{
		if(hit.collider.tag == "ground")
		{
			Debug.Log(hit.distance);
		}
	}
        
    }
}
