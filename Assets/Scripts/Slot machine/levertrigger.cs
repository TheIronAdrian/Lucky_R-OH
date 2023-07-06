using UnityEngine.SceneManagement;
using UnityEngine;
using System.Collections;

public class levertrigger : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] private Reel[] reels;

    [SerializeField] private AudioSource dingdingding;
    [SerializeField] private AudioSource celebration;

    public string riggedResult = "septar";
    public int riggedProbability;
    int nrb;
    public static float scortotal = 0;
    public static float multtotal = 1;
    int ok = 0;
    private void StartReels()
    {
        nrb = PlayerPrefs.GetInt("noBottles");
        riggedProbability = nrb * 10;
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
        dingdingding.Play();
        StartReels();
    }
    IEnumerator LoadScene()
    {
        yield return new WaitForSeconds(4.4f);
        SceneManager.LoadScene(0);
    }
    private void Update()
    {
        if (!reels[2].IsPlaying())
        {
            if (ok == 0)
            {
                if (scortotal > 0)
                {
                    ok = 1;
                    if(scortotal == 1500)
                        scortotal = 5000;
                    PlayerPrefs.SetInt("playerScore", (int)scortotal);
                    scortotal = 0;

                    dingdingding.Stop();
                    celebration.Play();

                    StartCoroutine(LoadScene());
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            dingdingding.Play();
            StartReels();
        }

    }
}
