using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour{

    public Boolean isPause = false;


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            isPause = !isPause;
        }
        if (isPause)
            Time.timeScale = 0f;
        else
            Time.timeScale = 1f;
    }

    public void pause() {
        isPause = !isPause;
    }
}
