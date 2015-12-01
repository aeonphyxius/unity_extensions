using UnityEngine;
using System;

public class PlayerControl : MonoBehaviour
{
    private const float MOVE_SPEED = 10.0f;
    private Renderer r;

	void Start ()
    {
        r = GetComponent<Renderer>();
        r.material.SetColor("_Color", Color.green);
	}
	
	
	void Update ()
    {
	
	}


    public Action GetAction()
    {
        return OnUpPressed;
    } 

    public void OnActionPressed()
    {
        if (r.material.GetColor("_Color").Equals(Color.green))
        {
            r.material.SetColor("_Color", Color.red);
        }
        else
        {
            r.material.SetColor("_Color", Color.green);
        }
        
    }

    public void OnUpPressed()
    {
        MovePlayer(new Vector3(0, Time.deltaTime * MOVE_SPEED, 0));
    }

    public void OnDownPressed()
    {
        MovePlayer(new Vector3(0, Time.deltaTime * MOVE_SPEED * -1, 0));        
    }

    public void OnLeftPressed()
    {
        MovePlayer(new Vector3(Time.deltaTime * MOVE_SPEED * -1,0, 0));
    }

    public void OnRightPressed()
    {
        MovePlayer(new Vector3(Time.deltaTime * MOVE_SPEED, 0, 0));
    }

    private void MovePlayer( Vector3 _v)
    {
        transform.Translate(_v, Space.World);
    }
}