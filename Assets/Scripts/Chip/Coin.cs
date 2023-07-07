using NaughtyAttributes;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public int value;

    [Button("Snap Position")]
    private void SnapPosition()
    {

    }

    public void OnDestroy()
    {
        Destroy(gameObject);
    }
}
