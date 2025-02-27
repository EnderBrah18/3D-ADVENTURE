using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Boss;

public class BossStateTrigger : MonoBehaviour
{
    public string PlayerTag = "Player";

    public GameObject bossCamera;

    public BossBase bossBase;
    private bool hasTriggered = false;

    private void Awake()
    {
        bossCamera.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!hasTriggered && other.CompareTag(PlayerTag))
        {
            bossBase.SwitchState(BossAction.INIT);
            TurnCameraOn();
            hasTriggered = true;
            gameObject.SetActive(false);
        }
    }

    private void TurnCameraOn()
    {
        bossCamera.SetActive(true);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(transform.position, transform.localScale.y);
    }

}
