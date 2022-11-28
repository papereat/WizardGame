using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class QuestObject : ScriptableObject
{
    [Header("ID and Stuff")]
    public string Name;
    public int ID;
    [Header("Data")]
    public List<QuestStage> Stages;

    public QuestSaveData CreateSaveData()
    {
        QuestSaveData QSD=new QuestSaveData();


        return QSD;
    }
    
}
[System.Serializable]
public class QuestStage
{
    public string Name;
    public List<QuestChallenge> Challenges;

}
[System.Serializable]
public class QuestChallenge
{
    public enum ChallengeType
    {
        GoToPos
    }
    public ChallengeType Type;
    public Vector2 Position;
    public float Size;
}
[System.Serializable]
public class QuestSaveData
{
    public QuestObject Quest;
    public int Stage;

    public bool NextStage()
    {
        foreach (var item in Quest.Stages[Stage].Challenges)
        {
            if(item.Type==QuestChallenge.ChallengeType.GoToPos)
            {
                if(Vector2.Distance(item.Position,PlayerManager.CurrentPlayerManger.transform.position)>=item.Size)
                {
                    return false;
                }
                return false;
            }
        }
        return true;
    }
}
