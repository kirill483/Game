using UnityEngine;

public class ColorPlate : MonoBehaviour
{
    public CubeColor CurrentColor { get; private set; } = CubeColor.None;

    public bool HasCube => CurrentColor != CubeColor.None;

    private ColorCube currentCube;

    private void OnTriggerEnter(Collider other)
    {
        ColorCube colorCube = other.GetComponent<ColorCube>();

        if (colorCube == null)
            return;

        currentCube = colorCube;
        CurrentColor = colorCube.cubeColor;
    }

    private void OnTriggerExit(Collider other)
    {
        ColorCube colorCube = other.GetComponent<ColorCube>();

        if (colorCube == null)
            return;

        if (colorCube == currentCube)
        {
            currentCube = null;
            CurrentColor = CubeColor.None;
        }
    }
}