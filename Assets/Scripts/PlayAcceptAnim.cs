using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAcceptAnim : MonoBehaviour
{
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetTrigger("Active");
    }
}
