using UnityEngine;
using UnityEngine.UI;

public class TimeAndPower : MonoBehaviour
{
    public float Time = 360;
    public int PowerLeft = 101;
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

    private string[] timeTexts = { "12 AM", "1 AM", "2 AM", "3 AM", "4 AM", "5 AM", "6 AM" };

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
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

        Time -= UnityEngine.Time.deltaTime;
        int index = Mathf.Clamp(6 - Mathf.CeilToInt(Time / 60), 0, 6);
        TimeCounter.GetComponent<Text>().text = timeTexts[index];
        // Clamp PowerUsage between 1 and 5

        PowerUsage = Mathf.Clamp(PowerUsage, 1, 5);

        // Decrease PowerDrain based on deltaTime
        PowerDrain -= UnityEngine.Time.deltaTime;

        // Check if it's time to reduce power
        if (PowerDrain <= 0)
        {
            PowerLeft -= 1;
            PowerCounter.GetComponent<Text>().text = "Power left: " + PowerLeft.ToString() + "%";
            PowerDrain = GetPowerDrainRate(PowerUsage);
        }
    }

    float GetPowerDrainRate(int usage)
    {
        switch (usage)
        {
            case 1:
                return 9.6f;
            case 2:
                return 4.8f;
            case 3:
                return 3.2f;
            case 4:
                return 2.4f;
            case 5:
                return 1.2f; // Adjusted for 5 bars, if needed
            default:
                Debug.LogError("Invalid PowerUsage value. Please enter a value between 1 and 5.");
                return 9.6f; // Default to 1 bar rate if invalid
        }
    }
}

