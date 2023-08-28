using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [Header("Timer")]
    private float countDownTimer = 5f;
    [SerializeField] private TextMeshProUGUI countDownText;

    [Header("Things to stop")]
    [SerializeField] private PlayerCar playerCar;
    [SerializeField] private PlayerCar playerCar_Caravan;
    [SerializeField] private PlayerCar playerCar_Diesel;
    [SerializeField] private PlayerCar playerCar_Megan;
    [SerializeField] private PlayerCar playerCar_Fury;
    [SerializeField] private PlayerCar playerCar_Stranger;
    [SerializeField] private OpponentCar opponentCar_Stranger;
    [SerializeField] private OpponentCar opponentCar_Megan;
    [SerializeField] private OpponentCar opponentCar_Fury;
    [SerializeField] private OpponentCar opponentCar_Caravan;
    [SerializeField] private OpponentCar opponentCar_Diesel;
    [SerializeField] private OpponentCar opponentCar_Thunder;


    private void Start()
    {
        StartCoroutine(TimeCount());
    }

    private void Update()
    {
        if(countDownTimer > 1)
        {
            playerCar.accelerationForce = 0f;
            playerCar_Caravan.accelerationForce = 0f;
            playerCar_Diesel.accelerationForce = 0f;
            playerCar_Megan.accelerationForce = 0f;
            playerCar_Fury.accelerationForce = 0f;
            playerCar_Stranger.accelerationForce = 0f;
            opponentCar_Stranger.movingSpeed = 0f;
            opponentCar_Megan.movingSpeed = 0f;
            opponentCar_Fury.movingSpeed = 0f;
            opponentCar_Caravan.movingSpeed = 0f;
            opponentCar_Diesel.movingSpeed = 0f;
            opponentCar_Thunder.movingSpeed = 0f;
        }

        if (countDownTimer == 0)
        {
            playerCar.accelerationForce = 300f;
            playerCar_Caravan.accelerationForce = 300f;
            playerCar_Diesel.accelerationForce = 300f;
            playerCar_Megan.accelerationForce = 300f;
            playerCar_Fury.accelerationForce = 300f;
            playerCar_Stranger.accelerationForce = 300f;
            opponentCar_Stranger.movingSpeed = 15f;
            opponentCar_Megan.movingSpeed = 12f;
            opponentCar_Fury.movingSpeed = 15f;
            opponentCar_Caravan.movingSpeed = 18f;
            opponentCar_Diesel.movingSpeed = 12f;
            opponentCar_Thunder.movingSpeed = 10f;
        }

    }
    IEnumerator TimeCount()
    {
        while(countDownTimer > 0)
        {
            countDownText.text = countDownTimer.ToString();
            yield return new WaitForSeconds(1f);
            countDownTimer--;
        }

        countDownText.text = "GO";
        yield return new WaitForSeconds(1f);
        countDownText.gameObject.SetActive(false);
    }
}
