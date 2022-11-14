using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Tilemaps;

public class Entitiy : MonoBehaviour
{
    [Header("Refrences")]
    public Tilemap tm;
    public float TileDamageCD;
    public GameObject DamageText;
    public GameObject canvas;
    public Camera cam;
    public bool isMoving;
    [Header("Health Stuff")]
    public float Health;
    public float MaxHealth;
    public bool canHeal;
    public float HealRate;
    [Header("Speed Stuff")]
    public float CurrentSpeed;
    public float BaseSpeed;
    public float MudSpeed;
    public float RoadSpeed;
    [Header("Other")]
    public float BurnDamage;
    public float GrowthDamageAffect;
    public float RoughDamageAffect;
    public float SuperBurnDamage;
    public float SuperGrowthDamage;
    public float TrapDamage;
    bool onGrowth;
    bool onBurn;
    bool onSuperBurn;
    bool onSuperGrowth;
    bool onRough;

    // Start is called before the first frame update
    void Start()
    {

        //StartCoroutine(CalkTileDamage());
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        TileCalk();
        HealthCalk();

    }
    void TileCalk()
    {
        if(tm.GetInstantiatedObject(tm.WorldToCell(transform.position))==null)
        {
            return;
        }
        WorldTile currentTile=tm.GetInstantiatedObject(tm.WorldToCell(transform.position)).GetComponent<WorldTile>();

        //burns
        onBurn=currentTile.Burn;
        onSuperBurn=currentTile.SuperBurn;

        //Growht
        onGrowth=currentTile.Growth;
        onSuperGrowth=currentTile.SuperGrowth;

        //Trap
        if(currentTile.Trap)
        {
            Damage(TrapDamage);
            currentTile.ActivateTrap();
        }

        //Rough
        onRough=currentTile.Rough;

        //Speed Tiles
        if(currentTile.Mud)
        {
            CurrentSpeed=MudSpeed;
        }
        else if(currentTile.Road)
        {
            CurrentSpeed=RoadSpeed;
        }
        else
        {
            CurrentSpeed=BaseSpeed;
        }
    }
    IEnumerator CalkTileDamage()
    {
        while (true)
        {
            if(isMoving&&onSuperGrowth)
            {
                Damage(SuperGrowthDamage);
            }
            if(onBurn)
            {
                Damage(BurnDamage*TileDamageCD);
            }

            if(onSuperBurn)
            {
                Damage(SuperBurnDamage*TileDamageCD);
            }

            yield return new WaitForSeconds(TileDamageCD);
        }
    }
    void HealthCalk()
    {
        if(Health<=0)
        {
            Die();
        }
        if(canHeal)
        {
            if(MaxHealth>Health)
            {
                Health+=HealRate*Time.deltaTime;
            }
            else if(MaxHealth<Health)
            {
                Health=MaxHealth;
            }
        }
    }
    public void Damage(float DamageTaken)
    {
        float damageTaken=0;
        if(onGrowth)
        {
            damageTaken=DamageTaken*GrowthDamageAffect;
        }
        else
        {
            damageTaken=DamageTaken;
        }
        if(damageTaken!=0)
        {
            GameObject damagText=Instantiate(DamageText);
            damagText.transform.position=cam.WorldToScreenPoint(transform.position);
            damagText.transform.SetParent(canvas.transform);
            damagText.GetComponent<Text>().text=damageTaken.ToString();
            damagText.GetComponent<DamagePopup>().OnRun();

            Health-=damageTaken;
        }
    }
    void Die()
    {
        Debug.Log(gameObject.name+" has Died");
    }
}
