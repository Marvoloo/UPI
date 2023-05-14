#include <iostream>
#include <string>

void print_max_len()
{
    std::string first;
    std::string second;
    int first_value;
    int second_value;
    int len1 = 0;
    int len2 = 0;
    long long fval;
    long long sval;
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
    std::cout << "Введите второе число в предалх +-INT_MAX\n";
    std::cin >> second;
    try {
        second_value = stoi(second);
    }
    catch (...)
    {
        std::cout << "Ошибка при вводе числа! Попробуйте еще раз.\n";
        return;
    }
    if (second_value < 0)
        sval = -second_value;
    else
        sval = second_value;
    if (first_value < 0)
        fval = -first_value;
    else
        fval = first_value;
    while (fval > 0)
    {
        len1++;
        fval = fval / 10;
    }
    while (sval > 0)
    {
        len2++;
        sval = sval / 10;
    }
    if (len1 > len2)
        std::cout << "Число " << first_value << " имеет больше знаков (" << len1 << ") чем число " << second_value << " (" << len2 << ").\n";
    else if (len1 != len2)
        std::cout << "Число " << second_value << " имеет больше знаков (" << len2 << ") чем число " << first_value << " (" << len1 << ").\n";
    else
        std::cout << "Число " << first_value << " имеет столько же знаков (" << len1 << "), что и число " << second_value << " (" << len2 << ").\n";
}

int main()
{
    setlocale(LC_ALL, "Russian");
    std::string str;
    while (1)
    {
        print_max_len();
        std::cout << "Желаете продолжить? \"n\" - отмена, остальное - продолжить.\n";
        std::cin >> str;
        if (str == "n")
            return (0);
    }
    return (0);
}

