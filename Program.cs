namespace Algorithms
{
    public class Search
    {
        private int[] pole;
        private int hledaneCislo;

        public Search()
        {
            pole = null;
            hledaneCislo = 0;
        }

        ~Search() { }

        public bool linearni()
        {
            input();
            printArr();

            for (int i = 0; i < pole.Length; i++)
            {
                if (pole[i] == hledaneCislo) { return true; }
            }

            return false;
        }

        public bool bezZarazky()
        {
            input();
            printArr();

            int i = 0;
            bool find = false;

            while ((find == false) && (i < pole.Length))
            {
                if (pole[i] == hledaneCislo) { find = true; }
                i += 1;
            }

            return find;
        }

        public bool seZarazkou()
        {
            input(true);
            printArr(true);

            pole[pole.Length - 1] = hledaneCislo;

            for (int i = 0; i < pole.Length - 1; i++)
            {
                if (pole[i] == hledaneCislo) { return true; }
            }

            return false;
        }

        public bool binarySearch()
        {
            Console.WriteLine();
            Console.WriteLine("Zadejete velikost pole: ");
            int vel = int.Parse(Console.ReadLine());
            Console.WriteLine();

            Console.WriteLine("Zadejete cislo, ktere chcete hledat: ");
            hledaneCislo = int.Parse(Console.ReadLine());
            Console.WriteLine();

            Sort radiciObj = new Sort();
            pole = radiciObj.selectionSort(vel);
            printArr();
            Console.WriteLine();


            int max = pole.Length - 1;
            int zacatek = 0;
            int stred = (pole.Length / 2) - 1;

            while (stred <= max)
            {
                if (pole[stred] == hledaneCislo)
                {
                    return true;
                }

                else if (pole[stred] < hledaneCislo)
                {
                    zacatek = stred;

                    if (zacatek % 2 == 0) { stred = (zacatek + (max + 1)) / 2; }
                    else if (zacatek % 2 == 1) { stred = ((zacatek + (max + 1)) / 2) + 1; }
                }

                else if (pole[stred] > hledaneCislo)
                {
                    for (int i = zacatek; i <= stred; i++)
                    {
                        if (pole[i] == hledaneCislo) { return true; }
                    }

                    return false;
                }
            }

            return false;
        }

        private void printArr(bool zarazka = false)
        {
            Console.Write("Obsah pole: ");

            int to = 0;
            if (zarazka == true) { to = pole.Length - 1; }
            else if (zarazka == false) { to = pole.Length; }

            for (int i = 0; i < to; i++)
            {
                Console.Write(pole[i] + " ");
            }

            Console.WriteLine();
        }


        private void input(bool isZar = false)
        {
            Console.WriteLine();
            Console.WriteLine("Zadejete velikost pole: ");
            int vel = int.Parse(Console.ReadLine());
            Console.WriteLine();

            Random rn = new Random();

            if (isZar == false)
            {
                pole = new int[vel];
                for (int i = 0; i < pole.Length; i++) { pole[i] = rn.Next(0, 1000); }
            }

            else if (isZar == true)
            {
                pole = new int[vel + 1];
                for (int i = 0; i < pole.Length - 1; i++) { pole[i] = rn.Next(0, 1000); }
            }

            Console.WriteLine("Zadejete cislo, ktere chcete hledat: ");
            hledaneCislo = int.Parse(Console.ReadLine());
            Console.WriteLine();
        }
    }


    public class Sort
    {
        private int[] pole;
        public Sort() => pole = null;
        ~Sort() { }

        public int[] bubbleSort()
        {
            input();
            Console.WriteLine("Puvodni obsah pole: ");
            printArr();
            Console.WriteLine();

            int kde = pole.Length - 2;

            for (int i = 0; i < pole.Length; i++)
            {
                for (int k = 0; k <= kde; k++)
                {
                    if (pole[k] > pole[k + 1])
                    {
                        int temp = pole[k + 1];
                        pole[k + 1] = pole[k];
                        pole[k] = temp;
                    }
                }

                kde -= 1;
            }

            return pole;
        }

        public int[] insertSort()
        {
            input();
            Console.WriteLine("Puvodni obsah pole: ");
            printArr();
            Console.WriteLine();

            for (int i = 1; i < pole.Length; i++)
            {
                int j = i;
                int temp = pole[j];

                while (j > 0 && temp < pole[j - 1])
                {
                    pole[j] = pole[j - 1];
                    j -= 1;
                }

                pole[j] = temp;
            }

            return pole;
        }

        public int[] selectionSort(int b = 0)
        {
            if (b == 0)
            {
                input();
                Console.WriteLine("Puvodni obsah pole: ");
                printArr();
                Console.WriteLine();
            }

            else if (b > 0)
            {
                Random rn = new Random();
                pole = new int[b];

                for (int i = 0; i < pole.Length; i++) { pole[i] = rn.Next(0, 1000); }
            }


            int n = pole.Length;

            for (int i = 0; i < (n - 1); i++)
            {
                int index = i;
                for (int j = i + 1; j < n; j++)
                {
                    if (pole[j] < pole[index]) { index = j; }
                }


                int temp = pole[index];
                pole[index] = pole[i];
                pole[i] = temp;
            }

            return pole;
        }


        public int[] quickSort()
        {
            input();
            Console.WriteLine("Puvodni obsah pole: ");
            printArr();
            Console.WriteLine();

            int left = 0;
            int right = pole.Length - 1;
            qSort(left, right);

            return pole;
        }

        private void qSort(int left, int right)
        {
            if (left < right)
            {
                int m = left;
                for (int i = (left + 1); i <= right; i++)
                {
                    if (pole[i] < pole[left])
                    {
                        m += 1;
                        int temp = pole[m];
                        pole[m] = pole[i];
                        pole[i] = temp;  
                    }
                }

                int pom = pole[left];
                pole[left] = pole[m];
                pole[m] = pom;

                qSort(left, m - 1);
                qSort(m + 1, right);
            }
        }

        private void input()
        {
            Random rn = new Random();
            pole = new int[100];
            for (int i = 0; i < pole.Length; i++) { pole[i] = rn.Next(-100, 100); }
        }

        private void printArr()
        {
            for (int i = 0; i < pole.Length; i++) { Console.Write(pole[i] + " "); }
            Console.WriteLine();
        }
    }
}
