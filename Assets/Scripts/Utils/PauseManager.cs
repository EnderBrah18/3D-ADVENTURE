using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PauseManager : MonoBehaviour
{
    protected Inputs inputs;
    public GameObject uiPause;

    public static event Action<bool> OnCursorToggle; // Evento público para toggle do cursor
    private bool cursorLocked = true;

    private bool isActive = false;

    private void Awake()
    {
        inputs = new Inputs();

        inputs.Gameplay.Pause.performed += cts => Toggle();

        inputs.Gameplay.Pause.performed += cts => ToggleCursor();

    }

    private void Toggle()
    {
        isActive = !isActive;

        if (isActive)
        {
            Pause();
        }
        else
        {
            UnPause();
        }
    }

    private void ToggleCursor()
    {
        cursorLocked = !cursorLocked;
        LockCursor(cursorLocked);

        OnCursorToggle?.Invoke(cursorLocked); // Notifica listeners como a câmera
    }


    public void Pause()
    {
        Debug.Log("Apertou");
        Time.timeScale = 0;
        uiPause.SetActive(true);
    }

    public void UnPause()
    {
        Debug.Log("Desapertou");
        Time.timeScale = 1;
        uiPause.SetActive(false);
    }


    private void OnEnable()
    {
        inputs.Gameplay.Enable();
        LockCursor(true);
        Application.focusChanged += OnFocusChanged;
    }

    private void OnDisable()
    {
        inputs.Gameplay.Disable();
        Application.focusChanged -= OnFocusChanged;
    }

    private void LockCursor(bool shouldLock)
    {
        Cursor.lockState = shouldLock ? CursorLockMode.Locked : CursorLockMode.None;
        Cursor.visible = !shouldLock;
    }

    private void OnFocusChanged(bool hasFocus)
    {
        if (hasFocus && !cursorLocked)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
}
