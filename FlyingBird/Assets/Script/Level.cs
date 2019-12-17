using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    private const float PIPE_WIDTH = 7.8f;
    private const float PIPE_HEAD_HEIGHT = 3.75f;
    private const float CAMERA_ORTHO_SIZE = 50f;
    private const float PIPE_MOVE_SPEED = 50f;
    private const float PIPE_DESTROY_X_POSITION = -100f;
    private float pipeSpawnTimer;
    // private float pipeSpawnTimerMax;


    int PipeIndex = -1;
    float[] PipegapY = new float[] { 50, 30, 50, 20, 40 };
    float[] PipegapSize = new float[] { 30, 30, 20, 20, 10 };
    float[] CreateTime = new float[] { 1f, 1.5f, 3f, 0.5f, 0f };

    private List<Pipe> pipeList;


    private void Awake()
    {
        pipeList = new List<Pipe>();
        // pipeSpawnTimerMax = 3f;
    }
    void Start()
    {
        // CreatePipe(50f, 0f, true);
        // CreatePipe(50f, 00f, false);
        // CreateGapPipes(50f, 20f, 20f);
        // pipeSpawnTimer = 3f;
    }

    private void Update()
    {
        HandlePipeMovement();
        HandlePipeSpawning();
    }

    private void HandlePipeSpawning()
    {
        pipeSpawnTimer -= Time.deltaTime;
        if (pipeSpawnTimer < 0)
        {
            PipeIndex++;


            // Debug.Log("CreateTime = " + CreateTime);
            Debug.Log("PipeIndex = " + PipeIndex);
            if (PipeIndex < PipegapY.Length)
            {
                pipeSpawnTimer += CreateTime[PipeIndex];
                CreateGapPipes(PipegapY[PipeIndex], PipegapSize[PipeIndex], 100f);
                // Debug.Log("CreateGapPipes");
            }

        }
    }

    private void HandlePipeMovement()
    {
        for (int i = 0; i < pipeList.Count; i++)
        {
            Pipe pipe = pipeList[i];
            pipe.Move();

            if (pipe.GetXPosition() < PIPE_DESTROY_X_POSITION)
            {
                // Destroy Pipe
                pipe.DestroySelf();
                pipeList.Remove(pipe);
                i--;
            }
        }
    }


    private void CreateGapPipes(float gapY, float gapSize, float xPosition)
    {
        CreatePipe(gapY - gapSize * .5f, xPosition, true);
        CreatePipe(CAMERA_ORTHO_SIZE * 2f - gapY - gapSize * .5f, xPosition, false);
    }


    private void CreatePipe(float height, float xPosition, bool createBottom)
    {
        // setting Head
        Transform pipeHead = Instantiate(GameAssets.GetInstance().pfPipeHead);
        float pipeHeadYPosition;
        if (createBottom)
        {
            pipeHeadYPosition = -CAMERA_ORTHO_SIZE + height - PIPE_HEAD_HEIGHT * .5f;
        }
        else
        {
            pipeHeadYPosition = +CAMERA_ORTHO_SIZE - height + PIPE_HEAD_HEIGHT * .5f;
        }
        pipeHead.position = new Vector3(xPosition, pipeHeadYPosition);
        // pipeList.Add(pipeHead);

        // setting Body
        Transform pipeBody = Instantiate(GameAssets.GetInstance().pfPipeBody);
        float pipeBodyYPosition;
        if (createBottom)
        {
            pipeBodyYPosition = -CAMERA_ORTHO_SIZE;
        }
        else
        {
            pipeBodyYPosition = +CAMERA_ORTHO_SIZE;
            pipeBody.localScale = new Vector3(1, -1, 1);
        }
        pipeBody.position = new Vector3(xPosition, pipeBodyYPosition);
        // pipeList.Add(pipeBody);

        // setting Render
        SpriteRenderer pipeBodySpriteRenderer = pipeBody.GetComponent<SpriteRenderer>();
        pipeBodySpriteRenderer.size = new Vector2(PIPE_WIDTH, height);

        // add BoxCollider
        BoxCollider2D pipeBodyBoxCollider = pipeBody.GetComponent<BoxCollider2D>();
        pipeBodyBoxCollider.size = new Vector2(PIPE_WIDTH, height);
        pipeBodyBoxCollider.offset = new Vector2(0f, height * .5f);

        // pipe
        Pipe pipe = new Pipe(pipeHead, pipeBody);
        pipeList.Add(pipe);
    }



    private class Pipe
    {
        private Transform pipeHeadTransform;
        private Transform pipeBodyTransform;
        private bool isBottom;

        public Pipe(Transform pipeHeadTransform, Transform pipeBodyTransform)
        {
            this.pipeHeadTransform = pipeHeadTransform;
            this.pipeBodyTransform = pipeBodyTransform;
        }

        public void Move()
        {
            pipeHeadTransform.position += new Vector3(-1, 0, 0) * PIPE_MOVE_SPEED * Time.deltaTime;
            pipeBodyTransform.position += new Vector3(-1, 0, 0) * PIPE_MOVE_SPEED * Time.deltaTime;
        }

        public float GetXPosition()
        {
            return pipeHeadTransform.position.x;
        }

        public void DestroySelf()
        {
            Destroy(pipeHeadTransform.gameObject);
            Destroy(pipeBodyTransform.gameObject);
        }
    }
}
