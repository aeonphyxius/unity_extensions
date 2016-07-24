using System;
using UnityEngine;


public interface IEnemyAction
{
    void ActionUpdate();

    void ActionStart();

    void ActionReset();
}

public abstract class EnemyAction
{    
	public Action OnFinish { get; set; }    
    public bool IsActive { get; set; }

    public GameObject ActionObject { get; set; }


    //public abstract void ActionUpdate();
	public abstract void ActionStart();
	public abstract void ActionReset ();
}