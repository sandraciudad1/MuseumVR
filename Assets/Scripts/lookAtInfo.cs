using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class lookAtInfo : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI infoText;


    public void showInfo()
    {
        infoText.gameObject.SetActive(true);
    }

    public void hideInfo()
    {
        infoText.gameObject.SetActive(false);
    }
}
