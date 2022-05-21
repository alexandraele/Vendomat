using System;
using System.IO;

namespace Vendomat
{ 
    class Vendomat {
       
        private int[] stocTip=new int[20];
        public void SetStocTip( int[] v)
        {
            int j = 0;
            for(int i = 0; i < v.Length; i++)
            {
                this.stocTip[j] = v[i];
                j++;
            }
        }
        public bool Vanzare(int[] p)
        {
            int nr = p.Length;
            for(int i = 0; i < nr; i++)
            {
                if (p[i] != 0)
                {
                    if (this.stocTip[i] == 0)
                    {

                        return false;
                    }
                    else
                    {
                        this.stocTip[i] -= p[i];
                    }
                }
                else 
                { 
                    continue; 
                }
            }
            return true;
        }
        public void Aprovizionare()
        {
            for(int i = 0; i < stocTip.Length; i++)
            {
                this.stocTip[i] += 10;
            }
        }
    }
    class Program
    { static bool eNula(int k, int[,] a)
        {
            for(int i = 0; i < a.GetLength(1); i++)
            {
                if (a[k, i] != 0) return false;
            }
            return true;
        }
        static void Main(string[] args)
        {
            Vendomat vendomat = new Vendomat();
            int N, n, nrAprov = 0, nrVanzare = 0,nrNereusite;
            try
            {
                StreamReader fin = new StreamReader("input.txt");
                string l1 = fin.ReadLine();
                string[] split = l1.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                N = int.Parse(split[0]);
                if (N <= 0 || N >= 21)
                {
                    throw new ArgumentOutOfRangeException("N trebuie sa fie cuprins intre 1 si 20!");
                }

                int[] v = new int[N];
                split = fin.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                for (int i = 0; i < N; i++)
                {
                    v[i] = int.Parse(split[i]);
                }
                vendomat.SetStocTip(v);

                split = fin.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                n = int.Parse(split[0]);
                if (n<=0 || n >= 101)
                {
                    throw new Exception("n trebuie sa fie cuprins intre 1 si 100!");
                }

                int[,] c = new int[n, N];

                for (int i = 0; i < n; i++)
                {
                    split = fin.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                    for (int j = 0; j < N; j++)
                    {
                        c[i, j] = int.Parse(split[j]);
                    }
                }
                fin.Close();

                int k = 0;
                while (k < n)
                {
                    bool e = eNula(k, c);
                    if (e == true)
                    {
                        vendomat.Aprovizionare();
                        nrAprov++;
                    }
                    else
                    {
                        int[] vect = new int[N];
                        for (int j = 0; j < N; j++)
                        {
                            vect[j] = c[k, j];
                        }
                        bool vandut = vendomat.Vanzare(vect);
                        if (vandut == true)
                        {
                            nrVanzare++;
                        }

                    }

                    k++;
                }
                nrNereusite = n - nrAprov - nrVanzare;
               
                Console.WriteLine(nrNereusite);
                Console.WriteLine(nrAprov);

            }catch(ArgumentOutOfRangeException e)
            {
                Console.WriteLine(e);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
