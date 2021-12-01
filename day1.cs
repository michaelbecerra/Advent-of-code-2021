
// Part 1
static int GetSingleMeasurementIncrease(string inputFile) {
    string[] lines = System.IO.File.ReadAllLines(inputFile);

    int count = 0;
    int index = 0, previous = 0;

    foreach(string line in lines) {
        if (index == 0) {
            previous = Int32.Parse(line);
        }
        if (previous < Int32.Parse(line)) {
            count++;
        }
        index++;
        previous = Int32.Parse(line);
    }

    return count;
}

// Part 2
static int GetMultipleMeasurementIncrease(string inputFile, int window) {
    int[] values = Array.ConvertAll(System.IO.File.ReadAllLines(inputFile), int.Parse);

    int count = 0;
    int previous = 0;
    int currentSum = 0;

    for (int i = 0; i < values.Length - window + 1; i++) {
        currentSum = values.Skip(i).Take(window).Sum();
        // uncomment the following line to see the ranges and their sum
        //Console.WriteLine("From range {0} to {1} the sum is {2}", i, (i + window), currentSum);
        if (i == 0) {
            previous = currentSum;
        }
        if (previous < currentSum) {
            count++;
        }
        previous = currentSum;

    }

    return count;
}

// With function 1 
int singleMeasurementIncrease_f1 = GetSingleMeasurementIncrease("./input.txt");

Console.WriteLine("The result for single measurements with function 1 is " + singleMeasurementIncrease_f1);

// Part 1 and 2 with function 2
int singleMeasurementIncrease_f2 = GetMultipleMeasurementIncrease("./input.txt", 1);
int multipleMeasurementIncrease = GetMultipleMeasurementIncrease("./input.txt", 3);

Console.WriteLine("The result for single measurements with function 2 is " + singleMeasurementIncrease_f2);
Console.WriteLine("The result for multiple measurements is " + multipleMeasurementIncrease);
