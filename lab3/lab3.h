#ifndef LAB3_H
#define LAB3_H

#include <vector>
#include <functional>
#include <ostream>

namespace lab3 {


/**
 * @brief printVector
 * @param stream strumień na który drukować wektor
 * @param v wektor do wydrukowania
 *
 * Drukuje elementy wektora oddzielone spacją na podany strumień.
 * Potem drukuje nową linię.
 * Nie wolno uzywać pętli, ani podobnych konstrukcji,
 * obowiązkowo użyć std::ostream_iterator i std::copy
 */
void printVector(std::ostream& stream, const std::vector<int>& v);

//Etap5
 
/**
 * @brief comparisonCountingSort Sortuje wektor podany przez referencję.
 * @param v wektor
 * @return Liczba wykonań operacji porównania w trakcie sortowania
 *
 * Sortowanie zrealizować wywołaniem std::sort.
 * Aby zliczać porównania, jako komparator podać wyrażenie lambda,
 * które przy każdym wywołaniu podbija licznik (i oczywiście zwraca
 * odpowiednią wartość porównania).
 *
 * Przypomnienie: komparator dla intów to a<b
 */
int comparisonCountingSort(std::vector<int> &v);


}

#endif // LAB3_H
