using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;
using System.IO;
using System.Windows;
using System;
public static class Inputdata1 // 다른 스크립트에서 사용을 위한 데이터 값 저장용 변수 생성
{
    public static int start;
    public static int index_F;
    public static int mid_F;
    public static int ring_F;
    public static int little_F;
    public static int thumb;
    public static int end;

}


public class Serial2 : MonoBehaviour
{
    public List<byte> b = new List<byte>();
    private SerialPort sp;
    public int[] data;
    string[] tempstr;

    string str = "";
    string backup = "";

    int count1 = 0;
    int count2 = 0;


    public static Serial2 instance;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        DontDestroyOnLoad(this);
    }

    private void Start()
    {
        ConnectSerial();
    }
    private void Update()
    {
        //sp.DataReceived += new SerialDataReceivedEventHandler(MySerialReceived);
        MySerialReceived();
    }

    void ConnectSerial()
    {
        string[] ports = SerialPort.GetPortNames();
        foreach (string p in ports)
        {
            sp = new SerialPort(p, 115200, Parity.None, 8, StopBits.One); // 초기화

            try
            {
                //sp.DataReceived += new SerialDataReceivedEventHandler(MySerialReceived);
                sp.WriteTimeout = 500;
                sp.Open(); // 프로그램 시작시 포트 열기
                sp.Write("b"); // 0x02 값을 받으면 데이터 출력 시작 --> by 배열 이용
            }
            catch (Exception ex)
            {
                Debug.Log(ex);
                continue;
            }

            Debug.Log("send message");
            Debug.Log(p);
            try
            {
                if (sp.ReadLine().Equals(""))
                {
                    //sp.DataReceived -= SerialDataReceived;
                    //sp.Close();
                    continue;
                }
                else break;
            }
            catch (Exception ex)
            {
                Debug.Log(ex);
            }

        }
    }

    private void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)  //수신 이벤트가 발생하면 이 부분이 실행된다.
    {
        //this.Invoke(new EventHandler(MySerialReceived));  //메인 쓰레드와 수신 쓰레드의 충돌 방지를 위해 Invoke 사용. MySerialReceived로 이동하여 추가 작업 실행.
    }

    private void MySerialReceived()  //여기에서 수신 데이타를 사용자의 용도에 따라 처리한다.
    {
        //string temp = sp.ReadLine(); // 데이터 한 줄씩 받기
        //Debug.Log(sp.ReadByte());
        /*
        string tmp = sp.ReadExisting();
        if (tmp.Length < 35)
        {
            for (int i = 0; i < tmp.Length; i++)
            {
                if (tmp[i] == 'a')
                {
                    temp += tmp.Substring(i, tmp.Length);
                    flag = true;
                }
                if (tmp[i] == 'b' && flag)
                {
                    temp += tmp.Substring(0,i);
                    backup = tmp.Substring(i, tmp.Length);
                    flag = false;

                    try
                    {
                        data = Array.ConvertAll(tempstr, int.Parse); // int 형으로 변환
                    }
                    catch (Exception e)
                    {
                        print(temp);
                    }
                    Inputdata1.end = data[6];
                    Inputdata1.thumb = data[5];
                    Inputdata1.little_F = data[4];
                    Inputdata1.ring_F = data[3];
                    Inputdata1.mid_F = data[2];
                    Inputdata1.index_F = data[1];
                    Inputdata1.start = data[0];
                    temp = "";
                }
                else if (flag)   //a 들어와 있고, tmp에 a나 b가 없을 때
                {
                    temp += tmp;
                }
            }
        }

        else
        {
            print("접어");
        }
        */
        print("=====================================================================");
        string tmp = sp.ReadExisting();
        print("tmp : " + tmp);
        if(backup.Length != 0)
        {
            str = backup;
            backup = "";
        }
        if(str.Length < 30)
        {
            str += tmp;
        }
        if(str.Length > 30)
        {
            backup = str.Substring(30, str.Length - 30);
            if(backup.Length == 28 || backup.Length == 29)
            {
                return ;
            }
            // print("BULength : "+backup.Length);
            print("backup : " + backup);
            print("str1 : " + str);
            str = str.Substring(0, 28); // 자르는 값 정상
            print("str2 : " + str);
            tempstr = str.Split(','); // , 단위로 나눠서 배열에 순서대로 저장
            try
            {
                data = Array.ConvertAll(tempstr, int.Parse); // int 형으로 변환
                Inputdata1.end = data[6];
            } catch(Exception e)
            {
                print("str3 : " + str);
                print("data : " + data);
                count1++;
                str = "";
                backup = "";
                return ;
            }
            Inputdata1.thumb = data[5];
            Inputdata1.little_F = data[4];
            Inputdata1.ring_F = data[3];
            Inputdata1.mid_F = data[2];
            Inputdata1.index_F = data[1];
            Inputdata1.start = data[0];
            count2++;
            str = "";
        }
        if(str.Length == 30)
        {
            str = str.Substring(0, 28);
            tempstr = str.Split(','); // , 단위로 나눠서 배열에 순서대로 저장
            try
            {
                data = Array.ConvertAll(tempstr, int.Parse); // int 형으로 변환
                Inputdata1.end = data[6];
            } catch(Exception e)
            {
                count1++;
                str = "";
                backup = "";
                return;
            }
            Inputdata1.thumb = data[5];
            Inputdata1.little_F = data[4];
            Inputdata1.ring_F = data[3];
            Inputdata1.mid_F = data[2];
            Inputdata1.index_F = data[1];
            Inputdata1.start = data[0];
            count2++;
            str = "";
        }
        print("데이터 송신 완료" + count2 + "데이터 날림 : " + count1);
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
