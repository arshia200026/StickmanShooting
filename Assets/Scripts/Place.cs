using UnityEngine;
public class Place : MonoBehaviour
{
    private bool isfull;
    private Human human;
    public Team.Teams team;

    public bool IsFull()
    {
        return isfull;
    }

    public void SetHuman(Human human)
    {
        this.human = human;
            
            human.transform.SetParent(transform);
            human.transform.localPosition=new Vector3(0,0,1);
            isfull = true;

    }
}
