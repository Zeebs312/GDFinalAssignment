using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MasterKohga : MonoBehaviour
{
    public static int dialogueNumber = 0;
    public TMP_Text dialogueText;
    public GameObject healthText;
    public GameObject nameText;
    public GameObject congratsText;
    //private Button continueButton;
    public GameObject dialogueBox;
    public GameObject enemy;
    public GameObject pistol;
    public float health = 1000000f;
    bool showMercy;

    // Start is called before the first frame update
    void Start()
    {
        dialogueBox.SetActive(true);
        healthText.SetActive(true);
        nameText.SetActive(true);
        congratsText.SetActive(false);
        showMercy = false;
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(Dialogue());
        StartCoroutine(Mercy());
    }

    public void TakeDamage(float dmg)
    {
        health -= dmg;
        Destroy(enemy);
        healthText.SetActive(false);
        nameText.SetActive(false);
        congratsText.SetActive(true);
    }

    IEnumerator Dialogue()
    {
        if (showMercy == false)
        {
            if (Input.GetKey(KeyCode.Mouse0))
            {
                pistol.SetActive(true);
                dialogueBox.SetActive(false);
                yield return new WaitForSeconds(5);
                dialogueBox.SetActive(true);
                dialogueText = GameObject.Find("DialogueText").GetComponent<TMP_Text>();
                dialogueText.text = "Wait I don't feel so good ...... What's the expiration date for these banana's? 10 YEARS AGO! I am rapidly reaching death's door, please put me out of my misery";
                showMercy = true;
            }
        }
    }

    IEnumerator Mercy()
    {
        if (showMercy == true)
        {
            if (Input.GetKey(KeyCode.Mouse0))
            {
                dialogueBox.SetActive(false);
                yield return new WaitForSeconds(2);
                Weapon.canShoot = true;
            }
        }
    }  
}
