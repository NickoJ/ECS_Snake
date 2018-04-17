using UnityEngine;

public static class ColorUtils
{

    private const uint mask = 0x000000FF;

    public static Color FromHex(uint hex)
    {
        float r = ((hex >> 24) & mask) / 255f;
        float g = ((hex >> 16) & mask) / 255f;
        float b = ((hex >> 8) & mask) / 255f;
        float a = (hex & mask) / 255f;

        return new Color(r, g, b, a);
    }

}