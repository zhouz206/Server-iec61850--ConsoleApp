﻿using System;
using Server.Settings;
using Server.ModBus;
using Server.Log;
using Server.Parser;

namespace test_console
{
    public static class Test
    {
        public static void Main()
        {
            Console.CancelKeyPress += Console_CancelKeyPress;
            
            //Открываем настройки сервера
            if (!Settings.ReadSettings())
            {
                Log.Write(@"Settings: ReadSettings finish with status false. Stop server", @"Error   ");
                return;
            }
            Settings.SaveSettings();

            //Парсим файл конфигурации
            if (!Parser.ParseFile())
            {
                Log.Write(@"ParseFile: Finish with status false. Stop server", @"Error   ");
                return;
            }
            Log.Write(@"ParseFile: File parse success", @"Success ");

            //ModBus.ModBus.CloseModBus();
            //ModBus.ModBus.InitConfigDownloadScope("true", "false", "comtrade", "1999", "512", "4096", "Scope\\", "50");
            //ModBus.ModBus.InitConfigModBus("115200", "Odd", "One", "COM1");
            ModBus.ConfigModBusPort();
            ModBus.StartModBus();

            //Создаем модель сервера
            Server.Server.Server.ConfigServer(@"test.cfg");

            //Запуск сервера 
            Server.Server.Server.StartServer();

            Console.WriteLine(@"Start server");

            //Server.Server.StopServer();
            //Console.WriteLine(@"Stop server");
        }

        private static void Console_CancelKeyPress(object sender, ConsoleCancelEventArgs e)
        {
            Server.Server.Server.StopServer();
        }
    }
}