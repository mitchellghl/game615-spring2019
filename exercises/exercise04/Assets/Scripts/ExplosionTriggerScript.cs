using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionTriggerScript : MonoBehaviour
{
    public float magnitude;
    public float air;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.name == "Player1" || col.gameObject.name == "Player2")
        {
            Vector3 vectorToTarget = col.transform.position - transform.position;
            vectorToTarget = vectorToTarget.normalized;
            Rigidbody rb = col.GetComponent<Rigidbody>();
            rb.AddForce(vectorToTarget * magnitude);
            rb.AddForce(Vector3.up * air);
        }

        if(col.gameObject.name == "Cover")
        {
            col.GetComponent<CoverScript>().bombed = true;
        }
    }

}
