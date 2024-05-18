using UnityEngine;

public static class ChanceCalculator
{
    private static float _startRange = 0;
    private static float _endRange = 101;

    public static bool GetSuccessStatus(float coefficient)
    {
        var chance = Random.Range(_startRange, _endRange);

        return coefficient >= chance;
    }
}
