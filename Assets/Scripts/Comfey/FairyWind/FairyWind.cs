using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FairyWind : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject start;
    // GameObject center;
    GameObject fairyWind;
    public static bool startSkill;
    void Start()
    {
        fairyWind = Resources.Load<GameObject>("Prefabs/ComfeyFairyWind/FairyWind");
        start = GameObject.FindGameObjectWithTag("Comfey");
    }

    // Update is called once per frame
    void Update()
    {
        if (startSkill)
        {
            print("startSkill" + startSkill);
            startSkill = false;
            Instantiate(fairyWind, start.transform.position, Quaternion.identity, start.transform);
        }
    }
}
