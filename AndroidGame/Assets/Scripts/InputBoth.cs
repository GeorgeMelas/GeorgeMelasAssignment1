using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class InputBoth : MonoBehaviour
{
    public float score = 20f;
    public GameObject mycookie;
    public Text mytext;
    public bool adding;                     // Variables
    public Text timer;
    public float timervalue = 10;
    public Button Restart;
    // Use this for initialization
    void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        mytext.text = "" + score;
        PC();
        Timer();

    }

    public void PC()
    {
        if (Input.GetMouseButtonDown(0))    // Mouse Input
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);    //Finds the Mouse Position
            RaycastHit hit;
            // Casts the ray and get the first game object hit
            Physics.Raycast(ray, out hit);
            if (hit.collider.tag == "Cherry")    // If it hits the Cherry, addscore.
            {
                score += 20;
                adding = true;
            }


        }
    }

    public void Android()
    {
        if (Input.touchCount > 0)       //Android Work
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            if (Physics.Raycast(ray, out hit))

                if (hit.collider.gameObject.tag == "Cherry")    // If you hit the Cherry Add Score 
                {

                    score += 20;
                    adding = true;

                }


        }
    }

    
        public void Timer()
        {

        timervalue -= Time.deltaTime;
        timer.text = "" + timervalue;                               //Where time is added and added to gui
        timer.text = "" + timervalue.ToString("f1");


        if(timervalue <= 0)
        {
            timer.gameObject.SetActive(false);      // if it is lower than 0 disable the Ui Components.
            Restart.gameObject.SetActive(true);
            mytext.gameObject.SetActive(false);
            adding = false;
        }
        }




    }

   

    

