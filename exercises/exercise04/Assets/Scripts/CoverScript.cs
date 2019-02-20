using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoverScript : MonoBehaviour
{

    public bool bombed;
    float timer = 0f;

    // Start is called before the first frame update
    void Start()
    {
        bombed = false;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, 60, 0) * Time.deltaTime);
        if(bombed == true)
        {
            GetComponent<Collider>().enabled = false;
            GetComponent<MeshRenderer>().enabled = false;
            timer += Time.deltaTime;
            if(timer > 2)
            {
                bombed = false;
                timer = 0f;
                GetComponent<Collider>().enabled = true;
                GetComponent<MeshRenderer>().enabled = true;
            }
        }
    }

}
