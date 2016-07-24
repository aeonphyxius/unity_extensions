using System;
using DimensionDrive.Enemies;

public class EnemyGoToAction : EnemyAction
{
    public bool IsFinished { get; set; }
    public int GotoAction { get; set; }

    private int numRepetitions;    
    private int timesRepeated;
    


    public EnemyGoToAction(GoToData _data)         
    {
        numRepetitions = _data.repeatNum;
        GotoAction = _data.actionNum;
        timesRepeated = 0;        
    }



	public override void ActionStart()
	{
        if (numRepetitions > 0)
        {
            ++timesRepeated;
        }
        OnActionFinished();
    }

    private void OnActionFinished()
    {
        if (numRepetitions > 0)
        {
            if (timesRepeated > numRepetitions)
            {
                IsFinished = true;
            }
        }
        OnFinish();
    }


    public override void ActionReset ()
	{
        timesRepeated = 0;
        IsFinished = false;
	}

}

