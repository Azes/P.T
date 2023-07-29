using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TelePortPlayer : MonoBehaviour
{

    public Camera c;
    public GameObject viewField;

    public Transform floorOne, floorTwo;

    public Transform testBall;

    //your player script / gameobject
    //public BetterPlayer player;

    bool inSide;


    private void OnTriggerEnter(Collider other)
    {
        inSide = true;
    }

    private void OnTriggerExit(Collider other)
    {
        inSide = false;
    }

    
    // Update is called once per frame
    void Update()
    {
        if(inSide && !View.IsVisible(c, viewField.gameObject))
        {
            //var p1 = floorTwo.InverseTransformPoint(player.transform.position);
            //Quaternion playerRotationInFloorTwo = Quaternion.Inverse(floorTwo.rotation) * player.transform.rotation;
           // Quaternion playerRotationInFloorOne = floorOne.rotation * playerRotationInFloorTwo;

            inSide = false;
            //player.TP_Player(floorOne.position + p1);
            //player.transform.rotation = playerRotationInFloorOne;
        }
       
    }
}
