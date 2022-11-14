using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldTile : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public BoxCollider2D wall;
    public bool Burn,Growth,Rough,Wet,SuperBurn,SuperGrowth,Fortified,Mud,Wall,Steam,Trap,Smoker,Collapse,Road;
    public Sprite[] AffectOverlay;
    public bool Quake;

    
    public float FireTime;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void ActivateTrap(){}
    // Update is called once per frame
    void FixedUpdate()
    {
        Reactions();
    }
    void Reactions()
    {
        //Check Reactions
        if(Burn)
        {
            if(Growth)
            {
                Burn=false;
                Growth=false;
                SuperBurn=true;
            }
            else if(Rough)
            {
                Burn=false;
            }
            else if(Rough)
            {
                Burn=false;
            }
            else if(Wet)
            {
                Burn=false;
                Wet=false;
            }
            else if(SuperBurn)
            {
                Burn=false;
            }
            else if(SuperGrowth)
            {
                SuperGrowth=false;
                Burn=false;
                Smoker=true;
            }
            else if(Fortified)
            {
                Fortified=false;
                Burn=false;
                Collapse=true;;
            }
            else if(Mud)
            {
                Burn=false;
                Mud=false;
                Road=true;
            }
        }
        else if(Growth)
        {
            if(Wet)
            {
                Growth=false;
                Wet=false;
                SuperGrowth=true;
            }
            else if(Rough)
            {
                Growth=false;
                Rough=false;
                Fortified=true;
            }
            else if(SuperBurn)
            {
                Growth=false;
            }
            else if(SuperGrowth)
            {
                Growth=false;
            }
            else if(Fortified){}
            else if(Mud){}
        }
        else if(Rough)
        {
            if(Wet)
            {
                Rough=false;
                Wet=false;
                Mud=true;
            }
            else if(SuperBurn)
            {
                SuperBurn=false;
                Rough=false;
                Wall=true;
            }
            else if(SuperGrowth)
            {
                SuperGrowth=false;
                Rough=false;
                Trap=true;
            }
            else if(Fortified){}
            else if(Mud){}
        }
        else if(Wet)
        {
            if(SuperBurn)
            {
                Wet=false;
                SuperBurn=false;
                Steam=true;
            }
            if(SuperGrowth)
            {
                Wet=false;
            }
            else if(Fortified){}
            else if(Mud){}
        }

        

        spriteRenderer.sprite=AffectOverlay[0];
        //Color
        if(Burn)
        {
            spriteRenderer.color=Color.red;
        }
        else if(Growth)
        {
            spriteRenderer.sprite=AffectOverlay[1];
        }
        else if(Rough)
        {
            spriteRenderer.color=Color.grey;
        }
        else if(Wet)
        {
            spriteRenderer.color=Color.blue;
        }
        else if(SuperBurn)
        {
            spriteRenderer.color=Color.cyan;
        }
        else
        {
            spriteRenderer.color=Color.white;
        }
    }
}
