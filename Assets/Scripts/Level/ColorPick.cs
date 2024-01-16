using UnityEngine;

public enum ColorPick 
{
    Red,
    Green,
    Blue,
    Black,
    Yellow,
    Cyan,
    Magenta,
    White,
}

public static class ColorPickExtensions
{
    public static Color ToColor(this ColorPick colorPick)
    {
        switch(colorPick)
        {
            case ColorPick.Red:
                return Color.red;
            case ColorPick.Green:
                return Color.green;
            case ColorPick.Blue:
                return Color.blue;
            case ColorPick.Black:
                return Color.black;
            case ColorPick.Yellow:
                return Color.yellow;
            case ColorPick.Cyan:
                return Color.cyan;
            case ColorPick.Magenta:
                return Color.magenta;
            case ColorPick.White:
            default:
                return Color.white;
        }
    }
}
