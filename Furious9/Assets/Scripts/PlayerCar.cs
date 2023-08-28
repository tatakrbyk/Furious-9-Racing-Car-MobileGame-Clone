using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements.Experimental;

public class PlayerCar : MonoBehaviour
{
    [Header("Wheels collider")]
    [SerializeField] public WheelCollider frontLeftWheelCollider;
    [SerializeField] public WheelCollider frontRightWheelCollider;
    [SerializeField] public WheelCollider backLeftWheelCollider;
    [SerializeField] public WheelCollider backRightWheelCollider;

    [Header("Wheels Transform")]
    [SerializeField] private Transform frontLeftWheelTransform;
    [SerializeField] private Transform frontRightWheelTransform;
    [SerializeField] private Transform backLeftWheelTransform;
    [SerializeField] private Transform backRightWheelTransform;

    [Header("Car Engine")]
    public float accelerationForce = 300f;
    public float breakingForce = 3000f;
    public float presentBreakForce = 0f;
    private float presentAccelerationForce = 0f;

    [Header("Car Steering")]
    public float wheelsTorque = 35f;
    private float presentTurnAngle = 0f;

    [Header("CarSounds")]
    [SerializeField] public AudioSource audioSource;
    [SerializeField] public AudioClip accelerationSound;
    [SerializeField] public AudioClip slowAccelerationSound;
    [SerializeField] public AudioClip stopSound;

    public Button breaksButton;

    private void Start()
    {
        breaksButton.GetComponent<Button>();

    }
    private void Update()
    {
        
       
        breaksButton?.onClick.AddListener(() => { StartCoroutine(carBreaks()); });
        MoveCar();
        CarSteering();
        
          
    }

    private void MoveCar()
    {
        //FWD
        frontLeftWheelCollider.motorTorque = presentAccelerationForce;
        frontRightWheelCollider.motorTorque = presentAccelerationForce;
        backLeftWheelCollider.motorTorque = presentAccelerationForce;
        backRightWheelCollider.motorTorque = presentAccelerationForce;

        presentAccelerationForce = accelerationForce * SimpleInput.GetAxis("Vertical");

        if(presentAccelerationForce > 0f )
        {
            audioSource.PlayOneShot(accelerationSound, 0.5f);
        }else if(presentAccelerationForce < 0f)
        {
            audioSource.PlayOneShot(slowAccelerationSound, 0.5f);

        }
        else if(presentAccelerationForce == 0)
        {
            audioSource.PlayOneShot(stopSound, 0.3f);

        }
    }

    private void CarSteering()
    {
        presentTurnAngle = wheelsTorque * SimpleInput.GetAxis("Horizontal");
        frontLeftWheelCollider.steerAngle = presentTurnAngle;
        frontRightWheelCollider.steerAngle = presentTurnAngle;

        SteeringWheels(frontLeftWheelCollider, frontLeftWheelTransform);
        SteeringWheels(frontRightWheelCollider, frontRightWheelTransform);
        SteeringWheels(backLeftWheelCollider, backLeftWheelTransform);
        SteeringWheels(backRightWheelCollider, backRightWheelTransform);

    }

    private void SteeringWheels(WheelCollider WC, Transform WT)
    {
        Vector3 position;
        Quaternion rotation;

        WC.GetWorldPose(out position, out rotation);

        WT.position = position; 
        WT.rotation = rotation;
    }

   public void ApplyBreaks()
   {
        StartCoroutine(carBreaks());
   }

    IEnumerator carBreaks()
    {
        presentBreakForce = breakingForce;

        frontLeftWheelCollider.brakeTorque = presentBreakForce;
        frontRightWheelCollider.brakeTorque = presentBreakForce;
        backLeftWheelCollider.brakeTorque = presentBreakForce;
        backRightWheelCollider.brakeTorque = presentBreakForce;

        yield return new WaitForSeconds(2f);

        presentBreakForce = 0f;
        frontLeftWheelCollider.brakeTorque = presentBreakForce;
        frontRightWheelCollider.brakeTorque = presentBreakForce;
        backLeftWheelCollider.brakeTorque = presentBreakForce;
        backRightWheelCollider.brakeTorque = presentBreakForce;
    }
}
