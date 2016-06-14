using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class GUIHelp : MonoBehaviour
{
    public Text helptext;
    public Text clickhere;
    
	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    public void IfPressed()
    {
        clickhere.gameObject.SetActive(false);  // If i pressed the button it would get rid of the clickhere text.
        print("This is working");
        helptext.gameObject.SetActive(true);    // Sets the Help text to true and hides the clickhere text.
        

    }


}
