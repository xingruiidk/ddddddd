using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Tank : MonoBehaviour
{
    public MonoBehaviour CarController;
    public GameObject Player;
    //public GameObject hand;
    public Transform tank;
    public TMP_Text R;
    private bool Candrive;

    public Camera PlayerCam;
    public Camera TankCam;
    public Camera MinigunCam;
    private bool driving;
    public bool IsMounted;
    // Start is called before the first frame update
    void Start()
    {
        TankCam.gameObject.SetActive(false);
        MinigunCam.gameObject.SetActive(false);
        CarController.enabled = false;
        R.gameObject.SetActive(false);
        IsMounted = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Candrive)
        {
            R.gameObject.SetActive(true);
        }
        else
        {
            R.gameObject.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            if (Candrive)
            {
            PlayerCam.gameObject.SetActive(false);
            MinigunCam.gameObject.SetActive(false);
            TankCam.gameObject.SetActive(true);
            CarController.enabled = true;
            R.gameObject.SetActive(false);
            driving = true;
            Player.transform.SetParent(tank);
            Player.SetActive(false);
            }
        }
        if (Input.GetKeyDown(KeyCode.T) && IsMounted)
        {
            PlayerCam.gameObject.SetActive(false);
            MinigunCam.gameObject.SetActive(false);
            TankCam.gameObject.SetActive(true);
            CarController.enabled = true;
            R.gameObject.SetActive(false);
            driving = true;
            Player.transform.SetParent(tank);
            Player.SetActive(false);
            IsMounted = false;
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (driving || IsMounted)
            {
            PlayerCam.gameObject.SetActive(true);
            TankCam.gameObject.SetActive(false);
            driving = false;
            CarController.enabled = false;
            Player.transform.SetParent(null);
            Player.SetActive(true);
            IsMounted = false;
            }
        }
        if (Input.GetKeyDown(KeyCode.G) && driving)
        {
            MinigunCam.gameObject.SetActive(true);
            TankCam.gameObject.SetActive(false);
            driving = false;
            CarController.enabled = false;
            IsMounted = true;
        }
    }

    void OnTriggerStay(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            Candrive = true;
            R.gameObject.SetActive(true);
        }
    }
    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            Candrive = false;
        }
    }

}
