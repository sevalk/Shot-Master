using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SpawnBall : MonoBehaviour
{
    //Prefab Playerımız
    [SerializeField] private GameObject ballGO;

    //Sahip oldugumuz atılabilir top sayısı
    [SerializeField] private int ownBallNumber;


    [SerializeField] private TextMeshProUGUI throvawayBallText;

    [SerializeField] private float waitSpawnTime=1f;

    [HideInInspector]
    public BallController isBallSpawnCheck;

    [SerializeField] private Transform spawnPointsTransform;

    //List<GameObject> ball = new List<GameObject>();

    private void Awake()
    {
        
        throvawayBallText.text = ownBallNumber.ToString();
    }
    

    void FixedUpdate()
    {
        //ball[0] = GameObject.FindGameObjectWithTag("Player");
        //isBallSpawnCheck = ball[0].GetComponent<BallController>();
        isBallSpawnCheck = GameObject.FindGameObjectWithTag("Player").GetComponent<BallController>();

        if (isBallSpawnCheck.canSpawn == true )
        {

            IncreaseBallNumber();
            StartCoroutine(InstantiateBall());
           
        }


        
    }

    private void IncreaseBallNumber()
    {
        ownBallNumber--;
        throvawayBallText.text = ownBallNumber.ToString();

    }

    private IEnumerator InstantiateBall()
    {
        isBallSpawnCheck.canSpawn = false;
        
        yield return new WaitForSeconds(waitSpawnTime);

        Instantiate(ballGO, spawnPointsTransform.transform.position, spawnPointsTransform.transform.rotation);
        
    }
}
