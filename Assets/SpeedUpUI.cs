using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUpUI : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator anim;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Trigger()
    {
        gameObject.SetActive(true);
        StartCoroutine(PlayAnimCo());
	}

    IEnumerator PlayAnimCo()
    {
        anim.Play("speed_up");
        AnimationClip[] clips = anim.runtimeAnimatorController.animationClips;
        yield return new WaitForSeconds(clips[0].length);
        gameObject.SetActive(false);
	}
}
