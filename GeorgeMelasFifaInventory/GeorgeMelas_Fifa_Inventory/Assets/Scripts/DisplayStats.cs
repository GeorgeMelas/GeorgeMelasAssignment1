using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class DisplayStats : MonoBehaviour
{
    public Image rooney;
	// Use this for initialization
	void Start ()
    {
        rooney.gameObject.SetActive(false);
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    public void LoadWazza()
    {
        rooney.gameObject.SetActive(true);
    }
}
