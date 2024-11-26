import math

def calculate(udot, u1, u2, N1, N2):
    S = 10
    V = (N1 + N2) * math.log2(u1 + u2)
    Vdot = (2 + udot) * math.log2(2 + udot)
    Lgalka = (2 / u1) * (u2 / N2)
    
    print(f"Предсказанная длина реализации по соотношению Холстеда (N^) = {u1 * math.log2(u1) + u2 * math.log2(u2)}")
    print(f"Потенциальный объём реализации (V*) = {Vdot}")
    print(f"Объём реализации (V) = {V}")
    print(f"Уровень программы = {Vdot / V}")
    print(f"Уровень программы по реализации (L^) = {Lgalka}")
    print(f"Интеллектуальное содержание программы (I) = {(2 / u1) * (u2 / N2) * (N1 + N2) * math.log2(u1 + u2)}")
    print(f"Прогназируемое время написания программы (T1) = {V * V / (S * Vdot)}")
    print(f"Прогназируемое время написания программы по Холстеду (T2) = {(u1 * N2 * (u1 * math.log2(u1) + u2 * math.log2(u2)) * math.log2(u1 + u2)) / (2 * S * u2)}")
    print(f"Прогназируемое время написания программы (T3) = {(u1 * N2 * (N1 + N2) * math.log2(u1 + u2)) / (2 * S * u2)}")
    print(f"Среднее значение уровня языков программирования lamda1 = {Lgalka * Lgalka * V}")
    print(f"Среднее значение уровня языков программирования lamda2 = {Vdot * Vdot / V}")


def find_min(a):
    if not a:
        return (float('inf'), -1)

    min_val = a[0]
    min_index = 0
    for i in range(1, len(a)):
        if a[i] < min_val:
            min_val = a[i]
            min_index = i
    return (min_val, min_index)


def bubble_sort(a):
    n = len(a)
    for i in range(n-1):
        for j in range(n-i-1):
            if a[j] > a[j+1]:
                a[j], a[j+1] = a[j+1], a[j]


def binary_search(a, target):
    left, right = 0, len(a) - 1
    while left <= right:
        mid = (left + right) // 2
        if a[mid] == target:
            return mid
        elif a[mid] < target:
            left = mid + 1
        else:
            right = mid - 1
    return -1


def find_min_matrix(a):
    if not a or not a[0]:
        return (float('inf'), -1, -1)

    min_val = a[0][0]
    min_row, min_col = 0, 0
    for i in range(len(a)):
        for j in range(len(a[i])):
            if a[i][j] < min_val:
                min_val = a[i][j]
                min_row, min_col = i, j
    return (min_val, min_row, min_col)

def reverse(a):
    a.reverse()


def cycle_shift(a, positions):
    positions %= len(a)
    if positions == 0:
        return
    a[:] = a[-positions:] + a[:-positions]

def replace_value(a, old_value, new_value):
    for i in range(len(a)):
        if a[i] == old_value:
            a[i] = new_value

if __name__ == "__main__":
    print("=================Проверка кода на Python=================")
    print("Запуск программы поиска минимального элемента в массиве и его индекса:\n")
    calculate(1, 6, 7, 9, 12)

    print("Запуск программы пузырьковой сортировки:\n")
    calculate(1, 4, 6, 7, 7)

    print("Запуск программы бинарного поиска:\n")
    calculate(3, 8, 9, 16, 21)

    print("Запуск программы поиска минимального элемента в двумерном массиве и его индекса:\n")
    calculate(2, 7, 9, 13, 18)

    print("Запуск программы переворачивания массива:\n")
    calculate(1, 1, 1, 1, 2)

    print("Запуск программы циклического сдвига:\n")
    calculate(2, 4, 3, 4, 7)

    print("Запуск программы замены элемента в массиве на новое:\n")
    calculate(3, 4, 4, 5, 6)