using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Fan : MonoBehaviour {
	public Sprite frame1;
	public Sprite frame2;
	public Sprite frame3;
	// Use this for initialization
	void OnEnable () {
		StartCoroutine("Animation");
	}

	IEnumerator Animation()
	{
		while (true)
		{
            yield return new WaitForSeconds(0.01f);
            gameObject.GetComponent<Image>().sprite = frame1;
            yield return new WaitForSeconds(0.01f);
            gameObject.GetComponent<Image>().sprite = frame2;
            yield return new WaitForSeconds(0.01f);
            gameObject.GetComponent<Image>().sprite = frame3;
        }
    }
}
