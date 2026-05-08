using UnityEngine;

public class RailControlButton : MonoBehaviour
{
    public GravityRailMover railMover;

    public void Press()
    {
        if (railMover == null)
            return;

        railMover.MoveLoop();
    }
}