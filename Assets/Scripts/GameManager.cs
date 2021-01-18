using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    [SerializeField] private GameObject StartPanelGO;
    [SerializeField] private GameObject RestartPanelGO;
    [SerializeField] private GameObject CameraGO;


    [SerializeField] private float CameraSpeed;

    private void Awake()
    {
        StartPanelGO.SetActive(true);
        RestartPanelGO.SetActive(false);
        //PlayerGO.GetComponent<BallController>().enabled = false;
        //CameraGO.GetComponent<CameraMov>().enabled = false;
        CameraGO.GetComponent<CameraMov>().cameraSpeed = 0;


    }
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void OnLeanFingerDown()
    {
        
        StartPanelGO.SetActive(false);
        StartCoroutine(EnableBallController());
    }

    IEnumerator EnableBallController()
    {
        yield return new WaitForSeconds(0.001f);

        CameraGO.GetComponent<CameraMov>().cameraSpeed = CameraSpeed;

        //PlayerGO.GetComponent<BallController>().enabled = true;
        //CameraGO.GetComponent<CameraMov>().enabled = true;

    }
}
