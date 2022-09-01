using UnityEngine;
using System.IO.Ports;
using System;
using System.IO;

public static class Inputdata // 다른 스크립트에서 사용을 위한 데이터 값 저장용 변수 생성
{
    public static int start;
    public static int index_F;
    public static int mid_F;
    public static int ring_F;
    public static int little_F;
    public static int thumb;
    public static int end;

    //public static bool isClicked;
    //public static int max;
    //public static bool Click_Controller = true;

}

public class Serial : MonoBehaviour
{
    private SerialPort sp;
    public int[] data;
    string[] tempstr;

    public static Serial instance;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        DontDestroyOnLoad(this);
    }

    void Start()
    {
        sp = new SerialPort("COM4", 115200, Parity.None, 8, StopBits.One); // 초기화
        try
        {
            sp.Open(); // 프로그램 시작시 포트 열기
            sp.Write("b");
        }
        catch (TimeoutException e) //예외처리
        {
            Debug.Log(e);
        }
        catch (IOException ex) //예외처리
        {
            Debug.Log(ex);
        }

    }


    void Update()
    {
        if (sp != null && sp.IsOpen)
        {
            sp.DiscardInBuffer();

            string temp = sp.ReadLine();
            tempstr = temp.Split(',');
            if (tempstr.Length == 7)
            {
                data = Array.ConvertAll(tempstr, int.Parse);
                Inputdata.end = data[6];
                Inputdata.thumb = data[5];
                Inputdata.little_F = data[4];
                Inputdata.ring_F = data[3];
                Inputdata.mid_F = data[2];
                Inputdata.index_F = data[1];
                Inputdata.start = data[0];
            }
        }
    }

    public void Active()
    {
        if (!sp.IsOpen)
        {
            sp.Open();
        }    
        sp.Write("b");
        Debug.Log(sp.ReadLine());
        Debug.Log(sp.ReadLine());
        
    }

    public void End()
    {     
        sp.Write("t");
        sp.Close();
        Debug.Log(sp.ReadLine());
        print("end");
    }

    private void OnDisable()
    {
        sp.Close();
    }

    private void OnApplicationQuit()
    {
        sp.Close(); // 프로그램 종료시 포트 닫기
    }
}



