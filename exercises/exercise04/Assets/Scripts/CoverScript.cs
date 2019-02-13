using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoverScript : MonoBehaviour
{
    Vector3 startposition;

    // Start is called before the first frame update
    void Start()
    {
        startposition = gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, 60, 0) * Time.deltaTime);
    }
}
