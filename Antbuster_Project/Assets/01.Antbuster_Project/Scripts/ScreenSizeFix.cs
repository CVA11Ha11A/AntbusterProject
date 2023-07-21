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

    // 기본 해상도 설정 (가로 1920, 세로 1080으로 예시)
    public Vector2 defaultResolution = new Vector2(1280, 720);

    protected void AdjustScaleForResolution()
    {
        // 현재 디스플레이의 너비와 높이를 가져옵니다.
        int screenWidth = Screen.width;
        int screenHeight = Screen.height;

        // 기본 해상도와 현재 해상도 비율을 계산합니다.
        float widthRatio = screenWidth / defaultResolution.x;
        float heightRatio = screenHeight / defaultResolution.y;

        // 적용할 스케일 값을 결정합니다.
        float scale = widthRatio;

        // UI와 그래픽의 스케일을 조정합니다.
        transform.localScale = new Vector3(scale, scale, 1f);

        Debug.LogFormat("Width ->{0} Height -> {1}",screenWidth,screenHeight);
        Debug.LogFormat("WidthRatio = {0}, HeightRatio = {1}", widthRatio, heightRatio);
        Debug.LogFormat("Scale = {0}", scale);
        Debug.LogFormat("스크린 스케일 오차 : {0}, {1}, {2}", 
            scale, devScrScaleRation, devScrScaleRation / scale);
        gameObjs.transform.localScale *= devScrScaleRation / scale;
    }
}
