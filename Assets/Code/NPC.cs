using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class NPC : MonoBehaviour
{
    #region  Public Var
    public ChatObject TestMessage;
    public string Name;
    public Sprite NPCImage;
    #endregion

    #region  Private Var
    int ChatLine;
    #endregion

    #region  Public Func
    void Update()
    {
    }
    #endregion

    #region  Private Func
    void NextLine()
    {
        if(TestMessage.Messages.Length<ChatLine+1)
        {
            ChatLine=0;
            ChatManager.Current.EndChat();
            if(TestMessage.QuestIDAtEnd!=-1)
            {
                GameEvents.Current.AddQuest(TestMessage.QuestIDAtEnd);
            }
        }
        else
        {
            ChatManager.Current.Chat(new ChatMessageInfo(Name,NPCImage,TestMessage.Messages[ChatLine]));
            ChatLine++;
        }
    }

    #endregion
}
