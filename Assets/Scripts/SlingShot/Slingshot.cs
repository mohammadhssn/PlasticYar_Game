using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slingshot : MonoBehaviour
{
    public bool isFlaying; //check bird is flay
    
    //pathpoint
    [SerializeField] float spaceBetweenPoint;
    [SerializeField] private GameObject pointPrefabs;
    private GameObject[] points;
    [SerializeField] private int numberOfPoint;
    //
    
    private Vector3 dir;

    private GameObject parentPoint;
    
    public LineRenderer[] lineRenderers;
    public Transform[] stripPositions;
    public Transform center;
    public Transform idlePosition;

    public Vector3 currentPosition;

    public float maxLength;

    public float bottomBoundary;

    bool isMouseDown;

    public List<GameObject> birdPrefab; // list gameobject bird also use change

    public float birdPositionOffset;

    Rigidbody2D bird;
    Collider2D birdCollider;

    public float force;

    private void Awake()
    {
        parentPoint = new GameObject("ParentPoint");
    }

    void Start()
    {
        isFlaying = false;
        lineRenderers[0].positionCount = 2;
        lineRenderers[1].positionCount = 2;
        lineRenderers[0].SetPosition(0, stripPositions[0].position);
        lineRenderers[1].SetPosition(0, stripPositions[1].position);

        CreateBird();
        points = new GameObject[numberOfPoint];
        for (int i = 0; i < numberOfPoint; i++)
        {
            points[i] = Instantiate(pointPrefabs, bird.transform.position, Quaternion.identity);
        }
    }

    void CreateBird()
    {
        for (int i = 0; i < birdPrefab.Count;)
        {
            bird = Instantiate(birdPrefab[0]).GetComponent<Rigidbody2D>();
            /*
            if (!birdPrefab[i])
            {
                bird = Instantiate(birdPrefab[i]).GetComponent<Rigidbody2D>();

                birdPrefab.Remove(birdPrefab[i]);
                break;
            }*/
            birdPrefab.Remove(birdPrefab[0]);
            break;
        }
        //bird = Instantiate(birdPrefab).GetComponent<Rigidbody2D>();
        if (bird)
        {
            birdCollider = bird.GetComponent<Collider2D>();
            birdCollider.enabled = false;

            bird.isKinematic = true;
        }

        ResetStrips();
    }

    void Update()
    {
        if (isMouseDown)
        {
            Vector3 mousePosition = Input.mousePosition;
            mousePosition.z = 10;

            currentPosition = Camera.main.ScreenToWorldPoint(mousePosition);
            currentPosition = center.position + Vector3.ClampMagnitude(currentPosition
                - center.position, maxLength);

            //currentPosition = ClampBoundary(currentPosition);

            SetStrips(currentPosition);

            if (birdCollider)
            {
                birdCollider.enabled = true;
            }
            
        }
        else
        {
            ResetStrips();
        }
        for (int i = 0; i < numberOfPoint; i++)
        {
            points[i].transform.position = PointPosition(i * spaceBetweenPoint);
            points[i].transform.SetParent(parentPoint.transform);
        }
    }

    private void OnMouseDown()
    {
        isMouseDown = true;
        AudioMaster.Play(0); // play audio
    }

    private void OnMouseUp()
    {
        isFlaying = true;
        isMouseDown = false;
        Shoot();
        currentPosition = idlePosition.position;
    }

    void Shoot()
    {
        if (bird)
        {
            bird.isKinematic = false;
            Vector3 birdForce = (currentPosition - center.position) * force * -1;
            bird.velocity = birdForce;

            bird.GetComponent<Bird>().Release();
        
        }

        bird = null;
        birdCollider = null;
        Invoke("CreateBird", 5);
    }

    
    void ResetStrips()
    {
        currentPosition = idlePosition.position;
        SetStrips(currentPosition);
    }

    void SetStrips(Vector3 position)
    {
        lineRenderers[0].SetPosition(1, position);
        lineRenderers[1].SetPosition(1, position);

        if (bird)
        {
            dir = position - center.position;
            bird.transform.position = position + dir.normalized * birdPositionOffset;
            bird.transform.right = -dir.normalized;
        }
    }

    Vector3 ClampBoundary(Vector3 vector)
    {
        vector.y = Mathf.Clamp(vector.y, bottomBoundary, 1000);
        return vector;
    }
    
    Vector2 PointPosition(float t)
    {
        if (bird)
        {
            Vector2 currentPointPos = (Vector2)bird.transform.position + (-(Vector2)dir * force * t) + 0.5f * Physics2D.gravity * (t * t);
            return currentPointPos;
        }

        return default;
    }
}
