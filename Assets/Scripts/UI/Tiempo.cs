using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Tiempo : MonoBehaviour
{
    private float timer;
    private TextMeshProUGUI texto;
    void Start()
    {
        texto = GetComponent<TextMeshProUGUI>();
    }
    
    void Update()
    {
        timer += Time.deltaTime;
        texto.text = "Tiempo: " + timer.ToString("0");
    }
}
