using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class RayMenu : MonoBehaviour
{

    private int sceneOption;
    private bool isMenuClicked;


    private bool sceneGo;


    public Text contDownText;

    private float currentTime = 0f;
    public float satartTime = 10f;

    void Start()
    {
        isMenuClicked = false;
        sceneGo = false;
        currentTime = satartTime;
    }



    void Update()
    {

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(ray.origin, ray.direction * 100, Color.green);
        RaycastHit hit;

//RayCast

        if (Input.GetMouseButtonDown(0) && isMenuClicked == false)
        {
            if (Physics.Raycast(ray, out hit) == true)
            {
                var selection = hit.transform;

//Comparar i guardar l'opcio clickada "hit"

                if (selection.CompareTag("Scene1") || selection.CompareTag("Scene2") || selection.CompareTag("Scene3"))
                {

                    Debug.DrawRay(ray.origin, ray.direction * hit.distance);
                    Debug.Log(hit.transform.gameObject.tag);

                    sceneGo = true;

                   // Debug.Log("PreScena: " + sceneOption);


                    if (selection.CompareTag("Scene1"))
                    {
                        sceneOption = 1;
                    }
                    if (selection.CompareTag("Scene2"))
                    {
                       sceneOption = 2;
                    }
                    if (selection.CompareTag("Scene3"))
                    {
                        sceneOption = 3;
                    }

                    sceneGo = true;

                   // Debug.Log("PostScena: " + sceneOption);


                }
            }

        }

        if (sceneGo == true)            //Timer
        {
            // Debug.Log("DinsScena: " + sceneOption);

            currentTime -= 1 * Time.deltaTime;
            contDownText.text = currentTime.ToString("0");

            if (currentTime <= 0)
            {
                currentTime = 0;
            }

//Entra a l'escena quan el temps es = 0 segons l'opcio triada

            if (sceneOption == 1 && currentTime == 0)
            {

                SceneManager.LoadScene(1, LoadSceneMode.Single);

            }

            if (sceneOption == 2 && currentTime == 0)
            {

                SceneManager.LoadScene(2, LoadSceneMode.Single);

            }

            if (sceneOption == 3 && currentTime == 0)
            {

                SceneManager.LoadScene(3, LoadSceneMode.Single);

            }
        }
    }

    public void BackButton(){
        SceneManager.LoadScene(0, LoadSceneMode.Single);
    }


}