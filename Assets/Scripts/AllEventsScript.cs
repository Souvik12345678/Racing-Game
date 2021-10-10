using UnityEngine;

public class AllEventsScript : MonoBehaviour
{
    public delegate void BlankFunc();

    //On ship destroyed
    // public static Func1 OnShipDestroyed;

    //function delegate for live decrease event
    public delegate void Func1(uint availableLives);
    //On car life decrease event
    public static Func1 OnCarLifeDecrease;
    public static BlankFunc OnCarDestroyed;
    public static BlankFunc OnCountdownOver;
}
