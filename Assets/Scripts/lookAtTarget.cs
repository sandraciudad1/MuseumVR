using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class lookAtTarget : MonoBehaviour
{
    [SerializeField] GameObject radialBar_elements;
    [SerializeField] Image radialImg;
    [SerializeField] TextMeshProUGUI percentage;

    [SerializeField] GameObject player;
    [SerializeField] GameObject mainCamera;

    [SerializeField] GameObject circle1;
    [SerializeField] GameObject circle2;
    [SerializeField] GameObject circle3;
    [SerializeField] GameObject circle4;
    [SerializeField] GameObject circle5;
    [SerializeField] GameObject circle6;

    float counter;
    float totalTime = 5f;
    bool startCounter=false;

    private void Update()
    {
        float cameraHeight = 0.55f; 
        Camera.main.transform.position = new Vector3(player.transform.position.x, player.transform.position.y + cameraHeight, player.transform.position.z);

        if (startCounter)
        {
            counter += Time.deltaTime;

            float fillAmount = Mathf.Clamp01(counter / totalTime); 
            radialImg.fillAmount = fillAmount; 
            percentage.text = Mathf.RoundToInt(fillAmount * 100).ToString() + "%";

            if (counter >= totalTime)
            {
                activeCircles();
                startCounter = false;

                checkCircle();
                desactivate();
            }
        }

    }

    void activeCircles()
    {
        circle1.SetActive(true);
        circle2.SetActive(true);
        circle3.SetActive(true);
        circle4.SetActive(true);
        circle5.SetActive(true);
        circle6.SetActive(true);
    }

    public void activate()
    {
        radialBar_elements.SetActive(true);
        startCounter = true;
    }

    public void desactivate()
    {
        radialBar_elements.SetActive(false);
        startCounter = false;
        resetValues();
    }

    void resetValues()
    {
        counter = 0;
        radialImg.fillAmount = 0;
        percentage.text = "0%";
    }

    void checkCircle()
    {
        Vector3 targetPosition = player.transform.position;

        if (gameObject.tag.Equals("circle1"))
        {
            targetPosition = new Vector3(4f, 0f, -8.8f);
            circle1.SetActive(false);
        }
        else if (gameObject.tag.Equals("circle2"))
        {
            targetPosition = new Vector3(9.1f, 0f, -0.2f);
            circle2.SetActive(false);
        }
        else if (gameObject.tag.Equals("circle3"))
        {
            targetPosition = new Vector3(4f, 0f, 8.55f);
            circle3.SetActive(false);
        }
        else if (gameObject.tag.Equals("circle4"))
        {
            targetPosition = new Vector3(-6f, 0f, 8.6f);
            circle4.SetActive(false);
        }
        else if (gameObject.tag.Equals("circle5"))
        {
            targetPosition = new Vector3(-11.1f, 0f, -0.2f);
            circle5.SetActive(false);
        }
        else if (gameObject.tag.Equals("circle6"))
        {
            targetPosition = new Vector3(-6f, 0f, -9.1f);
            circle6.SetActive(false);
        }
        player.transform.DOMove(new Vector3(targetPosition.x, player.transform.position.y, targetPosition.z), 1f).SetEase(Ease.InOutQuad);
    }

    
}

