using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;

public class levertrigger : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] private Reel[] reels;

    public string riggedResult = "septar";
    public int riggedProbability = 50;

    private void StartReels()
    {
        if (!reels[2].IsPlaying())
        {
            int jackpot = Random.Range(0, 100);

            animator.SetTrigger("spin");
            foreach (var reel in reels)
            {
                if (jackpot <= riggedProbability)
                    reel.StartReel(riggedResult);
                else
                    reel.StartReel();
            }
        }
    }
    // Start is called before the first frame update
    private void OnMouseDown()
    {
        StartReels();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartReels();
        }

    }
}
