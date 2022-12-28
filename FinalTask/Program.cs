
using System.Reflection.Metadata;

class MainClass
{
    static void Main(string[] args)
    {
        PrintUserData(UserData());

    }
    // Метод проверки корректности ввода числовых значений
    static int IsCorrect(string value)
    {
        int num;
        bool correct =  int.TryParse(value, out num);
        if (correct)
        {
            while (num < 1)
            {
                Console.Write("Введите число больше 0! Введите число: ");
                num = IsCorrect(Console.ReadLine());
            }
            
        }
        else
        {
            Console.Write($"{value} не является числом! Введите число: ");
            num = IsCorrect(Console.ReadLine());

        }

        return num;
    }
    // Метод для ввода питомцев
    static string[] GetPets(int petsCount)
    {
        string[] pets = new string[petsCount];
        for (int i = 0; i < pets.Length; i++)
        {
            Console.Write($"Введите кличку питомца номер {i+1}: ");
            string pet = Console.ReadLine();
            while (pet == "")
            {
                Console.Write("Кличка не может быть пустой строкой! Введите кличку питомца: ");
            }
            pet = char.ToUpper(pet[0]) + pet.Substring(1);
            pets[i] = pet;
        }

        return pets;
    }
    // Метод для ввода цветов
    static string[] GetColors(int colorsCount)
    {
        string[] favColors = new string[colorsCount];
        for (int i = 0; i < favColors.Length; i++)
        {
            Console.Write($"Введите цвет номер {i+1}: ");
            string favColor = Console.ReadLine();
            while (favColor == "")
            {
                Console.Write("Цвет не может быть пустой строкой! Введите название цвета: ");
            }
            favColors[i] = favColor;
        }

        return favColors;
    }
    // Метод для ввода пользовательских данных
    static (string name, string lastName, int age, string[] pets, string[] favColors) UserData()
    {
        (string name, string lastName, int age, string[] pets, string[] favColors) user = (null, null, 0, new string[] { }, new string[] { });
        
        // Ввод имени
        Console.Write("Введите ваше имя: ");
        user.name = Console.ReadLine();
        user.name = char.ToUpper(user.name[0]) + user.name.Substring(1);
        
        // Ввод фамилии
        Console.Write("Введите вашу фамилию: ");
        user.lastName = Console.ReadLine();
        user.lastName = char.ToUpper(user.lastName[0]) + user.lastName.Substring(1);
       
        // Ввод возраста
        Console.Write("Введите ваш возраст: ");
        user.age = IsCorrect(Console.ReadLine());
        
        //Получение данных о питомцах
        Console.Write("Есть ли у вас питомец? ");
        string hasPet = Console.ReadLine();
        int petCounter = 0;
        while (hasPet.ToLower() != "да" && hasPet.ToLower() != "нет")
        {
            Console.Write("Введите да или нет: ");
            hasPet = Console.ReadLine();
        }
        switch (hasPet.ToLower())
        {
            case "да":
                Console.Write("Введите количество питомцев: ");
                petCounter = IsCorrect(Console.ReadLine());
                break;
            case "нет":
                break;
        }
        if (hasPet.ToLower() == "да")
        {
            user.pets = GetPets(petCounter);
        }
        
        //Получение данных о цветах
        Console.Write("Есть ли у вас любимый цвет? ");
        string hasFavColors = Console.ReadLine();
        int colorsCounter = 0;
        while (hasFavColors.ToLower() != "да" && hasFavColors.ToLower() != "нет")
        {
            Console.WriteLine("Введите да или нет");
            hasFavColors = Console.ReadLine();
        }
        switch (hasFavColors.ToLower())
        {
            case "да":
                Console.Write("Введите количество любимых цветов: ");
                colorsCounter = IsCorrect(Console.ReadLine());
                break;
            case "нет":
                break;
        }
        if (hasFavColors.ToLower() == "да")
        {
            user.favColors= GetColors(colorsCounter);
        }
        
        //Возврат кортежа
        return user;
    }
    // Метод для печати пользовательских данных
    static void PrintUserData((string name, string lastName, int age, string[] pets, string[] favColors) user)
    {
        Console.WriteLine("Данные пользователя:");
        Console.WriteLine($"Имя пользователя: {user.name}");
        Console.WriteLine($"Фамилия пользователя: {user.lastName}");
        Console.WriteLine($"Возраст пользователя: {user.age}");
        
        //Печать данных о питомцах
        if (user.pets.Length != 0)
        {
            for (int i = 0; i < user.pets.Length; i++)
            {
                string petName = user.pets[i];
                
                Console.WriteLine($"Кличка {i+1}го питомца пользователя {user.name}: {user.pets[i]}");
            }
        }
        else
        {
            Console.WriteLine($"У пользователя {user.name} нет питомцев.");
        }
        
        // Печать данных о цветах
        if (user.favColors.Length != 0)
        {
            for (int i = 0; i < user.favColors.Length; i++)
            {
                Console.WriteLine($"{i+1}-ый любимый цвет пользователя {user.name}: {user.favColors[i]}");
            }
        }
        else
        {
            Console.WriteLine($"У пользователя {user.name} нет лююбимых цветов");
        }
        Console.ReadKey();
        
        }
    
}