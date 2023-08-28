using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CarSelecion : MonoBehaviour
{
    [Header("Buttons and Canvas")]
    [SerializeField] private Button nextButton;
    [SerializeField] private Button previousButton;

    [Header("Cameas")]
    [SerializeField] private GameObject animationCam;
    [SerializeField] private GameObject constCam;

    [Header("Buttons and Canvas")]
    [SerializeField] private GameObject selectionCanvas;
    [SerializeField] private GameObject skipButton;
    [SerializeField] private GameObject playButton;

    private float elapsedTime = 0f;
    private float AnimationDelayTime = 8.1f;


    private int currentCar;
    private GameObject[] carList;

    private void Awake()
    {
        selectionCanvas.SetActive(false);
        playButton.SetActive(false);
        constCam.SetActive(false);
        ChooseCar(0);
    }

    private void Start()
    {
        currentCar = PlayerPrefs.GetInt("CarSelected");
        
        SetCarforPlay();

    }

    private void Update()
    {
        elapsedTime += Time.deltaTime;
        if (elapsedTime >= AnimationDelayTime)
        {

            SkipButton();

        }
    }
    private void SetCarforPlay()
    {
        //feeding car models to carList array
        carList = new GameObject[transform.childCount];

        for (int i = 0; i < transform.childCount; i++)
        {
            carList[i] = transform.GetChild(i).gameObject;
        }

        // keeping track of currentcar
        foreach (GameObject car in carList)
        {
            car.SetActive(false);
        }

        if (carList[currentCar])
        {
            carList[currentCar].SetActive(true);
        }
    }
    private void ChooseCar(int index)
    {
        previousButton.interactable = (currentCar != 0);
        nextButton.interactable= (currentCar != transform.childCount - 1);

        for(int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(i == index);
        }
    }
    
    public void SwitchCar(int switchCars)
    {
        currentCar += switchCars;
        ChooseCar(currentCar);

    }
    
    public void playGame()
    {
        PlayerPrefs.SetInt("CarSelected", currentCar);
        SceneManager.LoadScene("scene_day");
    }

    public void SkipButton()
    {

        selectionCanvas.SetActive(true);
        playButton.SetActive(true);
        skipButton.SetActive(false);
        animationCam.SetActive(false);
        constCam.SetActive(true);
    }
}
