using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectBanana : MonoBehaviour
{
    public GameObject playerBanana;

    public GameObject PickUpText;
    public GameObject WarningText;
    // Start is called before the first frame update
    void Start()
    {
        playerBanana.SetActive(false);

        PickUpText.SetActive(false);
        WarningText.SetActive(false);
    }

    private void Update()
    {

    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player" && this.gameObject.tag == "FirstBanana")
        {
            if (BananaController.hasBanana == false)
            {
                PickUpText.SetActive(true);
                if (Input.GetKey(KeyCode.F))
                {
                    this.gameObject.SetActive(false);
                    playerBanana.SetActive(true);
                    PickUpText.SetActive(false);
                    BananaController.hasBanana = true;
                    BananaController.firstCollected = true;
                }
            }
            else
            {
                WarningText.SetActive(true);
            }
        }

        if (other.gameObject.tag == "Player" && this.gameObject.tag == "SecondBanana")
        {
            if (BananaController.hasBanana == false)
            {
                PickUpText.SetActive(true);
                if (Input.GetKey(KeyCode.F))
                {
                    this.gameObject.SetActive(false);
                    playerBanana.SetActive(true);
                    PickUpText.SetActive(false);
                    BananaController.hasBanana = true;
                    BananaController.secondCollected = true;
                }
            }
            else
            {
                WarningText.SetActive(true);
            }
        }

        if (other.gameObject.tag == "Player" && this.gameObject.tag == "ThirdBanana")
        {
            if (BananaController.hasBanana == false)
            {
                PickUpText.SetActive(true);
                if (Input.GetKey(KeyCode.F))
                {
                    this.gameObject.SetActive(false);
                    playerBanana.SetActive(true);
                    PickUpText.SetActive(false);
                    BananaController.hasBanana = true;
                    BananaController.thirdCollected = true;
                }
            }
            else
            {
                WarningText.SetActive(true);
            }
        }

        if (other.gameObject.tag == "Player" && this.gameObject.tag == "FourthBanana")
        {
            if (BananaController.hasBanana == false)
            {
                PickUpText.SetActive(true);
                if (Input.GetKey(KeyCode.F))
                {
                    this.gameObject.SetActive(false);
                    playerBanana.SetActive(true);
                    PickUpText.SetActive(false);
                    BananaController.hasBanana = true;
                    BananaController.fourthCollected = true;
                }
            }
            else
            {
                WarningText.SetActive(true);
            }
        }


        if (other.gameObject.tag == "Player" && this.gameObject.tag == "FifthBanana")
        {
            if (BananaController.hasBanana == false)
            {
                PickUpText.SetActive(true);
                if (Input.GetKey(KeyCode.F))
                {
                    this.gameObject.SetActive(false);
                    playerBanana.SetActive(true);
                    PickUpText.SetActive(false);
                    BananaController.hasBanana = true;
                    BananaController.fifthCollected = true;
                }
            }
            else
            {
                WarningText.SetActive(true);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        PickUpText.SetActive(false);
        WarningText.SetActive(false);
    }
}
