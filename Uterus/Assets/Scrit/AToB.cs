using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AToB : MonoBehaviour
{
    public Animator animator;
    float InputX;
    public float InputY;
    float InputZ;
    // Start is called before the first frame update
    void Start()
    {
        //Get Animator
        animator = this.gameObject.GetComponent<Animator>();
        

    }

    // Update is called once per frame
    void Update()
    {

        
            InputY = Input.GetAxis("Vertical");
            animator.SetFloat("InputY", InputY);
        
    }
}
