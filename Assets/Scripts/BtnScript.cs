using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BtnScript : MonoBehaviour
{
    public void btnSrarpressed()
    {
        SceneManager.LoadScene("UFOX");
    }

    public void btnQuitpressed()
    {
        Application.Quit();
    }
}
