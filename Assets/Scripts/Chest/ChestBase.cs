using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ChestBase : MonoBehaviour
{
    public KeyCode keyCode = KeyCode.Z;
    public Animator animator;
    public string triggerOpen = "Open";

    [Header("Notification")]
    public GameObject notification;
    public float tweenDuration = .2f;
    public Ease tweenEase = Ease.OutBack;
    private float startScale;

    private bool _chestOpened = false;

    private void Start()
    {
        startScale = notification.transform.localScale.x;
        HideNotification();
    }


    [NaughtyAttributes.Button]
    private void Openchest()
    {
        if(_chestOpened) return;

        animator.SetTrigger(triggerOpen);
        _chestOpened = true;
        HideNotification();
    }

    public void OnTriggerEnter(Collider other)
    {
        Player p = other.transform.GetComponent<Player>();
        if (p != null)
        {
            ShowNotification();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Player p = other.transform.GetComponent<Player>();
        if (p != null)
        {
            HideNotification();
        }
    }

    private void ShowNotification()
    {
        notification.SetActive(true);
        notification.transform.localScale = Vector3.zero;
        notification.transform.DOScale(startScale, tweenDuration);
    }

    private void HideNotification()
    {
        notification.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(keyCode) && notification.activeSelf)
        {
            Openchest();
        }
    }
}
