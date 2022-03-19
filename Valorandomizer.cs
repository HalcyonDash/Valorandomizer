using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Valorandomizer : MonoBehaviour
{
    private int playerCount;
    private int count;
    private int i, t, n, x;
    public string playerName;
    private string[] playerNames = new string[] { "", "", "", "", "", "", "", "", "", "", "", "" };
    private string[] playerRandomized = new string[] { "", "", "", "", "", "", "", "", "", "", "", "" };
    private string[] agentRandomized = new string[] { "", "", "", "", "", "", "", "", "", "", "", "" };
    private string[] agentList = new string[] { "Astra", "Breach", "Brimstone", "Cypher", "Jett", "KAY/0", "Killjoy", "Omen", "Phoenix", "Raze", "Reyna", "Sage", "Skye", "Sova", "Viper", "Yoru" };
    //private string[] playerRandomized = new string[] { "player1", "player2", "player3", "player4", "player5", "player6", "player7", "player8", "player9", "player10", "player11", "player12" };
    private bool[] teamCheck = new bool[] { true, true, true, true, true, true, true, true, true, true, true, true }; //Checks if player has been assigned already
    bool[] agentCheck = new bool[] //Checks if a team already has an agent.
        { true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true,
        true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, };
    bool[] playerAgents = new bool[192]; //Number of agents times player index plus random number to see if character is available

    private string blankName;
    private bool blankCheck;
    //private string playerName1, playerName2, playerName3, playerName4, playerName5, playerName6, playerName7, playerName8, playerName9, playerName10, playerName11, playerName12;
    public GameObject inputField;
    public GameObject textDisplay;

    private string playerRole;


    public Button astra, breach, cypher, kayo, killjoy, omen, raze, reyna, skye, viper, yoru;
    public Button astraOff, breachOff, cypherOff, kayoOff, killjoyOff, omenOff, razeOff, reynaOff, skyeOff, viperOff, yoruOff;
    public GameObject _astra, _breach, _cypher, _kayo, _killjoy, _omen, _raze, _reyna, _skye, _viper, _yoru;
    public GameObject _astraOff, _breachOff, _cypherOff, _kayoOff, _killjoyOff, _omenOff, _razeOff, _reynaOff, _skyeOff, _viperOff, _yoruOff;

    public bool omenSwitch = true, viperSwitch = true, cypherSwitch = true, breachSwitch = true, razeSwitch = true, reynaSwitch = true, kayoSwitch = true, killjoySwitch = true, skyeSwitch = true, yoruSwitch = true, astraSwitch = true;
    public InputField playerInputField;
    public Text nextPlayer;



    // Start is called before the first frame update
    void Start()
    {
        playerName = "";
        playerCount = PlayerNameController.playerCount;
        //playerCount = 12;
        AgentToggle();
        i = 0;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return)) NextPlayer();

    }
    public void NextPlayer()
    {
        NextPlayerButton();

        playerNames[i] = inputField.GetComponent<Text>().text;
        if (playerNames[i] == "") playerNames[i] = "Player " + (i + 1).ToString();
        AgentSwitch();
        

        playerInputField.Select();
        playerInputField.text = "";
        i++;

        if (i == playerCount)
        {
            Randomize();
        }

        ResetButton();
        textDisplay.GetComponent<Text>().text = "Enter Player " + (i + 1).ToString();
    }

    public void Randomize()
    {
        for (int i = 0; i < playerCount; i++)
        {
            if (i % 2 == 1) t = 1;
            else if (i % 2 == 0) t = 0;

            int agentCount = agentList.Length;
            count = t * (agentCount - 1);

            n = Random.Range(0, playerCount);
            while (teamCheck[n] == false) { n = Random.Range(0, (playerCount)); }
            playerRandomized[i] = playerNames[n];
            
            x = Random.Range(0, agentList.Length);
            while (agentCheck[x + count] == false || playerAgents[agentCount * n + x] == false)
            { x = Random.Range(0, agentList.Length); }
            agentRandomized[i] = agentList[x];

            teamCheck[n] = false;
            agentCheck[x + count] = false;
            //RoleSwitch();
            //Debug.Log("Player Name: " + playerNames[i]);
            //Debug.Log("Player Role Name: " + playerRole);
            //Debug.Log("Attacker 1: " + PlayerNameController.Attacker1);
            //Debug.Log("Defender 1: " + PlayerNameController.Defender1);
        }

        Randomized();
        SceneManager.LoadScene("Results");
    }

    private void NextPlayerButton()
    {
        if (i + 2 == playerCount)
        {
            nextPlayer.text = "RANDOMIZE";
        }
        else { nextPlayer.text = "Next Player"; }
    }

    /*
    public void AddPlayer()
    {
        if (playerCount < 12)
        {
            playerName = inputField.GetComponent<Text>().text;
            if (playerName == "") playerName = "Player " + (playerCount+1).ToString();
            playerNames[playerCount] = playerName;
            ResetButton();
            playerCount++;
            //ClearFields();
            textDisplay.GetComponent<Text>().text = "Enter Player " + (playerCount).ToString();
        }
        else if (playerCount == 12)
        {
            Randomize();
        }
    }
    void GetName()
    {
        playerName = inputField.GetComponent<Text>().text;
        if (playerName == "") playerName = "Player " + playerCount.ToString();
        playerNames[playerCount] = playerName;
        //Debug.Log(playerNames[i]);
    }

    public void Randomize()
    {
        BlankCheck();
        if (!blankCheck) { GetName(); }
        else { playerCount -= 1; }

        for (int i = 0; i <= playerCount; i++)
        {
            //int x = Random.Range(0, (playerCount));
            //Debug.Log("x = " + x);
            playerRole = playerNames[i];
            RoleSwitch();
            Debug.Log("Player " + i + ": " + playerNames[i] + " Player Count: " + playerCount);
        }

        SceneManager.LoadScene("Results");
    }


    void BlankCheck ()
    {
        blankName = inputField.GetComponent<Text>().text;
        if (blankName == "") blankCheck = true;
        else blankCheck = false;
    }

    public void ClearFields()
    {
        playerInputField.Select();
        playerInputField.text = "";
        //playerCount++;
        //i++;
    }
    */

    void Randomized()
    {
        PlayerNameController.Attacker1 = playerRandomized[0];
        PlayerNameController.Defender1 = playerRandomized[1];
        PlayerNameController.Attacker2 = playerRandomized[2];
        PlayerNameController.Defender2 = playerRandomized[3];
        PlayerNameController.Attacker3 = playerRandomized[4];
        PlayerNameController.Defender3 = playerRandomized[5];
        PlayerNameController.Attacker4 = playerRandomized[6];
        PlayerNameController.Defender4 = playerRandomized[7];
        PlayerNameController.Attacker5 = playerRandomized[8];
        PlayerNameController.Defender5 = playerRandomized[9];
        PlayerNameController.Observer1 = playerRandomized[10];
        PlayerNameController.Observer2 = playerRandomized[11];

        PlayerNameController.AAgent1 = agentRandomized[0];
        PlayerNameController.DAgent1 = agentRandomized[1];
        PlayerNameController.AAgent2 = agentRandomized[2];
        PlayerNameController.DAgent2 = agentRandomized[3];
        PlayerNameController.AAgent3 = agentRandomized[4];
        PlayerNameController.DAgent3 = agentRandomized[5];
        PlayerNameController.AAgent4 = agentRandomized[6];
        PlayerNameController.DAgent4 = agentRandomized[7];
        PlayerNameController.AAgent5 = agentRandomized[8];
        PlayerNameController.DAgent5 = agentRandomized[9];
    }
    void RoleSwitch()
    {
        if (i == 0) PlayerNameController.Attacker1 = playerRole;
        else if (i == 1) PlayerNameController.Defender1 = playerRole;
        if (i == 2) PlayerNameController.Attacker2 = playerRole;
        if (i == 3) PlayerNameController.Defender2 = playerRole;
        if (i == 4) PlayerNameController.Attacker3 = playerRole;
        if (i == 5) PlayerNameController.Defender3 = playerRole;
        if (i == 6) PlayerNameController.Attacker4 = playerRole;
        if (i == 7) PlayerNameController.Defender4 = playerRole;
        if (i == 8) PlayerNameController.Attacker5 = playerRole;
        if (i == 9) PlayerNameController.Defender5 = playerRole;
        if (i == 10) PlayerNameController.Observer1 = playerRole;
        if (i == 11) PlayerNameController.Observer2 = playerRole;
    }

    private void AgentSwitch()
    {
        playerAgents[agentList.Length * i + 0] = astraSwitch; //Astra
        playerAgents[agentList.Length * i + 1] = breachSwitch; //Breach
        playerAgents[agentList.Length * i + 2] = true; //Brimstone
        playerAgents[agentList.Length * i + 3] = cypherSwitch; //Cypher
        playerAgents[agentList.Length * i + 4] = true; //Jett
        playerAgents[agentList.Length * i + 5] = kayoSwitch; //Kayo
        playerAgents[agentList.Length * i + 6] = killjoySwitch; //Killjoy
        playerAgents[agentList.Length * i + 7] = omenSwitch; //Omen
        playerAgents[agentList.Length * i + 8] = true; //Phoenix
        playerAgents[agentList.Length * i + 9] = razeSwitch; //Raze
        playerAgents[agentList.Length * i + 10] = reynaSwitch; //Reyna
        playerAgents[agentList.Length * i + 11] = true; //Sage
        playerAgents[agentList.Length * i + 12] = skyeSwitch; //Skye
        playerAgents[agentList.Length * i + 13] = true; //Sova
        playerAgents[agentList.Length * i + 14] = viperSwitch; //Viper
        playerAgents[agentList.Length * i + 15] = yoruSwitch; //Yoru
    }

    public void ResetButton()
    {
        astraSwitch = true; _astra.SetActive(true); _astraOff.SetActive(false);
        breachSwitch = true; _breach.SetActive(true); _breachOff.SetActive(false);
        cypherSwitch = true; _cypher.SetActive(true); _cypherOff.SetActive(false);
        kayoSwitch = true; _kayo.SetActive(true); _kayoOff.SetActive(false);
        killjoySwitch = true; _killjoy.SetActive(true); _killjoyOff.SetActive(false);
        omenSwitch = true; _omen.SetActive(true); _omenOff.SetActive(false);
        razeSwitch = true; _raze.SetActive(true); _razeOff.SetActive(false);
        reynaSwitch = true; _reyna.SetActive(true); _reynaOff.SetActive(false);
        skyeSwitch = true; _skye.SetActive(true); _skyeOff.SetActive(false);
        viperSwitch = true; _viper.SetActive(true); _viperOff.SetActive(false);
        yoruSwitch = true; _yoru.SetActive(true); _yoruOff.SetActive(false);
    }

    public void AllOff()
    {
        astraSwitch = false; _astra.SetActive(false); _astraOff.SetActive(true);
        breachSwitch = false; _breach.SetActive(false); _breachOff.SetActive(true);
        cypherSwitch = false; _cypher.SetActive(false); _cypherOff.SetActive(true);
        kayoSwitch = false; _kayo.SetActive(false); _kayoOff.SetActive(true);
        killjoySwitch = false; _killjoy.SetActive(false); _killjoyOff.SetActive(true);
        omenSwitch = false; _omen.SetActive(false); _omenOff.SetActive(true);
        razeSwitch = false; _raze.SetActive(false); _razeOff.SetActive(true);
        reynaSwitch = false; _reyna.SetActive(false); _reynaOff.SetActive(true);
        skyeSwitch = false; _skye.SetActive(false); _skyeOff.SetActive(true);
        viperSwitch = false; _viper.SetActive(false); _viperOff.SetActive(true);
        yoruSwitch = false; _yoru.SetActive(false); _yoruOff.SetActive(true);
    }

    void AgentToggle()
    {
        //TO TURN OFF
        astra.onClick.AddListener(delegate { astraSwitch = false; _astra.SetActive(false); _astraOff.SetActive(true); });
        breach.onClick.AddListener(delegate { breachSwitch = false; _breach.SetActive(false); _breachOff.SetActive(true); });
        cypher.onClick.AddListener(delegate { cypherSwitch = false; _cypher.SetActive(false); _cypherOff.SetActive(true); });
        kayo.onClick.AddListener(delegate { kayoSwitch = false; _kayo.SetActive(false); _kayoOff.SetActive(true); });
        killjoy.onClick.AddListener(delegate { killjoySwitch = false; _killjoy.SetActive(false); _killjoyOff.SetActive(true); });
        omen.onClick.AddListener(delegate { omenSwitch = false; _omen.SetActive(false); _omenOff.SetActive(true); });
        raze.onClick.AddListener(delegate { razeSwitch = false; _raze.SetActive(false); _razeOff.SetActive(true); });
        reyna.onClick.AddListener(delegate { reynaSwitch = false; _reyna.SetActive(false); _reynaOff.SetActive(true); });
        skye.onClick.AddListener(delegate { skyeSwitch = false; _skye.SetActive(false); _skyeOff.SetActive(true); });
        viper.onClick.AddListener(delegate { viperSwitch = false; _viper.SetActive(false); _viperOff.SetActive(true); });
        yoru.onClick.AddListener(delegate { yoruSwitch = false; _yoru.SetActive(false); _yoruOff.SetActive(true); });

        //TO TURN BACK ON
        astraOff.onClick.AddListener(delegate { astraSwitch = true; _astra.SetActive(true); _astraOff.SetActive(false); });
        breachOff.onClick.AddListener(delegate { breachSwitch = true; _breach.SetActive(true); _breachOff.SetActive(false); });
        cypherOff.onClick.AddListener(delegate { cypherSwitch = true; _cypher.SetActive(true); _cypherOff.SetActive(false); });
        kayoOff.onClick.AddListener(delegate { kayoSwitch = true; _kayo.SetActive(true); _kayoOff.SetActive(false); });
        killjoyOff.onClick.AddListener(delegate { killjoySwitch = true; _killjoy.SetActive(true); _killjoyOff.SetActive(false); });
        omenOff.onClick.AddListener(delegate { omenSwitch = true; _omen.SetActive(true); _omenOff.SetActive(false); });
        razeOff.onClick.AddListener(delegate { razeSwitch = true; _raze.SetActive(true); _razeOff.SetActive(false); });
        reynaOff.onClick.AddListener(delegate { reynaSwitch = true; _reyna.SetActive(true); _reynaOff.SetActive(false); });
        skyeOff.onClick.AddListener(delegate { skyeSwitch = true; _skye.SetActive(true); _skyeOff.SetActive(false); });
        viperOff.onClick.AddListener(delegate { viperSwitch = true; _viper.SetActive(true); _viperOff.SetActive(false); });
        yoruOff.onClick.AddListener(delegate { yoruSwitch = true; _yoru.SetActive(true); _yoruOff.SetActive(false); });

    }

}





