using System.Collections;
using UnityEngine;

public class DividedStatic : MonoBehaviour
{

    void OnEnable()
    {
        StartCoroutine("Disable");
    }
    IEnumerator Disable()
    {
        yield return new WaitForSeconds(0.2f);
        gameObject.SetActive(false);

    }
}
