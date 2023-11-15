using Microsoft.VisualStudio.TestTools.UnitTesting;
using latuc.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using latuc.Data.Model;
using Microsoft.EntityFrameworkCore;

namespace latuc.Services.Tests
{
    [TestClass()]
    public class LevelsServiceTests
    {
        LevelsService _service;
        public LevelsServiceTests()
        {
            var builder = new DbContextOptionsBuilder<LatucCodeContext>();
            builder.UseMySql("server=localhost;user=root;password=1234;database=latuc_code", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.31-mysql"));
            LatucCodeContext context = new LatucCodeContext(builder.Options);
            _service = new LevelsService(context);

        }

       

        [TestMethod()]
        public void shouldAssertWhenTheoryIsNotNull()
        {
            var theory = _service.getTheoryFirst("Структура программы");

            Assert.IsNotNull(theory);
        }

        [TestMethod()]
        public void shouldAssertWhenResultTypeIsTheory()
        {
            var theory = _service.getTheoryFirst("Структура программы");
            Assert.IsTrue(theory.GetType() == typeof(Theory));
        }

        [TestMethod()]
        public void shouldAssertWhenResultDataRight()
        {
            var theory = _service.getTheoryFirst("Структура программы");

            bool result = theory.IdTheory == 0 && theory.Text == "Структура программы./nБазовым строительным блоком программы являются инструкции (statement). Инструкция представляет некоторое действие, например, арифметическую операцию, вызов метода, объявление переменной и присвоение ей значения. В конце каждой инструкции в C# ставится точка с запятой (;). Данный знак указывает компилятору на конец инструкции. Например, в проекте консольного приложения, который создается по умолчанию, есть такая строка:/nConsole.WriteLine(\"Hello, World!\");/nДанная строка представляет вызов метода \"Console.WriteLine\", который выводит на консоль строку. В данном случае вызов метода является инструкцией и поэтому завершается точкой с запятой. Здесь блок кода содержит две инструкции. И при выполении этого кода, консоль выведет две строки /n/nПривет Добро пожаловать в C#./nВ данном блоке кода две инструкции, которые выводят на консоль определенную строку.  Одни блоки кода могут содержать другие блоки:/n{/n\tConsole.WriteLine(\"Первый блок\");/n\t{         /n\tConsole.WriteLine(\"Второй блок\");/n\t}/n}/n/nРегистрозависимость./nC# Является регистрозависимым языком. Это значит, что в зависимости от регистра символов какие-то определенные названия могут представлять разные классы, методы, переменные и т.д. Например, для вывода на консоль используется метод \"WriteLine\" - его имя начинается именно с большой буквы: \"WriteLine\". Если мы вместо \"Console.WriteLine\" напишем \"Console.writeline\", то программа не скомпилируется, так как данный метод обязательно должен называться \"WriteLine\", а не \"writeline\" или \"WRITELINE\" или как-то иначе. /n/nКомментарии./nВажной частью программного кода являются комментарии. Они не являются собственно частью программы, при компиляции они игнорируются. Тем не менее комментарии делают код программы более понятным, помогая понять те или иные его части.  есть два типа комментариев: однострочный и многострочный. Однострочный комментарий размещается на одной строке после двойного слеша \"//\". А многострочный комментарий заключается между символами \"/*\" \"текст комментария\" \"*/\". Он может размещаться на нескольких строках. Например:/n/*  первая программа на C#,/nкоторая выводитприветствие на консоль *//nConsole.WriteLine(\"Привет\");/n//Выводим строку \"Привет\"/nConsole.WriteLine(\"Добро пожаловать в C#\");/n// Выводим строку \"Добро пожаловать в C#\"";

            Assert.IsTrue(result);
        }



        [TestMethod()]
        public void shouldAssertWhenNoExistParamThenReturnException()
        {
            Assert.ThrowsException<InvalidOperationException>(() =>
            {
                _service.getTheoryFirst(",l,l");
            });
        }


        // Я не знаю как тестировать при неверном аргументе, так как там ничего не возвращается, ни налл, ни экзепшн, хуй с ним короче 
    }
}