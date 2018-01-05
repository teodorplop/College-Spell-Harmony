using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellLauncher : MonoBehaviour {

    public GameObject fireball;
    public GameObject shield;
    public GameObject electricSpark;
    public GameObject iceball;

    public float speed = 10.0f;
    public Player player;

    private bool defense = false;

	void Start () {	
	}
	
	void Update () {
        string input = Input.inputString;

        switch (input){
            case "1": {
                    GameObject fire = (GameObject)Instantiate(fireball, player.transform.position, player.transform.rotation);
                    fire.GetComponent<Rigidbody>().AddForce(player.GetComponentInChildren<Camera>().transform.forward * speed, ForceMode.Impulse);
                    break;
                }
            case "2": {                 
                    if (!defense){
                        GameObject defenseShield = (GameObject)Instantiate(shield, player.transform.position, player.transform.rotation);
                        defense = true;
                        defenseShield.transform.parent = player.transform;
                        Player.Instance.ApplyShield(1);
                    }
                    break;
                }
            case "3": {
                    GameObject spark = (GameObject)Instantiate(electricSpark, player.transform.position, player.transform.rotation);
                    spark.GetComponent<Rigidbody>().AddForce(player.GetComponentInChildren<Camera>().transform.forward * speed, ForceMode.Impulse);
                    break;
                }

            case "4":
                {
                    GameObject ice = (GameObject)Instantiate(iceball, player.transform.position, player.transform.rotation);
                    ice.GetComponent<Rigidbody>().AddForce(player.GetComponentInChildren<Camera>().transform.forward * speed, ForceMode.Impulse);
                    break;
                }

        }

        if (Player.Instance.ShieldStatus == 0 && defense){
            Debug.Log("No shield");
            Destroy(player.transform.Find("Shield(Clone)").gameObject);
            defense = false;
            }

        }

           
}
