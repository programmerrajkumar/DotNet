using System;

namespace DomainService
{
    public class Number
    {
        public bool IsEven(int num)
        {
            return num % 2 == 0;
        }

        public bool IsOdd(int num)
        {
            return !IsEven(num);
        }
    }
}
