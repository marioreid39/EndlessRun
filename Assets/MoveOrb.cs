using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveOrb : MonoBehaviour
{    
    public KeyCode moveL;
    public KeyCode moveR;

    public float horizVel = 0;
    public int laneNum = 2;
    public string controlLocked = "n";

    public Transform boomObj;
    // Use this for initialization
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Rigidbody>().velocity = new Vector3(horizVel, GM.verticalVel, 4);

        if ((Input.GetKeyDown(moveL)) && (laneNum>1) && (controlLocked == "n")) {

            horizVel = -2;
            StartCoroutine(stopSlide());
            laneNum -= 1;
            controlLocked = "y";
        }

        if ((Input.GetKeyDown(moveR)) && (laneNum<3) && (controlLocked == "n"))
        {
            horizVel = 2;
            StartCoroutine(stopSlide());
            laneNum += 1;
            controlLocked = "y";
        }

    }

    //on collison destroy objects 
    void OnCollisionEnter(Collision other) {

        if (other.gameObject.tag == "Lethal") {
            Destroy(gameObject);
            GM.zVelAdj = 0;

            GM.levelCompStatus = "Fail";

            Instantiate(boomObj, transform.position, boomObj.rotation);
        }

        if (other.gameObject.name == "Capsule(Clone)") {

            Destroy(other.gameObject);            
        }

      
    }

    void OnTriggerEnter(Collider other) {

        if (other.gameObject.name == "RampBottomTrig") {
            GM.verticalVel = 2;
        }
        
        if (other.gameObject.name == "RampTopTrig")
        {
            GM.verticalVel = 0;
        }

        if (other.gameObject.name == "Exit") {

            SceneManager.LoadScene("LevelComp");
            GM.levelCompStatus = "Jheez! Well done!";
        }

        if (other.gameObject.name == "Coin(Clone)")
        {
            Destroy(other.gameObject);
            GM.cointTotal++;
        }
    }

    IEnumerator stopSlide() {

        yield return new WaitForSeconds(.5f);
        horizVel = 0;
        controlLocked = "n";

    }
}
