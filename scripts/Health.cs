using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class Health : MonoBehaviour
{
    public int health = 10;
    public Text healthDisplay;
    private PhotonView view;

    void Start()
    {
        view = FindObjectOfType<PhotonView>();
    }

    public void TakeDamage()
    {
        view.RPC("TakeDamageRPC", RpcTarget.All);
    }
    
    [PunRPC]
    public void TakeDamageRPC()
    {
        health--;
        healthDisplay.text = health.ToString();
    }
}