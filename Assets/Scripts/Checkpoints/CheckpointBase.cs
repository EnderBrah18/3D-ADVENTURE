using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class CheckpointBase : MonoBehaviour
{
    public SFXType sfxType;

    public MeshRenderer meshRenderer;
    public int key = 01;

    [Header("Animation")]
    public float startAnimationDuration = .5f;
    public Ease startAnimationEase = Ease.OutBack;

    [Header("Text")]
    public float displayTime = 2f;
    public TextMeshProUGUI textMeshPro;


    private bool checkpointActivated = false;
    private string checkpointKey = "CheckpointKey";

    private void PlaySFX()
    {
        SFXPool.Instance.Play(sfxType);
    }


    private void OnTriggerEnter(Collider other)
    {
        if (!checkpointActivated && other.transform.tag == "Player")
        {
            PlaySFX();
            CheckCheckpoint();
            StartCoroutine(DisplayText());

        }
    }

    private void CheckCheckpoint()
    {
        TurnItOn();
        SaveCheckpoint();
    }

    [NaughtyAttributes.Button]
    private void TurnItOn()
    {
        meshRenderer.material.SetColor("_EmissionColor", Color.white);
    }
    
    [NaughtyAttributes.Button]
    private void TurnItOff()
    {
        meshRenderer.material.SetColor("_EmissionColor", Color.grey);
    }

    private void SaveCheckpoint()
    {
        if(PlayerPrefs.GetInt(checkpointKey, 0) > key)
             PlayerPrefs.SetInt(checkpointKey, key);

        CheckpointManager.Instance.SaveCheckPoint(key);

        checkpointActivated = true;
    }

    private IEnumerator DisplayText()
    {
        textMeshPro.gameObject.SetActive(true);
        textMeshPro.rectTransform.DOScale(Vector3.one * 1.5f, 1f).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.InOutBounce);
        yield return new WaitForSeconds(displayTime);
        textMeshPro.rectTransform.DOScale(Vector3.zero * 1.5f, 1f).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.InOutBounce);
        textMeshPro.gameObject.SetActive(false); 
    }
}
