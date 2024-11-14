namespace StoneScissorsPaper
{

    /// <summary>
    /// Игра "камень", "ножницы", "бумага" -Сначала вызовите  -> StepUserEndPR (Для хода человека )
    /// Потом посмотрите отчет  о  раунде-> GetMessageRaund
    /// </summary>
    public class Game
    {
        //логика  игры 

        // поля 

        /// <summary>
        /// массив строк -  варианты игры  (если хотим можем потом добавить  еще  вариантов)
        /// </summary>
        private string[] _variantsStep = new string[] { "камень", "ножницы", "бумага" };
       
        /// <summary>
        /// поле. ход человека  в  int
        /// </summary>
        private int _steepUs; // ход  юзера  

        /// <summary>
        /// поле. ход  пк  в  int
        /// </summary>
        private int _steepPk;  // ход пк

        // свойсва 


        /// <summary>
        /// Свойство .  Варианты ходов - берет  из _variantsStep
        /// </summary>
        public string[] GetVariantsStep {  get { return _variantsStep; } } // можно  только прочитать  берет  из  поля   _variantsStep ( см выше)

        /// <summary>
        /// Свойство (приватное). матрица вариантов
        /// </summary>
        string[,] GetVariantsGame  // можно  только прочитать   // ленивое  свойство  -> для  него не  созданно отдельное  поле как для  GetVariantsStep
        {   
            get   // получить
            {
                 return   new string[,]  // матрица  побед  - см скрин  на  лайв борде - 
                 {
                    { "ничья"     , "победа"    , "поражение" },       // строка - игрок  - столбец  противник
                    { "поражение" , "ничья"     , "победа"    },
                    { "победа"    , "поражение" , "ничья"     }
                 };
            }
        }

        /// <summary>
        /// свойсво. Номер раунда
        /// </summary>
        public int Raund { get; private set; } // поменять из вне нельзя
        /// <summary>
        ///  свойсво. очки человека
        /// </summary>
        
        public int TotalUser { get; private set; } // поменять из вне нельзя
        
        /// <summary>
        ///  свойсво. очки пк
        /// </summary>
        public int TotalPK { get; private set; }  // поменять из вне нельзя


        /// <summary>
        ///Свойство. Для вывода  на  экран - ход за компьютера в тексте
        /// </summary>
        public string GetVarPK { get { return GetVarPKString(); /* ленивое  свойство ->  поля  нет...  где то  внизу  метод*/} }

        /// <summary>
        /// ОСНОВНОЙ  МЕТОД! ход человека  -> Вернет  true если верно,  то  будет игра 
        /// </summary>
        /// <param name="variant"></param>
        /// <returns>false  если ход не  корректный</returns>
        public  bool StepUserEndPR(string variant)
        {
            for (int i = 0; i < GetVariantsStep.Length; i++) // поиск  в  массиве 
            {
                if (GetVariantsStep[i] == variant) // если есть
                {
                    _steepUs = i;   // запомним ход
                    GetVarRandomPK(); // сгенерим  ход  за  пк 
                    IsVin();   // найдем  победителя  -  определим счет 
                    Raund++;  // увеличим раунд
                    return true; // скажим миру что  ход  состоялся 
                }
            }
            return false;  // ход не  состоялся
        }

        /// <summary>
        /// МЕТОД! итог раунда  - вызывается полсе хода 
        /// </summary>
        /// <returns></returns>
        public string GetMessageRaund()  // результаты раунда  
        {

            string s = $"Результат раунда {Raund}:" + "\n";
            s += $"Ход компьютера: {GetVarPK}" + "\n";
            s += GetMessageUser(_steepUs, _steepPk) + "\n";
            return s += GetMessagePK(_steepPk, _steepUs);
        }


        #region приватные  методы 

        /// <summary>
        /// приватный метод  - ход за  пк 
        /// </summary>
        private void GetVarRandomPK()   
        {
             Random random = new Random (DateTime.Now.Microsecond); //  DateTime.Now.Microsecond -->
                                                                    //  определяет  микросекунду на  пк - (входной параметр в Random)
                                                                    //  Для  более точного псевдоRandom

            _steepPk = random.Next( GetVariantsStep.Length); // запомним _steepPk
        }

        /// <summary>
        /// возвращает  ход  за  пк --> логика для свойства GetVarPK  - смотри вверх 
        /// </summary>
        /// <returns></returns>
        private string GetVarPKString() 
        {
            if (_steepPk < GetVariantsStep.Length)
                return GetVariantsStep[_steepPk];
            else
                return "error";
        }

        /// <summary>
        /// логика  для опеределения  победителя 
        /// </summary>
        private void IsVin() 
        {
            if (GetVariantsGame[_steepUs, _steepPk] == "победа")
                TotalUser++; // победа человека 

            if (GetVariantsGame[_steepPk, _steepUs] == "победа")
                TotalPK++; // победа PK 
        }

        private string GetMessageUser(int us, int pk)
        {
            return $"Человек - {GetVariantsGame[us, pk]}";     // вывод из матрицы  за  юзера 
        }
        private string GetMessagePK(int pk, int us)
        {
            return $"Компьютер - {GetVariantsGame[us, pk]}";     // вывод из матрицы  за  пк 
        }

        #endregion
    }
}
