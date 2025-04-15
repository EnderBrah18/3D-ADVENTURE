using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using Ebac.Core.Singleton;
using Itens;

public class SaveManager : Singleton<SaveManager>
{
    private SaveSetup _saveSetup;

    protected override void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(gameObject);
        _saveSetup = new SaveSetup();
        _saveSetup.lastLevel = 2;
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
        string path = Application.dataPath + "save.txt";

        Debug.Log(path);
        File.WriteAllText(path, json);
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