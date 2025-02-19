using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class FlashColor : MonoBehaviour
{
    public MeshRenderer meshRenderer;

    [NaughtyAttributes.Button]

    private void Flash()
    {
        meshRenderer.material.DOColor(Color.red, "_EmissionColor", .2f).SetLoops(2, LoopType.Yoyo);
    }
}
