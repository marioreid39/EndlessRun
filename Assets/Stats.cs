using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {


        if (gameObject.name == "TimeTotal") {

            GetComponent<TextMesh>().text = "Time:" + GM.timeTotal;
        }


        if (gameObject.name == "CoinsTotal")
        {
            GetComponent<TextMesh>().text = "Coins:" + GM.cointTotal;
        }

        if (gameObject.name == "RunStatus")
        {
            GetComponent<TextMesh>().text = "Status:" + GM.levelCompStatus;
        }

    }


}
