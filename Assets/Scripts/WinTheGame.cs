using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinTheGame : MonoBehaviour
{
    [HideInInspector] public bool GameOverWin;
    private Transform _winCanvas;

    private void Start()
    {
        GameOverWin = false;
        _winCanvas = GameObject.Find("WinCanvas").transform;
        _winCanvas.GetChild(0).gameObject.SetActive(false); // deactivate image of win
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            GameOverWin = true;
            _winCanvas.GetChild(0).gameObject.SetActive(true); // activate image of win
        }
    }

}
