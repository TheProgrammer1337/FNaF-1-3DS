using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Movement : MonoBehaviour {
    int Night;
    public int BonnieDifficulty;
    public int ChicaDifficulty;
    int FreddyDifficulty;
    public int FoxyDifficulty;

    public int BonnieLocation;
    public int ChicaLocation;
    public int FreddyLocation;
    public int FoxyLocation;
    public float FoxyMovementCountdownBonus;
    public float FoxyMovementCountdown;

    public GameObject LowerCanvas;
    public GameObject Office;
    public Image CameraObject;
    public GameObject UpperCanvas;

    public AudioSource FanNoise;
    public AudioSource Ambience;
    public AudioSource CameraSound;
    public TimeAndPower power;
    public CameraScript CameraScript;
    public GameObject CameraStatic;
    public GameObject BonnieJumpscare;
    public bool bonnieinside = false;
    bool chicainside = false;
    public bool CameraIsUp = true;
    public GameObject Tablet;
    public GameObject DividedStatic;
    float cooldown;
    void Update()
    {
        // Foxy code
        { 
            if (CameraIsUp == !true)
            {
                FoxyMovementCountdownBonus = UnityEngine.Random.Range(0.83f, 16.67f);
            }
            if (CameraIsUp == !false)
            {
                if (FoxyMovementCountdownBonus > 0)
                {
                    FoxyMovementCountdownBonus -= Time.deltaTime;
                }
                else
                {
                    FoxyMovementCountdown -= Time.deltaTime;
                }
            }
            if (FoxyMovementCountdown < 0)
            {
                if (Random.Range(0, 21) <= FoxyDifficulty)
                {
                    FoxyLocation += 1;
                    CameraScript.OnButtonClick(CameraScript.currentbutton);
                }
                FoxyMovementCountdown = 5.01f;
            }
        }
        // End of Foxy code

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (cooldown < 0)
            {
                StartCoroutine("Camera");
                cooldown = 0.27f;
            }
        }
        cooldown -= Time.deltaTime;

    }
    IEnumerator Camera()
    {
        CameraIsUp = !CameraIsUp;
        Tablet.SetActive(true);
        if (CameraIsUp == true)
        {
            Tablet.GetComponent<Animator>().SetBool("Up", false);
            CameraObject.enabled = !CameraObject.IsActive() == true;
            LowerCanvas.SetActive(false);
            CameraStatic.SetActive(!CameraStatic.active);
            Office.SetActive(true);
            if (bonnieinside == true)
            {
                foreach (GameObject child in GameObject.FindGameObjectsWithTag("Respawn"))
                {
                    Destroy(child);
                    Debug.Log(child.name);
                }
                Instantiate(BonnieJumpscare, UpperCanvas.transform);
                Tablet.transform.SetAsLastSibling();
            }

        }
        else
        {
            Tablet.GetComponent<Animator>().SetBool("Up", true);

        }
        yield return new WaitForSeconds(0.24f);
        Tablet.SetActive(false);
        if (CameraIsUp == true)
        {

            LowerCanvas.SetActive(false);
            Office.SetActive(true);
            CameraObject.enabled = false;
            CameraStatic.SetActive(false);

        }
        else
        {
            DividedStatic.SetActive(true);

            LowerCanvas.SetActive(true);
            Office.SetActive(false);
            CameraObject.enabled = true;
            CameraStatic.SetActive(true);
            if (Office.GetComponent<Office>().leftlighton == true)
            {
                power.PowerUsage -= 1;
                Office.GetComponent<Office>().leftlighton = false;
                Office.GetComponent<Office>().LeftLightBar.GetComponent<Image>().sprite = Office.GetComponent<Office>().LeftLightBarNone;
            }
            if (Office.GetComponent<Office>().rightlighton == true)
            {
                power.PowerUsage -= 1;
                Office.GetComponent<Office>().rightlighton = false;
                Office.GetComponent<Office>().RightLightBar.GetComponent<Image>().sprite = Office.GetComponent<Office>().RightLightBarNone;
            }
            Office.GetComponent<Office>().LightSound.Stop();
            Office.GetComponent<Office>().gameObject.GetComponent<Image>().sprite = Office.GetComponent<Office>().NoLight;



        }


        FanNoise.volume = 0.15f;
        Ambience.volume = 0.5f;
        CameraSound.Play();
        if (CameraObject.IsActive() == false)
        {
            power.PowerUsage -= 1;
            FanNoise.volume = 1f;
            Ambience.volume = 1f;
        }
        else
        {
            power.PowerUsage += 1;
            FanNoise.volume = 0.25f;
            Ambience.volume = 0.8f;
        }
    }
    void Start () {
        StartCoroutine("BonnieMovement");
        StartCoroutine("ChicaMovement");
        Night = PlayerPrefs.GetInt("Night", Night);
        if (Night == 1)
        {
            BonnieDifficulty = 0;
            ChicaDifficulty = 0;
            FreddyDifficulty = 0;
            FoxyDifficulty = 0;

        }

        if (Night == 2)
        {
            BonnieDifficulty = 3;
            ChicaDifficulty = 1;
            FreddyDifficulty = 0;
            FoxyDifficulty = 1;


        }

        if (Night == 3)
        {
            BonnieDifficulty = 0;
            ChicaDifficulty = 5;
            FreddyDifficulty = 1;
            FoxyDifficulty = 2;

        }

        if (Night == 4)
        {
            BonnieDifficulty = 2;
            ChicaDifficulty = 4;
            FreddyDifficulty = 2;
            FoxyDifficulty = 6;

        }

        if (Night == 5)
        {
            BonnieDifficulty = 5;
            ChicaDifficulty = 7;
            FreddyDifficulty = 3;
            FoxyDifficulty = 5;


        }

        if (Night == 6)
        {
            BonnieDifficulty = 10;
            ChicaDifficulty = 12;
            FreddyDifficulty = 4;
            FoxyDifficulty = 16;

        }

        if (Night == 7)
        {
            BonnieDifficulty = PlayerPrefs.GetInt("BonnieDifficulty", BonnieDifficulty);
            ChicaDifficulty = PlayerPrefs.GetInt("ChicaDifficulty", ChicaDifficulty);
            FreddyDifficulty = PlayerPrefs.GetInt("FreddyDifficulty", FreddyDifficulty);
            FoxyDifficulty = PlayerPrefs.GetInt("FoxyDifficulty", FoxyDifficulty);
        }
    }

    IEnumerator BonnieMovement()
    {
        while (true)
        {
            yield return new WaitForSeconds(4.97f);
            int rand = Random.Range(0, 21);
            Debug.Log("BonnieMoveAttempt");
            if (rand < BonnieDifficulty)
            {
                switch (BonnieLocation)
                {
                    case 0: // stage
                        rand = Random.Range(0, 2);
                        if (rand == 1)
                        {
                            // backstage
                            BonnieLocation = 1;
                        }
                        else
                        {
                            // party room
                            BonnieLocation = 2;
                        }
                        break;
                    case 1: // backstage
                        rand = Random.Range(0, 2);
                        if (rand == 1)
                        {
                            // backstage
                            BonnieLocation = 1;
                        }
                        else
                        {
                            // west hallway
                            BonnieLocation = 3;
                        }
                        break;

                    case 2: // party room
                        rand = Random.Range(0, 2);
                        if (rand == 1)
                        {
                            // backstage
                            BonnieLocation = 1;
                        }
                        else
                        {
                            // west hallway
                            BonnieLocation = 3;
                        }
                        break;

                    case 3: // west hallway
                        rand = Random.Range(0, 2);
                        if (rand == 1)
                        {
                            // west corner
                            BonnieLocation = 4;
                        }
                        else
                        {
                            // supply closet
                            BonnieLocation = 5;
                        }
                        break;

                    case 4: // west corner
                        rand = Random.Range(0, 2);
                        if (rand == 1)
                        {
                            // left door
                            BonnieLocation = 6;
                        }
                        else
                        {
                            // supply closet
                            BonnieLocation = 5;
                        }
                        break;
                    case 5: // supply closet
                        rand = Random.Range(0, 2);
                        if (rand == 0)
                        {
                            BonnieLocation = 3; // west hallway
                        }
                        else if (rand == 1)
                        {
                            // left door
                            BonnieLocation = 6;
                        }

                        break;

                    case 6:
                        StopCoroutine("BonnieMovement");
                        bonnieinside = true;
                        break;
                    default:
                        break;
                }
            }
                CameraScript.OnButtonClick(CameraScript.currentbutton);
            Debug.Log(BonnieLocation.ToString());
        }
    }
    IEnumerator ChicaMovement()
    {
        while (true)
        {
            yield return new WaitForSeconds(4.98f);
            int rand = Random.Range(0, 21);
            Debug.Log("ChicaMoveAttempt");
            if (rand < ChicaDifficulty)
            {
                switch (ChicaLocation)
                {
                    case 0: // stage
                        //dining hall
                        ChicaLocation = 1;
                        break;
                    case 1: // dining hall
                        rand = Random.Range(0, 2);
                        if (rand == 1)
                        {
                            // kitchen
                            ChicaLocation = 2;
                        }
                        else
                        {
                            // bathrooms
                            ChicaLocation = 3;
                        }
                        break;

                    case 2: // kitchen
                        rand = Random.Range(0, 2);
                        if (rand == 1)
                        {
                            // bathrooms
                            ChicaLocation = 3;
                        }
                        else
                        {
                            // east hallway
                            ChicaLocation = 4;
                        }
                        break;

                    case 3: // bathrooms
                        rand = Random.Range(0, 2);
                        if (rand == 1)
                        {
                            // east hallway
                            ChicaLocation = 4;
                        }
                        else
                        {
                            // kitchen
                            ChicaLocation = 2;
                        }
                        break;

                    case 4: // east hallway
                        rand = Random.Range(0, 2);
                        if (rand == 1)
                        {
                            // dining hall
                            ChicaLocation = 1;
                        }
                        else
                        {
                            // east corner
                            ChicaLocation = 5;
                        }
                        break;
                    case 5: // east corner
                        rand = Random.Range(0, 2);
                        if (rand == 0)
                        {
                            // east hallway
                            ChicaLocation = 4;
                        }
                        else
                        {
                            // right door
                            ChicaLocation = 6;
                        }

                        break;

                    case 6:
                        StopCoroutine("ChicaMovement");
                        chicainside = true;
                        break;
                    default:
                        break;
                }
            }
            CameraScript.OnButtonClick(CameraScript.currentbutton);
            Debug.Log(BonnieLocation.ToString());
        }
    }

}
