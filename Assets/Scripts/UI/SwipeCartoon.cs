using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwipeCartoon : MonoBehaviour
{
    [SerializeField]
    private Scrollbar scrollbar;
    [SerializeField]
    private Transform[] circleContents;
    [SerializeField]
    private float swipeTime = 0.2f;
    [SerializeField]
    private float swipeDistance = 50.0f;


    private float[] scrollPageValues;
    private float valueDistance = 0;
    private int currentPage = 0;
    private int maxPage = 0;
    private float startTouchX;
    private float endTouchX;
    private bool isSwipeMode = false;
    private float circleContentScale = 1.6f;

    private void Awake()
    {
        scrollPageValues = new float[transform.childCount];

        valueDistance = 1f/(scrollPageValues.Length - 1f);

        for(int i = 0; i < scrollPageValues.Length; i++)
        {
            scrollPageValues[i] = valueDistance * i;
        }

        maxPage = transform.childCount;
    }

    private void Start()
    {
        SetScrollBarValue(0);
    }

    public void SetScrollBarValue(int ind)
    {
        currentPage = ind;
        scrollbar.value = scrollPageValues[ind];
    }

    private void Update()
    {
        if (isSwipeMode) return;
        // 현재 플레이 환경이 안드로이드일 때 전처리기 #if 조건에 만족하는 코드를 활성화
#if UNITY_ANDROID
        if(Input.touchCount == 1)
        {
            Touch touch = Input.GetTouch(0);

            if(touch.phase == TouchPhase.Began)
            {
                startTouchX = touch.position.x;
            }
            else if(touch.phase == TouchPhase.Ended)
            {
                endTouchX = touch.position.x;

                UpdateSwipe();
            }
        }
#endif

#if UNITY_EDITOR
        if(Input.touchCount == 1)
        {
            Touch touch = Input.GetTouch(0);

            if(touch.phase == TouchPhase.Began)
            {
                startTouchX = touch.position.x;
            }
            else if(touch.phase == TouchPhase.Ended)
            {
                endTouchX = touch.position.x;

                UpdateSwipe();
            }
        }
#endif

        UpdateCircleContent();
    }

    private void UpdateSwipe()
    {
        if(Mathf.Abs(startTouchX-endTouchX) < swipeDistance)
        {
            StartCoroutine(OnSwipeOneStep(currentPage));
            return;
        }
        bool isLeft = startTouchX < endTouchX ? true : false;

        if(isLeft)
        {
            if (currentPage == 0) return;
            currentPage -= 1;
        }
        else
        {
            if (currentPage == maxPage - 1) return;

            currentPage += 1;
        }

        StartCoroutine(OnSwipeOneStep(currentPage));
    }

    private IEnumerator OnSwipeOneStep(int ind)
    {
        float start = scrollbar.value;
        float current = 0;
        float percent = 0;

        isSwipeMode = true;
        while(percent < 1)
        {
            current += Time.deltaTime;
            percent = current / swipeTime;

            scrollbar.value = Mathf.Lerp(start, scrollPageValues[ind], percent);

            yield return null;
        }

        isSwipeMode = false;
    }

    private void UpdateCircleContent()
    {
        for(int i = 0; i < scrollPageValues.Length; i++)
        {
            circleContents[i].localScale = Vector2.one;
            circleContents[i].GetComponent<Image>().color = Color.white;

            if (scrollbar.value < scrollPageValues[i] + (valueDistance / 2) && scrollbar.value > scrollPageValues[i] - (valueDistance / 2)) {
                circleContents[i].localScale = Vector2.one * circleContentScale;
                circleContents[i].GetComponent<Image>().color = Color.blue;
            }
        }
    }
}
