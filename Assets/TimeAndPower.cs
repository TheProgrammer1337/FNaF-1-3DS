using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TimeAndPower : MonoBehaviour {
	public float Time = 360;
    int PowerLeft = 101;
    public float PowerDrain = 6;
    public int PowerUsage = 1;
    public GameObject TimeCounter;
    public GameObject PowerCounter;
    public GameObject PowerCounterBar;

    public Sprite PowerBar1;
    public Sprite PowerBar2;
    public Sprite PowerBar3;
    public Sprite PowerBar4;
    public Sprite PowerBar5;


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Time -= UnityEngine.Time.deltaTime;
        switch (PowerUsage)
        {
            case 1:
                PowerCounterBar.GetComponent<Image>().sprite = PowerBar1;
                break;
            case 2:
                PowerCounterBar.GetComponent<Image>().sprite = PowerBar2;
                break;
            case 3:
                PowerCounterBar.GetComponent<Image>().sprite = PowerBar3;
                break;
            case 4:
                PowerCounterBar.GetComponent<Image>().sprite = PowerBar4;
                break;
            case 5:
                PowerCounterBar.GetComponent<Image>().sprite = PowerBar5;
                break;
            default:
                break;
        }
        if (Time <= 360)
        {
            TimeCounter.GetComponent<Text>().text = "12 AM";
        }

        if (Time <= 300)
        {
            TimeCounter.GetComponent<Text>().text = "1 AM";
        }

        if (Time <= 240)
        {
            TimeCounter.GetComponent<Text>().text = "2 AM";
        }

        if (Time <= 180)
        {
            TimeCounter.GetComponent<Text>().text = "3 AM";
        }

        if (Time <= 120)
        {
            TimeCounter.GetComponent<Text>().text = "4 AM";
        }

        if (Time <= 60)
        {
            TimeCounter.GetComponent<Text>().text = "5 AM";
        }

        if (Time <= 0)
        {
            TimeCounter.GetComponent<Text>().text = "6 AM";

        }
        if (PowerUsage <= 0)
        {
            PowerUsage = 1;
        }

        if (PowerUsage >= 5)
        {
            PowerUsage = 5;
        }

        if (PowerUsage == 1)
        {
            PowerDrain -= UnityEngine.Time.deltaTime;

            if (PowerDrain <= 0)
            {
                PowerLeft -= 1;
                PowerCounter.GetComponent<Text>().text = "Power left: " + PowerLeft.ToString() + "%";
                PowerDrain = 8;
            }

        }

        if (PowerUsage == 2)
        {
            PowerDrain -= UnityEngine.Time.deltaTime;

            if (PowerDrain <= 0)
            {
                PowerLeft -= 1;
                PowerCounter.GetComponent<Text>().text = "Power left: " + PowerLeft.ToString() + "%";
                PowerDrain = 4.5f;
            }

        }

        if (PowerUsage == 3)
        {
            PowerDrain -= UnityEngine.Time.deltaTime;

            if (PowerDrain <= 0)
            {
                PowerLeft -= 1;
                PowerCounter.GetComponent<Text>().text = "Power left: " + PowerLeft.ToString() + "%";
                PowerDrain = 2.3f;
            }


        }

        if (PowerUsage == 4)
        {
            PowerDrain -= UnityEngine.Time.deltaTime;

            if (PowerDrain <= 0)
            {
                PowerLeft -= 1;
                PowerCounter.GetComponent<Text>().text = "Power left: " + PowerLeft.ToString() + "%";
                PowerDrain = 1.1f;
            }


        }

        if (PowerUsage == 5)
        {
            PowerDrain -= UnityEngine.Time.deltaTime;

            if (PowerDrain <= 0)
            {
                PowerLeft -= 1;
                PowerCounter.GetComponent<Text>().text = "Power left: " + PowerLeft.ToString() + "%";
                PowerDrain = 0.6f;
            }

        }
    }
}
