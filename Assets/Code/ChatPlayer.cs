using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.IO;


public class ChatPlayer : MonoBehaviour
{
    [Header("Refrences")]
    public GameObject TextPannel;
    public TextMeshProUGUI MainText;
    public GameObject QuestionPannel;
    public TextMeshProUGUI[] OtherTexts;
    [Header("Reader")]
    public ChatObject chatObject;
    public int CurrentLine;
    public bool InConvo;
    public bool inQuestion;
    bool nextLine;
    int opt;

    public float WritingSpeed;
    
    void Update()
    {
        TextPannel.SetActive(InConvo);
        QuestionPannel.SetActive(inQuestion);
        if(InConvo)
        {
            
            if(Input.GetKeyDown(KeyCode.Space))
            {
                ContinueConvo();
            }
        }
    }
    public void ContinueConvo()
    {
        nextLine=false;
        InConvo=true;
        Chat(CurrentLine);
        if(nextLine)
        {
            CurrentLine++;
        }

    }

    void Chat(int line)
    {
        ChatByte CurrentByte=chatObject.say[line];

        if(CurrentByte.Type==0)
        {
            //Words
            writeFunc(MainText,CurrentByte.words[0]);

            nextLine=true;
        }
        else if(CurrentByte.Type==1)
        {
            if(opt!=-1)
            {
                inQuestion=false;
                CurrentLine=CurrentByte.ToLine[opt];
                ContinueConvo();
                
                opt=-1;
            }
            //Player Input
            inQuestion=true;
            TextMeshProUGUI[] temp=new TextMeshProUGUI[4];
            temp[0]=MainText;
            temp[1]=OtherTexts[0];
            temp[2]=OtherTexts[1];
            temp[3]=OtherTexts[2];
            writeFunc(temp,CurrentByte.words);
        }
        else if(CurrentByte.Type==2)
        {

            writeFunc(MainText,CurrentByte.words[0]);
            CurrentLine=CurrentByte.ToLine[0];
        }

        if(CurrentByte.endConvo)
        {
            InConvo=false;
        }
    }

    void writeFunc(TextMeshProUGUI text,string write)
    {
        StopAllCoroutines();
        StartCoroutine(Write(text,write));
    }
    void writeFunc(TextMeshProUGUI[] text,string[] write)
    {
        StopAllCoroutines();
        
        int x=0;
        while (x<text.Length)
        {
            StartCoroutine(Write(text[x],write[x]));
            x++;
        }
        
    }
    IEnumerator Write(TextMeshProUGUI text,string write)
    {
        text.text="";
        int x=0;
        while (x<write.Length)
        {
            text.text+=write[x];
            
            yield return new WaitForSeconds(WritingSpeed);

            x++;
        }
    }

    public void ChatChoice(int Opt)
    {
        opt=Opt;
        ContinueConvo();
    }
    
    

    

    
}
