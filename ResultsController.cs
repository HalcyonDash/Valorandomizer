using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ResultsController : MonoBehaviour
{
    public Text Attacker1, Attacker2, Attacker3, Attacker4, Attacker5, Defender1, Defender2, Defender3, Defender4, Defender5, Observer1, Observer2;
    public Text AAgent1, AAgent2, AAgent3, AAgent4, AAgent5, DAgent1, DAgent2, DAgent3, DAgent4, DAgent5;
    // Start is called before the first frame update
    void Start()
    {
        Attacker1.text = PlayerNameController.Attacker1;
        Defender1.text = PlayerNameController.Defender1;
        Attacker2.text = PlayerNameController.Attacker2;
        Defender2.text = PlayerNameController.Defender2;
        Attacker3.text = PlayerNameController.Attacker3;
        Defender3.text = PlayerNameController.Defender3;
        Attacker4.text = PlayerNameController.Attacker4;
        Defender4.text = PlayerNameController.Defender4;
        Attacker5.text = PlayerNameController.Attacker5;
        Defender5.text = PlayerNameController.Defender5;
        Observer1.text = PlayerNameController.Observer1;
        Observer2.text = PlayerNameController.Observer2;

        AAgent1.text = PlayerNameController.AAgent1;
        DAgent1.text = PlayerNameController.DAgent1;
        AAgent2.text = PlayerNameController.AAgent2;
        DAgent2.text = PlayerNameController.DAgent2;
        AAgent3.text = PlayerNameController.AAgent3;
        DAgent3.text = PlayerNameController.DAgent3;
        AAgent4.text = PlayerNameController.AAgent4;
        DAgent4.text = PlayerNameController.DAgent4;
        AAgent5.text = PlayerNameController.AAgent5;
        DAgent5.text = PlayerNameController.DAgent5;
    }

    public void Restart()
    {
        SceneManager.LoadScene("Number");
    }
}

