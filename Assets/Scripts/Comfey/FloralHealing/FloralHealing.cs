using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloralHealing : MonoBehaviour
{
    // Start is called before the first frame update
    // public GameObject prefab;

    GameObject[] flowers = new GameObject[4];
    public Transform comfeyTransform;
    int type = 0;
    private int flowersNumber;
    int inputflowersNumber = 50;
    public float recreateFlowerDuration;
    public float deleteFlowerDuration;
    public static bool startSkill;

    private void Start()
    {
        flowers[0] = Resources.Load<GameObject>("Prefabs/ComfeyFlowersPrefab/ComfeyFlowerPink2");
        flowers[1] = Resources.Load<GameObject>("Prefabs/ComfeyFlowersPrefab/ComfeyFlowerRed2");
        flowers[2] = Resources.Load<GameObject>("Prefabs/ComfeyFlowersPrefab/ComfeyFlowerWhite2");
        flowers[3] = Resources.Load<GameObject>("Prefabs/ComfeyFlowersPrefab/ComfeyFlowerYellow2");
        //this.enabled = false;
        this.flowersNumber = inputflowersNumber;
    }

    // private void Update()
    // {
    //     startFloralHealing();
    // }

    public void Update()
    {
        if (startSkill)
        {
            startSkill = false;
            if (flowersNumber > 0)
            {
                flowersNumber--;
                StartCoroutine(createFlower());
            }
            else
            {
                startSkill = false;
                flowersNumber = inputflowersNumber;
            }
        }

    }
    IEnumerator createFlower()
    {
        switch (type)
        {
            case 0:
                GameObject yellowFlower = Instantiate(flowers[0], comfeyTransform);
                StartCoroutine(destroyFlower(yellowFlower));
                type++;
                break;
            case 1:
                GameObject redFlower = Instantiate(flowers[1], comfeyTransform);
                StartCoroutine(destroyFlower(redFlower));
                type++;
                break;
            case 2:
                GameObject whiteFlower = Instantiate(flowers[2], comfeyTransform);
                StartCoroutine(destroyFlower(whiteFlower));
                type++;
                break;
            case 3:
                GameObject pinkFlower = Instantiate(flowers[3], comfeyTransform);
                StartCoroutine(destroyFlower(pinkFlower));
                type = 0;
                break;
            default:
                break;
        }
        yield return new WaitForSeconds(recreateFlowerDuration);
        startSkill = true;
    }

    IEnumerator destroyFlower(GameObject flower)
    {
        yield return new WaitForSeconds(deleteFlowerDuration);
        Destroy(flower);

    }
}
