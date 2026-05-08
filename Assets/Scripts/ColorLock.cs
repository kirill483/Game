using UnityEngine;

public class ColorLock : MonoBehaviour
{
    public ColorPlate[] plates;
    public CubeColor requiredColor = CubeColor.Green;

    public bool IsActive => GetMixedColor() == requiredColor;

    public CubeColor GetMixedColor()
    {
        if (plates == null || plates.Length == 0)
            return CubeColor.None;

        bool hasRed = false;
        bool hasBlue = false;
        bool hasYellow = false;

        foreach (ColorPlate plate in plates)
        {
            if (plate == null || !plate.HasCube)
                return CubeColor.None;

            CubeColor color = plate.CurrentColor;

            if (color == CubeColor.Red)
                hasRed = true;

            if (color == CubeColor.Blue)
                hasBlue = true;

            if (color == CubeColor.Yellow)
                hasYellow = true;
        }

        if (hasBlue && hasYellow && !hasRed)
            return CubeColor.Green;

        if (hasRed && hasYellow && !hasBlue)
            return CubeColor.Orange;

        if (hasRed && hasBlue && !hasYellow)
            return CubeColor.Purple;

        if (hasRed && !hasBlue && !hasYellow)
            return CubeColor.Red;

        if (hasBlue && !hasRed && !hasYellow)
            return CubeColor.Blue;

        if (hasYellow && !hasRed && !hasBlue)
            return CubeColor.Yellow;

        return CubeColor.None;
    }
}