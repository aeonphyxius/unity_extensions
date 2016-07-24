using System;
using UnityEngine;

public abstract class EnemyAction
{    
	public Action OnFinish { get; set; }    
    public bool IsActive { get; set; }

    public GameObject ActionObject { get; set; }


	public abstract void ActionStart();
	public abstract void ActionReset ();
}