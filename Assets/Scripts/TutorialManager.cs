using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    public GameObject[] popUps;
    public int popUpIndex;

    private bool PickUpDone = false;

    void Update()
    {
        if (popUpIndex == 0)
        {
            if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D))
            {

                StartCoroutine(HandleIt());
                

            }

        }

        if (popUpIndex == 1)
        {
           
            if (Input.GetKeyDown(KeyCode.Q))
            {
                StartCoroutine(HandleIt());
                StartCoroutine(CandleIt());
            }
        }

        if (popUpIndex == 2)
        {
            if (Input.GetMouseButtonDown(0))
            {
                StartCoroutine(HandleIt());
                StartCoroutine(CandleIt());
            }
        }

        if (popUpIndex == 3)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                StartCoroutine(HandleIt());
            }
        }

        if (popUpIndex == 4)
        {
            if (Input.GetMouseButtonDown(0))
            {
                StartCoroutine(HandleIt());
                StartCoroutine(CandleIt());
            }
        }
        if (popUpIndex == 5)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                StartCoroutine(HandleIt());
            }
        }

        if (popUpIndex == 6)
        {
            this.enabled = false;
        }


    }
    private IEnumerator HandleIt()
    {
        yield return new WaitForSeconds(0.5f);
        // process post-yield
        popUps[popUpIndex].SetActive(false);
        popUpIndex++;
    }

    private IEnumerator CandleIt()
    {
        yield return new WaitForSeconds(0.5f);
        // process post-yield
        popUps[popUpIndex].SetActive(true);
        

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Wood" && !PickUpDone)
        {
            popUps[popUpIndex].SetActive(true);
            PickUpDone = true;
        }

        if (collision.gameObject.name == "Crafting Table" && popUpIndex == 4)
        {
            popUps[popUpIndex].SetActive(true);
        }
    }
}
