using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DamagePopup : MonoBehaviour
{
    public Text popup;
    Vector2 StartPos;
    Vector2 EndPos;
    public Vector4 endPosVariation;
    public float MoveTime;
    float StartRot;
    float EndRot;
    public Vector2 endRotVariation;
    public float TimeTillFade;
    public float FadeTime;

    public void OnRun()
    {
        StartPos=new Vector2(transform.localPosition.x,transform.localPosition.y);
        EndPos=StartPos+new Vector2(Random.Range(endPosVariation.x,endPosVariation.y),Random.Range(endPosVariation.z,endPosVariation.w));

        StartRot=transform.localEulerAngles.z;
        EndRot=StartRot+Random.Range(endRotVariation.x,endRotVariation.y);
        
        StartCoroutine(Move());
        StartCoroutine(Fade(0.01f));
    }
    IEnumerator Fade(float timeSkip)
    {
        float x=0;
        while (true)
        {
            if(x>=TimeTillFade)
            {
                popup.color=new Color(popup.color.r,popup.color.g,popup.color.b,Mathf.Lerp(popup.color.a,0,0.05f));

                if(popup.color.a<=0.05)
                {
                    Destroy(this.gameObject);
                }
                yield return new WaitForSeconds(timeSkip);
            }
            else
            {
                float wait=TimeTillFade-x;
                x=TimeTillFade;
                yield return new WaitForSeconds(wait);
            }
        }
    }
    IEnumerator Move()
    {
        while (true)
        {
            transform.localPosition=Vector3.Lerp(transform.localPosition,new Vector3(EndPos.x,EndPos.y,0),MoveTime*0.05f);
            transform.localEulerAngles=new Vector3(transform.localEulerAngles.x,transform.localEulerAngles.y,Mathf.LerpAngle(transform.localEulerAngles.z,EndRot,MoveTime*0.05f));

            yield return new WaitForSeconds(0.05f);
        }
    }
}
