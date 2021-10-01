using System.Collections.Generic;
using UnityEngine;

//Car class
public class CarScript : MonoBehaviour
{
    //Inspector

    public float clampMovePos = 1;
    public float turnSpeed;
    public float desiredPos;

    //Four Wheels
    public SliderJoint2D axleSlider;
    public HingeJoint2D fLJoint;
    public HingeJoint2D fRJoint;
    //List of all tires
    public List<TireScript> tireScripts;

    //Internal vars
    public enum AccState { NONE, UP, DOWN };
    public enum TurnState { NONE, RIGHT, LEFT };
    AccState currentAccState = AccState.NONE;
    TurnState currentTurnState = TurnState.NONE;

    private void Awake()
    {
    }

    // Update is called once per frame
    void Update()
    {
        //Accelerator
        if (Input.GetKey(KeyCode.W)) { currentAccState = AccState.UP; }
        else if (Input.GetKey(KeyCode.S)) { currentAccState = AccState.DOWN; }
        else { currentAccState = AccState.NONE; }

        //Steering
        if (Input.GetKey(KeyCode.A)) { currentTurnState = TurnState.LEFT; }
        else if (Input.GetKey(KeyCode.D)) { currentTurnState = TurnState.RIGHT; }
        else { currentTurnState = TurnState.NONE; }


    }

    private void FixedUpdate()
    {
        foreach (TireScript tireScript in tireScripts)
        {
            tireScript.UpdateFriction();
            tireScript.UpdateDrive(currentAccState);
        }

        UpdateTurn_2();

    }

    /*
    void UpdateTurn()
    {
        switch (currentTurnState)
        {
            case TurnState.LEFT: desiredAngle = -lockAngle; break;
            case TurnState.RIGHT: desiredAngle = lockAngle; break;
            default: desiredAngle = 0;
                break;//nothing
        };

        float angleNow = fLJoint.jointAngle;
        float angleToTurn = desiredAngle - angleNow;
        angleToTurn = Mathf.Clamp(angleToTurn, -turnPerTimeStep, turnPerTimeStep);
        float newAngle = angleNow + angleToTurn;

        JointAngleLimits2D lim = new JointAngleLimits2D() { max = newAngle, min = newAngle };
        fLJoint.limits = lim;
        fRJoint.limits = lim;
      
    }
    */

    void UpdateTurn_2()
    {
        float motorSpeed = 0;
        switch (currentTurnState)
        {
            case TurnState.LEFT: desiredPos = clampMovePos; break;
            case TurnState.RIGHT: desiredPos = -clampMovePos; break;
            case TurnState.NONE:desiredPos = 0; break;
            default: break;//nothing
        };

        //If axle to center
        if (desiredPos == 0)
        {
            //If axle pos is almost 0
            if (Mathf.Abs(axleSlider.jointTranslation) > 0.001f)
            {
                float dir = -axleSlider.jointTranslation;
                motorSpeed = (dir < 0) ? -turnSpeed : turnSpeed;
            }
            else { motorSpeed = 0; }
        }
        else //If axle to any direction
        {
            float dir = axleSlider.jointTranslation - desiredPos;
            motorSpeed = (dir < 0) ? turnSpeed : -turnSpeed;
        }

        //Debug.Log(axleSlider.jointTranslation);

        JointMotor2D motor = new JointMotor2D() { motorSpeed = motorSpeed, maxMotorTorque = 10  };
        axleSlider.motor = motor;

    }
}
