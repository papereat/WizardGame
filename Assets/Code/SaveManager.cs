using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    public static SaveManager CurrentSaveManager;

    [Header("PlayerSave")]
    public Vector2 PlayerPos;
    [Header("Quest Save")]
    public Dictionary<int,bool> QuestsAndCompletion;
    public Dictionary<int,QuestSaveData> QuestSaveData;
    

    #region  Public Func
    public void Awake()
    {
        //Set Pointer
        CurrentSaveManager=this;

        QuestsAndCompletion=new Dictionary<int, bool>();
        QuestSaveData= new Dictionary<int, QuestSaveData>();
    }
    
    void Start()
    {
        GameEvents.Current.onSave+=Save;
    }
    #endregion

    #region  Private Func
    void Save(){}
    #endregion
}
