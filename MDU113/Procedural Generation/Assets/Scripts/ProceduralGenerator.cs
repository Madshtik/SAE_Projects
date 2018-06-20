using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ProceduralGenerator : MonoBehaviour
{
    [SerializeField]
    GameObject statPanel;

    [SerializeField]
    Transform spawnPoint;

    [SerializeField]
    Animator openingAnimator;

    [SerializeField]
    Animator weaponAnimator;

    [SerializeField]
    Button btnGenerate;

    [SerializeField]
    Button btnRestart;

    int generateNumber = 0;

    [Header("Weapons")]
    [SerializeField]
    GameObject sword;
    [SerializeField]
    GameObject hammer;
    [SerializeField]
    GameObject spear;
    [SerializeField]
    GameObject mace;

    [Header("Weapon Stats and Variables")]
    float durability;
    float rarity;
    float weight;
    float damage;
    float speed;
    float higestSpeed = 500f;
    int fire;
    int poison;
    string raritylvl;
    string weightlvl;
    string weaponName;

    /*[Header("Super Formula Variables")]
    float m1;
    float m2;
    float n1;
    float n2;
    float n3;
    float a;
    float b;
    float angleHorz;
    float angleVert;*/

    [Header("Texts")]
    [SerializeField]
    Text txtName;
    [SerializeField]
    Text txtDamage;
    [SerializeField]
    Text txtDurability;
    [SerializeField]
    Text txtSpeed;
    [SerializeField]
    Text txtRarity;
    [SerializeField]
    Text txtWeight;
    [SerializeField]
    Text txtFire;
    [SerializeField]
    Text txtPoison;

    // Use this for initialization
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    float ranVals(float valMin, float valMax) //Genereic Value Generator
    {
        return Random.Range(valMin, valMax);
    }

    /*void Values()
    {
        m1 = ranVals(0.1f, 2f);
        m2 = ranVals(0.1f, 2f);
        n1 = ranVals(1f, 10f);
        n2 = ranVals(1f, 10f);
        n3 = ranVals(1f, 10f);
        a = ranVals(1, 10);
        b = ranVals(1, 10);
        angleHorz = ranVals(-90, 90) * Mathf.Rad2Deg;
        angleVert = ranVals(-180, 180) * Mathf.Rad2Deg;

        //Start of Superformula
        float rx1 = Mathf.Pow((Mathf.Pow(Mathf.Abs((Mathf.Cos((m1 * angleHorz) / 4)) / a), n2)) 
            + (Mathf.Pow(Mathf.Abs((Mathf.Sin((m2 * angleHorz) / 4)) / b), n3)), -(1 / n1));
        float rx2 = Mathf.Pow((Mathf.Pow(Mathf.Abs((Mathf.Cos((m1 * angleHorz) / 4)) / a), n2)) 
            + (Mathf.Pow(Mathf.Abs((Mathf.Sin((m2 * angleHorz) / 4)) / b), n3)), -(1 / n1));
        //End of Superformula
    }*/   

    //Generates the weapon and its stats
    public void GenerateWeapon()
    {
        durability = ranVals(20f, 100f);
        rarity = ranVals(1f, 100f);
        weight = ranVals(5f, 20f);

        openingAnimator.SetBool("Open", true);

        generateNumber++;

        //Prevents player from overusing the generator
        if (generateNumber >= 1 && btnGenerate.interactable == true && statPanel.activeInHierarchy == false)
        {
            btnGenerate.interactable = false;
            statPanel.SetActive(true);
        }

        //Spawns the weapons randomly
        int weapons = (int)ranVals(1, 4);

        if (weapons <= 1)
        {
            weaponName = "Sword";
            Instantiate(sword, spawnPoint.position, Quaternion.identity);
            txtDurability.text = "Durability: " + durability.ToString("00");
            txtName.text = "Weapon: " + weaponName.ToString();
        }

        if (weapons <= 2 && weapons > 1)
        {
            weaponName = "Hammer";
            Instantiate(hammer, spawnPoint.position, Quaternion.identity); 
            txtDurability.text = "Durability: " + durability.ToString("00");
            txtName.text = "Weapon: " + weaponName.ToString();
        }

        if (weapons <= 3 && weapons > 2)
        {
            weaponName = "Spear";
            Instantiate(spear, spawnPoint.position, Quaternion.identity);
            txtDurability.text = "Durability: " + durability.ToString("00");
            txtName.text = "Weapon: " + weaponName.ToString();
        }

        if (weapons <= 5 && weapons > 3)
        {
            weaponName = "Mace";
            Instantiate(mace, spawnPoint.position, Quaternion.identity);
            txtDurability.text = "Durability: " + durability.ToString("00");
            txtName.text = "Weapon: " + weaponName.ToString();
        }

        //Rarity is determined here
        if (rarity >= 1f && rarity <= 20f)
        {
            fire = 0;
            poison = 0;
            raritylvl = "Common";
            print("Common");
            txtRarity.text = "Rarity: " + raritylvl.ToString();
            txtFire.text = "Fire: " + fire.ToString();
            txtPoison.text = "Poison: " + poison.ToString();
        }

        if (rarity >= 21f && rarity <= 40f)
        {
            fire = 1;
            poison = 0;
            raritylvl = "Uncommon";
            print("Uncommon");
            txtRarity.text = "Rarity: " + raritylvl.ToString();
            txtFire.text = "Fire: " + fire.ToString();
            txtPoison.text = "Poison: " + poison.ToString();
        }

        if (rarity >= 41f && rarity <= 60f)
        {
            fire = 1;
            poison = 1;
            raritylvl = "Rare";
            print("Rare");
            txtRarity.text = "Rarity: " + raritylvl.ToString();
            txtFire.text = "Fire: " + fire.ToString();
            txtPoison.text = "Poison: " + poison.ToString();
        }

        if (rarity >= 61f && rarity <= 80f)
        {
            fire = 2;
            poison = 1;
            raritylvl = "Epic";
            print("Epic");
            txtRarity.text = "Rarity: " + raritylvl.ToString();
            txtFire.text = "Fire: " + fire.ToString();
            txtPoison.text = "Poison: " + poison.ToString();
        }

        if (rarity >= 81f && rarity <= 100f)
        {
            fire = 2;
            poison = 2;
            raritylvl = "Legendary";
            print("Legendary");
            txtRarity.text = "Rarity: " + raritylvl.ToString();
            txtFire.text = "Fire: " + fire.ToString();
            txtPoison.text = "Poison: " + poison.ToString();
        }

        //Weight is determined here
        if (weight >= 5f && weight <= 10f)
        {
            weightlvl = "Light";
            txtWeight.text = "Weight: " + weightlvl.ToString();
        }

        if (weight >= 11f && weight <= 15f)
        {
            weightlvl = "Normal";
            txtWeight.text = "Weight: " + weightlvl.ToString();
        }

        if (weight >= 16f && weight <= 20f)
        {
            weightlvl = "Heavy";
            txtWeight.text = "Weight: " + weightlvl.ToString();
        }

        //Inverse Square Law to determine Speed
        speed = ((higestSpeed / Mathf.Pow(weight, 2)));
        txtSpeed.text = "Speed: " + speed.ToString("00");

        //Newtonian equation F = m * v is used to determine Damage
        //Note that acceleration is not used here since time is considered to be 1 in this case
        damage = rarity * speed;
        txtDamage.text = "Damage: " + damage.ToString("00");
    }

    //stats the scene
    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}