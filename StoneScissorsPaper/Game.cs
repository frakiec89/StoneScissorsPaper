namespace StoneScissorsPaper
{
    public class Game
    {
        private static string[] GetVariantsStep()
        {
            return new string[] { "камень", "ножницы", "бумага" }; //варианты игры  - при желании можно  разширить
        }

        private static string[,] GetVariantsGame()
        {
            string[,] variantsGame = new string[,]  // матрица  побед  - см скрин  на  лайв борде - 
                        {
                            { "ничья"     , "победа"    , "поражение" },       // строка - игрок  - столбец  противник
                            { "поражение" , "ничья"     , "победа"    },
                            { "победа"    , "поражение" , "ничья"     },
                        };

            return variantsGame;
        }

        public static int GetVarUserInt(string variant)
        {
            bool flag = false; // для  выхода если что  
            var variantsStep = GetVariantsStep();
            for (int i = 0; i < GetVariantsStep().Length; i++) // поиск  в  массиве 
            {
                if (variantsStep[i] == variant)
                {
                    flag = true;
                    return i;
                }
            }

            return -1; // пока времменно  
        }


        public static int GetVarPK()
        {
            Random random = new Random();
            return random.Next(0, GetVariantsStep().Length);
        }


        public static string GetVariantForIndex(int i)
        {
            var variantsStep = GetVariantsStep();
            if (i < variantsStep.Length)
                return variantsStep[i];
            else
                return "error";
        }


        public static bool IsVinUser(int us, int pk)
        {
            var variantsGame = GetVariantsGame();

            if (variantsGame[us, pk] == "победа")
                return true;

            return false;
        }


        public static bool IsVinPK(int pk, int us)
        {
            var variantsGame = GetVariantsGame();

            if (variantsGame[pk, us] == "победа")
                return true;

            return false;
        }


        public static string GetMessageUser(int us, int pk)
        {
            var variantsGame = GetVariantsGame();
            return $"Человек  - {variantsGame[us, pk]}";     // вывод из матрицы  за  юзера 

        }

        public static string GetMessagePK(int pk, int us)
        {
            var variantsGame = GetVariantsGame();
            return $"Компьютер  - {variantsGame[pk, us]}";     // вывод из матрицы  за  юзера 
        }
    }
}
