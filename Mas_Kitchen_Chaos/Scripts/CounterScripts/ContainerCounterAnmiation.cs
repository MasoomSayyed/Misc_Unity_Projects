using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContainerCounterAnmiation : MonoBehaviour
{
    [SerializeField] private ContainerCounter ContainerCounter;

    private const string OPEN_CLOSE = "OpenClose";
    private Animator animator;


    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Start()
    {
        ContainerCounter.onPlayerGrabbedObject += ContainerCounter_onPlayerGrabbedObject;
    }

    private void ContainerCounter_onPlayerGrabbedObject(object sender, System.EventArgs e)
    {
        animator.SetTrigger(OPEN_CLOSE);
    }
}
