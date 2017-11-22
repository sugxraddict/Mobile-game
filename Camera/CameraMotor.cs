using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMotor : MonoBehaviour
{

    private Transform lookAt;
    private Vector3 startOffset;
    private Vector3 moveVector;
    public GameObject _player;
    public Transform cam;

    public float transition = 0.0f;
    public float animationDuration = 4.0f;
    public Vector3 animationOffset = new Vector3(0, 5, 5);
    private bool animPlay;

    // Use this for initialization
    void Start()
    {
        lookAt = _player.transform;
        startOffset = transform.position - lookAt.position;
    }

    // Update is called once per frame
    void Update()
    {
        Animation();
    }

    public void Animation()
    {
        moveVector = lookAt.position + startOffset;

        // X
        moveVector.x = 0;

        // Y
        moveVector.y = 5; //Mathf.Clamp(moveVector.y, 3, 5);

        // Z
        //moveVector.z = 1;

        if (transition > 1.0f)
        {
            transform.position = moveVector;
            animPlay = true;
        }
        else
        {
            // Animation at the start of the game
            transform.position = Vector3.Lerp(moveVector + animationOffset, moveVector, transition);
            transition += Time.deltaTime * 1 / animationDuration;
            transform.LookAt(lookAt.position + Vector3.up);

        }

    }
}