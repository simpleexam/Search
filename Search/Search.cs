using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Search
{
    public class Search
    {

        public static int SimpleSearch(int key, int[] source) //простой поиск через перебор
        {
            int i = 0;
            //в цикле при каждой операции выполняются два действия:
            //проверка что не вышли за пределы массива и не нашли искомое
            while (i< source.Length && source[i] != key)
                i++;
            if (i<source.Length) return i; //если до конца объода всего массива нашли элемент, то возвращаем его индекс
            else return -1; //если нет - то эмулируем ошибку (-1)
        }

        public static int SearchWithBarrier(int key, int[] source) //поиск перебором с использованием барьера = искомому значению
        {
            int n = source.Length;
            int temp; //временная переменная для хранения совпадения по последнему элементу. но нужно убедиться, что больше нет таких же элементов
            if (source[n-1]==key) temp = n-1;
            else
            {
                source[n-1] = key; //записываем значение барьера

                int i = 0;
                while (source[i] != key) //теперь в цикле на каждой итерации выполняется только одно действие
                    i++;
                if (i<n-1) return i;
                else return -1;
            }
            return temp;
        }

        public static int BynarySearch(int key, int[] source)//бинарный поиск (строго на предварительно отсортированном по возрастанию наборе данных)
        {
            int middle; //середина набора
            int left = 0; //левая граница = индексу первого элемента
            int right = source.Length-1;//правая граница = индексу последнего элемента

            do
            {
                middle = (left+right)/2; //находим индекс элемента посередине (целочисленное деление здесь актуально)
                if (key > source[middle])//если искомое больше того значения, что находится в середине
                    left = middle+1; //то дальнейший поиск осущществлять в правой половине массива
                else
                    right = middle-1; //иначе поиск осуществлять в левой половине массива
            }
            while (source[middle]!=key && left <=right); //до тех пор, пока не найдется key, или границы не схлопнутся

            if (source[middle] == key) return middle;
            else return -1;
        }

        public static int[] GenerateArray(int countOfElements) //генерация массива
        {
            int[] array = new int[countOfElements];
            Random random = new Random();
            for (int i = 0; i<countOfElements; i++)
                array[i] = random.Next(10, 100);
            return array;
        }
    }
}
