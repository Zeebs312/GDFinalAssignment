using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BananaController : MonoBehaviour
{
    public static bool hasBanana;
    public static bool noBananas;
    public static bool firstCollected;
    public static bool secondCollected;
    public static bool thirdCollected;
    public static bool fourthCollected;
    public static bool fifthCollected;

    private void Start()
    {
        hasBanana = false;
        noBananas = false;
        firstCollected = false;
        secondCollected = false;
        thirdCollected = false;
        fourthCollected = false;
        fifthCollected = false;
    }
}
