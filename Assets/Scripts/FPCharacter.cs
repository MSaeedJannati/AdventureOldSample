using UnityEngine;
using System.Collections;

public class FPCharacter : MonoBehaviour
{
    #region Variables
    public float moveSpeed = 10f;
    public float jumpHeight = 10f;
    public float rotateSpeed = 10f;
    public float hDirection = 0;
    public float vDirection = 0;
    public float hRotation = 0;
    public float vRotation = 0;
    public RectTransform Image1RecT;
    public RectTransform Image2RecT;
    public Vector2 RectTAnchPos = Vector2.zero;
    public Vector2 RectTAnchPos2 = Vector2.zero;
    public Vector3 movement = Vector3.zero;
    CharacterController Char;
    Transform CamTransform;
    Vector3 forward = Vector3.zero;
    Vector3 right = Vector3.zero;
    public Vector3 TotalRot = Vector3.zero;
    public Vector3 move = Vector3.zero;
    public float ROTX = 0.0f;
    public float ROTY = 0.0f;
    Quaternion DestRot = Quaternion.identity;



    #endregion
    // Use this for initialization
    void Start()
    {
        Char = gameObject.GetComponent<CharacterController>();
        CamTransform = Camera.main.transform;


    }


    // Update is called once per frame
    void Update()
    {


        MoveChar();
        RotateCam();
        //RotateChar ();
        Move();



    }
    public void MoveChar()
    {
        hDirection = Input.GetAxis("Horizontal");
        vDirection = Input.GetAxis("Vertical");
        Vector2 MousePos = (Input.mousePosition).normalized;
        hRotation = MousePos.x;
        vRotation = MousePos.y;
        forward = CamTransform.TransformDirection(Vector3.forward);
        right = CamTransform.TransformDirection(Vector3.right);

        movement = (forward * vDirection + right * hDirection).normalized;
        Char.Move(movement * moveSpeed * Time.deltaTime + new Vector3(0, -10, 0) * Time.deltaTime);
        if (Input.GetButtonDown("Jump"))
        {
            if (Char.isGrounded)
                Char.Move(new Vector3(0, 10, 0));
        }
    }
    public void Move()
    {
        RectTAnchPos2 = Image2RecT.anchoredPosition;
        forward = CamTransform.TransformDirection(Vector3.forward);
        right = CamTransform.TransformDirection(Vector3.right);
        vDirection = RectTAnchPos2.y;
        hDirection = RectTAnchPos2.x;
        if (hDirection * hDirection < 1)
        {
            hDirection = 0;

        }
        if (vDirection * vDirection < 1)
        {
            vDirection = 0;
        }
        movement = (forward * vDirection + right * hDirection).normalized;
        Char.Move(movement * moveSpeed * Time.deltaTime + new Vector3(0, -10, 0) * Time.deltaTime);

    }
    public void RotateCam()
    {
        RectTAnchPos = Image1RecT.anchoredPosition;

        if (RectTAnchPos.x * RectTAnchPos.x > 1)
        {
            hRotation = RectTAnchPos.x;
        }
        else
        {
            hRotation = 0;
        }
        if (RectTAnchPos.y * RectTAnchPos.y > 1)
        {
            vRotation = RectTAnchPos.y;
        }
        else
        {
            vRotation = 0;
        }


        vRotation = vRotation * rotateSpeed * Time.deltaTime;
        hRotation = hRotation * rotateSpeed * Time.deltaTime;
        ROTX -= vRotation;
        ROTY += hRotation;
        Quaternion Yrot = Quaternion.Euler(0f, ROTY, 0f);

        ROTX = Mathf.Clamp(ROTX, -60f, 60f);
        DestRot = Yrot * Quaternion.Euler(ROTX, 0f, 0f);
        Camera.main.transform.rotation = DestRot;
    }
    public void Jump()
    {
        if (Char.isGrounded)
        {
            Char.Move(new Vector3(0, jumpHeight, 0));


        }

    }




}
