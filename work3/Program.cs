/* Задача №58 
Задайте две матрицы. Напишите программу, которая будет находить произведение двух матриц. */

void PrintArray(int[,] inArray) //Отображение массива
{
    for (int i = 0; i < inArray.GetLength(0); i++)
    {
        for (int j = 0; j < inArray.GetLength(1); j++)
        {
            Console.Write($"{inArray[i, j]} ");
        }
        Console.WriteLine();
    }
}

int[,] GetArray(int m, int n, int minValue, int maxValue) //Создание массива
{
    int[,] result = new int[m, n];
    for (int i = 0; i < m; i++)
    {
        for (int j = 0; j < n; j++)
        {
            result[i, j] = new Random().Next(minValue, maxValue);
        }
    }
    return result;
}



int[,] MatrixMultiply(int[,] matrixA, int[,] matrixB) //Умножение матриц
{
    //Колличество столбцов первой матрицы должно быть равно колличеству строк 2 матрицы
    //Должна умножаться строка на столбец
    int rowsA = matrixA.GetLength(0);
    int colsA = matrixA.GetLength(1);
    int rowsB = matrixB.GetLength(0);
    int colsB = matrixB.GetLength(1);

    if (colsA != rowsB)
    {
        throw new Exception("Ошибка, столбец матрицы А не совпадает со строкой матрицы B");
        //Для того чтобы в консоль выдалась информация о не совпадении
    }

    int[,] result = new int[rowsA, colsB]; //Результирующая матрица

    for (int i = 0; i < rowsA; i++) //строка 1 матрицы
    {
        for (int j = 0; j < colsB; j++) //столбец второй
        {
            for (int k = 0; k < colsA; k++) //строка первой 
            {
                result[i, j] += matrixA[i, k] * matrixB[k, j];
            }
        }
    }

    return result;
}

int[,] matrix1 = GetArray(3, 2, 1, 10);         //Задали 2 матрицы
int[,] matrix2 = GetArray(2, 3, 1, 10);  
Console.WriteLine("Матрица А:");
PrintArray(matrix1);                             //Отобразили 2 матрицы
Console.WriteLine("Матрица B:");
PrintArray(matrix2); //Функция вам известна 
Console.WriteLine("Результирующая матрица:");
int[,] matrix = MatrixMultiply(matrix1, matrix2); //Перемножили
PrintArray(matrix);  