using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnBanana : MonoBehaviour
{
    // Start is called before the first frame update
    public static int bananasCollected;
    public GameObject firstBanana;
    public GameObject secondBanana;
    public GameObject thirdBanana;
    public GameObject fourthBanana;
    public GameObject fifthBanana;
    public GameObject ReturnText;

    public static bool firstReturned;
    public static bool secondReturned;
    public static bool thirdReturned;
    public static bool fourthReturned;
    public static bool fifthReturned;

    public TMP_Text bananaText;
    public TMP_Text dialogueText;
    //private Button continueButton;
    public GameObject dialogueBox;

    bool talking;

    private void Start()
    {
        bananasCollected = 0;
        ReturnText.SetActive(false);

        firstReturned = false;
        secondReturned = false;
        thirdReturned = false;
        fourthReturned = false;
        fifthReturned =  false;
        talking = false;
}

    private void Update()
    {
        Debug.Log(bananasCollected);
        bananaText = GameObject.Find("ItemsCollected").GetComponent<TMP_Text>();
        bananaText.text = "Bananas Returned: " + bananasCollected.ToString();

        if(bananasCollected == 5)
        {
            dialogueBox.SetActive(true);
            dialogueText = GameObject.Find("DialogueText").GetComponent<TMP_Text>();
            dialogueText.text = "At last I finally have all the banana's you fool! Now that the Cabaiste nomads are gone, it is time to harness the power of the banana's. As promised here is your gift, we shall battle now.";
            if (Input.GetKey(KeyCode.Mouse0))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player" && this.gameObject.tag == "Merchant")
        {
            if (BananaController.hasBanana == true)
            {
                ReturnText.SetActive(true);
                if (Input.GetKey(KeyCode.Q))
                {
                    bananasCollected++;
                    dialogueBox.SetActive(true);
                    dialogueText = GameObject.Find("DialogueText").GetComponent<TMP_Text>();
                    dialogueText.text = "Thank you good sir, only " + bananasCollected.ToString() +
                                    " more banana's to collect. Vanquish those fiendish troublemakers from this realm once & for all.";
                    NPCTrigger.dialogueNumber = 2;
                    talking = true;
                    
                    if (BananaController.firstCollected == true)
                    {
                        firstBanana.SetActive(false);
                        ReturnText.SetActive(false);
                        BananaController.hasBanana = false;
                        firstReturned = true;
                    }
                    if (BananaController.secondCollected == true)
                    {
                        secondBanana.SetActive(false);
                        ReturnText.SetActive(false);
                        BananaController.hasBanana = false;
                        secondReturned = true;
                    }
                    if (BananaController.thirdCollected == true)
                    {
                        thirdBanana.SetActive(false);
                        ReturnText.SetActive(false);
                        BananaController.hasBanana = false;
                        thirdReturned = true;
                    }
                    if (BananaController.fourthCollected == true)
                    {
                        fourthBanana.SetActive(false);
                        ReturnText.SetActive(false);
                        BananaController.hasBanana = false;
                        fourthReturned = true;
                    }
                    if (BananaController.fifthCollected == true)
                    {
                        fifthBanana.SetActive(false);
                        ReturnText.SetActive(false);
                        BananaController.hasBanana = false;
                        fifthReturned = true;
                    }
                }
                if(talking == true)
                {
                    if (Input.GetKey(KeyCode.Mouse0))
                    {
                        dialogueBox.SetActive(false);
                        dialogueText.text = " ";
                        talking = false;
                    }
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        ReturnText.SetActive(false);
    }
}
