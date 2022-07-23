using System;

namespace sorting
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> fullNameList = new List<string> { "Петров Михаил Евгеньевич", "Васильев Евгений Иванович", "Дроздов Николай Петрович" };
            bool isWorking = true;
            List<string> employeePositionList = new List<string> { "Менеджер", "Сантехник", "Зоолог" };

            while (isWorking)
            {
                Console.WriteLine("\nВыберите соответствующую цифру на клавиатуре:\n1 - Добавить досье. 2 - Вывести все досье. " +
                    "3 - Удалить досье. 0 - Выход\n");
                ConsoleKeyInfo choosenMenu = Console.ReadKey(true);

                switch (choosenMenu.Key)
                {
                    case ConsoleKey.D1:
                        AddDossier(ref fullNameList, ref employeePositionList);
                        break;
                    case ConsoleKey.D2:
                        WriteList(fullNameList, employeePositionList, fullNameList.Count);
                        break;
                    case ConsoleKey.D3:
                        DeleteDossier(ref fullNameList, ref employeePositionList);
                        break;
                    case ConsoleKey.D0:
                        isWorking = false;
                        break;
                    default:
                        int cursorPosition = Console.CursorTop - 4;
                        Console.SetCursorPosition(0, cursorPosition);
                        break;
                }
            }
        }

        static void DeleteDossier(ref List<string> fullNameList, ref List<string> employeePositionList)
        {
            int dossierForDelete;
            Console.Write("Укажите номер досье, которое необходимо удалить: ");

            if (int.TryParse(Console.ReadLine(), out dossierForDelete))
            {
                int indexForDelete = dossierForDelete - 1;

                if (indexForDelete >= 0 && indexForDelete < fullNameList.Count)
                {
                    Console.Write("\nВы пытаетесь удалить досье №");
                    WriteList(fullNameList, employeePositionList, indexForDelete + 1, indexForDelete, "\n1 - Подтвердить удаление. Любая другая клавиша - Отменить удаление.");
                    ConsoleKeyInfo choosenConfirmationMenu = Console.ReadKey(true);

                    switch (choosenConfirmationMenu.Key)
                    {
                        case ConsoleKey.D1:
                            fullNameList.RemoveAt(indexForDelete);
                            employeePositionList.RemoveAt(indexForDelete);

                            ChangeColor("Данные успешно удалены. Для продолжения нажмите любую клавишу...", ConsoleColor.Green);
                            Console.ReadKey(true);
                            break;
                        default:
                            ChangeColor("Удаление отменено.");
                            break;
                    }
                }
                else
                {
                    ChangeColor("Такого досье не найдено.");
                }
            }
            else
            {
                ChangeColor("Введенное значение не является числом");
            }
        }

        static void AddDossier(ref List<string> fullNameList, ref List<string> employeePositionList)
        {
            string fullName = "";
            string employeePosition = "";

            fullName = ReadText("Введите Фамилию, Имя и Отчество последовательно, через пробел: ");
            employeePosition = ReadText("Введите должность: ");

            fullNameList.Add(fullName);
            employeePositionList.Add(employeePosition);

            ChangeColor("Данные успешно внесены. Для продолжения нажмите любую клавишу...", ConsoleColor.Green);

            Console.ReadKey(true);
        }

        static void ChangeColor(string error, ConsoleColor color = ConsoleColor.Red)
        {
            ConsoleColor defaultColor = Console.ForegroundColor;
            Console.ForegroundColor = color;
            Console.WriteLine(error);
            Console.ForegroundColor = defaultColor;
        }

        static string ReadText(string text)
        {
            string value = "";
            int minValueLenght = 2;

            while (value.Length < minValueLenght)
            {
                Console.Write(text);
                value = Console.ReadLine();

                if (value.Length < minValueLenght)
                {
                    ChangeColor("Пожалуйста, введите данные без сокращений.");
                }
            }

            return value;
        }

        static void WriteList(List<string> fullNameList, List<string> employeePositionList, int maxCycles, int x = 0, string text = "\nДля продолжения нажмите любую клавишу...")
        {
            for (int i = x; i < maxCycles; i++)
            {
                Console.Write(i + 1 + ". ");
                Console.Write(fullNameList[i]);
                Console.WriteLine(" - " + employeePositionList[i]);
            }

            Console.WriteLine(text);

            if (text == "\nДля продолжения нажмите любую клавишу...")
            {
                Console.ReadKey(true);
            }
        }
    }
}