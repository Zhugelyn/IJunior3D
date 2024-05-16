using UnityEngine;

public static class ChanceCalculator
{
    private static int _initialChance = 1;

    public static bool GetSuccessStatus(int coefficient)
    {
        int incrementedMaxValue = 1;
        var chance = Random.Range(_initialChance, coefficient + incrementedMaxValue);

        return _initialChance == chance;
    }
}
