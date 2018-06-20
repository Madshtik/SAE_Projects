using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Stats : MonoBehaviour
{

    [Header ("Stat Variables")]

    int wisdom;
    int strength;
    int charisma;
    int constitution;
    int dexteity;
    int intellignce;

    [Header("Stat Names")]

    [SerializeField]
    Text Wisdom;

    [SerializeField]
    Text Strength;

    [SerializeField]
    Text Charisma;

    [SerializeField]
    Text Constitution;

    [SerializeField]
    Text Dexterity;

    [SerializeField]
    Text Intelligence;

    [Header("Roll Checker")]

    [SerializeField]
    Button DiceButton;

    int rollNumber = 0;

    int rollsleft = 2;

    [SerializeField]
    Text RollAmount;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (rollNumber >= 3 && DiceButton.interactable == true) //Checks to see if the number of rolls is equal to or more than 3 and disables the button
        {
            DiceButton.interactable = false;
            print("Roll limit reached");
        }
    }

    public void rollDice()
    {
        wisdom = Random.Range(3, 18);
        print(wisdom);
        Wisdom.text = "Wisdom: " + wisdom;

        strength= Random.Range(3, 18);
        print(strength);
        Strength.text = "Strength: " + strength;

        charisma = Random.Range(3, 18);
        print(charisma);
        Charisma.text = "Charisma: " + charisma;

        constitution= Random.Range(3, 18);
        print(constitution);
        Constitution.text = "Constitution: " + constitution;

        dexteity = Random.Range(3, 18);
        print(dexteity);
        Dexterity.text = "Dexterity: " + dexteity;

        intellignce = Random.Range(3, 18);
        print(intellignce);
        Intelligence.text = "Intelligence: " + intellignce;

        RollAmount.text = "Rolls Left: " + rollsleft;

        rollNumber++;
        rollsleft--;
    }
}