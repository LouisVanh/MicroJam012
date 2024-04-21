using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinTheGame : MonoBehaviour
{
    [HideInInspector] public bool GameOverWin;
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            GameOverWin = true;
        }
    }

}
