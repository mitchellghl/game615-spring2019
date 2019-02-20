using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionScript : MonoBehaviour
{

    float timer = 0f;
    public GameObject Explosion;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > 2)
        {
            GameObject boom = Instantiate(Explosion, transform.position, transform.rotation);
            Destroy(boom, 0.75f);
            Destroy(gameObject);
        }
    }

}
