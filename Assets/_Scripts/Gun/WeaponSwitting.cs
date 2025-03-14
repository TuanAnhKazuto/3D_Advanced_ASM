using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ProBuilder.MeshOperations;

public class WeaponSwitting : MonoBehaviour
{
    public int selectedWeapon = 0;



    void Start()
    {
        SelectWeapon();
    }

    // Update is called once per frame
    void Update()
    {
        int previousSelectedWeapon = selectedWeapon;

        if (Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            if (selectedWeapon >= transform.childCount - 1)
                selectedWeapon = 0;
            else
                selectedWeapon++;
        }
        if(Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            if(selectedWeapon <= 0)
               selectedWeapon = transform.childCount - 1;
               else
               selectedWeapon--;
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            selectedWeapon = 0;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2) && transform.childCount >=2)
        {
            selectedWeapon = 1;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3) && transform.childCount >=3)
        {
            selectedWeapon = 2;
        }
        if (Input.GetKeyDown(KeyCode.Alpha4) && transform.childCount >=4)
        {
            selectedWeapon = 3;
        }
        

        if (previousSelectedWeapon != selectedWeapon)
        {
            SelectWeapon();
        }


    }
    void SelectWeapon()
    {
        int i = 0;
        foreach (Transform weapn in transform)
            {
                if (i == selectedWeapon)
                weapn.gameObject.SetActive(true);
                else
                weapn.gameObject.SetActive(false);
                i++;
            }
    }
} 
