using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryScript : MonoBehaviour
{
    public bool powered = false;
    public bool solved = false;
    public float powerOff = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (solved == true)
        {
            transform.GetChild(2).gameObject.SetActive(true);
            transform.GetChild(2).gameObject.GetComponent<ParticleSystem>().startColor = new Color(0, 29, 253, 255);
        }
        if (solved == false)
        {
            if (powered == true)
            {
                transform.GetChild(2).gameObject.SetActive(true);
                if (powerOff < 5f)
                {
                    powerOff += Time.deltaTime;
                }
                if (powerOff >= 5f)
                {
                    powerOff = 0f;
                    powered = false;
                }
            }
            if (powered == false)
            {
                transform.GetChild(2).gameObject.SetActive(false);
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Player")
        {
            powered = true;
            powerOff = 0f;
        }
    }
}
