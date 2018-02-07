using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    [SerializeField]
    GameObject GatlingTower;

    [SerializeField]
    GameObject Flamethrower;

    [SerializeField]
    GameObject IonTower;

    [SerializeField]
    GameObject TeslaTower;

    GameObject CurrentTurret;
  
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, Mathf.Infinity, LayerMask.GetMask("Platform")))
        {
            if (Input.GetMouseButtonDown(0) && CurrentTurret != null)
            {
                Vector3 Position = new Vector3(hit.collider.transform.position.x, hit.collider.transform.position.y + hit.collider.transform.localScale.y / 2, hit.collider.transform.position.z);
                Spawner spawner = hit.collider.gameObject.GetComponent<Spawner>();
                spawner.Spawn(CurrentTurret, Position, new Vector3(0f, 0f, 0f));
                print(gameObject.name);
            }
        }
    }

    public void TurretA()
    {
        CurrentTurret = GatlingTower;
    }

    public void TurretB()
    {
        CurrentTurret = Flamethrower;
    }

    public void TurretC()
    {
        CurrentTurret = IonTower;
    }

    public void TurretD()
    {
        CurrentTurret = TeslaTower;
    }
}