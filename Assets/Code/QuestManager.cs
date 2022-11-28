using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class QuestManager : MonoBehaviour
{
    public static QuestManager CurrentQuestManager;
    public static Dictionary<int,QuestObject> IDToQuestDict;
    public intToQuestDict G;
    public List<int> CurrentQuests;
    public TextMeshProUGUI CompletionText;
    public Vector3 QuestStartedMessageWaits;

    

    #region  Public Func
    public void Awake()
    {
        IDToQuestDict=new Dictionary<int, QuestObject>();
        //Set Pointer
        CurrentQuestManager=this;
        int x=0;
        while(x<G.Keys.Count)
        {
            IDToQuestDict.Add(G.Keys[x],G.Quest[x]);
            x++;
        }
    }
    
    void Start()
    {
        GameEvents.Current.onAddQuest+=AddQuest;
    }
    #endregion

    #region  Private Func
    void AddQuest(int id)
    {
        if(!SaveManager.CurrentSaveManager.QuestSaveData.ContainsKey(id))
        {
            SaveManager.CurrentSaveManager.QuestSaveData.Add(id,IDToQuestDict[id].CreateSaveData());
            StartCoroutine(AddQuestAnimation(IDToQuestDict[id].Name));
        }
    }

    IEnumerator AddQuestAnimation(string QuestName)
    {
        CompletionText.text="Started "+QuestName+" Quest";
        float time=0;
        while (true)
        {
            if(time<QuestStartedMessageWaits.x)
            {
                CompletionText.color=new Color(CompletionText.color.r,CompletionText.color.g,CompletionText.color.b,time/QuestStartedMessageWaits.x);
            }
            else if(time>=QuestStartedMessageWaits.x&&time<QuestStartedMessageWaits.x+QuestStartedMessageWaits.y)
            {
                CompletionText.color= new Color(CompletionText.color.r,CompletionText.color.g,CompletionText.color.b,1);
            }
            else if(time<QuestStartedMessageWaits.x+QuestStartedMessageWaits.y+QuestStartedMessageWaits.z)
            {
                CompletionText.color= new Color(CompletionText.color.r,CompletionText.color.g,CompletionText.color.b,1-(time-(QuestStartedMessageWaits.x+QuestStartedMessageWaits.y))/QuestStartedMessageWaits.z);
            }
            else
            {
                break;
            }



            time+=0.1f;
            yield return new WaitForSeconds(0.1f);
        }
    }
    #endregion
}
[System.Serializable]
public struct intToQuestDict
{
    public List<int> Keys;
    public List<QuestObject> Quest;
    public QuestObject GetQuest(int key)
    {
        return Quest[Keys.IndexOf(key)];
    }
}
