using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class CardCode : ScriptableObject
{
    public string Name;
    public int id;
    public CardType cardType;
    public float size;
    public float time;
    public enum CardType
    {
        Fire,
        Plant,
        Earth,
        Water
    }
}
[System.Serializable]
public struct CardInfo
{
    public string Name;
    public int id;
    public float size;
    public float time;
    public CardCode.CardType cardType;

    public IEnumerator UseCard(PlayerControler pc)
    {
        Vector3Int currentTile=pc.CurrentTile;
        int direction=pc.direction;

        while (true)
        {
            yield return new WaitForSeconds(time);
            //fire
            if(cardType==CardCode.CardType.Fire)
            {
                //Do Affect
                int x=0;
                while (x<size)
                {
                    //Right Wall
                    int y=-x;
                    while (y<=x)
                    {
                        if(pc.LocationAvailible(currentTile+new Vector3Int(x,y,0)))
                        {
                            pc.GetWorldTile(currentTile+new Vector3Int(x,y,0)).Burn=true;
                        }

                        y++;
                    }

                    //Left Wall
                    y=-x;
                    while (y<=x)
                    {
                        if(pc.LocationAvailible(currentTile+new Vector3Int(-x,y,0)))
                        {
                            pc.GetWorldTile(currentTile+new Vector3Int(-x,y,0)).Burn=true;
                        }

                        y++;
                    }
                    
                    //Top Wall
                    y=-x;
                    while (y<=x)
                    {
                        if(pc.LocationAvailible(currentTile+new Vector3Int(y,x,0)))
                        {
                            pc.GetWorldTile(currentTile+new Vector3Int(y,x,0)).Burn=true;
                        }

                        y++;
                    }

                    //Bottom Wall
                    y=-x;
                    while (y<=x)
                    {
                        if(pc.LocationAvailible(currentTile+new Vector3Int(y,-x,0)))
                        {
                            pc.GetWorldTile(currentTile+new Vector3Int(y,-x,0)).Burn=true;
                        }

                        y++;
                    }

                    x++;
                    yield return new WaitForSeconds(0.3f);
                }
                
            }
            //plant
            else if(cardType==CardCode.CardType.Plant)
            {
                //Do Affect
                int x=0;
                while (x<size)
                {
                    if(direction==0&&pc.LocationAvailible(currentTile+new Vector3Int(0,x,0)))
                    {
                        pc.GetWorldTile(currentTile+new Vector3Int(0,x,0)).Growth=true;
                    }
                    if(direction==1&&pc.LocationAvailible(currentTile+new Vector3Int(x,0,0)))
                    {
                        pc.GetWorldTile(currentTile+new Vector3Int(x,0,0)).Growth=true;
                    }
                    if(direction==2&&pc.LocationAvailible(currentTile+new Vector3Int(0,-x,0)))
                    {
                        pc.GetWorldTile(currentTile+new Vector3Int(0,-x,0)).Growth=true;
                    }
                    if(direction==3&&pc.LocationAvailible(currentTile+new Vector3Int(-x,0,0)))
                    {
                        pc.GetWorldTile(currentTile+new Vector3Int(-x,0,0)).Growth=true;
                    }

                    x++;
                    yield return new WaitForSeconds(0.1f);
                }
            }
            //Earth
            else if(cardType==CardCode.CardType.Earth)
            {
                //Do Afffect
                int z=0;
                while (z<size)
                {
                    int x=-z;
                    while (x<=z)
                    {
                        int y=-z;
                        while (y<=z)
                        {
                            if(Vector2.Distance(new Vector2(0,0),new Vector2(x,y))<=(z+1)/2)
                            {
                                if(pc.LocationAvailible(currentTile+new Vector3Int(x,y,0)))
                                {
                                    if(Vector2.Distance(new Vector2(0,0),new Vector2(x,y))>=(z-0.5)/2)
                                    {
                                        pc.GetWorldTile(currentTile+new Vector3Int(x,y,0)).Rough=true;
                                    }
                                    else
                                    {
                                        
                                        pc.GetWorldTile(currentTile+new Vector3Int(x,y,0)).Rough=false;
                                    }
                                }
                            }

                            y++;
                        }
                        
                        x++;
                    }

                    z++;
                    yield return new WaitForSeconds(0.3f);
                }
            }
            //Water
            else if(cardType==CardCode.CardType.Water)
            {
                //do Affect
                int x=0;
                while (x<size)
                {
                    //Right Wall
                    int y=-x;
                    while (y<=x)
                    {
                        if(pc.LocationAvailible(currentTile+new Vector3Int(x,y,0))&&(x+y)%2==0)
                        {
                            pc.GetWorldTile(currentTile+new Vector3Int(x,y,0)).Wet=true;
                        }

                        y++;
                    }

                    //Left Wall
                    y=-x;
                    while (y<=x)
                    {
                        if(pc.LocationAvailible(currentTile+new Vector3Int(-x,y,0))&&(x+y)%2==0)
                        {
                            pc.GetWorldTile(currentTile+new Vector3Int(-x,y,0)).Wet=true;
                        }

                        y++;
                    }
                    
                    //Top Wall
                    y=-x;
                    while (y<=x)
                    {
                        if(pc.LocationAvailible(currentTile+new Vector3Int(y,x,0))&&(x+y)%2==0)
                        {
                            pc.GetWorldTile(currentTile+new Vector3Int(y,x,0)).Wet=true;
                        }

                        y++;
                    }

                    //Bottom Wall
                    y=-x;
                    while (y<=x)
                    {
                        if(pc.LocationAvailible(currentTile+new Vector3Int(y,-x,0))&&(x+y)%2==0)
                        {
                            pc.GetWorldTile(currentTile+new Vector3Int(y,-x,0)).Wet=true;
                        }

                        y++;
                    }

                    x++;
                    yield return new WaitForSeconds(0.3f);
                }
            }
            break;
        }
        
    }

    public CardInfo(CardCode cardCode)
    {
        this.Name=cardCode.Name;
        this.id=cardCode.id;
        this.size=cardCode.size;
        this.time=cardCode.time;
        this.cardType=cardCode.cardType;
    }
}
