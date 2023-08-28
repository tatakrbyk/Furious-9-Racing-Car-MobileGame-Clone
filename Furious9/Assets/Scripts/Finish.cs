using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Finish : MonoBehaviour
{
    [Header("Finish UI var")]
    [SerializeField] private GameObject finishUI;
    [SerializeField] private GameObject playerUI; // Timer
    [SerializeField] private GameObject playerCarUI;

    [Header("Win/lose status")]
    [SerializeField] private TextMeshProUGUI status;

    private void Start()
    {
        StartCoroutine(waitfortheFinishUI());
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            StartCoroutine(finishZoneTimer());
            gameObject.GetComponent<BoxCollider>().enabled = false;

            status.text = "YOU WIN";
            status.color = Color.black;
        }
        if (other.gameObject.tag == "OpponentCar")
        {
            StartCoroutine(finishZoneTimer());
            gameObject.GetComponent<BoxCollider>().enabled = false;


            status.text = "YOU LOSE";
            status.color = Color.red;
        }
    }
    IEnumerator waitfortheFinishUI()
    {
        gameObject.GetComponent<BoxCollider>().enabled = false;
        yield return new WaitForSeconds(25f);
        gameObject.GetComponent<BoxCollider>().enabled = true;
    }
    IEnumerator finishZoneTimer()
    {
        finishUI.SetActive(true);
        playerUI.SetActive(false);
        playerCarUI.SetActive(false);

        yield return new WaitForSeconds(5f);
        Time.timeScale = 0f;
    }
}
