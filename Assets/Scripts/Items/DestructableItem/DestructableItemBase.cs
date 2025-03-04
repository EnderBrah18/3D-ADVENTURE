using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DestructableItemBase : MonoBehaviour
{
    public healthBase healthBase;

    public float shakeDuration = .1f;
    public int shakeForce = 5;

    private void OnValidate()
    {
        if(healthBase != null) healthBase = GetComponent<healthBase>();
    }

    private void Awake()
    {
        OnValidate();
        healthBase.OnDamage += OnDamage;
    }

    private void OnDamage(healthBase h)
    {
        transform.DOShakeScale(shakeDuration, Vector3.up, shakeForce);
    }




}
