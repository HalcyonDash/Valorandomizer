using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CounterController : MonoBehaviour
{
    public void StartRandomizer()
    {
        SceneManager.LoadScene("Number");
    }

    public void BackButton()
    {
        SceneManager.LoadScene("Start");
    }

    public void About()
    {
        SceneManager.LoadScene("About");
    }
    public void PlayerCount(int input)
    {
        PlayerNameController.playerCount = input;
        SceneManager.LoadScene("New Player 1");
    }
}
