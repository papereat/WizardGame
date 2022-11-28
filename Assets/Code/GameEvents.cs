using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameEvents : MonoBehaviour
{
    public static GameEvents Current;
    
    public void Awake()
    {
        Current=this;
    }


    public event Action onSave;
    public void Save()
    {
        
        if(onSave!=null)
        {
            onSave();
        }
    }

    public event Action onGatherSaveData;
    public void GatherSaveData()
    {
        if(onGatherSaveData!=null)
        {
            onGatherSaveData();
        }
    }

    public event Action<int> onAddQuest;
    public void AddQuest(int id)
    {
        if(onAddQuest!=null)
        {
            onAddQuest(id);
        }
    }
}
