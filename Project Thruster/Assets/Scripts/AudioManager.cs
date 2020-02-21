using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioClip rocketThrust, win, explosion, lose;
    static AudioSource audioSrc;

    private void Start()
    {
        rocketThrust = Resources.Load<AudioClip>("rocketThrust");
        lose = Resources.Load<AudioClip>("lose");
        win = Resources.Load<AudioClip>("win");
        explosion = Resources.Load<AudioClip>("explosion");

        audioSrc = GetComponent<AudioSource>();
    }

    public static void PlaySound(string clip, float vol)
    {
        switch (clip)
        {
            case "rocketThrust":
                audioSrc.PlayOneShot(rocketThrust, vol);
                break;
            case "lose":
                audioSrc.PlayOneShot(lose, vol);
                break;
            case "win":
                audioSrc.PlayOneShot(win, vol);
                break;
            case "explosion":
                audioSrc.PlayOneShot(explosion, vol);
                break;
        }
    }
}
