## Лабораторная работа № 1 "Организация информационно технического проекта"
### Вариант 23 (задания 6,6)
### Задание 1 - Определение числа с большим количеством цифр
Для реализации программы использовалось консольное приложение Windows, написанное на языке `C++`.
### Usage
После запуска `Task_1_6_Suchkov.exe` файла появится консольный интерфейс программы:

<p align="center">
  <img src="img/task1_interface.png"/>
</p>

**Важно! число, которое вы вводите должно быть _числом_ в формате INT, в противном случае - программа выдаст ошибку**

Программа использует stoi для преобразования строки в число
```cpp
std::cout << "Введите первое число в предалх +-INT_MAX\n";
std::cin >> first;
try {
    first_value = stoi(first);
}
catch (...)
{
    std::cout << "Ошибка при вводе числа! Попробуйте еще раз.\n";
    return ;
}
```
Поэтому программа поддерживает формат входного числа:
* `1234[some_text]`
* `00001234`
*  `+1234`
*  `12.34`

Но будет выдавать ошибки при переполнении INT! 

В случае возникновения ошибок или успешного выполнения, программа предложит продолжить использование.

**Введите `n` для выхода.**
```
[Title START]
Формат записи должен быть: 
{ 
Фамилия 
Имя 
Отчество 
Дата рождения 
[ 
Название 
предмета 
Дата экзамена 
Фамилия преподавателя 
Имя преподавателя 
Отчество преподавателя 
Оценка 
] 
} 
Число предметов в [] может быть от 3 до 5 
[Title END]
```
