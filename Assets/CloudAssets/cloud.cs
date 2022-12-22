using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cloud : MonoBehaviour
{
    private float range = 0.125f;
    private float current = 0f;
    private float direction = 0.125f;
    private float timer = 0.0f;

    private float x, y, z;

    // Start is called before the first frame update
    void Start()
    {
        x = transform.position.x;
        y = transform.position.y;
        z = transform.position.z;
    }
    
    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        current += Time.deltaTime * direction;
        if (current >= range)
        {
            direction *= -1;
            current = range;
        }
        else if (current <= (-(range)))
        {
            direction *= -1;
            current = -(range);
        }
        transform.position = new Vector3((x - (current/2)), (y + current), (z - (current/2)));
    }
}
