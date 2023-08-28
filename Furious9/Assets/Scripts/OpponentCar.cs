using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpponentCar : MonoBehaviour
{
    [Header("Car Engine")]

    [SerializeField] public float movingSpeed = 7f;
    [SerializeField] private float turningSpeed = 50f;
    [SerializeField] private float breakSpeed = 12f;

    [Header("Destination Var")]

    [SerializeField] private Vector3 destination;
    [SerializeField] public bool destinationReached;

    private void Update()
    {
        Drive();
    }

    public void Drive()
    {
        if(transform.position != destination)
        {
            Vector3 destinationDirection = destination - transform.position;
            destinationDirection.y = 0;
            float destinationDistance = destinationDirection.magnitude;

            if(destinationDistance >= breakSpeed)
            {
                // Steering car
                destinationReached = false;
                Quaternion targetRotation = Quaternion.LookRotation(destinationDirection);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, turningSpeed * Time.deltaTime);

                // Move Vehicle
                transform.Translate(Vector3.forward * movingSpeed * Time.deltaTime);

            }
            else
            {
                destinationReached = true;
            }
        }
    }

    public void LocateDestination(Vector3 destination)
    {
        this.destination = destination;
        destinationReached = false;
    }

}
             