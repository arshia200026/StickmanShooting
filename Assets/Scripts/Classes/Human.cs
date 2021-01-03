using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;
using UnityEngine.UIElements;
using Random = System.Random;

public class Human : MonoBehaviour
{
    public string nickName;
    public GameObject SIGHT;
    public Weapons.Weaponss myWeapon;
    public int health = 100;
    private Transform _selection;
    public GameObject ScopeLimit;
    public int ali;
    public Team.Teams team;
    public float time;
    public float bulletpause=7;
    public List<Sprite> player = new List<Sprite>();
    public Collider2D head;
    public Collider2D body;
    public Collider2D foot;
    public Collider2D hand;

    public int damage;
//    {
//        get { return team; }
//        set
//        {
//            if (blueteam<=redteam)
//            {
//                value = team = global::Team.Teams.red;
//            }
//            else if (redteam<=blueteam)
//            {
//                value = team = global::Team.Teams.blue;
//            }
//        }
//    }


    private void Start()
    {

        damage = (int) myWeapon;
        ScopeLimit = GameObject.Find("Arrow");
       // team = GetComponent<Team>();
       InvokeRepeating("AISystem",bulletpause,bulletpause);
    }

    void Update()
    {
        
        
        BulletShooted();
        DoStuffBasedOnTeamColor();

            AISystem();


        time += Time.deltaTime;

    }

    private void AISystem()
    {
        if (IsAlive()==true)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Human enemyposition = GameManager.Instance.GetEnemy(team);
                print(this.name + "want attacks " + enemyposition);
                EnemyHit(enemyposition);
                WhatWeapon();
            }
        }
    }

    private void WhatWeapon()
    {
        
    }

    private void EnemyHit(Human en)
    {
      
      if (IsAlive()==true)
      {
          var finaldamage=0;
          var enemypos = new Vector3(UnityEngine.Random.Range(en.transform.position.x-0.5f,en.transform.position.x+0.5f),UnityEngine.Random.Range(en.transform.position.y-.5f,en.transform.position.y+.5f),UnityEngine.Random.Range(en.transform.position.y-.5f,en.transform.position.y+.5f));
          RaycastHit2D hit = Physics2D.Raycast(transform.position,enemypos+this.transform.position,10f);
          if (hit)
          {
              if (hit.collider==head)
              {
                  finaldamage = damage * 2;
                  print(this.name+"headshot"+hit.collider.name);
              }

              if  (hit.collider==body)
              {
                  finaldamage = damage;
                  print(this.name+"bodyshot"+hit.collider.name);
              }

              if (hit.collider==hand || foot)
              {
                  finaldamage = damage / 2;
                  print(this.name+"legshot"+hit.collider.name);
              }
              else
              {
                  print(this.name+"missed"+hit.collider.name);
              }





              print(hit.collider.name);
 
                  
//              }
//              switch (hit.collider)
//              {
//              case head:
//                  print("headshot");
//                  break;
//              case hand:
//                  print("handshot");
//                  break;
//              case body:
//                  print("bodyshot");
//                  break;
//              case foot:
//                  print("footshot");
//                  break;
//              default:
//                  print("missed");
//                  break;
//              }
              
              
                  
              
              Debug.Log("THE NAME OF " + hit.collider.name);
//                hit.transform.position = new Vector3(1000, 1000, 0f);
              // var enemy = hit;
               
              hit.collider.GetComponent<Human>().health -= finaldamage;
          }
        //  en.health -= damage;
          print(name+damage);
      }
      
    }
    



    private void DoStuffBasedOnTeamColor()
    {
        
    }

    public void BulletShooted()
    {
        
        if (Input.GetKey(KeyCode.Space))
        {
            var position = ScopeLimit.transform.localPosition + Camera.main.transform.position;
            RaycastHit2D hit = Physics2D.Raycast(position, transform.TransformDirection(0,0,1f), 10f);
            if (hit)
            {
                Debug.Log("THE NAME OF " + hit.collider.name);
//                hit.transform.position = new Vector3(1000, 1000, 0f);
               // var enemy = hit;
               
                hit.collider.GetComponent<Human>().health -= 100;
            }
        }
    }
    public void SetPlace()
    {
        throw new NotImplementedException();
    }

    public bool IsAlive()
    {
        if (health > 0)
        {
            return true;
        }
        else
        {
            print(name);
            GetComponent<SpriteRenderer>().sprite = player[1];
            transform.localScale = new Vector3(10,10,10);
            return false;
        }
        
    }
    
}
