using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gamemaster : MonoBehaviour {

    public int points;

    public Text pointsText;
    public Text InputText;
    public Text GuideText;
    void Update()
    {
        pointsText.text = ("Đá Quý : " + points);
    }
}
