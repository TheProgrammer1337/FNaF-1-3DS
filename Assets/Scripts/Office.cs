using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Office : MonoBehaviour {
    public GameObject LeftLightBar;
    public GameObject RightLightBar;

    public GameObject LeftDoor;
    public GameObject RightDoor;


    public GameObject LowerCanvas;

    public Sprite LeftLightBarLight;
    public Sprite LeftLightBarNone;

    public Sprite RightLightBarLight;
    public Sprite RightLightBarNone;

    public Sprite NoLight;
	public Sprite LeftLight;
    public Sprite RightLight;

    public Sprite LeftLightBonnie;
    public Sprite RightLightChica;

    public AudioSource LightSound;
    public AudioSource DoorSound;
    public AudioSource error;

    float leftdoorcooldown;
    float rightdoorcooldown;
    public bool leftlighton;
    public bool rightlighton;

    public bool leftdoorclosed;
    public bool rightdoorclosed;
    public Movement movement;

    public TimeAndPower timeandpower;

    bool done;
    public bool cancamera;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        leftdoorcooldown -= Time.deltaTime;
        rightdoorcooldown -= Time.deltaTime;
        if (Input.GetKey(KeyCode.LeftArrow))
		{
			if (transform.localPosition.x < 69)
			{
				transform.localPosition += new Vector3(4, 0);
			}
		}
        if (Input.GetKey(KeyCode.RightArrow))
        {
            if (transform.localPosition.x > -75)
            {
                transform.localPosition -= new Vector3(4, 0);
            }
        }
		if (Input.GetKeyDown(KeyCode.B))
		{
            if (transform.localPosition.x >= 69)
            {
                leftlighton = true;
                rightlighton = false;
                if (movement.BonnieLocation == "LEFTDOOR")
                {
                    gameObject.GetComponent<Image>().sprite = LeftLightBonnie;
                    LeftLightBar.GetComponent<Image>().sprite = LeftLightBarLight;
                    LightSound.Play();
                    timeandpower.PowerUsage += 1;
                }
                else if (movement.BonnieLocation != "INSIDE")
                {
                    gameObject.GetComponent<Image>().sprite = LeftLight;
                    LeftLightBar.GetComponent<Image>().sprite = LeftLightBarLight;
                    LightSound.Play();
                    timeandpower.PowerUsage += 1;
                }
                else
                {
                    error.Play();
                }

                done = false;
            }
            if (transform.localPosition.x <= -76.2)
            {
                leftlighton = false;
                rightlighton = true;
                if (movement.ChicaLocation == "RIGHTDOOR")
                {
                    gameObject.GetComponent<Image>().sprite = RightLightChica;
                    RightLightBar.GetComponent<Image>().sprite = RightLightBarLight;
                    LightSound.Play();
                    timeandpower.PowerUsage += 1;
                    done = false;
                }
                else if (movement.ChicaLocation != "INSIDE")
                {
                    gameObject.GetComponent<Image>().sprite = RightLight;
                    RightLightBar.GetComponent<Image>().sprite = RightLightBarLight;
                    LightSound.Play();
                    timeandpower.PowerUsage += 1;
                    done = false;
                }
                else
                {
                    error.Play();
                }

            }

        }
        if (Input.GetKeyUp(KeyCode.B))
        {
            if (done == false)
            {
                gameObject.GetComponent<Image>().sprite = NoLight;
                LeftLightBar.GetComponent<Image>().sprite = LeftLightBarNone;
                RightLightBar.GetComponent<Image>().sprite = RightLightBarNone;
                LightSound.Stop();
                timeandpower.PowerUsage -= 1;
                leftlighton = false;
                rightlighton = false;
                done = true;
                
            }

        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            if (transform.localPosition.x >= 69 && leftdoorcooldown < 0)
            {
                if (movement.BonnieLocation != "INSIDE")
                {
                    leftdoorcooldown = 0.3f;
                    Debug.Log("Epic");
                    DoorSound.Play();
                    if (leftdoorclosed == true)
                    {
                        LeftDoor.GetComponent<Animator>().Play("LeftdoorOpen");
                        timeandpower.PowerUsage -= 1;
                        leftdoorclosed = false;
                    }
                    else
                    {
                        LeftDoor.GetComponent<Animator>().Play("Close");
                        timeandpower.PowerUsage += 1;
                        leftdoorclosed = true;
                        LeftDoor.SetActive(true);
                    }   
                }
                else
                {
                    error.Play();
                }

            }
            if (transform.localPosition.x <= -76.2 && rightdoorcooldown < 0)
            {
                if (movement.ChicaLocation != "INSIDE")
                {
                    rightdoorcooldown = 0.3f;

                    Debug.Log("Epic");
                    DoorSound.Play();

                    if (rightdoorclosed == true)
                    {
                        RightDoor.GetComponent<Animator>().Play("Rightdooropen");
                        timeandpower.PowerUsage -= 1;
                        rightdoorclosed = false;
                    }
                    else
                    {
                        RightDoor.GetComponent<Animator>().Play("Rightdoorclose");
                        timeandpower.PowerUsage += 1;
                        rightdoorclosed = true;
                        RightDoor.SetActive(true);
                    }
                }
                else
                {
                    error.Play();
                }

            }

        }
    }

}
