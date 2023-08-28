using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpponentCarWaypoints : MonoBehaviour
{
    [Header("Opponent Car")]
    [SerializeField] public OpponentCar opponentCar;
    [SerializeField] private WayPoint currentWayPoint;

    private void Awake()
    {
        opponentCar = GetComponent<OpponentCar>();
    }

    private void Start()
    {
        opponentCar.LocateDestination(currentWayPoint.GetPosition());
    }

    private void Update()
    {
        if (opponentCar.destinationReached)
        {
            currentWayPoint = currentWayPoint.nexrWaypoint;
            opponentCar.LocateDestination(currentWayPoint.GetPosition());
        }
    }
}
