using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RPGManager : MonoBehaviour
{
    [Header("Battle Variables")] //Variables used for the battle
    int playerHealth = 100;
    int playerDamage;
    int playerArmorClass = 15;
    int playerInitiative;
    int playerAttackRoll;
    int playerLevel = 1;
    int playerExperience;
    int enemyHealth = 100;
    int enemyDamage;
    int enemyArmorClass = 10;
    int enemyInitiative;
    int enemyAttackRoll;
    int enemyLevel;

    [Header("Battle Texts")]
    [SerializeField]
    Text txtPlayerHP;
    [SerializeField]
    Text txtPlayerAC;
    [SerializeField]
    Text txtPlayerLvl;
    [SerializeField]
    Text txtPlayerExp;
    [SerializeField]
    Text txtEnemyHP;
    [SerializeField]
    Text txtEnemyAC;
    [SerializeField]
    Text txtEnemyLvl;

    [Header("Game Panels")] //Panels in the game
    [SerializeField]
    GameObject OpeningPanel;
    [SerializeField]
    GameObject CharacterPanel;
    [SerializeField]
    GameObject NPCPanel;
    [SerializeField]
    GameObject BattlePanel;
    [SerializeField]
    GameObject NavPanel;
    [SerializeField]
    GameObject ClassPanel;
    [SerializeField]
    GameObject RacePanel;
    [SerializeField]
    GameObject ConfirmClassPanel;
    [SerializeField]
    GameObject ConfirmRacePanel;
    [SerializeField]
    GameObject DeathPanel;
    [SerializeField]
    GameObject VictoryPanel;

    [Header("Fear Factors")] //Player stats are called Fear Factors
    public int playerStrength;
    public int playerIntimidation;
    public int playerDexterity;
    public int playerIntelligence;
    public int playerEndurance;
    public int playerPerception;

    [Header("Fear Factor Texts")] //Player stats texts
    [SerializeField]
    Text txtStrength;
    [SerializeField]
    Text txtIntimidation;
    [SerializeField]
    Text txtDexterity;
    [SerializeField]
    Text txtIntelligence;
    [SerializeField]
    Text txtEndurance;
    [SerializeField]
    Text txtPerception;
    [SerializeField]
    Text btlStrength;
    [SerializeField]
    Text btlIntimidation;
    [SerializeField]
    Text btlDexterity;
    [SerializeField]
    Text btlIntelligence;
    [SerializeField]
    Text btlEndurance;
    [SerializeField]
    Text btlPerception;

    public enum PlayerKillers //Enumerated Player Classes
    {
        Stalker,
        Gentleman,
        Clown,
    };

    public enum PlayerRaces //Enumerated Player Races
    {
        Rodian,
        Wookie,
        Human,
    };

    PlayerKillers playerKillers;
    PlayerRaces playerRaces;

    [Header("Buttons")]
    [SerializeField]
    Button btnDice;
    [SerializeField]
    Button btnClown;
    [SerializeField]
    Button btnGentleman;
    [SerializeField]
    Button btnStalker;
    [SerializeField]
    Button btnStatConfirm;
    [SerializeField]
    Button btnRodian;
    [SerializeField]
    Button btnWookie;
    [SerializeField]
    Button btnHuman;
    [SerializeField]
    Button btnClassConfirm;
    [SerializeField]
    Button btnClassCancel;
    [SerializeField]
    Button btnRaceConfirm;
    [SerializeField]
    Button btnRaceCancel;
    [SerializeField]
    Button btnWalker;
    [SerializeField]
    Button btnDemon;
    [SerializeField]
    Button btnDrone;
    [SerializeField]
    Button btnPlayerAttack;
    [SerializeField]
    Button btnPlayerDamage;
    [SerializeField]
    Button btnEnemyAttack;
    [SerializeField]
    Button btnEnemyDamage;
    [SerializeField]
    Button btnInitRoll;

    int rollNumber;

    // Use this for initialization
    void Start()
    {
        MainPanel();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public int dice(int diceMin, int diceMax) //Generic Dice
    {
        return Random.Range(diceMin, diceMax);
    }

    public void FearFactorGenerator() //Randomly Generates the Stats for the player
    {
        playerStrength = dice(1, 6) + dice(1, 6) + dice(1, 6);
        playerIntimidation = dice(1, 6) + dice(1, 6) + dice(1, 6);
        playerDexterity = dice(1, 6) + dice(1, 6) + dice(1, 6);
        playerIntelligence = dice(1, 6) + dice(1, 6) + dice(1, 6);
        playerEndurance = dice(1, 6) + dice(1, 6) + dice(1, 6);
        playerPerception = dice(1, 6) + dice(1, 6) + dice(1, 6);

        txtStrength.text = "Strength: " + playerStrength.ToString("00");
        txtIntimidation.text = "Intimidation: " + playerIntimidation.ToString("00");
        txtDexterity.text = "Dexterity: " + playerDexterity.ToString("00");
        txtIntelligence.text = "Intelligence: " + playerIntelligence.ToString("00");
        txtEndurance.text = "Endurance: " + playerEndurance.ToString("00");
        txtPerception.text = "Perception: " + playerPerception.ToString("00");

        rollNumber++;

        if (rollNumber >= 3 && btnDice.interactable == true) //Checks to see if the number of rolls is equal to or more than 3 and disables the button
        {
            btnDice.interactable = false;
        }

        if (btnStatConfirm.interactable == false) //Makes the confirm button interactable after the first dice roll
        {
            btnStatConfirm.interactable = true;
        }
    }

    public void ConfirmFactors() //Function to confirm and save Fear Factors
    {
        PlayerPrefs.SetInt("Strength", playerStrength);
        PlayerPrefs.SetInt("Intimidation", playerIntimidation);
        PlayerPrefs.SetInt("Detxerity", playerDexterity);
        PlayerPrefs.SetInt("Intelligence", playerIntelligence);
        PlayerPrefs.SetInt("Endurance", playerEndurance);
        PlayerPrefs.SetInt("Perception", playerPerception);

        if (ClassPanel.gameObject.activeInHierarchy == false && RacePanel.gameObject.activeInHierarchy == false
            && btnDice.interactable == true || btnDice.interactable == false && btnStatConfirm.interactable == true)
        {
            ClassPanel.gameObject.SetActive(true);
            btnDice.interactable = false;
            btnStatConfirm.interactable = false;
        }
    }

    public void LoadStats() //Loads the stats from the registry
    {
        txtStrength.text = "Strength: " + PlayerPrefs.GetInt("Strength", playerStrength).ToString("00");
        txtIntimidation.text = "Intimidation: " + PlayerPrefs.GetInt("Intimidation", playerIntimidation).ToString("00");
        txtDexterity.text = "Dexterity: " + PlayerPrefs.GetInt("Dexterity", playerDexterity).ToString("00");
        txtIntelligence.text = "Intelligence: " + PlayerPrefs.GetInt("Intelligence", playerIntelligence).ToString("00");
        txtEndurance.text = "Endurance: " + PlayerPrefs.GetInt("Endurance", playerEndurance).ToString("00");
        txtPerception.text = "Perception: " + PlayerPrefs.GetInt("Perception", playerPerception).ToString("00");
    }

    //Functions that handle the panels
    public void MainPanel() //Opens the main panel
    {
        OpeningPanel.SetActive(true);
        CharacterPanel.SetActive(false);
        NPCPanel.SetActive(false);
        BattlePanel.SetActive(false);
        NavPanel.SetActive(false);
    }

    public void Quit() //Closes the build
    {
        Application.Quit();
    }

    public void Play() //Opens the Character and Navigaion panel
    {
        OpeningPanel.SetActive(false);
        CharacterPanel.SetActive(true);
        NavPanel.SetActive(true);
        ClassPanel.SetActive(false);
        RacePanel.SetActive(false);
    }

    public void CharacterButton() //Reopens the character panel through the Navigation panel
    {
        CharacterPanel.SetActive(true);
        NPCPanel.SetActive(false);
        BattlePanel.SetActive(false);
    }

    public void NPCButton() //Opens the NPC Panel
    {
        PlayerPrefs.SetInt("Strength", playerStrength);
        PlayerPrefs.SetInt("Intimidation", playerIntimidation);
        PlayerPrefs.SetInt("Detxerity", playerDexterity);
        PlayerPrefs.SetInt("Intelligence", playerIntelligence);
        PlayerPrefs.SetInt("Endurance", playerEndurance);
        PlayerPrefs.SetInt("Perception", playerPerception);

        CharacterPanel.SetActive(false);
        NPCPanel.SetActive(true);
        BattlePanel.SetActive(false);
    }

    public void BattleButton() //Opens the Battle panel
    {
        CharacterPanel.SetActive(false);
        NPCPanel.SetActive(false);
        BattlePanel.SetActive(true);
        NavPanel.SetActive(true);

        btnPlayerAttack.interactable = false;
        btnPlayerDamage.interactable = false;
        btnEnemyAttack.interactable = false;
        btnEnemyDamage.interactable = false;

        btlStrength.text = "Strength: " + PlayerPrefs.GetInt("Strength", playerStrength).ToString("00");
        btlIntimidation.text = "Intimidation: " + PlayerPrefs.GetInt("Intimidation", playerIntimidation).ToString("00");
        btlDexterity.text = "Dexterity: " + PlayerPrefs.GetInt("Dexterity", playerDexterity).ToString("00");
        btlIntelligence.text = "Intelligence: " + PlayerPrefs.GetInt("Intelligence", playerIntelligence).ToString("00");
        btlEndurance.text = "Endurance: " + PlayerPrefs.GetInt("Endurance", playerEndurance).ToString("00");
        btlPerception.text = "Perception: " + PlayerPrefs.GetInt("Perception", playerPerception).ToString("00");
        txtPlayerHP.text = "Hit Points: " + playerHealth.ToString("00");
        txtPlayerAC.text = "Armor Class: " + playerArmorClass.ToString("00");
        txtEnemyHP.text = "Hit Points: " + enemyHealth.ToString("00");
        txtEnemyAC.text = "Armor Class: " + enemyArmorClass.ToString("00");
    }

    //Class Fucntions
    public void Clown()
    {
        playerKillers = PlayerKillers.Clown;

        playerIntelligence += 2;
        txtIntelligence.text = "Intelligence: " + playerIntelligence.ToString("00");
        playerIntimidation += 1;
        txtIntimidation.text = "Intimidation: " + playerIntimidation.ToString("00");
        playerEndurance += 1;
        txtEndurance.text = "Endurance: " + playerEndurance.ToString("00");

        if (btnClown.interactable == true)
        {
            btnClown.interactable = false;
            btnGentleman.interactable = false;
            btnStalker.interactable = false;
            ConfirmClassPanel.SetActive(true);
        }
    }

    public void Gentleman()
    {
        playerKillers = PlayerKillers.Gentleman;

        playerPerception += 1;
        txtPerception.text = "Perception: " + playerPerception.ToString("00");
        playerEndurance += 1;
        txtEndurance.text = "Endurance: " + playerEndurance.ToString("00");
        playerDexterity += 2;
        txtDexterity.text = "Dexterity: " + playerDexterity.ToString("00");

        if (btnGentleman.interactable == true)
        {
            btnGentleman.interactable = false;
            btnClown.interactable = false;
            btnStalker.interactable = false;
            ConfirmClassPanel.gameObject.SetActive(true);
        }
    }

    public void Stalker()
    {
        playerKillers = PlayerKillers.Stalker;

        playerStrength += 2;
        txtStrength.text = "Strength: " + playerStrength.ToString("00");
        playerIntimidation += 2;
        txtIntimidation.text = "Intimidation: " + playerIntimidation.ToString("00");

        if (btnStalker.interactable == true)
        {
            btnStalker.interactable = false;
            btnClown.interactable = false;
            btnGentleman.interactable = false;
            ConfirmClassPanel.SetActive(true);
        }
    }

    public void ConfirmClass() //A function to confirm the player's class choice
    {
        PlayerPrefs.SetInt("Strength", playerStrength);
        PlayerPrefs.SetInt("Intimidation", playerIntimidation);
        PlayerPrefs.SetInt("Detxerity", playerDexterity);
        PlayerPrefs.SetInt("Intelligence", playerIntelligence);
        PlayerPrefs.SetInt("Endurance", playerEndurance);
        PlayerPrefs.SetInt("Perception", playerPerception);

        RacePanel.gameObject.SetActive(true);
        ClassPanel.gameObject.SetActive(false);
    }

    public void CancelClass()
    {
        LoadStats();

        ConfirmClassPanel.gameObject.SetActive(false);
        btnStalker.interactable = true;
        btnClown.interactable = true;
        btnGentleman.interactable = true;
    }
    //Race Functions
    public void Rodian()
    {
        playerRaces = PlayerRaces.Rodian;

        playerIntelligence += 1;
        txtIntelligence.text = "Intelligence: " + playerIntelligence.ToString("00");

        if (btnRodian.interactable == true)
        {
            btnRodian.interactable = false;
            btnWookie.interactable = false;
            btnHuman.interactable = false;
            ConfirmRacePanel.gameObject.SetActive(true);
        }
    }

    public void Wookie()
    {
        playerRaces = PlayerRaces.Wookie;

        playerStrength += 1;
        txtStrength.text = "Strength: " + playerStrength.ToString("00");

        if (btnWookie.interactable == true)
        {
            btnRodian.interactable = false;
            btnWookie.interactable = false;
            btnHuman.interactable = false;
            ConfirmRacePanel.gameObject.SetActive(true);
        }
    }

    public void Human()
    {
        playerRaces = PlayerRaces.Human;

        playerPerception += 1;
        txtPerception.text = "Perception: " + playerPerception.ToString("00");

        if (btnHuman.interactable == true)
        {
            btnRodian.interactable = false;
            btnWookie.interactable = false;
            btnHuman.interactable = false;
            ConfirmRacePanel.gameObject.SetActive(true);
        }
    }

    public void ConfirmRace() //A function to confirm the player's class choice
    {
        PlayerPrefs.SetInt("Strength", playerStrength);
        PlayerPrefs.SetInt("Intimidation", playerIntimidation);
        PlayerPrefs.SetInt("Detxerity", playerDexterity);
        PlayerPrefs.SetInt("Intelligence", playerIntelligence);
        PlayerPrefs.SetInt("Endurance", playerEndurance);
        PlayerPrefs.SetInt("Perception", playerPerception);

        CharacterPanel.SetActive(false);
        NPCPanel.SetActive(true);
        BattlePanel.SetActive(false);
    }

    public void CancelRace()
    {
        LoadStats();
        btnRodian.interactable = true;
        btnWookie.interactable = true;
        btnHuman.interactable = true;

        ConfirmRacePanel.gameObject.SetActive(false);
    }

    public void Walker()
    {
        enemyHealth = 100;
        enemyLevel = dice(1, 10);
        txtEnemyLvl.text = "Level: " + enemyLevel.ToString("00");

        CharacterPanel.SetActive(false);
        NPCPanel.SetActive(false);
        BattlePanel.SetActive(true);
        NavPanel.SetActive(true);

        btnPlayerAttack.interactable = false;
        btnPlayerDamage.interactable = false;
        btnEnemyAttack.interactable = false;
        btnEnemyDamage.interactable = false;

        btlStrength.text = "Strength: " + PlayerPrefs.GetInt("Strength", playerStrength).ToString("00");
        btlIntimidation.text = "Intimidation: " + PlayerPrefs.GetInt("Intimidation", playerIntimidation).ToString("00");
        btlDexterity.text = "Dexterity: " + PlayerPrefs.GetInt("Dexterity", playerDexterity).ToString("00");
        btlIntelligence.text = "Intelligence: " + PlayerPrefs.GetInt("Intelligence", playerIntelligence).ToString("00");
        btlEndurance.text = "Endurance: " + PlayerPrefs.GetInt("Endurance", playerEndurance).ToString("00");
        btlPerception.text = "Perception: " + PlayerPrefs.GetInt("Perception", playerPerception).ToString("00");
        txtPlayerHP.text = "Hit Points: " + playerHealth.ToString("00");
        txtPlayerAC.text = "Armor Class: " + playerArmorClass.ToString("00");
        txtEnemyHP.text = "Hit Points: " + enemyHealth.ToString("00");
        txtEnemyAC.text = "Armor Class: " + enemyArmorClass.ToString("00");
    }

    public void Demon()
    {
        enemyHealth = 100;
        enemyLevel = dice(5, 15);
        txtEnemyLvl.text = "Level: " + enemyLevel.ToString("00");

        CharacterPanel.SetActive(false);
        NPCPanel.SetActive(false);
        BattlePanel.SetActive(true);
        NavPanel.SetActive(true);

        btnPlayerAttack.interactable = false;
        btnPlayerDamage.interactable = false;
        btnEnemyAttack.interactable = false;
        btnEnemyDamage.interactable = false;

        btlStrength.text = "Strength: " + PlayerPrefs.GetInt("Strength", playerStrength).ToString("00");
        btlIntimidation.text = "Intimidation: " + PlayerPrefs.GetInt("Intimidation", playerIntimidation).ToString("00");
        btlDexterity.text = "Dexterity: " + PlayerPrefs.GetInt("Dexterity", playerDexterity).ToString("00");
        btlIntelligence.text = "Intelligence: " + PlayerPrefs.GetInt("Intelligence", playerIntelligence).ToString("00");
        btlEndurance.text = "Endurance: " + PlayerPrefs.GetInt("Endurance", playerEndurance).ToString("00");
        btlPerception.text = "Perception: " + PlayerPrefs.GetInt("Perception", playerPerception).ToString("00");
        txtPlayerHP.text = "Hit Points: " + playerHealth.ToString("00");
        txtPlayerAC.text = "Armor Class: " + playerArmorClass.ToString("00");
        txtEnemyHP.text = "Hit Points: " + enemyHealth.ToString("00");
        txtEnemyAC.text = "Armor Class: " + enemyArmorClass.ToString("00");
    }

    public void Drones()
    {
        enemyHealth = 100;
        enemyLevel = dice(10, 20);
        txtEnemyLvl.text = "Level: " + enemyLevel.ToString("00");

        CharacterPanel.SetActive(false);
        NPCPanel.SetActive(false);
        BattlePanel.SetActive(true);
        NavPanel.SetActive(true);

        btnPlayerAttack.interactable = false;
        btnPlayerDamage.interactable = false;
        btnEnemyAttack.interactable = false;
        btnEnemyDamage.interactable = false;

        btlStrength.text = "Strength: " + PlayerPrefs.GetInt("Strength", playerStrength).ToString("00");
        btlIntimidation.text = "Intimidation: " + PlayerPrefs.GetInt("Intimidation", playerIntimidation).ToString("00");
        btlDexterity.text = "Dexterity: " + PlayerPrefs.GetInt("Dexterity", playerDexterity).ToString("00");
        btlIntelligence.text = "Intelligence: " + PlayerPrefs.GetInt("Intelligence", playerIntelligence).ToString("00");
        btlEndurance.text = "Endurance: " + PlayerPrefs.GetInt("Endurance", playerEndurance).ToString("00");
        btlPerception.text = "Perception: " + PlayerPrefs.GetInt("Perception", playerPerception).ToString("00");
        txtPlayerHP.text = "Hit Points: " + playerHealth.ToString("00");
        txtPlayerAC.text = "Armor Class: " + playerArmorClass.ToString("00");
        txtEnemyHP.text = "Hit Points: " + enemyHealth.ToString("00");
        txtEnemyAC.text = "Armor Class: " + enemyArmorClass.ToString("00");
        txtPlayerLvl.text = "Level: " + playerLevel.ToString("00");
    }

    public void RollInitiative()
    {
        playerInitiative = dice(1, 20);
        enemyInitiative = dice(1, 20);

        if (playerInitiative > enemyInitiative)
        {
            btnPlayerAttack.interactable = true;
            btnPlayerDamage.interactable = false;
            btnEnemyAttack.interactable = false;
            btnEnemyDamage.interactable = false;
            btnInitRoll.interactable = false;
        }

        if (playerInitiative < enemyInitiative)
        {
            btnPlayerAttack.interactable = false;
            btnPlayerDamage.interactable = false;
            btnEnemyAttack.interactable = true;
            btnEnemyDamage.interactable = false;
            btnInitRoll.interactable = false;
        }
    }

    public void PlayerAttack()
    {
        playerAttackRoll = dice(1, 20);

        if (playerAttackRoll > enemyArmorClass)
        {
            btnPlayerAttack.interactable = false;
            btnPlayerDamage.interactable = true;
        }
        else
        {
            if (playerAttackRoll < enemyAttackRoll)
            {
                btnPlayerAttack.interactable = false;
                btnPlayerDamage.interactable = false;
                btnEnemyAttack.interactable = true;
                btnEnemyDamage.interactable = false;
            }
        }
    }

    public void PlayerDamage()
    {
        playerDamage = dice(1, 20);
        enemyHealth -= (playerDamage + ((playerStrength - 10) / 2));
        txtEnemyHP.text = "Hit Points: " + enemyHealth.ToString("00");

        btnPlayerDamage.interactable = false;
        btnEnemyAttack.interactable = true;


        if (enemyHealth <= 0)
        {
            playerHealth = 100;

            BattlePanel.gameObject.SetActive(false);
            NPCPanel.gameObject.SetActive(true);

            playerExperience = enemyLevel * 2;
            txtPlayerExp.text = "Experience: " + playerExperience.ToString("00");

            if (playerExperience >= 100)
            {
                playerLevel++;
                txtPlayerLvl.text = "Level: " + playerLevel.ToString("00");
                playerExperience = 0;
                txtPlayerExp.text = "Experience: " + playerExperience.ToString("00");
                playerStrength += 1;
                txtStrength.text = "Strength: " + playerStrength.ToString("00");
            }
        }
    }

    public void EnemyAttack()
    {
        enemyAttackRoll = dice(1, 20);

        if (enemyAttackRoll > playerArmorClass)
        {
            btnEnemyAttack.interactable = false;
            btnEnemyDamage.interactable = true;
        }
        else
        {
            if (enemyAttackRoll < playerArmorClass)
            {
                btnPlayerAttack.interactable = true;
                btnPlayerDamage.interactable = false;
                btnEnemyAttack.interactable = false;
                btnEnemyDamage.interactable = false;
            }
        }
    }

    public void EnemyDamage()
    {
        enemyDamage = dice(10, 20);
        playerHealth -= enemyDamage;
        txtPlayerHP.text = "Hit Points: " + playerHealth.ToString("00");

        btnEnemyDamage.interactable = false;
        btnPlayerAttack.interactable = true;

        if (playerHealth <= 0)
        {
            BattlePanel.gameObject.SetActive(false);
            DeathPanel.gameObject.SetActive(true);
        }
    }
}