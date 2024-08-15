using UnityEngine;
using UnityEngine.UI;

public class Office : MonoBehaviour
{
    public GameObject LeftLightBar;
    public GameObject RightLightBar;

    public GameObject LeftDoor;
    public GameObject RightDoor;


    public GameObject LowerCanvas;

    public Sprite LeftLightBarLightDoor;
    public Sprite LeftLightBarDoor;
    public Sprite LeftLightBarLight;
    public Sprite LeftLightBarNone;

    public Sprite RightLightBarDoor;
    public Sprite RightLightBarLightDoor;
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


    void Update()
    {
        leftdoorcooldown -= Time.deltaTime;
        rightdoorcooldown -= Time.deltaTime;

        if (Input.GetKey(KeyCode.LeftArrow) && transform.localPosition.x < 69)
        {
            transform.localPosition += new Vector3(4, 0);
        }
        if (Input.GetKey(KeyCode.RightArrow) && transform.localPosition.x > -75)
        {
            transform.localPosition -= new Vector3(4, 0);
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
                    LeftLightBar.GetComponent<Image>().sprite = leftdoorclosed ? LeftLightBarLightDoor : LeftLightBarLight;
                    LightSound.Play();
                    timeandpower.PowerUsage += 1;
                }
                else
                {
                    error.Play();
                }
                done = false;
            }
            else if (transform.localPosition.x <= -76.2)
            {
                leftlighton = false;
                rightlighton = true;
                if (movement.ChicaLocation == "RIGHTDOOR")
                {
                    gameObject.GetComponent<Image>().sprite = RightLightChica;
                    RightLightBar.GetComponent<Image>().sprite = RightLightBarLight;
                    LightSound.Play();
                    timeandpower.PowerUsage += 1;
                }
                else if (movement.ChicaLocation != "INSIDE")
                {
                    gameObject.GetComponent<Image>().sprite = RightLight;
                    RightLightBar.GetComponent<Image>().sprite = rightdoorclosed ? RightLightBarLightDoor : RightLightBarLight;
                    LightSound.Play();
                    timeandpower.PowerUsage += 1;
                }
                else
                {
                    error.Play();
                }
                done = false;
            }
        }

        if (Input.GetKeyUp(KeyCode.B) && !done)
        {
            gameObject.GetComponent<Image>().sprite = NoLight;
            LeftLightBar.GetComponent<Image>().sprite = leftdoorclosed ? LeftLightBarDoor : LeftLightBarNone;
            RightLightBar.GetComponent<Image>().sprite = rightdoorclosed ? RightLightBarDoor : RightLightBarNone;
            LightSound.Stop();
            timeandpower.PowerUsage -= 1;
            leftlighton = false;
            rightlighton = false;
            done = true;
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            if (transform.localPosition.x >= 69 && leftdoorcooldown < 0)
            {
                if (movement.BonnieLocation != "INSIDE")
                {
                    leftdoorcooldown = 0.3f;
                    DoorSound.Play();
                    if (leftdoorclosed)
                    {
                        LeftDoor.GetComponent<Animator>().Play("LeftdoorOpen");
                        timeandpower.PowerUsage -= 1;
                        if (leftlighton == true)
                        {
                            LeftLightBar.GetComponent<Image>().sprite = LeftLightBarLight;
                        }
                        else
                        {
                            LeftLightBar.GetComponent<Image>().sprite = LeftLightBarNone;
                        }
                    }
                    else
                    {
                        LeftDoor.GetComponent<Animator>().Play("Close");
                        timeandpower.PowerUsage += 1;
                        LeftDoor.SetActive(true);
                        if (leftlighton == true)
                        {
                            LeftLightBar.GetComponent<Image>().sprite = LeftLightBarLightDoor;
                        }
                        else
                        {
                            LeftLightBar.GetComponent<Image>().sprite = LeftLightBarDoor;
                        }
                    }
                    leftdoorclosed = !leftdoorclosed;
                }
                else
                {
                    error.Play();
                }
            }
            else if (transform.localPosition.x <= -76.2 && rightdoorcooldown < 0)
            {
                if (movement.ChicaLocation != "INSIDE")
                {
                    rightdoorcooldown = 0.3f;
                    DoorSound.Play();
                    if (rightdoorclosed)
                    {
                        RightDoor.GetComponent<Animator>().Play("Rightdooropen");
                        timeandpower.PowerUsage -= 1;
                        if (rightlighton == true)
                        {
                            RightLightBar.GetComponent<Image>().sprite = RightLightBarLight;
                        }
                        else
                        {
                            RightLightBar.GetComponent<Image>().sprite = RightLightBarNone;
                        }
                    }
                    else
                    {
                        RightDoor.GetComponent<Animator>().Play("Rightdoorclose");
                        timeandpower.PowerUsage += 1;
                        RightDoor.SetActive(true);
                        if (rightlighton == true)
                        {
                            RightLightBar.GetComponent<Image>().sprite = RightLightBarLightDoor;
                        }
                        else
                        {
                            RightLightBar.GetComponent<Image>().sprite = RightLightBarDoor;
                        }
                    }
                    rightdoorclosed = !rightdoorclosed;
                }
                else
                {
                    error.Play();
                }
            }
        }
    }
}

