using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpController : MonoBehaviour
{
   public Gun gunScript;
   public Rigidbody rb;
   public BoxCollider coll;
   public Transform Player, gunContainer, fpsCam;

    public float pickUpRange;
    public float dropTop, dropUp;


}
