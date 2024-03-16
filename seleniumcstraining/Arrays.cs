using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Collections;

string[] a = { "Ravi", "Teja", "Ram" };
int[] b = { 1, 2, 3 };

ArrayList c = new ArrayList();
c.Add("hello");
c.Add("Ravi");
c.Add("Teja");
        
Console.WriteLine(c[1]);

foreach (string item in c)
{
    Console.WriteLine(item);
}

for (int i = 0; i < a.Length; i++)
{
    Console.WriteLine(a[i]);
    if (a[i]=="Teja")
    { 
        Console.WriteLine("Match found in the array");
        break;
    }
}

