using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    public List<Place> Places = new List<Place>();
    private Place _place;
    public List<Human> Humans = new List<Human>();
    public Weapons Weapons;
    public GameObject player;
    private GameObject TempPlayer;
    public List<Human> teamblue = new List<Human>();
    public List<Human> teamred= new List<Human>();
    public static GameManager Instance
    {
        get
        {
            if (instance == null) instance = new GameObject ("GameManager").AddComponent<GameManager>();
            //create game manager object if required
            return instance;
        }
    }
    private static GameManager instance = null;

    private void Awake()
    {
        if(instance)
            DestroyImmediate(gameObject); //Delete duplicate
        else
        {
            instance = this; //Make this object the only instance
            DontDestroyOnLoad (gameObject); //Set as do not destroy
        }
    }

    // Start is called before the first frame update
    void Start()
    {
       
        StartRound(10);

    }

    private void StartRound(int PlayerCount)
    {
        
        for (int i = 0; i < PlayerCount; i++)
        {

            var tempPlayer = Instantiate(player);
            List<Place> tempplaces = Places.FindAll(place => !place.IsFull());
            tempplaces[0].SetHuman(tempPlayer.GetComponent<Human>());
            tempPlayer.name = "player" + i;
            tempPlayer.GetComponent<Human>().myWeapon = Weapons.WhatWeapon();
            Humans.Add(tempPlayer.GetComponent<Human>());
            tempPlayer.GetComponent<Human>().team =
                Humans.FindAll(human => human.team == Team.Teams.red).Count < Team.maxTeamCapacity
                    ? Team.Teams.red
                    : Team.Teams.blue;
               //Weapons.WhatWeapon();
             //  Humans.Add(tempPlayer.GetComponent<Human>());
        }
    }

    public void EndRound()
    {
        teamblue = Humans.FindAll(human => human.team == Team.Teams.blue && human.IsAlive()==true);
        teamred = Humans.FindAll(human => human.team == Team.Teams.red && human.IsAlive()==true);
        if (teamblue.Count==0)
        {
            print("red wins");
        }
        else if(teamred.Count==0)
        {
            print("blue win");
        }
        
    }



    // Update is called once per frame
    void Update()
    {
        EndRound();
    }

    public Human GetEnemy(Team.Teams team)
    {
         List<Human> enemies  = Humans.FindAll(human => human.team != team && human.IsAlive()==true);
         Human ali = enemies[Random.Range(0,enemies.Count)];
         return ali;
    }
    
}
