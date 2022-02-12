public class HW1
{
    public static long QueueTime(int[] customers, int n)
    {
        if (customers.Length <= n) return customers.Max();
        int skipTime, finishTime, tempTime;
        int[] timeCass = new int[n]; 
        for (int i = 0; i < n; i++)
        {
            timeCass[i] = customers[i];
            customers[i] = 0;
        }
        finishTime = timeCass.Max();
        tempTime = finishTime;
        while (true)
        {
            skipTime = timeCass.Min();
            for (int i = 0; i < timeCass.Length; i++) // перебираем кассы               
                timeCass[i] -= skipTime; // проматываем время на кассе
            tempTime -= skipTime;
            for (int i = 0; i < timeCass.Length; i++)
            {            
                if (timeCass[i] == 0) // если касса свободна
                {
                    for (int j = 0; j < customers.Length; j++) 
                    {
                        if (customers[j] != 0) // находим первого в очереди
                        {
                            timeCass[i] = customers[j]; // отправляем на кассу
                            customers[j] = 0; // удаляем из очереди
                            break;
                        }
                    }
                    if (timeCass[i] == timeCass.Max()) // если добавили покупателя, который будет стоять дольше остальных
                    {
                        finishTime += timeCass[i] - tempTime;
                        tempTime = timeCass[i];
                    }
                }
            }
            if (customers.Sum() == 0) break; // если очередь пуста - выход
        }
        return finishTime;
    }
}

public class Programm
{
    public static void Main()
    {
        int[] a = { 5, 3, 4 };
        Console.WriteLine(HW1.QueueTime(a, 1));
        int[] b = { 10, 2, 3, 3 };
        Console.WriteLine(HW1.QueueTime(b, 2));
        int[] c = { 2, 3, 10 };
        Console.WriteLine(HW1.QueueTime(c, 2));
    }
}