using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraScript : MonoBehaviour {
	public Sprite CAM1A;
	public Sprite CAM1ABonnieMissing;
	public Sprite CAM1AChicaMissing;
    public Sprite CAM1ABonnieChicaMissing;
    public Sprite CAM1AFreddyStaring;
    public Sprite CAM1AEmpty;

    public Sprite CAM1B;
    public Sprite CAM1BBonnie;
    public Sprite CAM1BBonnie2;
    public Sprite CAM1BChica;
    public Sprite CAM1BChica2;
    public Sprite CAM1BFreddy;

    public Sprite CAM1CStage0, CAM1CStage1, CAM1CStage2, CAM1CStage3, CAM1CStage4;
    public Sprite CAM2A, CAM2A2, CAM2ABonnie;
    public Sprite CAM2B, CAM2BBonnie1, CAM2BBonnie2, CAM2BBonnie3, CAM2BSecret, CAM2BSecretGoldenF;
    public Sprite CAM3, CAM3Bonnie;
    public Sprite CAM4A, CAM4AChica1, CAM4AChica2, CAM4AFreddy, CAM4ASecret1, CAM4ASecret2;
    public Sprite CAM4B, CAM4BChica1;
    public Sprite CAM5, CAM5Bonnie, CAM5EasterEgg, CAM5BonnieEasterEgg;
    public Sprite CAM7, CAM7Chica, CAM7Chica2, CAM7Freddy;

    public GameObject KitchenText;


    public GameObject SpriteHolder;
    public Sprite ButtonClicked;
    public Sprite ButtonUnClicked;

    public GameObject LowerCanvas;
    public GameObject Office;

	public Movement Movement;
    public string currentbutton;
    private bool isrunning;
    private bool isrunning2;
    public int Night;
    public GameObject buttonobject;
    public GameObject cachedbutton;
    public GameObject DividedStatic;
    public string cameratransfer;

    // Use this for initialization
    void Start () {
        Night = PlayerPrefs.GetInt("Night", 1);
    }

    // Update is called once per frame
    public void buttonclick(GameObject buttonclicked)
    {
        if (cachedbutton != null)
        {
            cachedbutton.GetComponent<Image>().sprite = ButtonUnClicked;
        }
        buttonclicked.GetComponent<Image>().sprite = ButtonClicked;
        cachedbutton = buttonclicked;
    }
    public void OnButtonClick(string button)
	{
        if (Movement.CameraIsUp == false)
        {
            DividedStatic.SetActive(true);

        }
        SpriteHolder.GetComponent<Image>().color = new Color(255, 255, 255);
        KitchenText.SetActive(false);

        if (button != "CAM2A")
        {
            StopCoroutine("CAM2AAnimation");
            isrunning = false;
        }
        if (button != "CAM2B")
        {
            StopCoroutine("CAM2BAnimation");
            isrunning2 = false;
        }
        if (button == "CAM1A")
		{
			if (Movement.BonnieLocation == 0 && Movement.ChicaLocation == 0)
			{
				SpriteHolder.GetComponent<Image>().sprite = CAM1A;
			}
            if (Movement.BonnieLocation != 0 && Movement.ChicaLocation == 0)
            {
                SpriteHolder.GetComponent<Image>().sprite = CAM1ABonnieMissing;
            }
            if (Movement.BonnieLocation == 0 && Movement.ChicaLocation != 0)
            {
                SpriteHolder.GetComponent<Image>().sprite = CAM1AChicaMissing;
            }
            if (Movement.BonnieLocation != 0 && Movement.ChicaLocation != 0)
            {
                SpriteHolder.GetComponent<Image>().sprite = CAM1AFreddyStaring;
            }
        }
        if (button == "CAM1B")
        {
            if (Movement.BonnieLocation != 2 && Movement.ChicaLocation != 1)
            {
                SpriteHolder.GetComponent<Image>().sprite = CAM1B;
            }

            if (Movement.BonnieLocation == 2 && Movement.ChicaLocation != 1)
            {
                SpriteHolder.GetComponent<Image>().sprite = CAM1BBonnie;
            }

            if (Movement.BonnieLocation != 2 && Movement.ChicaLocation == 1)
            {
                SpriteHolder.GetComponent<Image>().sprite = CAM1BChica;
            }
            if (Movement.BonnieLocation == 2)
            {
                SpriteHolder.GetComponent<Image>().sprite = CAM1BBonnie;
            }
        }
        if (button == "CAM1C")
        {
            if (Movement.FoxyLocation == 0)
            {
                SpriteHolder.GetComponent<Image>().sprite = CAM1CStage0;
            }
            else if (Movement.FoxyLocation == 1)
            {
                SpriteHolder.GetComponent<Image>().sprite = CAM1CStage1;
            }
            else if (Movement.FoxyLocation == 2)
            {
                SpriteHolder.GetComponent<Image>().sprite = CAM1CStage2;
            }
            else if (Movement.FoxyLocation == 3)
            {
                SpriteHolder.GetComponent<Image>().sprite = CAM1CStage3;
            }
            else if (Movement.FoxyLocation == 4)
            {
                SpriteHolder.GetComponent<Image>().sprite = CAM1CStage4;
            }
        }
        if (button == "CAM2A")
        {
            if (isrunning == false)
            {
                StartCoroutine("CAM2AAnimation");
            }
            if (Movement.BonnieLocation == 3)
            {
                SpriteHolder.GetComponent<Image>().sprite = CAM2ABonnie;
            }
            else
            {
                SpriteHolder.GetComponent<Image>().sprite = CAM2A;
            }
        }
        if (button == "CAM2A")
        {
            if (isrunning == false)
            {
                StartCoroutine("CAM2AAnimation");
            }
            if (Movement.BonnieLocation == 3)
            {
                SpriteHolder.GetComponent<Image>().sprite = CAM2ABonnie;
            }
            else
            {
                SpriteHolder.GetComponent<Image>().sprite = CAM2A;
            }
        }
        if (button == "CAM2B")
        {

            if (Movement.BonnieLocation == 4)
            {
                SpriteHolder.GetComponent<Image>().sprite = CAM2BBonnie1;
                if (isrunning2 == false && Night >= 4)
                {
                    StartCoroutine("CAM2BAnimation");
                }
            }
            else
            {
                SpriteHolder.GetComponent<Image>().sprite = CAM2B;
            }
        }
        if (button == "CAM3")
        {

            if (Movement.BonnieLocation == 5)
            {
                SpriteHolder.GetComponent<Image>().sprite = CAM3Bonnie;
            }
            else
            {
                SpriteHolder.GetComponent<Image>().sprite = CAM3;
            }
        }
        if (button == "CAM4A")
        {

            if (Movement.ChicaLocation == 3)
            {
                SpriteHolder.GetComponent<Image>().sprite = CAM4AChica1;
            }
            else
            {
                SpriteHolder.GetComponent<Image>().sprite = CAM4A;
            }
        }
        if (button == "CAM4B")
        {

            if (Movement.ChicaLocation == 5)
            {
                SpriteHolder.GetComponent<Image>().sprite = CAM4BChica1;
            }
            else
            {
                SpriteHolder.GetComponent<Image>().sprite = CAM4B;
            }
        }
        if (button == "CAM5")
        {
            if (Movement.BonnieLocation == 1)
            {
                SpriteHolder.GetComponent<Image>().sprite = CAM5Bonnie;
            }
            else
            {
                SpriteHolder.GetComponent<Image>().sprite = CAM5;

            }
        }
        if (button == "CAM6")
        {
            SpriteHolder.GetComponent<Image>().color = new Color(0, 0, 0);
            KitchenText.SetActive(true);
        }
        if (button == "CAM7")
        {
            if (Movement.ChicaLocation == 3)
            {
                SpriteHolder.GetComponent<Image>().sprite = CAM7Chica;
            }
            else
            {
                SpriteHolder.GetComponent<Image>().sprite = CAM7;
            }


        }
        currentbutton = button;
    }
    IEnumerator CAM2AAnimation()
    {
        isrunning = true;
        while (true)
        {
            SpriteHolder.GetComponent<Image>().sprite = CAM2A2;
            yield return new WaitForSeconds(0.1f - Random.Range(-0.03f, 0.09f));
            if (Movement.BonnieLocation == 3)
            {
                SpriteHolder.GetComponent<Image>().sprite = CAM2ABonnie;
            }
            else
            {
                SpriteHolder.GetComponent<Image>().sprite = CAM2A;
            }
            yield return new WaitForSeconds(0.1f - Random.Range(-0.03f, 0.09f));
        }
    }
    IEnumerator CAM2BAnimation()
    {
        isrunning2 = true;
        while (Movement.BonnieLocation == 4)
        {
            SpriteHolder.GetComponent<Image>().sprite = CAM2BBonnie1;
            yield return new WaitForSeconds(0.1f - Random.Range(-0.03f, 0.09f));
            SpriteHolder.GetComponent<Image>().sprite = CAM2BBonnie2;
            yield return new WaitForSeconds(0.1f - Random.Range(-0.09f, 0.09f));
            int rand = Random.Range(0, 2);
            if (rand == 0)
            {
                SpriteHolder.GetComponent<Image>().sprite = CAM2BBonnie3;
                yield return new WaitForSeconds(0.1f - Random.Range(-0.09f, 0.09f));
            }
        }
        isrunning2 = false;
        SpriteHolder.GetComponent<Image>().sprite = CAM2B;
    }

}
