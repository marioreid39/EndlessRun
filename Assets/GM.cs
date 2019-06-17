using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GM : MonoBehaviour {

    public static float verticalVel = 0;
    public static int cointTotal = 0;
    public static float timeTotal = 0;
    public static float zVelAdj = 1;

    public float zScenePos = 58;

    public static string levelCompStatus = "";

    public float waitToLoad = 0;

    public Transform bBlockNoPit;
    public Transform bBlockPitMid;

    public Transform coinObj;
    public Transform obstacleObj;
    public Transform capsuleObj;

    public int randNum;

    public Transform levelComp;

	// Use this for initialization
	void Start () {

        Instantiate(bBlockNoPit, new Vector3(0,(float)2.270,42), bBlockNoPit.rotation);
        Instantiate(bBlockNoPit, new Vector3(0, (float)2.270, 46), bBlockNoPit.rotation);
        Instantiate(bBlockNoPit, new Vector3(0, (float)2.270, 50), bBlockNoPit.rotation);

        Instantiate(bBlockPitMid, new Vector3(0, (float)2.270, 54), bBlockPitMid.rotation);


    }

    // Update is called once per frame
    void Update () {

        if (zScenePos < 120) {

            randNum = Random.Range(0,10);

            if (randNum < 3) {
                Instantiate(coinObj, new Vector3(-1, 3.270f, zScenePos), coinObj.rotation);
            }
            
            //if (randNum > 7)
            //{
            //    Instantiate(coinObj, new Vector3(1, 3.270f, zScenePos), coinObj.rotation);
            //}

            if (randNum == 6)
            {
                Instantiate(capsuleObj, new Vector3(0, 3.270f, zScenePos), capsuleObj.rotation);
            }

            if (randNum > 6) {

                Instantiate(coinObj, new Vector3(-1, 3.270f, zScenePos), coinObj.rotation);
                Instantiate(obstacleObj, new Vector3(1, 3.270f, zScenePos), obstacleObj.rotation);
            }

            Instantiate(bBlockNoPit, new Vector3(0, (float)2.270, zScenePos), bBlockNoPit.rotation);
            zScenePos += 4;


        }


        //if (zScenePos == 116)
        //{
        //    Instantiate(levelComp, new Vector3(0, (float)2.270, zScenePos), levelComp.rotation);
        //}



        timeTotal += Time.deltaTime;

        if (levelCompStatus == "Fail") {

            waitToLoad += Time.deltaTime; 
        }


        if (waitToLoad > 2) {
            SceneManager.LoadScene("LevelComp");
        }

	}


}
