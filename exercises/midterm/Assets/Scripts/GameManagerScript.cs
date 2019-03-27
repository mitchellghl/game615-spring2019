using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    public GameObject player;

    public GameObject Door1;
    public GameObject Door2;
    public GameObject Door3;
    public GameObject Door4;
    public GameObject Door5;
    public GameObject Door6;

    public GameObject Platform1;
    public GameObject Platform2;
    public GameObject Platform3;
    public GameObject Platform4;
    public GameObject Platform5;

    public GameObject Battery1;
    public GameObject Battery2;
    public GameObject Battery3;
    public GameObject Battery4;
    public GameObject Battery5;
    public GameObject Battery6;
    public GameObject Battery7;
    public GameObject Battery8;
    public GameObject Battery9;
    public GameObject Battery10;
    public GameObject Battery11;
    public GameObject Battery12;
    public GameObject Battery13;
    public GameObject Battery14;

    public GameObject Switch1;
    public GameObject Switch2;
    public GameObject Switch3;
    public GameObject Switch4;
    public GameObject Switch5;

    bool Winner;

    public GameObject GameOver;

    // Start is called before the first frame update
    void Start()
    {
        Door1.SetActive(true);
        Door2.SetActive(true);
        Door3.SetActive(true);
        Door4.SetActive(true);
        Door5.SetActive(true);
        Door6.SetActive(true);
        Platform1.SetActive(false);
        Platform2.SetActive(true);
        Platform3.SetActive(true);
        Platform4.SetActive(true);
        Platform5.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (Battery1.GetComponent<BatteryScript>().powered)
        {
            Battery1.GetComponent<BatteryScript>().solved = true;
            Door1.SetActive(false);
        }

        if (Battery2.GetComponent<BatteryScript>().powered && Battery3.GetComponent<BatteryScript>().powered)
        {
            Battery2.GetComponent<BatteryScript>().solved = true;
            Battery3.GetComponent<BatteryScript>().solved = true;
            Door2.SetActive(false);
        }

        if (Battery4.GetComponent<BatteryScript>().powered && Battery5.GetComponent<BatteryScript>().powered)
        {
            Battery4.GetComponent<BatteryScript>().solved = true;
            Battery5.GetComponent<BatteryScript>().solved = true;
            Door3.SetActive(false);
        }

        if (Battery6.GetComponent<BatteryScript>().powered && Battery7.GetComponent<BatteryScript>().powered 
            && Battery8.GetComponent<BatteryScript>().powered && Battery9.GetComponent<BatteryScript>().powered)
        {
            Battery6.GetComponent<BatteryScript>().solved = true;
            Battery7.GetComponent<BatteryScript>().solved = true;
            Battery8.GetComponent<BatteryScript>().solved = true;
            Battery9.GetComponent<BatteryScript>().solved = true;
            Door4.SetActive(false);
            player.GetComponent<PlayerController>().respawnLocation = player.GetComponent<PlayerController>().respawnLocation2;
        }

        if (Switch1.GetComponent<BatteryScript>().powered)
        {
            Switch1.GetComponent<BatteryScript>().solved = true;
            Platform1.SetActive(true);
        }

        if (Battery10.GetComponent<BatteryScript>().powered)
        {
            Battery10.GetComponent<BatteryScript>().solved = true;
            Door5.SetActive(false);
        }

        if (Switch2.GetComponent<BatteryScript>().powered)
        {
            Switch2.GetComponent<BatteryScript>().solved = true;
            Platform2.SetActive(false);
        }

        if (Switch3.GetComponent<BatteryScript>().powered)
        {
            Switch3.GetComponent<BatteryScript>().solved = true;
            Platform3.SetActive(false);
        }

        if (Switch4.GetComponent<BatteryScript>().powered)
        {
            Switch4.GetComponent<BatteryScript>().solved = true;
            Platform4.SetActive(false);
        }

        if (Switch5.GetComponent<BatteryScript>().powered)
        {
            Switch5.GetComponent<BatteryScript>().solved = true;
            Platform5.SetActive(false);
        }

        if (Battery11.GetComponent<BatteryScript>().powered && Battery12.GetComponent<BatteryScript>().powered)
        {
            Battery11.GetComponent<BatteryScript>().solved = true;
            Battery12.GetComponent<BatteryScript>().solved = true;
            Door6.SetActive(false);
        }

        if (Battery13.GetComponent<BatteryScript>().powered && Battery14.GetComponent<BatteryScript>().powered)
        {
            Battery13.GetComponent<BatteryScript>().solved = true;
            Battery14.GetComponent<BatteryScript>().solved = true;
            Winner = true;
            player.GetComponent<PlayerController>().Winner = true;
        }

        if (Winner)
        {
            GameOver.SetActive(true);
        }
    }
}
