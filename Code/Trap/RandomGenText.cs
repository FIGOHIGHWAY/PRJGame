using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class RandomGenText : MonoBehaviour
{
    [SerializeField]
    public TMP_Text text;
	Text TextBox;
    public static int randomNumberOne;
    public static int randomNumberTwo;
    public static int randomNumberThree;
    public static int randomNumberFour;
    public static string sum;
    public static string One;
    public static string Two;
    public static string Three;
    public static string Four;
    
    void Start(){
        
    }
    
    public string GetRandomBirthday()
    {
        // สุ่มปี ค.ศ. ระหว่าง 1900-2022
        int year = UnityEngine.Random.Range(1950, 1970);

        // สุ่มเดือน 1-12
        int month = UnityEngine.Random.Range(1, 13);

        // หาจำนวนวันในเดือนนั้น
        int daysInMonth = DateTime.DaysInMonth(year, month);

        // สุ่มวันที่ระหว่าง 1 ถึงจำนวนวันในเดือนนั้น
        int day = UnityEngine.Random.Range(1, daysInMonth + 1);

        // สร้างวันที่จากตัวเลขที่สุ่มได้
        DateTime birthday = new DateTime(year, month, day);

        // แปลงรูปแบบวันที่เป็น string ในรูปแบบ "dd/MM/yyyy"
        string formattedBirthday = birthday.ToString("dd/MM/yyyy");

        return formattedBirthday;
    }

    

}
    
