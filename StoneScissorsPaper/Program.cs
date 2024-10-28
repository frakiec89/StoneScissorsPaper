// track
// Важно !!! подобные аглритмы могут  быть разными
// -- если попросить  10 разных  программистов  написать  такую  игру - код  будет  у  всех максимально разный )
// так что  я  не  наставию на  том  что  мое  исполнение  каноничное  

// подготовка 
Random random = new Random(); // для  генерации  ходов  пк

int raund = 0; // будем считать  раунды

int totalUser = 0; // будем  вести счет  игры
int totalPK = 0;

string[] variantsStep = new string[] { "камень", "ножницы", "бумага" }; //варианты игры  - при желании можно  разширить

string[,] variantsGame = new string[,]  // матрица  побед  - см скрин  на  лайв борде - 
{
    { "ничья"     , "победа"    , "поражение" },       // строка - игрок  - столбец  противник
    { "поражение" , "ничья"     , "победа"    },
    { "победа"    , "поражение" , "ничья"     },
};

Console.WriteLine("Игра \"камень ножницы бумага\""); // старт  игры

while (true) // раунд
{
    // ход игрока
    Console.WriteLine("Введите ваш вариант:");

    string varUserString = Console.ReadLine();
    int varUserInt = 0;  // для поиска в  матрице 

    bool flag = false; // для  выхода если что  

    for (int i = 0; i < variantsStep.Length; i++) // поиск  в  массиве 
    {
        if (variantsStep[i] == varUserString)
        {
            varUserInt = i;
            flag = true;
            break; // Выход  из for
        }
    }

    if (flag == false) // если не  нашли вариант в  массиве 
    {
        Console.WriteLine("Такого варинта нет");
        continue; // пропустить  все что  ниже  - начнем  раунд занова
    }

    raund++; // если  ввод  удачный  -раунд состоится 

    // ход  пк 

    int varPKint = random.Next(0, variantsStep.Length); // рандом  их диапазона  массива  // 0 до  3 (3 не включать) тоесть 0 ,1 ,2 
    Console.WriteLine($"Ход компьютера: {variantsStep[varPKint]}");

    // итоги 
    Console.WriteLine("__________");
    if (variantsGame[varUserInt, varPKint] == "победа")  // проверка победы юзера
    {
        totalUser++;
    }

    if (variantsGame[varUserInt, varPKint] == "поражение") // поражение  юзера  -> победа  за  пк ,  хотя тут можно трактовать по разнаму 
    {
        totalPK++;
    }
    // при  ничье  счет не  меняется  -- такую ситуации  отрабатывать вообще не  будем 

    Console.WriteLine($"Результат раунда {raund}:");
    Console.WriteLine($"Человек  - {variantsGame[varUserInt, varPKint]}");     // вывод из матрицы  за  юзера 
    Console.WriteLine($"Компьютер  - {variantsGame[varPKint, varUserInt]}");   // вывод из матрицы  за  пк 

    Console.WriteLine("__________");
    Console.WriteLine($"Общий счёт игры: \nЧеловек:{totalUser} | Компьютер:{totalPK}");

    Console.WriteLine("__________\n"); // для  красоты 
}