// track

// Важно !!! подобные аглритмы могут  быть разными
// -- если попросить  10 разных  программистов  написать  такую  игру - код  будет  у  всех максимально разный )
// так что  я  не  наставию на  том  что  мое  исполнение  каноничное  

// подготовка 

using StoneScissorsPaper;
Game game = new Game();

Console.WriteLine("Игра \"камень ножницы бумага\""); // старт  игры

while (true) // раунд
{
    // ход игрока
    Console.WriteLine("Введите ваш вариант:");
    string temp = Console.ReadLine();
    
    bool f = game.StepUserEndPR(temp);  // раунд 
   
    if (f == false) // если не состялся 
    {
        Console.WriteLine("Такого варинта нет");
        continue; // пропустить  все что  ниже  - начнем  раунд занова
    }

    // итоги 
    Console.WriteLine("__________");

    Console.WriteLine(game.GetMessageRaund());    
    
    Console.WriteLine("__________");

    Console.WriteLine($"Общий счёт игры: \nЧеловек:{game.TotalUser} | Компьютер:{game.TotalPK}"); // при  желании  можно  сделать  метод в классе  game 

    Console.WriteLine("__________\n"); // для  красоты 
}