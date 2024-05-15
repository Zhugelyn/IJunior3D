using UnityEngine;

public class ChanceCalculator : MonoBehaviour
{
    private int _initialChance = 1;

    public bool GetSuccessStatus(int coefficient)
    {
        var chance = Random.Range(_initialChance, coefficient);

        return _initialChance == chance;
    }
}
