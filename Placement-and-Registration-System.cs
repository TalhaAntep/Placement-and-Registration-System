using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace yks
{
    internal class Program
    {
        static void Main(string[] args)
        {  //Read inputs
            string[] candidate = System.IO.File.ReadAllLines(@"candidates.txt", Encoding.GetEncoding("windows-1254"));


            string[] depart = System.IO.File.ReadAllLines(@"departments.txt", Encoding.GetEncoding("windows-1254"));
            //Define arrays
            int[] stu_num = new int[candidate.Length];
            string[] name = new string[candidate.Length];
            int[] diploma = new int[candidate.Length];
            char[] answers = new char[25];
            char[] answer_list = new char[1000];
            string[] ilk_tercih = new string[candidate.Length];
            string[] ikinci_tercih = new string[candidate.Length];
            string[] üçüncü_tercih = new string[candidate.Length];

            int a = 0;
            int grade = 0;
            int x = 0;

            while (x < candidate.Length)
            {
                string[] index = candidate[x].Split(',');
                stu_num[x] = Convert.ToInt32(index[0]);
                name[x] = index[1];
                diploma[x] = Convert.ToInt32(index[2]);
                ilk_tercih[x] = index[3];
                ikinci_tercih[x] = index[4];
                üçüncü_tercih[x] = index[5];
                if (index.Length > 31)
                {
                    Console.WriteLine("Error!! There are 25 questions.");
                    Console.WriteLine();
                    break;
                }

                for (int j = 0; j < 25; j++)//store the students' answers
                {
                    answers[j] = Convert.ToChar(index[j + 6]);
                    answer_list[a] = answers[j];
                    a++;
                }
                x++;


            }

            int b = 0;
            int[] grade_list = new int[candidate.Length];
            char[] key = { 'A', 'B', 'D', 'C', 'C', 'C', 'A', 'D', 'B', 'C', 'D', 'B', 'A', 'C', 'B', 'A', 'C', 'D', 'C', 'D', 'A', 'D', 'B', 'C', 'D' };
            for (int j = 0; j < candidate.Length; j++)//Calculate the students' grades
            {
                for (int i = 0; i < 25; i++)
                {
                    if (answer_list[b] == (key[i]))
                        grade += 4;
                    else if (answer_list[b] == ' ')
                        grade = grade;
                    else
                        grade -= 3;
                    b++;

                }
                grade_list[j] = grade;


                grade = 0;
            }
            int temp;
            int temp_no;
            string temp_name;
            int temp_diploma;
            string temp_ilktercih;
            string temp_ikincitercih;
            string temp_üçüncütercih;

            for (int i = 0; i < grade_list.Length - 1; i++) // For order high grade to low grade
            {
                for (int j = i + 1; j < grade_list.Length; j++)
                {

                    if (grade_list[i] < grade_list[j])
                    {

                        temp = grade_list[i];
                        grade_list[i] = grade_list[j];
                        grade_list[j] = temp;
                        temp_no = stu_num[i];
                        stu_num[i] = stu_num[j];
                        stu_num[j] = temp_no;
                        temp_name = name[i];
                        name[i] = name[j];
                        name[j] = temp_name;
                        temp_diploma = diploma[i];
                        diploma[i] = diploma[j];
                        diploma[j] = temp_diploma;
                        temp_ilktercih = ilk_tercih[i];
                        ilk_tercih[i] = ilk_tercih[j];
                        ilk_tercih[j] = temp_ilktercih;
                        temp_ikincitercih = ikinci_tercih[i];
                        ikinci_tercih[i] = ikinci_tercih[j];
                        ikinci_tercih[j] = temp_ikincitercih;
                        temp_üçüncütercih = üçüncü_tercih[i];
                        üçüncü_tercih[i] = üçüncü_tercih[j];
                        üçüncü_tercih[j] = temp_üçüncütercih;


                    }
                    else if (grade_list[i] == grade_list[j])
                    {
                        if (diploma[i] < diploma[j])
                        {
                            temp = grade_list[i];
                            grade_list[i] = grade_list[j];
                            grade_list[j] = temp;
                            temp_no = stu_num[i];
                            stu_num[i] = stu_num[j];
                            stu_num[j] = temp_no;
                            temp_name = name[i];
                            name[i] = name[j];
                            name[j] = temp_name;
                            temp_diploma = diploma[i];
                            diploma[i] = diploma[j];
                            diploma[j] = temp_diploma;
                            temp_ilktercih = ilk_tercih[i];
                            ilk_tercih[i] = ilk_tercih[j];
                            ilk_tercih[j] = temp_ilktercih;
                            temp_ikincitercih = ikinci_tercih[i];
                            ikinci_tercih[i] = ikinci_tercih[j];
                            ikinci_tercih[j] = temp_ikincitercih;
                            temp_üçüncütercih = üçüncü_tercih[i];
                            üçüncü_tercih[i] = üçüncü_tercih[j];
                            üçüncü_tercih[j] = temp_üçüncütercih;
                        }
                    }
                }

            }

            string[] dept_no = new string[depart.Length];
            string[] dept_name = new string[depart.Length];
            int[] dept_quota = new int[depart.Length];
            for (int i = 0; i < depart.Length; i++)
            {
                string[] indexdept = depart[i].Split(',');
                dept_no[i] = indexdept[0];
                dept_name[i] = indexdept[1];
                dept_quota[i] = Convert.ToInt16(indexdept[2]);
            }
            //Write first output
            Console.WriteLine("The grades of all candidates");
            Console.WriteLine();
            Console.WriteLine("Number" + "      " + "Name & Surname" + "        " + "Grade");

            for (int i = 0; i < candidate.Length; i++)
            {
                Console.Write(stu_num[i] + "         ");
                Console.Write(name[i] + "    ");
                Console.CursorLeft = 34;
                Console.Write(grade_list[i]);
                Console.WriteLine();
            }
            
            int[] D1 = new int[8]; int var1 = 0;
            int[] D2 = new int[8]; int var2 = 0;
            int[] D3 = new int[8]; int var3 = 0;
            int[] D4 = new int[8]; int var4 = 0;
            int[] D5 = new int[8]; int var5 = 0;
            int[] D6 = new int[8]; int var6 = 0;
            int[] D7 = new int[8]; int var7 = 0;
            int[] D8 = new int[8]; int var8 = 0;
            int[] D9 = new int[8]; int var9 = 0;
            int[] D10 = new int[8]; int var10 = 0;
            //Place the students in array of departments 
            for (int i = 0; i < candidate.Length; i++)
            {
                if (grade_list[i] >= 40)
                {
                    if (dept_quota.Length > 0)
                    {
                        if (ilk_tercih[i] == "D1" && var1 < dept_quota[0])
                        {
                            D1[var1] = stu_num[i];
                            Array.Clear(stu_num, i, 1);
                            var1++;
                        }
                    }
                    if (dept_quota.Length > 1)
                    {
                        if (ilk_tercih[i] == "D2" && var2 < dept_quota[1])
                        {
                            D2[var2] = stu_num[i];
                            Array.Clear(stu_num, i, 1);
                            var2++;
                        }
                    }
                    if (dept_quota.Length > 2)
                    {
                        if (ilk_tercih[i] == "D3" && var3 < dept_quota[2])
                        {
                            D3[var3] = stu_num[i];
                            Array.Clear(stu_num, i, 1);
                            var3++;
                        }
                    }
                    if (dept_quota.Length > 3)
                    {
                        if (ilk_tercih[i] == "D4" && var4 < dept_quota[3])
                        {
                            D4[var4] = stu_num[i];
                            Array.Clear(stu_num, i, 1);
                            var4++;
                        }
                    }
                    if (dept_quota.Length > 4)
                    {
                        if (ilk_tercih[i] == "D5" && var5 < dept_quota[4])
                        {
                            D5[var5] = stu_num[i];
                            Array.Clear(stu_num, i, 1);
                            var5++;
                        }
                    }
                    if (dept_quota.Length > 5)
                    {
                        if (ilk_tercih[i] == "D6" && var6 < dept_quota[5])
                        {
                            D6[var6] = stu_num[i];
                            Array.Clear(stu_num, i, 1);
                            var6++;
                        }
                    }
                    if (dept_quota.Length > 6)
                    {
                        if (ilk_tercih[i] == "D7" && var7 < dept_quota[6])
                        {
                            D7[var7] = stu_num[i];
                            Array.Clear(stu_num, i, 1);
                            var7++;
                        }
                    }
                    if (dept_quota.Length > 7)
                    {
                        if (ilk_tercih[i] == "D8" && var8 < dept_quota[7])
                        {
                            D8[var8] = stu_num[i];
                            Array.Clear(stu_num, i, 1);
                            var8++;
                        }
                    }
                    if (dept_quota.Length > 8)
                    {
                        if (ilk_tercih[i] == "D9" && var9 < dept_quota[8])
                        {
                            D9[var9] = stu_num[i];
                            Array.Clear(stu_num, i, 1);
                            var9++;
                        }
                    }
                    if (dept_quota.Length > 9)
                    {

                        if (ilk_tercih[i] == "D10" && var10 < dept_quota[9])
                        {
                            D10[var10] = stu_num[i];
                            Array.Clear(stu_num, i, 1);
                            var10++;
                        }

                    }
                }
            }

            if (dept_quota.Length > 0)
                dept_quota[0] = dept_quota[0] - var1;
            if (dept_quota.Length > 1)
                dept_quota[1] = dept_quota[1] - var2;
            if (dept_quota.Length > 2)
                dept_quota[2] = dept_quota[2] - var3;
            if (dept_quota.Length > 3)
                dept_quota[3] = dept_quota[3] - var4;
            if (dept_quota.Length > 4)
                dept_quota[4] = dept_quota[4] - var5;
            if (dept_quota.Length > 5)
                dept_quota[5] = dept_quota[5] - var6;
            if (dept_quota.Length > 6)
                dept_quota[6] = dept_quota[6] - var7;
            if (dept_quota.Length > 7)
                dept_quota[7] = dept_quota[7] - var8;
            if (dept_quota.Length > 8)
                dept_quota[8] = dept_quota[8] - var9;
            if (dept_quota.Length > 9)
                dept_quota[9] = dept_quota[9] - var10;
            int tempvar1 = var1;
            int tempvar2 = var2;
            int tempvar3 = var3;
            int tempvar4 = var4;
            int tempvar5 = var5;
            int tempvar6 = var6;
            int tempvar7 = var7;
            int tempvar8 = var8;
            int tempvar9 = var9;
            int tempvar10 = var10;
            var1 = 0;
            var2 = 0;
            var3 = 0;
            var4 = 0;
            var5 = 0;
            var6 = 0;
            var7 = 0;
            var8 = 0;
            var9 = 0;
            var10 = 0;

            for (int i = 0; i < candidate.Length; i++)
            {
                if (grade_list[i] >= 40)
                {
                    if (dept_quota.Length > 0)
                    {
                        if (ikinci_tercih[i] == "D1" && var1 < dept_quota[0])
                        {
                            D1[tempvar1] = stu_num[i];
                            Array.Clear(stu_num, i, 1);
                            var1++;
                        }
                    }
                    if (dept_quota.Length > 1)
                    {
                        if (ikinci_tercih[i] == "D2" && var2 < dept_quota[1])
                        {
                            D2[tempvar2] = stu_num[i];
                            Array.Clear(stu_num, i, 1);
                            var2++;
                        }
                    }
                    if (dept_quota.Length > 2)
                    {
                        if (ikinci_tercih[i] == "D3" && var3 < dept_quota[2])
                        {
                            D3[tempvar3] = stu_num[i];
                            Array.Clear(stu_num, i, 1);
                            var3++;
                        }
                    }
                    if (dept_quota.Length > 3)
                    {
                        if (ikinci_tercih[i] == "D4" && var4 < dept_quota[3])
                        {
                            D4[tempvar4] = stu_num[i];
                            Array.Clear(stu_num, i, 1);
                            var4++;
                        }
                    }
                    if (dept_quota.Length > 4)
                    {
                        if (ikinci_tercih[i] == "D5" && var5 < dept_quota[4])
                        {
                            D5[tempvar5] = stu_num[i];
                            Array.Clear(stu_num, i, 1);
                            var5++;
                        }
                    }
                    if (dept_quota.Length > 5)
                    {
                        if (ikinci_tercih[i] == "D6" && var6 < dept_quota[5])
                        {
                            D6[tempvar6] = stu_num[i];
                            Array.Clear(stu_num, i, 1);
                            var6++;
                        }
                    }
                    if (dept_quota.Length > 6)
                    {
                        if (ikinci_tercih[i] == "D7" && var7 < dept_quota[6])
                        {
                            D7[tempvar7] = stu_num[i];
                            Array.Clear(stu_num, i, 1);
                            var7++;
                        }
                    }
                    if (dept_quota.Length > 7)
                    {
                        if (ikinci_tercih[i] == "D8" && var8 < dept_quota[7])
                        {
                            D8[tempvar8] = stu_num[i];
                            Array.Clear(stu_num, i, 1);
                            var8++;
                        }
                    }
                    if (dept_quota.Length > 8)
                    {
                        if (ikinci_tercih[i] == "D9" && var9 < dept_quota[8])
                        {
                            D9[tempvar9] = stu_num[i];
                            Array.Clear(stu_num, i, 1);
                            var9++;
                        }
                    }
                    if (dept_quota.Length > 9)
                    {
                        if (ikinci_tercih[i] == "D10" && var10 < dept_quota[9])
                        {
                            D10[tempvar10] = stu_num[i];
                            Array.Clear(stu_num, i, 1);
                            var10++;
                        }
                    }
                }

            }
            if (dept_quota.Length > 0)
                dept_quota[0] = dept_quota[0] - var1;
            if (dept_quota.Length > 1)
                dept_quota[1] = dept_quota[1] - var2;
            if (dept_quota.Length > 2)
                dept_quota[2] = dept_quota[2] - var3;
            if (dept_quota.Length > 3)
                dept_quota[3] = dept_quota[3] - var4;
            if (dept_quota.Length > 4)
                dept_quota[4] = dept_quota[4] - var5;
            if (dept_quota.Length > 5)
                dept_quota[5] = dept_quota[5] - var6;
            if (dept_quota.Length > 6)
                dept_quota[6] = dept_quota[6] - var7;
            if (dept_quota.Length > 7)
                dept_quota[7] = dept_quota[7] - var8;
            if (dept_quota.Length > 8)
                dept_quota[8] = dept_quota[8] - var9;
            if (dept_quota.Length > 9)
                dept_quota[9] = dept_quota[9] - var10;
            tempvar1 += var1;
            tempvar2 += var2;
            tempvar3 += var3;
            tempvar4 += var4;
            tempvar5 += var5;
            tempvar6 += var6;
            tempvar7 += var7;
            tempvar8 += var8;
            tempvar9 += var9;
            tempvar10 += var10;
            var1 = 0;
            var2 = 0;
            var3 = 0;
            var4 = 0;
            var5 = 0;
            var6 = 0;
            var7 = 0;
            var8 = 0;
            var9 = 0;
            var10 = 0;
            for (int i = 0; i < candidate.Length; i++)
            {
                if (grade_list[i] >= 40)
                {
                    if (dept_quota.Length > 0)
                    {
                        if (üçüncü_tercih[i] == "D1" && var1 < dept_quota[0])
                        {
                            D1[tempvar1] = stu_num[i];
                            Array.Clear(stu_num, i, 1);
                            var1++;
                        }
                    }
                    if (dept_quota.Length > 1)
                    {
                        if (üçüncü_tercih[i] == "D2" && var2 < dept_quota[1])
                        {
                            D2[tempvar2] = stu_num[i];
                            Array.Clear(stu_num, i, 1);
                            var2++;
                        }
                    }
                    if (dept_quota.Length > 2)
                    {
                        if (üçüncü_tercih[i] == "D3" && var3 < dept_quota[2])
                        {
                            D3[tempvar3] = stu_num[i];
                            Array.Clear(stu_num, i, 1);
                            var3++;
                        }
                    }
                    if (dept_quota.Length > 3)
                    {
                        if (üçüncü_tercih[i] == "D4" && var4 < dept_quota[3])
                        {
                            D4[tempvar4] = stu_num[i];
                            Array.Clear(stu_num, i, 1);
                            var4++;
                        }
                    }
                    if (dept_quota.Length > 4)
                    {
                        if (üçüncü_tercih[i] == "D5" && var5 < dept_quota[4])
                        {
                            D5[tempvar5] = stu_num[i];
                            Array.Clear(stu_num, i, 1);
                            var5++;
                        }
                    }
                    if (dept_quota.Length > 5)
                    {
                        if (üçüncü_tercih[i] == "D6" && var6 < dept_quota[5])
                        {
                            D6[tempvar6] = stu_num[i];
                            Array.Clear(stu_num, i, 1);
                            var6++;
                        }
                    }
                    if (dept_quota.Length > 6)
                    {
                        if (üçüncü_tercih[i] == "D7" && var7 < dept_quota[6])
                        {
                            D7[tempvar7] = stu_num[i];
                            Array.Clear(stu_num, i, 1);
                            var7++;
                        }
                    }
                    if (dept_quota.Length > 7)
                    {
                        if (üçüncü_tercih[i] == "D8" && var8 < dept_quota[7])
                        {
                            D8[tempvar8] = stu_num[i];
                            Array.Clear(stu_num, i, 1);
                            var8++;
                        }
                    }
                    if (dept_quota.Length > 8)
                    {
                        if (üçüncü_tercih[i] == "D9" && var9 < dept_quota[8])
                        {
                            D9[tempvar9] = stu_num[i];
                            Array.Clear(stu_num, i, 1);
                            var9++;
                        }
                    }
                    if (dept_quota.Length > 9)
                    {
                        if (üçüncü_tercih[i] == "D10" && var10 < dept_quota[9])
                        {
                            D10[tempvar10] = stu_num[i];
                            Array.Clear(stu_num, i, 1);
                            var10++;
                        }
                    }
                }

            }
            //Write last output
            Console.WriteLine();
            Console.WriteLine("The results of department assignments");
            Console.WriteLine();
            Console.WriteLine("No" + "         " + "Department" + "                 " + "Students");
            for (int i = 0; i < dept_name.Length; i++)
            {
                Console.Write(dept_no[i] + "         ");
                Console.Write(dept_name[i] + "    ");
                Console.CursorLeft = 38;
                if (i == 0)
                {
                    for (int k = 0; k < D1.Length; k++)
                    {
                        if (D1[k] != 0)
                            Console.Write(D1[k] + "  ");
                    }
                }
                if (i == 1)
                {
                    for (int k = 0; k < D1.Length; k++)
                    {
                        if (D2[k] != 0)
                            Console.Write(D2[k] + "  ");
                    }
                }
                if (i == 2)
                {
                    for (int k = 0; k < D1.Length; k++)
                    {
                        if (D3[k] != 0)
                            Console.Write(D3[k] + "  ");
                    }
                }
                if (i == 3)
                {
                    for (int k = 0; k < D1.Length; k++)
                    {
                        if (D4[k] != 0)
                            Console.Write(D4[k] + "  ");
                    }
                }
                if (i == 4)
                {
                    for (int k = 0; k < D1.Length; k++)
                    {
                        if (D5[k] != 0)
                            Console.Write(D5[k] + "  ");
                    }
                }
                if (i == 5)
                {
                    for (int k = 0; k < D1.Length; k++)
                    {
                        if (D6[k] != 0)
                            Console.Write(D6[k] + "  ");
                    }
                }
                if (i == 6)
                {
                    for (int k = 0; k < D1.Length; k++)
                    {
                        if (D7[k] != 0)
                            Console.Write(D7[k] + "  ");
                    }
                }
                if (i == 7)
                {
                    for (int k = 0; k < D1.Length; k++)
                    {
                        if (D8[k] != 0)
                            Console.Write(D8[k] + "  ");
                    }
                }
                if (i == 8)
                {
                    for (int k = 0; k < D1.Length; k++)
                    {
                        if (D9[k] != 0)
                            Console.Write(D9[k] + "  ");
                    }
                }
                if (i == 9)
                {
                    for (int k = 0; k < D1.Length; k++)
                    {
                        if (D10[k] != 0)
                            Console.Write(D10[k] + "  ");
                    }
                }

                Console.WriteLine();
            }

            Console.ReadLine();


        }
    }
}
