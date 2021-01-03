
using System.Collections.Generic;
using UnityEngine;

public class Weapons : MonoBehaviour
{
    public List<Place> Places = new List<Place>();
    private Place _place;
    public List<Weaponss> damage=new List<Weaponss>();
    public enum Weaponss
    {
        Awp=100,
        Scout=80,
        Kar98=72,
        Ar50=50,
    }

    public void WeaponDamage()
    {
        
    }
    public static Weaponss WhatWeapon()
    {
       return GetRandomEnum<Weaponss>();
        
    }
    static T GetRandomEnum<T>()
    {
        System.Array A = System.Enum.GetValues(typeof(T));
        T V = (T)A.GetValue(UnityEngine.Random.Range(0,A.Length));
        return V;
    }

}
