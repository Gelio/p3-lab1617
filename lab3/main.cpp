#include <iostream>
#include <vector>
#include <algorithm>
#include <iterator>
#include <numeric>

#include "lab3.h"

using namespace std;

using namespace lab3;

int main() {
    srand(0xFULL);
    std::vector<int> v1(10), v2(10), v3(15);

    //Etap1
    cout << "**\nEtap1" << endl;

    // Wypełnić wektor losowymi liczbami z przedziałów:
    // v1: [3,13), v2: [0,10), v3: [1,12)
    // Koniecznie użyć algorytmu generate, jako funkcję generującą elementy
    // podać funkcję lambda wywołującą std::rand i przakształacjącą uzyskaną
    // liczbę losową na wymagany zakres
	generate(v1.begin(), v1.end(), []() -> int {
		return (rand() % 10) + 3;
	});
	generate(v2.begin(), v2.end(), []() -> int {
		return (rand() % 10);
	});
	generate(v3.begin(), v3.end(), []() -> int {
		return (rand() % 11) + 1;
	});

    // Tu implementujemy wypełnianie
    
    printVector(cout, v1);
    printVector(cout, v2);
    printVector(cout, v3);

    //Etap 2
    cout << "**\nEtap2" << endl;

    std::vector<int> v4(v1.size()+v2.size()+v3.size());// Alokacja odpowiednio dużego wektora, mieszczącego v1, v2, v3
    const int k1 = 4 + rand() % 7;
    // Losowana wartość k1:
    // W wektorze v4 ustawić wartości kolejnych elementów na
    // elementy v1 pomnożone przez k1
    // zwiększone o k1 elementy v2
    // dzielone całkowicie przez k1 elementy v3
    // Użyć algorymu std::transform
    // Uwaga: wartość zwaracana przez transform może byc przydatna

    // Tu implementujemy etap2

    printVector(cout, v4);

    //Etap 3
    cout << "**\nEtap3" << endl;
    std::vector<int> v5;

    // Do wektora v5 wstawić na koniec kolejno
    // wszystkie podzielne przez 2 elementy v1, wszystkie podzielne przez 3 elementy v2,
    // wszystkie podzielne przez 5 elementy v3.
    // uzyć std::copy_if, za każdym razem użyć tego samego nazwanego wyrażenia
    // lambda przechwytującego zmienną zewnętrzną k. Wyrażenie lambda przypisać
    // do zmiennej k
    // Uwaga: może się przydać std::back_inserter i wartość zwracana przez std::copy_if
    int k;

    //const auto podzielnosc =  TU funkcja lambda

    k = 2;
    //operacja z v1 -> v5
    
    k = 3;
    //operacja z v2 -> v5
    
    k = 5;
    //operacja z v3 -> v5

    printVector(cout, v5);

    //Etap 4
    cout << "**\nEtap4" << endl;

    // Wypisać odpowiednie wyniki działań. Wykorzystać algorytm std::accumulate i funkcje lambda
    // Ad. v3: w dokumentacji accumulate zwrócić uwagę co dokładnie jest podawane jako pierwszy a co jako drugi
    // argument funkcji akumulującej
    // Zamienić "???" odpowiednimi wywołaniami std::accumulate
    cout << "iloczyn elementów  v1: " << "???"  << endl;
    cout << "suma elementów v2: " << "???"  << endl;
    cout << "suma silni elementów v3: " << "???" << endl;

    //Etap5
    cout << "**\nEtap5" << endl;

    // Zaimplementować comparisonCountingSort, szczegóły w lab3.h
    // następnie odkomentować poniższy fragment
    
    //cout << "v1: " << comparisonCountingSort(v1) << ", v2: "
    //     << comparisonCountingSort(v2)
    //     << ", v3: " << comparisonCountingSort(v3) << endl;

    return 0;
}

