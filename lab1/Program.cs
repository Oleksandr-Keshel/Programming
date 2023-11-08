/*
    Завдання #1
    Дано структуру даних (колекцію) відповідно до варіанта. Додати
    зазначену кількість елементів, які описують відповідну предметну
    область. Вивести всі елементи на консоль в прямому та зворотному
    порядку. Вивести кількість елементів у колекції. Очистити колекцію.
    9. Array -  Назви знаків зодіаку к-ст:12;
*/


//method that prints elements in direct order 
static void printArray(string [] array){
    System.Console.WriteLine("Elements of the array in direct order:");
    foreach (string item in array)
    {
        System.Console.WriteLine(item);
    }
}

//method that prints elements in reversed order
static void printReversedArray(string [] array){
    System.Console.WriteLine("Elements of the array in reversed order:");
    for (int i = array.Length-1; i > 0; i--)
    {
        System.Console.WriteLine(array[i]);
    }
}

// creating an array with astrological signs
string [] AstrologSign = new string [12]{ 
    "Aries","Taurus","Gemini","Cancer","Leo","Virgo","Libra","Scorpio","Sagittarius","Capricorn", "Aquarius", "Pisces"
}; 

// printArray(AstrologSign);
// printReversedArray(AstrologSign);
// System.Console.WriteLine("The amount of elements in the array: " + AstrologSign.Length);

// Array.Clear(AstrologSign,0, AstrologSign.Length);


//-----------------------------------------------------------------------

/*
    Завдання #2
    9 Дано чергу цілих чисел, яка складається з n елементів.
    Визначити середнє арифметичне значення додатних елементів і
    середнє арифметичне значення від’ємних елементів.
*/

static void generateQueue(int numOfElements, Queue<int> queue){
    Random rnd = new Random();
    for(int i=0; i < numOfElements; i++){
        int rndInt = rnd.Next(-100,101);
        queue.Enqueue(rndInt);
    }
}
static void drawQueueElems(Queue<int> queue){
    System.Console.WriteLine("Queue elements:");
    foreach (int el in queue)
    {
        Console.WriteLine(el);
    }
}
static double аrithMeanOfPositive(Queue<int> queue){
    int sum = 0;
    int amountOfPos = 0;
    foreach (int el in queue)
    {
        if(el > 0){
            amountOfPos += 1;
            sum += el;
        }
    }
    double arithMean = sum / amountOfPos;
    return arithMean;
}
static double аrithMeanOfNegative(Queue<int> queue){
    int sum = 0;
    int amountOfNeg = 0;
    foreach (int el in queue)
    {
        if(el < 0){
            amountOfNeg += 1;
            sum += el;
        }
    }
    double arithMean = sum / amountOfNeg;
    return arithMean;
}


Queue<int> myQueue = new Queue<int>();
Console.Write("Type the amount of elements in a queue: ");
int numOfElements = Convert.ToInt32(Console.ReadLine());

generateQueue(numOfElements,myQueue);
drawQueueElems(myQueue);

System.Console.WriteLine("Arithmetic mean of positive elements of the queue is " + аrithMeanOfPositive(myQueue));

System.Console.WriteLine("Arithmetic mean of negative elements of the queue is " + аrithMeanOfNegative(myQueue));


















