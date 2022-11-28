using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ChatManager : MonoBehaviour
{
    public static ChatManager Current; 
    [Header("Refrences")]
    public GameObject ChatBlock;
    public TextMeshProUGUI Name;
    public TextMeshProUGUI Message;
    public Image NPCImage;
    [Header("Settings")]
    public float MessageSpeed;

    string ShouldSay;
    

    public void Awake()
    {
        Current=this;
    }


    public void Chat(ChatMessageInfo Info)
    {
        ChatBlock.SetActive(true);
        ZeroText();
        Name.text=Info.NPCName;
        NPCImage.sprite=Info.NPCImage;
        ShouldSay=Info.NPCMessage;
        StartCoroutine(SayMessage());
    }
    public void EndChat()
    {
        ChatBlock.SetActive(false);
        ZeroText();
    }
    void ZeroText()
    {
        StopAllCoroutines();
        Message.text="";
    }
    IEnumerator SayMessage()
    {
        foreach (var item in ShouldSay)
        {
            Message.text+=item;

            yield return new WaitForSeconds(MessageSpeed);
        }
    }
}
[System.Serializable]
public class ChatMessageInfo
{
    public string NPCName;
    public Sprite NPCImage;
    public string NPCMessage;

    public ChatMessageInfo(string NPCName,Sprite NPCImage,string NPCMessage)
    {
        this.NPCName=NPCName;
        this.NPCImage=NPCImage;
        this.NPCMessage=NPCMessage;
    }
}
