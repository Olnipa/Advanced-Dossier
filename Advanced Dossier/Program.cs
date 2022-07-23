using System;

namespace sorting
{
    class Program
    {
        static void Main(string[] args)
        {
            bool isWorking = true;

            List<string> fullNames = new List<string> { "Петров Михаил Евгеньевич", "Васильев Евгений Иванович", "Дроздов Николай Петрович" };
            List<string> positions = new List<string> { "Менеджер", "Сантехник", "Зоолог" };

            while (isWorking)
            {
                Console.WriteLine("\nВыберите соответствующую цифру на клавиатуре:\n1 - Добавить досье. 2 - Вывести все досье. " +
                    "3 - Удалить досье. 0 - Выход\n");
                ConsoleKeyInfo choosenMenu = Console.ReadKey(true);

                switch (choosenMenu.Key)
                {
                    case ConsoleKey.D1:
                        AddDossier(fullNames, positions);
                        break;
                    case ConsoleKey.D2:
                        WriteList(fullNames, positions);
                        break;
                    case ConsoleKey.D3:
                        DeleteDossier(fullNames, positions);
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

        static void DeleteDossier(List<string> fullNames, List<string> positions)
        {
            int dossierForDelete;
            Console.Write("Укажите номер досье, которое необходимо удалить: ");

            if (int.TryParse(Console.ReadLine(), out dossierForDelete))
            {
                int indexForDelete = dossierForDelete - 1;

                if (indexForDelete >= 0 && indexForDelete < fullNames.Count)
                {
                    Console.Write("\nВы пытаетесь удалить досье №");
                    WriteDossier(indexForDelete, fullNames[indexForDelete], positions[indexForDelete]);
                    WriteSystemMessage("1 - Подтвердить удаление. Любая другая клавиша - Отменить удаление.");
                    ConsoleKeyInfo choosenConfirmationMenu = Console.ReadKey(true);

                    switch (choosenConfirmationMenu.Key)
                    {
                        case ConsoleKey.D1:
                            fullNames.RemoveAt(indexForDelete);
                            positions.RemoveAt(indexForDelete);
                            WriteSystemMessage("Данные успешно удалены. Для продолжения нажмите любую клавишу...", ConsoleColor.Green);
                            Console.ReadKey(true);
                            break;
                        default:
                            WriteSystemMessage("Удаление отменено.");
                            break;
                    }
                }
                else
                {
                    WriteSystemMessage("Такого досье не найдено.");
                }
            }
            else
            {
                WriteSystemMessage("Введенное значение не является числом");
            }
        }

        static void WriteDossier(int index, string fullName, string position)
        {
            Console.WriteLine($"{index + 1}. {fullName} - {position}");
        }

        static void AddDossier(List<string> fullNames, List<string> positions)
        {
            string fullName = ReadText("Введите Фамилию, Имя и Отчество последовательно, через пробел: ");
            string employeePosition = ReadText("Введите должность: ");

            fullNames.Add(fullName);
            positions.Add(employeePosition);
            WriteSystemMessage("Данные успешно внесены. Для продолжения нажмите любую клавишу...", ConsoleColor.Green);
            Console.ReadKey(true);
        }

        static void WriteSystemMessage(string text, ConsoleColor color = ConsoleColor.Red)
        {
            ConsoleColor defaultColor = Console.ForegroundColor;
            Console.ForegroundColor = color;
            Console.WriteLine(text);
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
                    WriteSystemMessage("Пожалуйста, введите данные без сокращений.");
                }
            }

            return value;
        }

        static void WriteList(List<string> fullNames, List<string> positions, string text = "\nДля продолжения нажмите любую клавишу...")
        {
            for (int i = 0; i < positions.Count; i++)
            {
                WriteDossier(i, fullNames[i], positions[i]);
            }

            Console.WriteLine(text);
            Console.ReadKey(true);
        }
    }
}