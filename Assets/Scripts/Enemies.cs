using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemies : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform[] waypoints;
    public float startWaitTime = 4;
    public GameObject player;
    public GameObject playerBanana;
    public GameObject enemy;
    public GameObject enemyBanana;
    private float detectedRadius = 5;
    private float lookingRadius = 8;
    bool playerDetected;
    
    private void Start()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        agent.destination = waypoints[0].position;

        agent.speed = 7f;
    }

    private void Update()
    {
        Waypoints();
        
        if(playerBanana.name == "Banana1R")
        {
            if (BananaController.firstCollected == true && ReturnBanana.firstReturned == false)
            {
                agent.destination = player.transform.position;
                playerDetected = true;
                agent.speed = 10f;
                if (Vector3.Distance(player.transform.position, gameObject.transform.position) <= detectedRadius)
                {
                    takeBanana();
                    BananaController.firstCollected = false;
                }
                else
                {
                    agent.speed = 7f;
                }
            }
           
            if (Vector3.Distance(player.transform.position, gameObject.transform.position) <= lookingRadius)
            {
                playerDetected = true;
                if(playerDetected == true)
                {
                    agent.speed = 10f;
                    agent.destination = player.transform.position;
                }
            }
            else
            {
                agent.speed = 7f;
                playerDetected = false;
            }

            if (ReturnBanana.firstReturned == true)
            {
                Destroy(enemy);
            }
        }

        if (playerBanana.name == "Banana2R")
        {
            if (BananaController.secondCollected == true && ReturnBanana.secondReturned == false)
            {
                agent.speed = 10f;
                agent.destination = player.transform.position;
                playerDetected = true;
                if (Vector3.Distance(player.transform.position, gameObject.transform.position) <= detectedRadius)
                {
                    takeBanana();
                    BananaController.secondCollected = false;
                }
                else
                {
                    agent.speed = 7f;
                }
            }

            if (Vector3.Distance(player.transform.position, gameObject.transform.position) <= lookingRadius)
            {
                playerDetected = true;
                if (playerDetected == true)
                {
                    agent.speed = 10f;
                    agent.destination = player.transform.position;
                }
            }
            else
            {
                agent.speed = 7f;
                playerDetected = false;
            }

            if (ReturnBanana.secondReturned == true)
            {
                Destroy(enemy);
            }
        }
        if (playerBanana.name == "Banana3R")
        {
            if (BananaController.thirdCollected == true && ReturnBanana.thirdReturned == false)
            {
                agent.destination = player.transform.position;
                playerDetected = true;
                agent.speed = 10f;
                if (Vector3.Distance(player.transform.position, gameObject.transform.position) <= detectedRadius)
                {
                    takeBanana();
                    BananaController.thirdCollected = false;
                }
                else
                {
                    agent.speed = 7f;
                }
            }

            if (Vector3.Distance(player.transform.position, gameObject.transform.position) <= lookingRadius)
            {
                playerDetected = true;
                if (playerDetected == true)
                {
                    agent.speed = 10f;
                    agent.destination = player.transform.position;
                }
            }
            else
            {
                agent.speed = 7f;
                playerDetected = false;
            }

            if (ReturnBanana.thirdReturned == true)
            {
                Destroy(enemy);
            }
        }
        if (playerBanana.name == "Banana4R")
        {
            if (BananaController.fourthCollected == true && ReturnBanana.fourthReturned == false)
            {
                agent.speed = 10f;
                agent.destination = player.transform.position;
                playerDetected = true;
                if (Vector3.Distance(player.transform.position, gameObject.transform.position) <= detectedRadius)
                {
                    takeBanana();
                    BananaController.fourthCollected = false;
                }
                else
                {
                    agent.speed = 7f;
                }
            }


            if (Vector3.Distance(player.transform.position, gameObject.transform.position) <= lookingRadius)
            {
                playerDetected = true;
                if (playerDetected == true)
                {
                    agent.speed = 10f;
                    agent.destination = player.transform.position;
                }
            }
            else
            {
                agent.speed = 7f;
                playerDetected = false;
            }

            if (ReturnBanana.fourthReturned == true)
            {
                Destroy(enemy);
            }
        }
        if (playerBanana.name == "Banana5R")
        {
            if (BananaController.fifthCollected == true && ReturnBanana.fifthReturned == false)
            {
                agent.speed = 10f;
                agent.destination = player.transform.position;
                playerDetected = true;
                if (Vector3.Distance(player.transform.position, gameObject.transform.position) <= detectedRadius)
                {
                    takeBanana();
                    BananaController.fifthCollected = false;
                }
                else
                {
                    agent.speed = 7f;
                }
            }

            if (Vector3.Distance(player.transform.position, gameObject.transform.position) <= lookingRadius)
            {
                playerDetected = true;
                if (playerDetected == true)
                {
                    agent.speed = 10f;
                    agent.destination = player.transform.position;
                }
            }
            else
            {
                agent.speed = 7f;
                playerDetected = false;
            }

            if (ReturnBanana.fifthReturned == true)
            {
                Destroy(enemy);
            }
        }
    }

    private void takeBanana()
    {
        BananaController.hasBanana = false;
        playerBanana.SetActive(false);
        enemyBanana.SetActive(true);
        playerDetected = false;
        Waypoints();
    }

    private void Waypoints()
    {
        if (agent.remainingDistance < 0.5f && playerDetected == false)
        {
            agent.destination = waypoints[Random.Range(0, waypoints.Length)].position;
        }
    }
}