using UnityEngine;

public class ChanceCalculator : MonoBehaviour
{
    private int _initialChance = 1;

    public bool GetSuccessStatus(int attemptNumber)
    {
        int coefficient = (int)Mathf.Pow(2, attemptNumber);
        var chance = Random.Range(_initialChance, coefficient);

        if (_initialChance == chance)
            return true;
        else 
            return false;
    }
}
