// track
// Важно !!! подобные аглритмы могут  быть разными
// -- если попросить  10 разных  программистов  написать  такую  игру - код  будет  у  всех максимально разный )
// так что  я  не  наставию на  том  что  мое  исполнение  каноничное  

// подготовка 

using StoneScissorsPaper;

int raund = 0; // будем считать  раунды

int totalUser = 0; // будем  вести счет  игры
int totalPK = 0;

Console.WriteLine("Игра \"камень ножницы бумага\""); // старт  игры

while (true) // раунд
{
    // ход игрока
    Console.WriteLine("Введите ваш вариант:");

    string temp = Console.ReadLine();
    int varUserInt = Game.GetVarUserInt(temp);  // для поиска в  матрице 
   
    if (varUserInt == -1) // если не  нашли вариант в  массиве 
    {
        Console.WriteLine("Такого варинта нет");
        continue; // пропустить  все что  ниже  - начнем  раунд занова
    }

    raund++; // если  ввод  удачный  -раунд состоится 

    // ход  пк 

    int varPKint = Game.GetVarPK();  // рандом  их диапазона  массива  // 0 до  3 (3 не включать) тоесть 0 ,1 ,2 
   
    Console.WriteLine($"Ход компьютера: {Game.GetVariantForIndex(varPKint)}");

    // итоги 
    Console.WriteLine("__________");

    if (Game.IsVinUser(varUserInt , varPKint) ==true)  // проверка победы юзера
    {
        totalUser++;
    }

    if (Game.IsVinPK( varPKint , varUserInt) == true) // поражение  юзера  -> победа  за  пк ,  хотя тут можно трактовать по разнаму 
    {
        totalPK++;
    }
    // при  ничье  счет не  меняется  -- такую ситуации  отрабатывать вообще не  будем 

    Console.WriteLine($"Результат раунда {raund}:");
    Console.WriteLine(Game.GetMessageUser(varUserInt, varPKint));     // вывод из матрицы  за  юзера 
    Console.WriteLine(Game.GetMessagePK (varPKint, varUserInt));   // вывод из матрицы  за  пк 

    Console.WriteLine("__________");
    Console.WriteLine($"Общий счёт игры: \nЧеловек:{totalUser} | Компьютер:{totalPK}");

    Console.WriteLine("__________\n"); // для  красоты 
}