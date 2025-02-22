using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Boss;

public class BossStateTrigger : MonoBehaviour
{
    public string PlayerTag = "Player";
    
    public BossBase bossBase;
    private bool hasTriggered = false;

    private void OnTriggerEnter(Collider other)
    {
        if (!hasTriggered && other.CompareTag(PlayerTag))
        {
            bossBase.SwitchState(BossAction.INIT);
            hasTriggered = true;
            gameObject.SetActive(false);
        }
    }
}
