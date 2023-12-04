using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class InvManager : MonoBehaviour
{
    public bool pickup;
    public TMP_Text PickupText;
    public Transform hand;
    public GameObject pistol;
    public GameObject ar;
    public GameObject sniper;
    public GameObject homing;
    public GameObject rocket;
    public bool pickedUpP;
    public bool pickedUpA;
    public bool pickedUpS;
    public bool pickedUpH;
    public bool pickedUpR;
    private int index;
    private bool gotGun;
    public GameObject HandXD;
    public List<GameObject> Inv;
    private GameObject selectedWeapon;
    // Start is called before the first frame update
    void Start()
    {
        index = 0;
        PickupText.gameObject.SetActive(false);
        pickup = false;
        pickedUpP = false;
        pickedUpA = false;
        pickedUpS = false;
        pickedUpH = false;
        pickedUpR = false;
        Inv = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        if (pickedUpA || pickedUpH || pickedUpP || pickedUpH || pickedUpR)
        {
            gotGun = true;
        }
        else
            gotGun = false;
        if (gotGun)
        {
            foreach (var weapon in Inv)
            {
                weapon.SetActive(false);
            }
            index = Mathf.Clamp(index, 0, Inv.Count - 1);
            selectedWeapon = Inv[index];
            selectedWeapon.SetActive(true);
            if (Input.GetAxis("Mouse ScrollWheel") > 0f)
            {
                index++;
            }
            else if (Input.GetAxis("Mouse ScrollWheel") < 0f)
            {
                index--;
            }
        }
    }

    void OnTriggerStay(Collider col)
    {
        if (col.gameObject.tag == "Pistol")
        {
            PickupText.gameObject.SetActive(true);
            pickup = true;
            if (Input.GetKeyDown(KeyCode.E) && pickup)
            {
                PickupText.gameObject.SetActive(false);
                var item = col.GetComponent<Pistol>();
                if (item)
                {
                    Inv.Add(item.gameObject);
                    pistol.transform.SetParent(hand);
                    pistol.transform.position = hand.transform.position;
                    pistol.transform.rotation = hand.transform.rotation * Quaternion.Euler(0, 87.6f, 2.7f);
                    pistol.GetComponent<Rigidbody>().isKinematic = true;
                    pickedUpP = true;
                }
                pickup = false;
            }
        }
        if (col.gameObject.tag == "AR")
        {
            PickupText.gameObject.SetActive(true);
            pickup = true;
            if (Input.GetKeyDown(KeyCode.E) && pickup)
            {
                PickupText.gameObject.SetActive(false);
                var item = col.GetComponent<AR>();
                if (item)
                {
                    Inv.Add(item.gameObject);
                    ar.transform.SetParent(hand);
                    ar.transform.position = hand.transform.position;
                    ar.transform.rotation = hand.transform.rotation * Quaternion.Euler(1.18f, -0.75f, 0f);
                    ar.GetComponent<Rigidbody>().isKinematic = true;
                    pickedUpA = true;
                }
                pickup = false;
            }
        }
        if (col.gameObject.tag == "Sniper")
        {
            PickupText.gameObject.SetActive(true);
            pickup = true;
            if (Input.GetKeyDown(KeyCode.E) && pickup)
            {
                PickupText.gameObject.SetActive(false);
                var item = col.GetComponent<Sniper>();
                if (item)
                {
                    Inv.Add(item.gameObject);
                    sniper.transform.SetParent(hand);
                    sniper.transform.position = hand.transform.position;
                    sniper.transform.rotation = hand.transform.rotation * Quaternion.Euler(2.79f, 0f, 0);
                    sniper.GetComponent<Rigidbody>().isKinematic = true;
                    pickedUpS = true;
                }
                pickup = false;
            }
        }
        if (col.gameObject.tag == "RPG")
        {
            PickupText.gameObject.SetActive(true);
            pickup = true;
            if (Input.GetKeyDown(KeyCode.E) && pickup)
            {
                PickupText.gameObject.SetActive(false);
                var item = col.GetComponent<RPGLauncher>();
                if (item)
                {
                    Inv.Add(item.gameObject);
                    rocket.transform.SetParent(hand);
                    rocket.transform.position = hand.transform.position;
                    rocket.transform.rotation = hand.transform.rotation * Quaternion.Euler(0, 0, 5f);
                    rocket.GetComponent<Rigidbody>().isKinematic = true;
                    pickedUpR = true;
                }
                pickup = false;
            }
        }
        if (col.gameObject.tag == "Homing")
        {
            PickupText.gameObject.SetActive(true);
            pickup = true;
            if (Input.GetKeyDown(KeyCode.E) && pickup)
            {
                PickupText.gameObject.SetActive(false);
                var item = col.GetComponent<HomingLauncher>();
                if (item)
                {
                    Inv.Add(item.gameObject);
                    homing.transform.SetParent(hand);
                    homing.transform.position = hand.transform.position;
                    homing.transform.rotation = hand.transform.rotation * Quaternion.Euler(0, 0, 5f);
                    homing.GetComponent<Rigidbody>().isKinematic = true;
                    pickedUpH = true;
                }
                pickup = false;
            }
        }
    }
    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "Pistol")
        {
            PickupText.gameObject.SetActive(false);
            pickup = false;
        }
        if (col.gameObject.tag == "AR")
        {
            PickupText.gameObject.SetActive(false);
            pickup = false;
        }
        if (col.gameObject.tag == "Sniper")
        {
            PickupText.gameObject.SetActive(false);
            pickup = false;
        }
        if (col.gameObject.tag == "RPG")
        {
            PickupText.gameObject.SetActive(false);
            pickup = false;
        }
        if (col.gameObject.tag == "Homing")
        {
            PickupText.gameObject.SetActive(false);
            pickup = false;
        }
    }

}
