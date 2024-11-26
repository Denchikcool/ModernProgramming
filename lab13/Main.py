import math

def i(eta):
    return int(math.log2(eta) / 3 + 1)

def k(eta, i):
    total = 1
    for j in range(1, i):
        total += int(eta / (8**j))
    return total

def n(k, nk):
    return k * nk

def nk(eta2k):
    return 2 * eta2k * math.log2(eta2k)

def eta2k(eta):
    return eta * math.log2(eta)

def v(k, nk, eta2k):
    return k * nk * math.log2(2 * eta2k)

def p(n):
    return 3 * n / 8

def tk(n):
    return n / (5 * 20)

def t(tk):
    return tk / 2

def b0(v):
    return v / 3000

def tn(b0, t):
    return t / math.log(b0)


etas = [300, 400, 512]

for element in etas:
    i_val = i(element)
    k_val = k(element, i_val)
    eta2k_val = eta2k(element)
    nk_val = nk(eta2k_val)
    n_val = n(k_val, nk_val)
    v_val = v(k_val, nk_val, eta2k_val)
    p_val = p(n_val)
    tk_val = tk(n_val)
    t_val = t(tk_val)
    b0_val = b0(v_val)
    tn_val = tn(b0_val, t_val)

    print(f"Значение = {element}")
    print(f"Число уровней иерархии = {i_val}")
    print(f"Общее число модулей = {k_val}")
    print(f"Eta2k = {eta2k_val}")
    print(f"Nk = {nk_val}")
    print(f"Длина программы = {n_val}")
    print(f"Объём ПС = {v_val}")
    print(f"Длина ПС, выраженная в количестве команд ассемблера = {p_val}")
    print(f"Календарное время программирования = {tk_val}")
    print(f"Время отладки = {t_val}")
    print(f"Начальное количество ошибок = {b0_val}")
    print(f"Надежность ПС = {tn_val}")
    print("=============================================")