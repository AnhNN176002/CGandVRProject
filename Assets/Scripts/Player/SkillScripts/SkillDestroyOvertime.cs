using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillDestroyOvertime : MonoBehaviour
{
    public float timer = 3f;
    void Start()
    {
        Destroy(gameObject, timer);
    }

}
