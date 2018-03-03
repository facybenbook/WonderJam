﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CarSelectorScript : MonoBehaviour
{

    public GameObject[] cars;
    public GameObject curCar;
    private int curCarIndex;
    public Transform spawnPoint;

    [SerializeField]
    public Button readyButton;

	// Use this for initialization
	void Start ()
	{
	    initCar(0);
    }

    // Update is called once per frame
    void Update () {
		
	}

    public void SetNextCar()
    {
        curCarIndex++;
        if (curCarIndex == cars.Length)
        {
            curCarIndex = 0;
        }
        Destroy(curCar);
        initCar(curCarIndex);
    }

    public void SetPreviousCar()
    {
        curCarIndex--;
        if (curCarIndex == -1)
        {
            curCarIndex = cars.Length-1;
        }
        Destroy(curCar);
        initCar(curCarIndex);
    }

    public GameObject GetCurrentCar()
    {
        Destroy(curCar);
        return initCar(curCarIndex);
    }

    private GameObject initCar(int index)
    {
        GameObject car = Instantiate(cars[index], spawnPoint.position, spawnPoint.rotation);
        car.GetComponent<WheelVehicle>().enabled = false;
        car.GetComponent<Player>().enabled = false;
        car.GetComponent<Rigidbody>().isKinematic = true;
        car.GetComponentInChildren<Camera>().enabled = false;
        car.GetComponentInChildren<CameraPlayer>().enabled = false;
        car.transform.localScale = Vector3.one * 30;
        curCar = car;
        
        return car;
    }

    public void PlayerReady()
    {
        readyButton.interactable = false;
    }


}
