using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Main_UIManager : MonoBehaviour
{
    public GameObject loginPanel;
    public GameObject mainPanel;
    public GameObject testPanel;
    public GameObject practicePanel;
    public GameObject signUpPanel;
    public GameObject pausePanel;
    public GameObject firstPagePanel;
    public GameObject turnOffPanel;

    void Start() 
    {
        signUpPanel.SetActive(false);
        loginPanel.SetActive(false);
        mainPanel.SetActive(false);
        testPanel.SetActive(false);
        practicePanel.SetActive(false);
        pausePanel.SetActive(false);
        turnOffPanel.SetActive(false);
        firstPagePanel.SetActive(true);
    }

    void Update() {}

    // 메인 페이지 ->  첫 페이지
    public void MainToFirst()
    {
        mainPanel.SetActive(false);
        firstPagePanel.SetActive(true);
    }

    // 메인 페이지 -> 측정 페이지
    public void TestPage()
    {
        mainPanel.SetActive(false);
        testPanel.SetActive(true);
    }

    // 메인 페이지 -> 훈련 페이지
    public void PracticePage()
    {
        mainPanel.SetActive(false);
        practicePanel.SetActive(true);
    }

    // 로그인 페이지 -> 메인 페이지 
    public void LoginToMain()
    {
        loginPanel.SetActive(false);
        mainPanel.SetActive(true);
    }

    // 측정 페이지 -> 메인 페이지 
    public void TestToMain()
    {
        testPanel.SetActive(false);
        mainPanel.SetActive(true);
    }

    // 훈련 페이지 -> 메인 페이지 
    public void PracticeToMain()
    {
        practicePanel.SetActive(false);
        mainPanel.SetActive(true);
    }

    // 측정 페이지 -> 측정 컨텐츠 페이지 
    public void TestContent()
    {
        testPanel.SetActive(false);
        // 페그보드 씬 불러오기!!

    }

    // 훈련 페이지 -> 훈련 컨텐츠 페이지 
    public void PracticeContent()
    {
        practicePanel.SetActive(false);
        // 활쏘기 씬 불러오기!!

    }

    // 첫 페이지 -> 회원가입 페이지 
    public void FirstToSignUp()
    {
        firstPagePanel.SetActive(false);
        signUpPanel.SetActive(true);
    }

    // 첫 페이지 -> 로그인 페이지 
    public void FirstToLogin()
    {
        firstPagePanel.SetActive(false);
        loginPanel.SetActive(true);
    }

    // 로그인 페이지 -> 첫 페이지 
    public void LoginToFirst()
    {
        loginPanel.SetActive(false);
        firstPagePanel.SetActive(true);
    }

    // 회원가입 페이지 -> 첫 페이지 
    public void SignUpToFirst()
    {
        signUpPanel.SetActive(false);
        firstPagePanel.SetActive(true);
    }

    // 회원가입 페이지 -> 메인 페이지 
    public void SignUpToMain()
    {
        signUpPanel.SetActive(false);
        mainPanel.SetActive(true);
    }

    // 일시정지 패널 켜기
    public void OnPauseBtn()
    {
        pausePanel.SetActive(true);
    }

    // 일시정지 패널 끄기
    public void OffPauseBtn()
    {
        pausePanel.SetActive(false);
    }

    // 일시정지 패널 -> 메인 페이지
    public void PauseToMain()
    {
        pausePanel.SetActive(false);
        mainPanel.SetActive(true);
    }

    // 종료 패널 켜기
    public void OnTurnOffBtn()
    {
        turnOffPanel.SetActive(true);
    }

    // 종료 패널 끄기
    public void OffTurnOffBtn()
    {
        turnOffPanel.SetActive(false);
    }

    // 게임 종료 
    public void Quit()
    {
        Application.Quit();
    }
}
