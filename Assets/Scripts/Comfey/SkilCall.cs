using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkilCall : MonoBehaviour
{
    // Start is called before the first frame update
    private Transform transform;
    private Animator animator;
    private AnimationClip[] clips;
    private int sayHelloTime = 1;
    private string SAYHELLO_ANIMATION = "sayingHello";
    private string PLAYINGSKILL_ANIMATION = "isPlayingSkill";
    public ParticleSystem particle;
    void Start()
    {
        transform = GetComponent<Transform>();
        animator = GetComponent<Animator>();
        particle.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.H))
        {
            StartCoroutine(playingSkill(0));
        }
        if (Input.GetKey(KeyCode.G))
        {
            StartCoroutine(playingSkill(1));
        }
    }
    IEnumerator playingSkill(int key)
    {
        animator.SetBool(PLAYINGSKILL_ANIMATION, true);
        particle.Play();
        yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).normalizedTime);
        particle.Stop();
        animator.SetBool(PLAYINGSKILL_ANIMATION, false);
        switch (key)
        {
            case 0:
                FloralHealing.startSkill = true;
                break;
            case 1:
                FairyWind.startSkill = true;
                break;
            default:
                break;
        }
    }

    // public void onClickSkillButton()
    // {
    //     StartCoroutine(playingSkill());
    // }
}
