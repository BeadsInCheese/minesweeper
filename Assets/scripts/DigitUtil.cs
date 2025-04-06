using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DigitUtil 
{
    public static (int,int) extract2Digits(int num)
    {
        int digit1 = num % 10;
        int digit2 = num / 10;
        return (digit1 , digit2) ;

    }
}
