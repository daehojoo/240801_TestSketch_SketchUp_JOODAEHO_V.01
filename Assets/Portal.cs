using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    [SerializeField] private Transform playerTr;
    [SerializeField] private Transform targetLocation;
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerTr.position = targetLocation.position;
            playerTr.rotation = targetLocation.rotation;
        }
    }
    void Update()
    {
        
    }
}
