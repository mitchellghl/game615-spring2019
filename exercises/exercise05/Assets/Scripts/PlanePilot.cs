using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanePilot : MonoBehaviour
{

    public float speed;
    public float bias = 0.96f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 MoveCamTo = transform.position - transform.forward * 10f + Vector3.up * 5f;
        Camera.main.transform.position = Camera.main.transform.position * bias + MoveCamTo * (1f-bias);
        Camera.main.transform.LookAt(transform.position + transform.forward * 30f);

        speed -= transform.forward.y * Time.deltaTime * 20f;
        if(speed < 20f)
        {
            speed = 20f;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            speed = 0f;
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            speed = 40f;
        }

        transform.position += transform.forward * Time.deltaTime * speed;
        transform.Rotate(-Input.GetAxis("Vertical"), 0.0f, -Input.GetAxis("Horizontal"));

        float TerrainHeightWhereWeAre = Terrain.activeTerrain.SampleHeight(transform.position);

        if(TerrainHeightWhereWeAre > transform.position.y)
        {
            transform.position = new Vector3(transform.position.x, TerrainHeightWhereWeAre, transform.position.z);
        }


    }


}
