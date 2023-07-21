using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenSizeFix : MonoBehaviour
{
    public GameObject gameObjs = default;

    float xScreenHalfSize;
    float yScreenHalfSize;

    float xScreenFullSize;
    float yScreenFullSize;

    const float devScrScaleRation = 1.03125f;


    // Start is called before the first frame update
    void Start()
    {
        AdjustScaleForResolution();
        CameraSizeGet();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Vector3 CameraSizeGet()
    {
        Vector3 cameraSize = Vector3.zero;
        cameraSize.y = Camera.main.orthographicSize * 2.0f;
        cameraSize.x = cameraSize.y * Camera.main.aspect;
        Debug.LogFormat("x = {0}, y = {1}", cameraSize.x, cameraSize.y);

        return cameraSize;
    }

    // �⺻ �ػ� ���� (���� 1920, ���� 1080���� ����)
    public Vector2 defaultResolution = new Vector2(1280, 720);

    protected void AdjustScaleForResolution()
    {
        // ���� ���÷����� �ʺ�� ���̸� �����ɴϴ�.
        int screenWidth = Screen.width;
        int screenHeight = Screen.height;

        // �⺻ �ػ󵵿� ���� �ػ� ������ ����մϴ�.
        float widthRatio = screenWidth / defaultResolution.x;
        float heightRatio = screenHeight / defaultResolution.y;

        // ������ ������ ���� �����մϴ�.
        float scale = widthRatio;

        // UI�� �׷����� �������� �����մϴ�.
        transform.localScale = new Vector3(scale, scale, 1f);

        Debug.LogFormat("Width ->{0} Height -> {1}",screenWidth,screenHeight);
        Debug.LogFormat("WidthRatio = {0}, HeightRatio = {1}", widthRatio, heightRatio);
        Debug.LogFormat("Scale = {0}", scale);
        Debug.LogFormat("��ũ�� ������ ���� : {0}, {1}, {2}", 
            scale, devScrScaleRation, devScrScaleRation / scale);
        gameObjs.transform.localScale *= devScrScaleRation / scale;
    }
}
