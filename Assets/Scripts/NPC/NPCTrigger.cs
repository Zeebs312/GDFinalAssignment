using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NPCTrigger : MonoBehaviour
{
    public static int dialogueNumber = 0;
    public TMP_Text dialogueText;
    //private Button continueButton;
    public GameObject dialogueBox;
    public GameObject TalkNotification;
    public bool endDialogue = false;
    public bool finalLine = false;
    public bool canTalk = false;
    public bool nextLine;

    private void Start()
    {
        dialogueNumber = 1;
        dialogueBox.SetActive(false);
        TalkNotification.SetActive(false);
        canTalk = true;
        nextLine = false;
    }
    private void Update()
    {
        if (canTalk == false)
        {
            Talking();
        }
    }

    private void Talking()
    {
        if (endDialogue == true)
        {
            if (Input.GetKey(KeyCode.Mouse0))
            {
                dialogueText.text = "";
                dialogueBox.SetActive(false);
                canTalk = true;
                endDialogue = false;
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player" && this.gameObject.tag == "Merchant") {
            if (BananaController.hasBanana == false && canTalk == true)
            {
                TalkNotification.SetActive(true);
                if (Input.GetKey(KeyCode.E))
                {
                    canTalk = false;
                    TalkNotification.SetActive(false);
                    dialogueBox.SetActive(true);
                    if (BananaController.hasBanana == false && BananaController.noBananas == false)
                    {
                        switch (dialogueNumber)
                        {
                            case 1:
                                dialogueText = GameObject.Find("DialogueText").GetComponent<TMP_Text>();
                                dialogueText.text = "Greetings traveller I need your assistance, my banana's have be stolen by the dastardly Cabaiste Normads of Mount Badger." + 
                                    "If you retrieve 5 of my stolen banana's, I'll give you a reward for your troubles. Stay vigilant as they will chase you if take their banana.";
                                endDialogue = true;
                                break;
                            case 2:
                                dialogueText = GameObject.Find("DialogueText").GetComponent<TMP_Text>();
                                dialogueText.text = "Thank you good sir, only " + ReturnBanana.bananasCollected.ToString() +
                                    " more banana's to collect. Smith those fiendish troublemakers from this realm.";
                                endDialogue = true;
                                break;
                            default:
                                Debug.Log("");
                                break;
                        }
                    }    
                }
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        dialogueBox.SetActive(false);
        TalkNotification.SetActive(false);
        canTalk = true;
    }
}



