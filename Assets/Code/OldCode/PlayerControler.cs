using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Tilemaps;
using TMPro;


public class PlayerControler : MonoBehaviour
{
    #region Public Variables
    [Header("Refrences")]
    public Rigidbody2D rb;
    public Tilemap tm;
    public List<GameObject> cardUI;
    public Entitiy playerEntity;
    public Sprite[] CardImages;
    [Header("Card Setting and Stats")]
    public CardInfo[] holdingCards;
    public List<int> inventory;
    public List<CardCode> possibleCards;
    [Header("Other Stats")]
    public Vector3Int CurrentTile;
    public int direction;
    public bool CombatSystem;
    #endregion

    #region Private Var
    bool moveUp,moveRight,moveDown,moveLeft;
    int totalCards;
    bool showCards;
    int selectedCard;
    bool useCard;
    #endregion

    #region  Start and Update
    void Start()
    {
        
    }
    void Update()
    {
        CalkTotalCards();
        MovementInputs();
        CardInputs();
        UIUpdate();
    }
    void FixedUpdate()
    {
        Movement();
        CheckCards();
        OtherStatsCalk();
    }
    #endregion

    #region Public Fucntions
    public bool LocationAvailible(Vector3Int testSpot)
    {
        return tm.GetInstantiatedObject(testSpot)!=null;
    }
    public WorldTile GetWorldTile(Vector3Int testSpot)
    {
        return tm.GetInstantiatedObject(testSpot).GetComponent<WorldTile>();
    }
    #endregion

    #region Private Functions
    void UIUpdate()
    {
        int x=0;
        while(x<4)
        {
            if(holdingCards[x].id==-1)
            {
                cardUI[x].SetActive(false);
            }
            else
            {
                cardUI[x].SetActive(true);
            }
            cardUI[x].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text=holdingCards[x].Name;
            cardUI[x].transform.GetChild(1).GetComponent<TextMeshProUGUI>().text=holdingCards[x].time.ToString();
            cardUI[x].transform.GetChild(2).GetComponent<TextMeshProUGUI>().text=holdingCards[x].size.ToString();
            if(x==selectedCard)
            {
                cardUI[x].transform.localPosition=new Vector3(cardUI[x].transform.localPosition.x,Mathf.Lerp(cardUI[x].transform.localPosition.y,-300,10*Time.deltaTime),cardUI[x].transform.localPosition.z);
            }
            else
            {
                cardUI[x].transform.localPosition=new Vector3(cardUI[x].transform.localPosition.x,Mathf.Lerp(cardUI[x].transform.localPosition.y,-350,10*Time.deltaTime),cardUI[x].transform.localPosition.z);
            }

            //Card Sprite 
            if(holdingCards[x].cardType==CardCode.CardType.Fire)
            {
                cardUI[x].GetComponent<Image>().sprite=CardImages[0];
            }
            else if(holdingCards[x].cardType==CardCode.CardType.Plant)
            {
                cardUI[x].GetComponent<Image>().sprite=CardImages[1];
            }
            else if(holdingCards[x].cardType==CardCode.CardType.Earth)
            {
                cardUI[x].GetComponent<Image>().sprite=CardImages[2];
            }
            else if(holdingCards[x].cardType==CardCode.CardType.Water)
            {
                cardUI[x].GetComponent<Image>().sprite=CardImages[3];
            }

            x++;
        }
    }
    void OtherStatsCalk()
    {
        CurrentTile=tm.WorldToCell(transform.position);
    }
    void CardInputs()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            selectedCard=0;
        }
        if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            selectedCard=1;
        }
        if(Input.GetKeyDown(KeyCode.Alpha3))
        {
            selectedCard=2;
        }
        if(Input.GetKeyDown(KeyCode.Alpha4))
        {
            selectedCard=3;
        }
        if(Input.GetKeyDown(KeyCode.Mouse0)&&selectedCard!=-1)
        {
            useCard=true;
        }
    }
    void CheckCards()
    {
        //get Card
        int x=0;
        while (x<holdingCards.Length)
        {
            if(holdingCards[x].id==-1)
            {
                holdingCards[x]=ChoseHeldCards();
            }

            x++;
        }

        //check if use card
        if(useCard)
        {
            if(holdingCards[selectedCard].id!=-1)
            {
                StartCoroutine(holdingCards[selectedCard].UseCard(this));
                holdingCards[selectedCard].id=-1;
                selectedCard=-1;
                useCard=false;
            }
        }
    }
    CardInfo ChoseHeldCards()
    {
        CalkTotalCards();
        int rand=Random.Range(0,totalCards);
        CardInfo chosenCard=new CardInfo();
        chosenCard.id=-1;

        int x=0;
        while(x<inventory.Count)
        {
            if(inventory[x]>rand)
            {
                chosenCard=new CardInfo(possibleCards[x]);
                inventory[x]-=1;
                break;
            }
            rand-=inventory[x];

            x++;
        }

        

        return chosenCard;
    }
    void CalkTotalCards()
    {
        int total=0;
        foreach (var item in inventory)
        {
            total+=item;
        }
        totalCards=total;
    }
    void MovementInputs()
    {
        moveUp=false;
        moveDown=false;
        moveLeft=false;
        moveRight=false;
        if(Input.GetKey(KeyCode.W))
        {
            moveUp=true;
        }
        if(Input.GetKey(KeyCode.S))
        {
            moveDown=true;
        }
        if(Input.GetKey(KeyCode.D))
        {
            moveRight=true;
        }
        if(Input.GetKey(KeyCode.A))
        {
            moveLeft=true;
        }
    }
    void Movement()
    {
        Vector2 mov=new Vector2();
        
        if(moveUp)
        {
            direction=0;
            mov.y+=1;
        }
        if(moveDown)
        {
            direction=2;
            mov.y-=1;
        }
        if(moveLeft)
        {
            direction=3;
            mov.x-=1;
        }
        if(moveRight)
        {
            direction=1;
            mov.x+=1;
        }

        playerEntity.isMoving=mov!=new Vector2();

        rb.velocity=mov*playerEntity.CurrentSpeed;
    }
    #endregion
}
[System.Serializable]
public class InventorySlot
{
    public CardInfo Card;
    public int amount;
}
