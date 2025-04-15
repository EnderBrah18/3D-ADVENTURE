using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using Ebac.Core.Singleton;
using Itens;
using System;

public class SaveManager : Singleton<SaveManager>
{
    [SerializeField] private SaveSetup _saveSetup;
    private string _path = Application.dataPath + "/save.txt";

    public int lastLevel;

    public Action<SaveSetup> FileLoaded;

    public SaveSetup Setup
    {
        get {  return _saveSetup; }
    }

    protected override void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        Invoke(nameof(Load), .1f);
    }

    private void CreateNewSave()
    {

        _saveSetup = new SaveSetup();
        _saveSetup.lastLevel = 0;
        _saveSetup.playerName = "Pandora";
    }

    #region SAVE
    private void Save()
    {
        string setupToJson = JsonUtility.ToJson(_saveSetup, true);
        Debug.Log(setupToJson);
        SaveFile(setupToJson);
    }

    public void SaveItens()
    {
        _saveSetup.coins = Itens.ItemManager.Instance.GetItemByType(Itens.ItemType.COIN).soInt.value;
        _saveSetup.health = Itens.ItemManager.Instance.GetItemByType(Itens.ItemType.LIFE_PACK).soInt.value;
        Save();
    }

    public void Savename(string text)
    {
        _saveSetup.playerName = text;
        Save();
    }

    public void SaveLastLevel(int level)
    {
        _saveSetup.lastLevel = level;
        SaveItens();
        Save();
    }
    #endregion
    private void SaveFile(string json)
    {
        Debug.Log(_path);
        File.WriteAllText(_path, json);
    }

    private void Load()
    {
        string fileLoaded = "";

        if (File.Exists(_path))
        {
          fileLoaded = File.ReadAllText(_path);
          _saveSetup = JsonUtility.FromJson<SaveSetup>(fileLoaded);
          lastLevel = _saveSetup.lastLevel;

        }
        else
        {
            CreateNewSave();
        }

        FileLoaded.Invoke(_saveSetup);
    }


    private void SavelevelOne()
    {
        SaveLastLevel(1);
    }
}

[System.Serializable]
public class SaveSetup
{
    public int lastLevel;
    public float coins;
    public float health;
    
    public string playerName;


}